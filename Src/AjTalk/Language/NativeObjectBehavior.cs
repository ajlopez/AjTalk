namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Exceptions;

    public class NativeObjectBehavior : NativeBehavior
    {
        public NativeObjectBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(object))
        {
            this.DefineInstanceMethod(new FunctionalMethod("isNil", this, this.IsNil));
            this.DefineInstanceMethod(new FunctionalMethod("isNotNil", this, this.IsNotNil));
            this.DefineInstanceMethod(new FunctionalMethod("ifNil:", this, this.IfNil));
            this.DefineInstanceMethod(new FunctionalMethod("ifNotNil:", this, this.IfNotNil));
        }

        private object IfNil(Machine machine, object self, object[] arguments)
        {
            return null;
        }

        private object IfNotNil(Machine machine, object self, object[] arguments)
        {
            Block block = (Block)arguments[0];
            return block.Execute(machine, null);
        }

        private object IsNil(Machine machine, object self, object[] arguments)
        {
            return self == null;
        }

        private object IsNotNil(Machine machine, object self, object[] arguments)
        {
            return self != null;
        }
    }
}
