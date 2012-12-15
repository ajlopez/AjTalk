namespace AjTalk
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using AjTalk.Compiler;
    using AjTalk.Hosting;
    using AjTalk.Language;
    using AjTalk.Transactions;

    public class Machine
    {
        [ThreadStatic]
        private static Machine current;

        [ThreadStatic]
        private static Context currentEnvironment;

        [ThreadStatic]
        private static string currentPath;

        private BaseClass nilclass;
        private IClass classclass;
        private IClass metaclassclass;
        private Context environment = new Context();
        private bool debug;

        private Dictionary<Type, NativeBehavior> nativeBehaviors = new Dictionary<Type, NativeBehavior>();

        private Dictionary<Guid, IHost> localhosts = new Dictionary<Guid, IHost>();
        private Dictionary<Guid, IHost> remotehosts = new Dictionary<Guid, IHost>();

        private TransactionManager transactionManager;

        public Machine()
            : this(false)
        {
        }

        public Machine(bool iscurrent)
        {
            if (iscurrent)
                this.SetCurrent();

            IMetaClass meta = new BaseMetaClass(null, null, this, string.Empty);
            this.nilclass = (BaseClass)meta.CreateClass("UndefinedObject", string.Empty);

            // TODO review, nil object never receives a message, see Send in Execution block
            this.nilclass.DefineInstanceMethod(new BehaviorDoesNotUnderstandMethod(this, this.nilclass));
            this.nilclass.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(this, this.nilclass));
            this.nilclass.DefineInstanceMethod(new FunctionalMethod("ifNil:", this.nilclass, this.IfNil));
            this.nilclass.DefineInstanceMethod(new FunctionalMethod("ifNotNil:", this.nilclass, this.IfNotNil));
            this.nilclass.DefineInstanceMethod(new FunctionalMethod("isNil", this.nilclass, this.IsNil));
            this.nilclass.DefineInstanceMethod(new FunctionalMethod("isNotNil", this.nilclass, this.IsNotNil));

            // Native Behaviors
            var nativeObjectBehavior = new NativeObjectBehavior(meta, null, this);
            var enumerableBehavior = new EnumerableBehavior(meta, nativeObjectBehavior, this);
            var listBehavior = new ListBehavior(meta, enumerableBehavior, this);
            var stringBehavior = new StringBehavior(meta, nativeObjectBehavior, this);

            this.RegisterNativeBehavior(typeof(IEnumerable), enumerableBehavior);
            this.RegisterNativeBehavior(typeof(IList), listBehavior);
            this.RegisterNativeBehavior(typeof(Block), new BlockBehavior(meta, this.nilclass, this));
            this.RegisterNativeBehavior(typeof(string), stringBehavior);

            // Global Objects
            this.SetGlobalObject("UndefinedObject", this.nilclass);
            this.SetGlobalObject("Machine", this);
            this.SetGlobalObject("Smalltalk", this.environment);
        }

        public static Machine Current { get { return current; } }

        public IHost Host { get; set; }

        public Machine HostMachine { get; set; }

        public IClass MetaClassClass { get { return this.metaclassclass; } }

        public IClass UndefinedObjectClass { get { return this.nilclass; } }

        public Context Environment { get { return this.environment; } }

        public bool Debug { get { return this.debug; } set { this.debug = value; } }

        public string CurrentPath { get { return currentPath; } }

        public Context CurrentEnvironment
        {
            get
            {
                if (currentEnvironment == null)
                    return this.environment;

                return currentEnvironment;
            }

            set
            {
                currentEnvironment = value;
            }
        }

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

        public IClass GetClass(string clsname)
        {
            return this.GetGlobalObject(clsname) as IClass;
        }

        public IMetaClass GetMetaClass(string clsname)
        {
            var cls = this.GetGlobalObject(clsname) as IClass;

            if (cls != null)
                return (IMetaClass)cls.Behavior;

            return null;
        }

        public IClass GetAssociatedClass(IClass klass)
        {
            var associated = this.GetClass(klass.Name);

            while (associated == null && klass.SuperClass != null && klass.SuperClass is IClass)
            {
                klass = (IClass)klass.SuperClass;
                associated = this.GetClass(klass.Name);
            }

            return associated;
        }

        public IMetaClass GetAssociatedMetaClass(IMetaClass metaklass)
        {
            var associated = this.GetAssociatedClass(metaklass.ClassInstance);

            if (associated != null)
                return associated.Behavior as IMetaClass;

            return null;
        }

        public IBehavior GetAssociatedBehavior(IBehavior behavior)
        {
            if (behavior is IMetaClass)
                return this.GetAssociatedMetaClass((IMetaClass)behavior);
            return this.GetAssociatedClass((IClass)behavior);
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
            var oldcls = this.CurrentEnvironment.GetValue(clsname) as IClass;

            if (oldcls != null)
            {
                oldcls.RedefineClassVariables(classvarnames);
                oldcls.RedefineInstanceVariables(instancevarnames);
                return oldcls;
            }

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
            var result = this.environment.GetValue(objname);

            if (result != null || this.environment.HasValue(objname))
                return result;

            if (this.HostMachine != null)
                return this.HostMachine.GetGlobalObject(objname);

            return null;
        }

        public void SetGlobalObject(string objname, object value)
        {
            this.SetEnvironmentObject(this.environment, objname, value);
        }

        public void SetCurrentEnvironmentObject(string objname, object value)
        {
            this.SetEnvironmentObject(this.CurrentEnvironment, objname, value);
        }

        public void SetEnvironmentObject(Context environment, string objname, object value)
        {
            environment.SetValue(objname, value);

            if (environment != this.environment)
                return;

            if (objname == "Metaclass" && value is IClass)
                this.DefineMetaclass((IClass)value);
            else if (objname == "Class" && value is IClass)
                this.classclass = (IClass)value;
            else if (objname == "UndefinedObject" && value is IClass)
                this.nilclass = (BaseClass)value;
        }

        public void SetCurrent()
        {
            current = this;
        }

        public ICollection<string> GetGlobalNames()
        {
            return this.environment.GetNames();
        }

        public ICollection<IClass> GetClasses()
        {
            List<IClass> classes = new List<IClass>();

            foreach (string name in this.environment.GetNames())
            {
                object value = this.environment.GetValue(name);

                if (value != null && value is IClass)
                    classes.Add((IClass)value);
            }

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
            if (this.debug)
            {
                if (obj == null)
                    Console.Write("UndefinedObject");
                else if ((obj as IObject) == null)
                    Console.Write(obj.GetType().FullName);
                else 
                {
                    IObject io = (IObject)obj;

                    if (io.Behavior is IMetaClass) 
                    {
                        IClass cls = ((IMetaClass)io.Behavior).ClassInstance;

                        if (cls == null)
                            Console.Write("meta");
                        else
                            Console.Write(cls.Name);
                        Console.Write(" class");
                    }
                    else
                        Console.Write(((IClass)io.Behavior).Name);
                }

                Console.Write(">>");
                Console.WriteLine(msgname);
            }

            if (obj == null)
                return this.nilclass.SendMessageToNilObject(this, msgname, args);

            IObject iobj = obj as IObject;

            if (iobj != null)
                return iobj.Behavior.SendMessageToObject(iobj, this, msgname, args);

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

        public void LoadFile(string filename)
        {
            filename = this.GetFilename(filename);

            string originalpath = currentPath;
            string filepath = (new FileInfo(filename)).DirectoryName;

            try 
            {
                currentPath = filepath;
                Loader loader = new Loader(filename, new SimpleCompiler());
                loader.LoadAndExecute(this);
            }
            finally 
            {
                currentPath = originalpath;
            }
        }

        public void ImportModule(string modulename)
        {
            var context = this.GetOrCreateChildEnvironment(this.CurrentEnvironment, modulename);

            string modulefilename = modulename.Replace(".", "/");
            string filename = this.GetFilename("modules/" + modulefilename + ".st");

            if (filename == null)
                filename = this.GetFilename("modules/" + modulefilename + "/Init.st");

            var original = this.CurrentEnvironment;

            try
            {
                this.CurrentEnvironment = context;
                this.LoadFile(filename);
            }
            finally
            {
                this.CurrentEnvironment = original;
            }
        }

        private Context GetOrCreateChildEnvironment(Context environment, string envname)
        {
            var names = envname.Split('.');

            foreach (var name in names)
            {
                var result = environment.GetValue(name);

                if (result != null)
                    environment = (Context)result;
                else
                {
                    var context = new Context(environment);
                    environment.SetValue(name, context);
                    environment = context;
                }
            }

            return environment;
        }

        private string GetFilename(string filename)
        {
            if (Path.IsPathRooted(filename) || currentPath == null)
                if (File.Exists(filename))
                    return filename;
                else
                    return null;

            string newname = Path.Combine(currentPath, filename);

            if (File.Exists(newname))
                return newname;

            newname = Path.Combine(".", filename);

            if (File.Exists(newname))
                return newname;

            return null;
        }

        private void DefineMetaclass(IClass metaclass)
        {
            this.metaclassclass = metaclass;

            foreach (IClass cls in this.GetClasses())
                ((BaseBehavior)cls.Behavior).SetBehavior(this.metaclassclass);
        }

        private object IfNil(Machine machine, object self, object[] arguments)
        {
            Block block = (Block)arguments[0];
            return block.Execute(machine, null);
        }

        private object IfNotNil(Machine machine, object self, object[] arguments)
        {
            return null;
        }

        private object IsNil(Machine machine, object self, object[] arguments)
        {
            return self == machine.UndefinedObjectClass || self == null;
        }

        private object IsNotNil(Machine machine, object self, object[] arguments)
        {
            return self != machine.UndefinedObjectClass && self != null;
        }
    }
}
