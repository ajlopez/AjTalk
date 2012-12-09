namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // TODO It was removed from native behaviors in machine initialization
    public class ArrayBehavior : NativeBehavior
    {
        public ArrayBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(ArrayList))
        {
            this.DefineInstanceMethod(new FunctionalMethod("add:", this, this.AddMethod));
        }

        private object AddMethod(Machine machine, object obj, object[] arguments)
        {
            ((IList)obj).Add(arguments[0]);
            return obj;
        }
    }
}
