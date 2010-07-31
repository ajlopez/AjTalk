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

        public BaseClass(string name, IClass superclass, Machine machine)
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

        public BaseClass(string name, IClass superclass, IClass objclass, Machine machine)
            : this(name, superclass, machine)
        {
            this.SetBehavior(objclass);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override object NewObject()
        {
            if (this.isBehavior)
            {
                return new BaseBehavior(this, this.Machine);
            }

            if (this.isClassDescription)
            {
                return new BaseClassDescription(this, this.Machine);
            }

            return base.NewObject();
        }
    }
}

