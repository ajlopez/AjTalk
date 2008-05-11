using System;

namespace AjTalk
{
	/// <summary>
	/// Summary description for BaseObject.
	/// </summary>
	public class BaseObject : IObject
	{
		private IClass objclass;
		private object[] variables;

		public BaseObject()
		{
			objclass = null;
			variables = null;
		}

		public BaseObject(IClass cls, int nvars) 
		{
			objclass = cls;
			variables = new object[nvars];
		}

		public BaseObject(IClass cls, object [] vars) 
		{
			objclass = cls;
			variables = vars;
		}

		internal void SetClass(IClass cls)
		{
			objclass = cls;
		}

		#region IObject Members

		public IClass Class
		{
			get
			{
				// TODO:  Add BaseObject.Class getter implementation
				return objclass;
			}
		}

		public Object this[int n]
		{
			get
			{
				return variables[n];
			}
			set
			{
				variables[n] = value;
			}
		}

		public Object SendMessage(string msgname, Object[] args)
		{
            // TODO objclass to review
			IMethod mth = objclass.GetInstanceMethod(msgname);
            // TODO add does not understand logic
			return mth.Execute(this, args);
		}

		#endregion
	}
}
