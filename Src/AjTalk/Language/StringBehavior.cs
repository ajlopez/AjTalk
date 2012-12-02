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

        private object ConcatenateMethod(object obj, object[] arguments)
        {
            string str = (string)obj;
            object arg = arguments[0];

            if (arg == null)
                arg = "nil";
            else
                arg = arg.ToString();

            return str + arg;
        }

        private object AssertMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            var result = (new ExecutionBlock(this.Machine, block.Receiver, block, arguments)).Execute();

            // TODO review what is true
            if (result is bool && (bool)result == true)
                return true;

            throw new AssertError();
        }
    }
}
