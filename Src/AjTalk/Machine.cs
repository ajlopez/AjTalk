using System;
using System.Collections.Generic;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Machine.
	/// </summary>
	public class Machine
	{
		private BaseClass objectclass;
		private BaseClass classclass;

        private Dictionary<string, object> globals = new Dictionary<string, object>();

		public Machine()
		{
			objectclass = new BaseClass("Object", this);
			classclass = new BaseClass("Class", objectclass, this);

			objectclass.SetClass(classclass);
			classclass.SetClass(classclass);

            globals["Object"] = objectclass;
            globals["Class"] = classclass;
		}

		public IClass CreateClass(string clsname) 
		{
			BaseClass cls = new BaseClass(clsname, classclass, this);
			return cls;
		}

        public IClass CreateClass(string clsname, IClass superclass)
        {
            BaseClass cls = new BaseClass(clsname, superclass, this);
            return cls;
        }

        public object GetGlobalObject(string objname)
        {
            if (globals.ContainsKey(objname))
                return globals[objname];

            return null;
        }

        public void SetGlobalObject(string objname, object value)
        {
            globals[objname] = value;
        }
    }
}
