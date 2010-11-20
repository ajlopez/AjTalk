namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BaseMetaClass : BaseClassDescription, IMetaClass
    {
        private IClass classInstance;

        internal static IMetaClass CreateMetaClass(IBehavior superclass, Machine machine)
        {
            IMetaClass metasuperclass = null;

            if (superclass != null)
                metasuperclass = superclass.MetaClass;

            return new BaseMetaClass(metasuperclass, machine, "");
        }

        internal static IMetaClass CreateMetaClass(IBehavior superclass, Machine machine, string varnames)
        {
            IMetaClass metasuperclass = null;

            if (superclass != null)
                metasuperclass = superclass.MetaClass;

            return new BaseMetaClass(metasuperclass, machine, varnames);
        }

        public BaseMetaClass(IMetaClass superclass, Machine machine, string varnames)
            : base(superclass, machine, varnames)
        {
        }

        public IClass ClassInstance
        {
            get
            {
                return this.classInstance;
            }
        }

        public IClass CreateClass(string name, string varnames)
        {
            if (this.classInstance != null)
                throw new InvalidOperationException("Metaclass has an instance class");

            IBehavior super = null;

            if (this.SuperClass != null)
            {
                IMetaClass meta = this.SuperClass as IMetaClass;
                if (meta != null)
                    super = meta.ClassInstance;
            }

            BaseClass cls = new BaseClass(name, super, this.Machine, varnames);
            // TODO move to BaseClass constructor
            cls.SetBehavior(this);
            this.classInstance = cls;
            return cls;
        }
    }
}

