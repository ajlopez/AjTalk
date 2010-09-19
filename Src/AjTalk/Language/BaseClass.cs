namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BaseClass : BaseClassDescription, IClass
    {
        private string name;
        private bool isBehavior;
        private bool isClassDescription;
        
        public BaseClass(string name, Machine machine) : this(name, null, machine)
        {
        }

        public BaseClass(string name, IBehavior superclass, Machine machine)
            : base(superclass, machine)
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

        public bool IsAgentClass { get; set; }

        public override object NewObject()
        {
            if (this.isBehavior)
                return new BaseBehavior(this, this.Machine);

            if (this.isClassDescription)
                return new BaseClassDescription(this, this.Machine);

            if (this.IsAgentClass)
                return new AgentObject(this, this.NoInstanceVariables);

            return base.NewObject();
        }
    }
}

