namespace AjTalk
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for BaseClass.
    /// </summary>
    public class BaseClass : BaseClassDescription, IClass
    {
        private string name;
        
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
    }
}

