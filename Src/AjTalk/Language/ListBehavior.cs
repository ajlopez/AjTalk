namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListBehavior : NativeBehavior
    {
        public ListBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(IList))
        {
            this.DefineInstanceMethod(new FunctionalMethod("at:", this, this.AtMethod));
        }

        private object AtMethod(Machine machine, object obj, object[] arguments)
        {
            return ((IList)obj)[((int)arguments[0]) - 1];
        }
    }
}
