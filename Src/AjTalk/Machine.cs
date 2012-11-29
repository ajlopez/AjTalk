namespace AjTalk
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AjTalk.Compiler;
    using AjTalk.Hosting;
    using AjTalk.Language;
    using AjTalk.Transactions;

    public class Machine
    {
        [ThreadStatic]
        private static Machine current;

        private IClass nilclass;
        private IClass classclass;
        private IClass metaclassclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();
        private Dictionary<Type, NativeBehavior> nativeBehaviors = new Dictionary<Type, NativeBehavior>();

        private Dictionary<Guid, IHost> localhosts = new Dictionary<Guid, IHost>();
        private Dictionary<Guid, IHost> remotehosts = new Dictionary<Guid, IHost>();

        private TransactionManager transactionManager;

        public Machine()
            : this(true)
        {
        }

        public Machine(bool iscurrent)
        {
            if (iscurrent)
                this.SetCurrent();

            IMetaClass meta = new BaseMetaClass(null, null, this, string.Empty);
            this.nilclass = meta.CreateClass("UndefinedObject", string.Empty);

            // TODO review, nil object never receives a message, see Send in Execution block
            this.nilclass.DefineInstanceMethod(new DoesNotUnderstandMethod(this, this.nilclass));
            this.nilclass.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(this, this.nilclass));
            this.nilclass.DefineClassMethod(new FunctionalMethod("ifNil:", this.nilclass, this.IfNil));

            // Native Behaviors
            var enumerableBehavior = new EnumerableBehavior(meta, this.nilclass, this);
            var stringBehavior = new StringBehavior(meta, this.nilclass, this);

            this.RegisterNativeBehavior(typeof(IEnumerable), enumerableBehavior);
            this.RegisterNativeBehavior(typeof(bool), new BooleanBehavior(meta, this.nilclass, this));
            this.RegisterNativeBehavior(typeof(Block), new BlockBehavior(meta, this.nilclass, this));
            this.RegisterNativeBehavior(typeof(string), stringBehavior);

            // Global Objects
            this.SetGlobalObject("UndefinedObject", this.nilclass);
            this.SetGlobalObject("Machine", this);
        }

        public static Machine Current { get { return current; } }

        public IHost Host { get; set; }

        public IClass MetaClassClass { get { return this.metaclassclass; } }

        public IClass UndefinedObjectClass { get { return this.nilclass; } }

        public IClass ClassClass 
        {
            get { return this.classclass; }
            set { this.classclass = value; }
        }

        public TransactionManager TransactionManager
        {
            get
            {
                if (this.transactionManager == null)
                    this.transactionManager = new TransactionManager(this);

                return this.transactionManager;
            }
        }

        public static void SetCurrent(Machine machine)
        {
            current = machine;
        }

        public IClass CreateClass(string clsname)
        {
            return this.CreateClass(clsname, (this.classclass == null ? this.nilclass : this.classclass));
        }

        public IClass CreateClass(string clsname, bool isIndexed)
        {
            BaseClass cls = (BaseClass)this.CreateClass(clsname);
            cls.IsIndexed = isIndexed;
            return cls;
        }

        public IClass CreateClass(string clsname, IClass superclass)
        {
            return this.CreateClass(clsname, superclass, string.Empty, string.Empty);
        }

        public IClass CreateClass(string clsname, IClass superclass, string instancevarnames, string classvarnames)
        {
            IMetaClass supermeta = null;

            if (superclass == null)
                if (this.classclass != null)
                    superclass = this.classclass;
                else
                    superclass = this.nilclass;

            if (superclass != null)
                supermeta = superclass.MetaClass;

            // TODO review using a provisional metaclassclass, for test that doesn't define Metaclass yet
            IMetaClass meta = new BaseMetaClass(this.metaclassclass ?? this.nilclass.Behavior, supermeta, this, classvarnames);
            IClass cls = meta.CreateClass(clsname, instancevarnames);

            var oldcls = this.GetGlobalObject(clsname) as IClass;

            if (oldcls != null)
            {
                var oldmeta = oldcls.Behavior;

                this.CopyMethods(meta, oldmeta);
                this.CopyMethods(cls, oldcls);

                this.SetGlobalObject(clsname, cls);
            }

            return cls;
        }

        public IBehavior CreateNativeBehavior(IBehavior superclass, Type type)
        {
            IMetaClass supermeta = null;

            if (superclass != null)
                supermeta = superclass.MetaClass;

            IMetaClass meta = new BaseMetaClass(this.metaclassclass, supermeta, this, string.Empty);
            NativeBehavior behavior = new NativeBehavior(meta, superclass, this, type);
            return behavior;
        }

        public object GetGlobalObject(string objname)
        {
            if (this.globals.ContainsKey(objname))
            {
                return this.globals[objname];
            }

            return null;
        }

        public void SetGlobalObject(string objname, object value)
        {
            this.globals[objname] = value;

            if (/*this.metaclassclass == null && */objname == "Metaclass" && value is IClass)
                this.DefineMetaclass((IClass)value);
            else if (objname == "Class" && value is IClass)
                this.classclass = (IClass)value;
            else if (objname == "UndefinedObject" && value is IClass)
                this.nilclass = (IClass)value;
        }

        public void SetCurrent()
        {
            current = this;
        }

        public ICollection<string> GetGlobalNames()
        {
            return this.globals.Keys;
        }

        public ICollection<IClass> GetClasses()
        {
            List<IClass> classes = new List<IClass>();

            foreach (object value in this.globals.Values)
                if (value is IClass)
                    classes.Add((IClass)value);

            return classes;
        }

        public void RegisterHost(IHost host)
        {
            if (host.IsLocal)
                this.localhosts[host.Id] = host;
            else
                this.remotehosts[host.Id] = host;
        }

        public IHost GetHost(Guid id)
        {
            // if (this.Host != null && this.Host.Id == id)
            //    return this.Host;
            if (this.localhosts.ContainsKey(id))
                return this.localhosts[id];

            return this.remotehosts[id];
        }

        public ICollection<IHost> GetLocalHosts()
        {
            return this.localhosts.Values;
        }

        public ICollection<IHost> GetRemoteHosts()
        {
            return this.remotehosts.Values;
        }

        public object SendMessage(object obj, string msgname, object[] args)
        {
            if (obj == null)
                return this.nilclass.SendMessage(msgname, args);

            IObject iobj = obj as IObject;

            if (iobj != null)
                return iobj.SendMessage(msgname, args);

            return DotNetObject.SendMessage(this, obj, msgname, args);
        }

        public void RegisterNativeBehavior(Type type, NativeBehavior behavior)
        {
            this.nativeBehaviors[type] = behavior;
        }

        public NativeBehavior GetNativeBehavior(Type type)
        {
            if (this.nativeBehaviors.ContainsKey(type))
                return this.nativeBehaviors[type];

            return null;
        }

        private void DefineMetaclass(IClass metaclass)
        {
            this.metaclassclass = metaclass;

            foreach (IClass cls in this.GetClasses())
                ((BaseBehavior)cls.Behavior).SetBehavior(this.metaclassclass);
        }

        private object IfNil(object self, object[] arguments)
        {
            Block block = (Block)arguments[0];
            return block.Execute(this, null);
        }

        private void CopyMethods(IBehavior tocls, IBehavior fromcls)
        {
            VmCompiler compiler = new VmCompiler();

            foreach (var mth in fromcls.GetInstanceMethods())
            {
                var newmth = mth;
                if (!string.IsNullOrEmpty(mth.SourceCode))
                    newmth = compiler.CompileInstanceMethod(mth.SourceCode, tocls);
                else
                    newmth.Behavior = tocls;
                tocls.DefineInstanceMethod(newmth);
            }
        }
    }
}
