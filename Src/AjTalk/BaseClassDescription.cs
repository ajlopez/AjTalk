namespace AjTalk
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BaseClassDescription : BaseBehavior, IClassDescription
    {
        private List<string> classvariables = new List<string>();
        private List<string> instancevariables = new List<string>();
        
        public BaseClassDescription(Machine machine) : this(null, machine)
        {
        }

        public BaseClassDescription(IClass superclass, Machine machine)
            : base(superclass, machine)
        {
        }

        public BaseClassDescription(IClass superclass, IClass metaclass, Machine machine)
            : this(superclass, machine)
        {
            this.SetBehavior(metaclass);
        }

        public override int NoInstanceVariables
        {
            get
            {
                if (this.SuperClass != null)
                {
                    return this.instancevariables.Count + this.SuperClass.NoInstanceVariables;
                }

                return this.instancevariables.Count;
            }
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

        public int GetClassVariableOffset(string varname)
        {
            return this.classvariables.IndexOf(varname);
        }

        public int GetInstanceVariableOffset(string varname)
        {
            int offset;

            if (this.SuperClass != null)
            {
                offset = this.SuperClass.GetInstanceVariableOffset(varname);

                if (offset >= 0)
                {
                    return offset;
                }
            }
                
            offset = this.instancevariables.IndexOf(varname);

            if (offset >= 0 && this.SuperClass != null)
            {
                offset += this.SuperClass.NoInstanceVariables;
            }

            return offset;
        }
    }
}

