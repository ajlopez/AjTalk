using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AjTalk.Language
{
    public class BooleanBehavior : NativeBehavior
    {
        public BooleanBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(Boolean))
        {
            this.DefineInstanceMethod(new FunctionalMethod("ifFalse:", this, this.IfFalseMethod));
            this.DefineInstanceMethod(new FunctionalMethod("ifTrue:", this, this.IfTrueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("ifTrue:ifFalse:", this, this.IfTrueIfFalseMethod));
        }

        private object IfFalseMethod(object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count()!=1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock) arguments[0];
            Boolean value = (Boolean)obj;

            object result = null;
            if (!value)
                result = block.Execute(this.Machine, null);
            return result;
        }

        private object IfTrueMethod(object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            Boolean value = (Boolean)obj;

            object result = null;
            if (value)
                result = block.Execute(this.Machine, null);
            return result;
        }

        private object IfTrueIfFalseMethod(object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 2 || !(arguments[0] is IBlock) || !(arguments[1] is IBlock))
                throw new InvalidOperationException("Two Blocks were expected");
            IBlock thenblock = (IBlock)arguments[0];
            IBlock elseblock = (IBlock)arguments[1];
            Boolean value = (Boolean)obj;

            object result = null;
            if (value)
                result = thenblock.Execute(this.Machine, null);
            else
                result = elseblock.Execute(this.Machine, null);
            return result;
        }
    }
}
