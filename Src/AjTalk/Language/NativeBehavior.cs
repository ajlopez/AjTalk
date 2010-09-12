namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NativeBehavior : BaseBehavior
    {
        private Type nativeType;

        public NativeBehavior(IBehavior superclass, Machine machine, Type type)
            : base(superclass, machine)
        {
            this.nativeType = type;
            machine.RegisterNativeBehavior(type, this);
        }

        public Type NativeType { get { return this.nativeType; } }

        public override object NewObject()
        {
            return this.CreateObject();
        }

        public object CreateObject(params object[] parameters)
        {
            return DotNetObject.NewObject(this.nativeType, parameters);
        }
    }
}
