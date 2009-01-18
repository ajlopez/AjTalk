namespace AjTalk
{
    using System;
    using System.Collections.Generic;

    public class Machine
    {
        private BaseClass classclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();

        public Machine()
        {
            this.classclass = new BaseClass("nil", null, this);

            // TODO Review this tricky autoreference
            this.classclass.SetBehavior(this.classclass);

            this.globals["nil"] = this.classclass;
        }

        public IClass CreateClass(string clsname)
        {
            // TODO Review Tricky fourth param
            BaseClass cls = new BaseClass(clsname, this.classclass, this.classclass, this);
            return cls;
        }

        public IClass CreateClass(string clsname, IClass superclass)
        {
            // TODO Review Tricky fourth param
            BaseClass cls = new BaseClass(clsname, superclass, this.classclass, this);
            return cls;
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
    }
}
