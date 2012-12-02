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
        }

        private object ValueMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            return (new ExecutionBlock(this.Machine, null, block, arguments)).Execute();
        }

        private object WhileTrueMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            Block body = (Block)arguments[0];
            var result = (new ExecutionBlock(this.Machine, null, block, arguments)).Execute();

            while (result.Equals(true))
            {
                body.Execute(this.Machine, arguments);
                result = (new ExecutionBlock(this.Machine, null, block, arguments)).Execute();
            }

            return null;
        }

        private object AssertMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            var result = (new ExecutionBlock(this.Machine, null, block, arguments)).Execute();

            // TODO review what is true
            if (result is bool && (bool)result == true)
                return true;

            throw new AssertError();
        }
    }
}
