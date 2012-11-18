namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BaseMetaClass : BaseClassDescription, IMetaClass
    {
        private IClass classInstance;

        public BaseMetaClass(IBehavior behavior, IMetaClass superclass, Machine machine, string varnames)
            : base(behavior, superclass, machine, varnames)
        {
        }

        public IClass ClassInstance
        {
            get
            {
                return this.classInstance;
            }
        }

        public static IMetaClass CreateMetaClass(IBehavior superclass, Machine machine)
        {
            IMetaClass metasuperclass = null;

            if (superclass != null)
                metasuperclass = superclass.MetaClass;

            return new BaseMetaClass(machine.MetaClassClass, metasuperclass, machine, string.Empty);
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

            BaseClass cls = new BaseClass(this, name, super, this.Machine, varnames);
            this.classInstance = cls;
            return cls;
        }
    }
}

