namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class BaseClass : BaseClassDescription, IClass
    {
        private string name;
        private bool isBehavior;
        private bool isClassDescription;
        
        public BaseClass(string name, Machine machine) : this(null, name, null, machine, string.Empty)
        {
        }

        public BaseClass(IBehavior behavior, string name, IBehavior superclass, Machine machine, string varnames)
            : base(behavior, superclass, machine, varnames)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.name = name;

            this.isBehavior = name == "Behavior";
            this.isClassDescription = name == "ClassDescription";
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Category { get; set; }

        public bool IsAgentClass { get; set; }

        public override object NewObject()
        {
            // TODO review first parameter
            // if (this.isBehavior)
            //    return new BaseBehavior(null, this, this.Machine);
            // TODO review first parameter
            // if (this.isClassDescription)
            //    return new BaseClassDescription(null, this, this.Machine, string.Empty);
            if (this.IsAgentClass)
                return new AgentObject(this, this.NoInstanceVariables);

            return base.NewObject();
        }

        public string ToDefineString()
        {
            StringBuilder sb = new StringBuilder();

            this.BuildDefineString(sb);

            return sb.ToString();
        }

        public string ToOutputString()
        {
            StringBuilder sb = new StringBuilder();

            this.BuildDefineString(sb);

            sb.Append(string.Format("\r\n!{0} class methods!", this.Name));

            foreach (IMethod method in this.GetClassMethods()) 
            {
                sb.Append("\r\n");
                string source = method.SourceCode;

                if (string.IsNullOrEmpty(source))
                    continue;

                source = source.Replace("!", "!!");

                sb.Append(source);
                sb.Append("\r\n!");
            }

            sb.Append(" !\r\n\r\n");
            sb.Append(string.Format("!{0} methods!", this.Name));

            foreach (IMethod method in this.GetInstanceMethods())
            {
                sb.Append("\r\n");
                string source = method.SourceCode;

                if (string.IsNullOrEmpty(source))
                    continue;

                source = source.Replace("!", "!!");

                sb.Append(source);
                sb.Append("\r\n!");
            }

            sb.Append(" !\r\n\r\n");

            return sb.ToString();
        }

        private void BuildDefineString(StringBuilder sb)
        {
            if (this.SuperClass is IClass && ((IClass)this.SuperClass).Name != "UndefinedObject")
                sb.Append(((IClass)this.SuperClass).Name);
            else
                sb.Append("nil");

            if (this.IsAgentClass)
                sb.Append(" agent: #");
            else
                sb.Append(" subclass: #");

            sb.Append(this.Name);
            sb.Append("\r\n");
            sb.Append("    instanceVariableNames: '");
            sb.Append(this.GetInstanceVariableNamesAsString());
            sb.Append("'\r\n");
            sb.Append("    classVariableNames: '");
            sb.Append(this.GetClassVariableNamesAsString());
            sb.Append("'\r\n");
            sb.Append("    poolDictionaries: ''\r\n");
            sb.Append("    category: '");
            if (this.Category != null)
                sb.Append(this.Category);
            sb.Append("'!\r\n");
        }
    }
}

