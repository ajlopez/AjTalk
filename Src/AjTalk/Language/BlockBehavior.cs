namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockBehavior : NativeBehavior
    {
        public BlockBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(Block))
        {
            this.DefineInstanceMethod(new FunctionalMethod("value", this, this.ValueMethod));
        }

        private object ValueMethod(object obj, object[] arguments)
        {
            Block block = (Block)obj;
            return (new ExecutionBlock(this.Machine, null, block, arguments)).Execute();
        }
    }
}
