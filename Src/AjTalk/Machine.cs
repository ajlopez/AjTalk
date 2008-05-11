using System;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Machine.
	/// </summary>
	public class Machine
	{
		private BaseClass objectclass;
		private BaseClass classclass;

		public Machine()
		{
			objectclass = new BaseClass("Object");
			classclass = new BaseClass("Class",objectclass);

			objectclass.SetClass(classclass);
			classclass.SetClass(classclass);
		}

		public IClass CreateClass(string clsname) 
		{
			BaseClass cls = new BaseClass(clsname,classclass);
			return cls;
		}

        public IClass CreateClass(string clsname, IClass superclass)
        {
            BaseClass cls = new BaseClass(clsname, superclass);
            return cls;
        }
    }
}
