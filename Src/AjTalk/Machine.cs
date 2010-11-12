namespace AjTalk
{
    using System;
    using System.Collections.Generic;

    using AjTalk.Language;
    using AjTalk.Hosting;
    using System.Collections;
    using AjTalk.Transactions;

    public class Machine
    {
        private BaseClass classclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();
        private Dictionary<Type, NativeBehavior> nativeBehaviors = new Dictionary<Type, NativeBehavior>();

        private Dictionary<Guid, IHost> localhosts = new Dictionary<Guid, IHost>();
        private Dictionary<Guid, IHost> remotehosts = new Dictionary<Guid, IHost>();

        private TransactionManager transactionManager;

        [ThreadStatic]
        private static Machine current;

        public Machine()
            : this(true)
        {
        }

        public Machine(bool iscurrent)
        {
            if (iscurrent)
                this.SetCurrent();

            this.classclass = new BaseClass("nil", null, this);

            // TODO Review this tricky autoreference
            //this.classclass.SetBehavior(this.classclass);

            this.globals["nil"] = this.classclass;
            this.classclass.DefineInstanceMethod(new DoesNotUnderstandMethod(this));
            this.classclass.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(this));

            this.RegisterNativeBehavior(typeof(IEnumerable), new EnumerableBehavior(this.classclass, this));
            this.RegisterNativeBehavior(typeof(Boolean), new BooleanBehavior(this.classclass, this));
        }

        public static Machine Current { get { return current; } }

        public IHost Host { get; set; }

        public TransactionManager TransactionManager
        {
            get
            {
                if (this.transactionManager == null)
                    this.transactionManager = new TransactionManager(this);

                return this.transactionManager;
            }
        }

        public IClass CreateClass(string clsname)
        {
            return this.CreateClass(clsname, false);
        }

        public IClass CreateClass(string clsname, bool isIndexed)
        {
            BaseClass cls = new BaseClass(clsname, this.classclass, this);
            cls.IsIndexed = isIndexed;
            return cls;
        }

        public IClass CreateClass(string clsname, IBehavior superclass)
        {
            BaseClass cls = new BaseClass(clsname, superclass, this);
            return cls;
        }

        public IBehavior CreateNativeBehavior(IBehavior superclass, Type type)
        {
            NativeBehavior behavior = new NativeBehavior(superclass, this, type);
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
        }

        public void SetCurrent()
        {
            current = this;
        }

        public static void SetCurrent(Machine machine)
        {
            current = machine;
        }

        public ICollection<IClass> GetClasses()
        {
            List<IClass> classes = new List<IClass>();

            foreach (object value in this.globals.Values)
                if (value is IClass)
                    classes.Add((IClass) value);

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
            //if (this.Host != null && this.Host.Id == id)
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

        internal void RegisterNativeBehavior(Type type, NativeBehavior behavior)
        {
            this.nativeBehaviors[type] = behavior;
        }

        internal NativeBehavior GetNativeBehavior(Type type)
        {
            if (this.nativeBehaviors.ContainsKey(type))
                return this.nativeBehaviors[type];

            return null;
        }
    }
}
