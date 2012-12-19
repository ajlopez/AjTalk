namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BaseClassDescription : BaseBehavior, IClassDescription
    {
        private List<string> instancevariables = new List<string>();
        private List<string> classvariables = new List<string>();
        private List<object> classvariablevalues = new List<object>();

        public BaseClassDescription(Machine machine)
            : this(null, null, machine, string.Empty)
        {
        }

        public BaseClassDescription(IBehavior behavior, IBehavior superclass, Machine machine, string varnames)
            : base(behavior, superclass, machine)
        {
            IEnumerable<string> names = AsNames(varnames);

            foreach (string name in names)
                this.DefineInstanceVariable(name);
        }

        public BaseClassDescription(IBehavior behavior, IBehavior superclass, IClass metaclass, Machine machine, string varnames)
            : this(behavior, superclass, machine, varnames)
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

        public override int NoClassVariables
        {
            get
            {
                if (this.SuperClass != null)
                {
                    return this.classvariables.Count + this.SuperClass.NoClassVariables;
                }

                return this.classvariables.Count;
            }
        }

        public void DefineClassVariable(string varname)
        {
            if (this.classvariables.Contains(varname))
                throw new InvalidOperationException("Class variable already defined");

            if (this.SuperClass != null && this.SuperClass is IClassDescription && ((IClassDescription)this.SuperClass).GetClassVariableOffset(varname) >= 0)
                throw new InvalidOperationException("Class variable already defined");

            this.classvariables.Add(varname);
            this.classvariablevalues.Add(null);
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
            int offset;

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                offset = ((IClassDescription)this.SuperClass).GetClassVariableOffset(varname);
                if (offset >= 0)
                    return offset;
            }

            offset = this.classvariables.IndexOf(varname);

            if (offset < 0)
                return offset;

            if (this.SuperClass != null)
                offset += this.SuperClass.NoClassVariables;

            return offset;
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

        public ICollection<string> GetInstanceVariableNames()
        {
            IList<string> names = null;

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                var supernames = ((IClassDescription)this.SuperClass).GetInstanceVariableNames();

                if (supernames != null && supernames.Count > 0)
                    names = new List<string>(supernames);
            }

            if (this.instancevariables != null && this.instancevariables.Count > 0) 
            {
                if (names == null)
                    names = new List<string>();

                foreach (var name in this.instancevariables)
                    names.Add(name);
            }

            return names;
        }

        public string GetInstanceVariableNamesAsString()
        {
            int nv = 0;
            StringBuilder sb = new StringBuilder();

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                string vars = ((IClassDescription)this.SuperClass).GetInstanceVariableNamesAsString();

                if (!string.IsNullOrEmpty(vars))
                {
                    nv++;
                    sb.Append(vars);
                }
            }

            foreach (string varname in this.instancevariables)
            {
                if (nv > 0)
                    sb.Append(" ");
                sb.Append(varname);
                nv++;
            }

            return sb.ToString();
        }

        public ICollection<string> GetClassVariableNames()
        {
            IList<string> names = null;

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                var supernames = ((IClassDescription)this.SuperClass).GetClassVariableNames();

                if (supernames != null && supernames.Count > 0)
                    names = new List<string>(supernames);
            }

            if (this.classvariables != null && this.classvariables.Count > 0)
            {
                if (names == null)
                    names = new List<string>();

                foreach (var name in this.classvariables)
                    names.Add(name);
            }

            return names;
        }

        public string GetClassVariableNamesAsString()
        {
            int nv = 0;
            StringBuilder sb = new StringBuilder();

            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                string vars = ((IClassDescription)this.SuperClass).GetClassVariableNamesAsString();

                if (!string.IsNullOrEmpty(vars))
                {
                    nv++;
                    sb.Append(vars);
                }
            }

            foreach (string varname in this.classvariables)
            {
                if (nv > 0)
                    sb.Append(" ");
                sb.Append(varname);
                nv++;
            }

            return sb.ToString();
        }

        public void RedefineClassVariables(string varnames)
        {
            foreach (var varname in AsNames(varnames))
                this.DefineClassVariable(varname);
        }

        public void RedefineInstanceVariables(string varnames)
        {
            foreach (var varname in AsNames(varnames))
                if (!this.instancevariables.Contains(varname))
                    this.DefineInstanceVariable(varname);
        }

        public void SetClassVariable(int offset, object value)
        {
            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                int super = this.SuperClass.NoClassVariables;
                if (super > offset)
                    ((IClassDescription)this.SuperClass).SetClassVariable(offset, value);
                else
                    this.classvariablevalues[offset - super] = value;
                return;
            }

            this.classvariablevalues[offset] = value;
        }

        public object GetClassVariable(int offset)
        {
            if (this.SuperClass != null && this.SuperClass is IClassDescription)
            {
                int super = this.SuperClass.NoClassVariables;
                if (super > offset)
                    return ((IClassDescription)this.SuperClass).GetClassVariable(offset);
                else
                    return this.classvariablevalues[offset - super];
            }

            return this.classvariablevalues[offset];
        }

        private static IEnumerable<string> AsNames(string varnames)
        {
            if (string.IsNullOrEmpty(varnames))
                return new string[] { };

            string[] splits = varnames.Split(' ');

            IList<string> names = new List<string>();

            foreach (string split in splits)
                if (!string.IsNullOrEmpty(split))
                    names.Add(split);

            return names;
        }
    }
}

