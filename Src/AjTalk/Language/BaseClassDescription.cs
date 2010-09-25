namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BaseClassDescription : BaseBehavior, IClassDescription
    {
        private List<string> instancevariables = new List<string>();

        public BaseClassDescription(Machine machine)
            : this(null, machine)
        {
        }

        public BaseClassDescription(IBehavior superclass, Machine machine)
            : base(superclass, machine)
        {
        }

        public BaseClassDescription(IBehavior superclass, IClass metaclass, Machine machine)
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

            this.MetaClass.DefineInstanceVariable(varname);
            return;
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
            return this.MetaClass.GetInstanceVariableOffset(varname);
        }

        public int GetInstanceVariableOffset(string varname)
        {
            int offset;

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                offset = ((IClassDescription)this.SuperClass).GetInstanceVariableOffset(varname);

                if (offset >= 0)
                {
                    return offset;
                }
            }

            offset = this.instancevariables.IndexOf(varname);

            if (offset >= 0 && this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                offset += ((IClassDescription)this.SuperClass).NoInstanceVariables;
            }

            return offset;
        }

        public string GetInstanceVariableNames()
        {
            int nv = 0;
            StringBuilder sb = new StringBuilder();

            foreach (string varname in this.instancevariables)
            {
                if (nv > 0)
                    sb.Append(" ");
                sb.Append(varname);
                nv++;
            }

            return sb.ToString();
        }

        public string GetClassVariableNames()
        {
            return this.MetaClass.GetInstanceVariableNames();
        }
    }
}

