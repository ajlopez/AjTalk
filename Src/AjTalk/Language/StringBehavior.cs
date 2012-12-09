namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Exceptions;

    public class StringBehavior : NativeBehavior
    {
        public StringBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(string))
        {
            this.DefineInstanceMethod(new FunctionalMethod(",", this, this.ConcatenateMethod));
        }

        private object ConcatenateMethod(Machine machine, object obj, object[] arguments)
        {
            string str = (string)obj;
            object arg = arguments[0];

            if (arg == null)
                arg = "nil";
            else
                arg = arg.ToString();

            return str + arg;
        }
    }
}
