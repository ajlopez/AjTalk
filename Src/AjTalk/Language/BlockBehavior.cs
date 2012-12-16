namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Exceptions;

    public class BlockBehavior : NativeBehavior
    {
        public BlockBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(Block))
        {
            this.DefineInstanceMethod(new FunctionalMethod("assert", this, this.AssertMethod));
            this.DefineInstanceMethod(new FunctionalMethod("whileTrue:", this, this.WhileTrueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("whileFalse:", this, this.WhileFalseMethod));
        }

        private object WhileTrueMethod(Machine machine, object obj, object[] arguments)
        {
            Block block = (Block)obj;
            Block body = (Block)arguments[0];
            var result = block.Execute(machine, null);

            while (result.Equals(true))
            {
                body.Execute(this.Machine, null);
                if (body.Closure != null && body.Closure.HasReturnValue)
                    return null;
                result = block.Execute(machine, null);
            }

            return null;
        }

        private object WhileFalseMethod(Machine machine, object obj, object[] arguments)
        {
            Block block = (Block)obj;
            Block body = (Block)arguments[0];
            var result = block.Execute(machine, null);

            while (result.Equals(false))
            {
                body.Execute(this.Machine, null);
                if (body.Closure != null && body.Closure.HasReturnValue)
                    return null;
                result = block.Execute(machine, null);
            }

            return null;
        }

        private object AssertMethod(Machine machine, object obj, object[] arguments)
        {
            Block block = (Block)obj;
            var result = block.Execute(machine, arguments);

            // TODO review what is true
            if (result is bool && (bool)result == true)
                return true;

            throw new AssertError();
        }
    }
}
