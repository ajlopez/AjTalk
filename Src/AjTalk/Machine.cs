namespace AjTalk
{
    using System;
    using System.Collections.Generic;

    using AjTalk.Language;

    public class Machine
    {
        private BaseClass classclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();
        private Dictionary<Type, NativeBehavior> nativeBehaviors = new Dictionary<Type, NativeBehavior>();

        [ThreadStatic]
        private static Machine current;

        public Machine()
            : this(true)
        {
        }

        public Machine(bool iscurrent)
        {
            if (iscurrent)
                current = this;

            this.classclass = new BaseClass("nil", null, this);

            // TODO Review this tricky autoreference
            //this.classclass.SetBehavior(this.classclass);

            this.globals["nil"] = this.classclass;
            this.classclass.DefineInstanceMethod(new DoesNotUnderstandMethod(this));
            this.classclass.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(this));
        }

        public static Machine Current { get { return current; } }

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

        public ICollection<IClass> GetClasses()
        {
            List<IClass> classes = new List<IClass>();

            foreach (object value in this.globals.Values)
                if (value is IClass)
                    classes.Add((IClass) value);

            return classes;
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
