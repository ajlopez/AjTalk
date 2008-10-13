namespace AjTalk
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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
        
        public BaseClass(string name, Machine machine) : this(name, null, machine)
        {
        }

        public BaseClass(string name, IClass superclass, Machine machine)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;
            this.superclass = superclass;
            this.machine = machine;
        }

        public BaseClass(string name, IClass superclass, IClass objclass, Machine machine)
            : this(name, superclass, machine)
        {
            this.SetClass(objclass);
        }

        public IClass SuperClass
        {
            get
            {
                return this.superclass;
            }
        }

        public int NoInstanceVariables
        {
            get
            {
                if (this.superclass != null)
                    return this.instancevariables.Count + this.superclass.NoInstanceVariables;

                return this.instancevariables.Count;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Machine Machine
        {
            get
            {
                return this.machine;
            }
        }

        public void DefineClassMethod(IMethod method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            this.classmethods[method.Name] = method;
        }

        public void DefineInstanceMethod(IMethod method)
        {
            this.instancemethods[method.Name] = method;
        }

        public void DefineClassVariable(string varname)
        {
            if (varname == null)
            {
                throw new ArgumentNullException("varname");
            }

            if (this.classvariables.Contains(varname))
            {
                throw new InvalidOperationException(String.Format("Instance Variable {0} already defined", varname));
            }

            this.classvariables.Add(varname);
        }

        public void DefineInstanceVariable(string varname)
        {
            if (varname == null)
            {
                throw new ArgumentNullException("varname");
            }

            if (this.instancevariables.Contains(varname))
            {
                throw new InvalidOperationException(String.Format("Instance Variable {0} already defined", varname));
            }

            this.instancevariables.Add(varname);
        }

        public IObject NewObject()
        {
            return new BaseObject(this, this.instancevariables.Count);
        }

        public IMethod GetClassMethod(string mthname)
        {
            if (mthname == null)
            {
                throw new ArgumentNullException("mthname");
            }

            if (!this.classmethods.ContainsKey(mthname))
            {
                if (this.superclass != null)
                {
                    return this.superclass.GetClassMethod(mthname);
                }

                return null;
            }

            return this.classmethods[mthname];
        }

        public IMethod GetInstanceMethod(string mthname)
        {
            if (mthname == null)
            {
                throw new ArgumentNullException("mthname");
            }

            if (!this.instancemethods.ContainsKey(mthname))
            {
                if (this.superclass != null)
                {
                    return this.superclass.GetInstanceMethod(mthname);
                }

                return null;
            }

            return this.instancemethods[mthname];
        }

        public int GetClassVariableOffset(string varname)
        {
            return this.classvariables.IndexOf(varname);
        }

        public int GetInstanceVariableOffset(string varname)
        {
            int offset;

            if (this.superclass != null)
            {
                offset = this.superclass.GetInstanceVariableOffset(varname);

                if (offset >= 0)
                {
                    return offset;
                }
            }
                
            offset = this.instancevariables.IndexOf(varname);

            if (offset >= 0 && this.superclass != null)
            {
                offset += this.superclass.NoInstanceVariables;
            }

            return offset;
        }
    }
}

