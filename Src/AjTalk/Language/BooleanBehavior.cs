namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BooleanBehavior : NativeBehavior
    {
        public BooleanBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(bool))
        {
            this.DefineInstanceMethod(new FunctionalMethod("ifFalse:", this, this.IfFalseMethod));
            this.DefineInstanceMethod(new FunctionalMethod("ifTrue:", this, this.IfTrueMethod));
            this.DefineInstanceMethod(new FunctionalMethod("ifTrue:ifFalse:", this, this.IfTrueIfFalseMethod));
            this.DefineInstanceMethod(new FunctionalMethod("ifFalse:ifTrue:", this, this.IfFalseIfTrueMethod));
        }

        private object IfFalseMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            bool value = (bool)obj;

            object result = null;
            if (!value)
                result = block.Execute(machine, null);
            return result;
        }

        private object IfTrueMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            bool value = (bool)obj;

            object result = null;
            if (value)
                result = block.Execute(machine, null);
            return result;
        }

        private object IfTrueIfFalseMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 2 || !(arguments[0] is IBlock) || !(arguments[1] is IBlock))
                throw new InvalidOperationException("Two Blocks were expected");
            IBlock thenblock = (IBlock)arguments[0];
            IBlock elseblock = (IBlock)arguments[1];
            bool value = (bool)obj;

            object result = null;
            if (value)
                result = thenblock.Execute(machine, null);
            else
                result = elseblock.Execute(machine, null);
            return result;
        }

        private object IfFalseIfTrueMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 2 || !(arguments[0] is IBlock) || !(arguments[1] is IBlock))
                throw new InvalidOperationException("Two Blocks were expected");
            IBlock elseblock = (IBlock)arguments[0];
            IBlock thenblock = (IBlock)arguments[1];
            bool value = (bool)obj;

            object result = null;
            if (value)
                result = thenblock.Execute(machine, null);
            else
                result = elseblock.Execute(machine, null);
            return result;
        }
    }
}
