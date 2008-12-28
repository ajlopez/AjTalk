using System;
using System.Collections.Generic;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Machine.
	/// </summary>
	public class Machine
	{
		private BaseClass classclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();

		public Machine()
		{
			classclass = new BaseClass("nil", null, this);

            // TODO Review this tricky autoreference
			classclass.SetBehavior(classclass);

            globals["nil"] = classclass;
		}

		public IClass CreateClass(string clsname) 
		{
            // TODO Review Tricky fourth param
			BaseClass cls = new BaseClass(clsname, classclass, classclass, this);
			return cls;
		}

        public IClass CreateClass(string clsname, IClass superclass)
        {
            // TODO Review Tricky fourth param
            BaseClass cls = new BaseClass(clsname, superclass, classclass, this);
            return cls;
        }

        public object GetGlobalObject(string objname)
        {
            if (globals.ContainsKey(objname))
                return globals[objname];

            if (objname.IndexOf('.') >= 0)
            {
                Type type = Type.GetType(objname);

                if (type != null)
                    return type;
            }

            return null;
        }

        public void SetGlobalObject(string objname, object value)
        {
            globals[objname] = value;
        }
    }
}
