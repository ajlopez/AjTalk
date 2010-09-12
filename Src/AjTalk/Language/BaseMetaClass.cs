namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class BaseMetaClass : BaseClassDescription, IMetaClass
    {
        internal static IMetaClass CreateMetaClass(IBehavior superclass, Machine machine)
        {
            IClassDescription metasuperclass = null;

            if (superclass != null)
                metasuperclass = superclass.MetaClass;

            return new BaseMetaClass(metasuperclass, machine);
        }

        private BaseMetaClass(IClassDescription superclass, Machine machine)
            : base(superclass, machine)
        {
        }
    }
}

