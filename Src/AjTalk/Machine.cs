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

        public Machine()
        {
            this.classclass = new BaseClass("nil", null, this);

            // TODO Review this tricky autoreference
            //this.classclass.SetBehavior(this.classclass);

            this.globals["nil"] = this.classclass;
        }

        public IClass CreateClass(string clsname)
        {
            return this.CreateClass(clsname, false);
        }

        public IClass CreateClass(string clsname, bool isIndexed)
        {
            // TODO Review Tricky fourth param
            BaseClass cls = new BaseClass(clsname, this.classclass, this);
            cls.IsIndexed = isIndexed;
            return cls;
        }

        public IClass CreateClass(string clsname, IClass superclass)
        {
            // TODO Review Tricky fourth param
            BaseClass cls = new BaseClass(clsname, superclass, this);
            return cls;
        }

        public IBehavior CreateNativeBehavior(IClass superclass, Type type)
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
