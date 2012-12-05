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
            this.DefineInstanceMethod(new FunctionalMethod("value", this, this.ValueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("value:", this, this.ValueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("value:value:", this, this.ValueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("assert", this, this.AssertMethod));
            this.DefineInstanceMethod(new FunctionalMethod("whileTrue:", this, this.WhileTrueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("whileFalse:", this, this.WhileFalseMethod));
        }

        private object ValueMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;

            return (new ExecutionBlock(this.Machine, block.Receiver, block, arguments)).Execute();
        }

        private object WhileTrueMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            Block body = (Block)arguments[0];
            var result = (new ExecutionBlock(this.Machine, block.Receiver, block, null)).Execute();

            while (result.Equals(true))
            {
                body.Execute(this.Machine, arguments);
                if (body.Closure != null && body.Closure.HasReturnValue)
                    return null;
                result = (new ExecutionBlock(this.Machine, block.Receiver, block, null)).Execute();
            }

            return null;
        }

        private object WhileFalseMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            Block body = (Block)arguments[0];
            var result = (new ExecutionBlock(this.Machine, block.Receiver, block, null)).Execute();

            while (result.Equals(false))
            {
                body.Execute(this.Machine, arguments);
                if (body.Closure != null && body.Closure.HasReturnValue)
                    return null;
                result = (new ExecutionBlock(this.Machine, block.Receiver, block, null)).Execute();
            }

            return null;
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
