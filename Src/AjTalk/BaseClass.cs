using System;
using System.Collections;
using System.Collections.Generic;

namespace AjTalk
{
	/// <summary>
	/// Summary description for BaseClass.
	/// </summary>

	public class BaseClass : BaseObject, IClass
	{
		private IClass superclass;
		private string name;
        private Machine machine;

        private Dictionary<string, IMethod> classmethods = new Dictionary<string, IMethod>();
        private Dictionary<string, IMethod> instancemethods = new Dictionary<string, IMethod>();
        private List<string> classvariables = new List<string>();
        private List<string> instancevariables = new List<string>();
        
		public BaseClass(string name, Machine machine) : this(name,null,machine)
		{
		}

		public BaseClass(string name, IClass superclass, Machine machine)
		{
            if (name == null)
                throw new ArgumentNullException("name");

            this.name = name;
			this.superclass = superclass;
            this.machine = machine;
		}

		public IClass SuperClass
		{
			get
			{
				return superclass;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

        public Machine Machine
        {
            get
            {
                return machine;
            }
        }

        public void DefineClassMethod(IMethod method)
        {
            if (method == null)
                throw new ArgumentNullException("method");

            classmethods[method.Name] = method;
        }

        public void DefineInstanceMethod(IMethod method)
        {
            instancemethods[method.Name] = method;
        }

        public void DefineClassVariable(string varname)
        {
            if (varname == null)
                throw new ArgumentNullException("varname");

            if (classvariables.Contains(varname))
                throw new InvalidOperationException(String.Format("Instance Variable {0} already defined", varname));

            classvariables.Add(varname);
        }

        public void DefineInstanceVariable(string varname)
        {
            if (varname == null)
                throw new ArgumentNullException("varname");

            if (instancevariables.Contains(varname))
                throw new InvalidOperationException(String.Format("Instance Variable {0} already defined", varname));

            instancevariables.Add(varname);
        }

		public IObject NewObject()
		{
			return new BaseObject(this,instancevariables.Count);
		}

		public IMethod GetClassMethod(string mthname)
		{
            if (mthname == null)
                throw new ArgumentNullException("mthname");

            if (!classmethods.ContainsKey(mthname))
                return null;

			return classmethods[mthname];
		}

        public IMethod GetInstanceMethod(string mthname)
        {
            if (mthname == null)
                throw new ArgumentNullException("mthname");

            if (!instancemethods.ContainsKey(mthname))
                return null;

            return instancemethods[mthname];
        }

        public int GetClassVariableOffset(string varname)
        {
            return classvariables.IndexOf(varname);
        }

        public int GetInstanceVariableOffset(string varname)
        {
            int offset;

            if (superclass != null)
            {
                offset = superclass.GetInstanceVariableOffset(varname);

                if (offset >= 0)
                    return offset;
            }
                
            offset = instancevariables.IndexOf(varname);

            if (offset >= 0 && superclass != null && superclass is BaseClass)
                offset += ((BaseClass)superclass).instancevariables.Count;

            return offset;
        }
    }
}

