namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NativeBehavior : BaseBehavior
    {
        private Type nativeType;

        public NativeBehavior(IClass superclass, Machine machine, Type type)
            : base(superclass, machine)
        {
            this.nativeType = type;
            machine.RegisterNativeBehavior(type, this);
        }

        public override object NewObject()
        {
            return base.NewObject();
        }

        public object CreateObject(params object[] parameters)
        {
            return DotNetObject.NewObject(this.nativeType, parameters);
        }
    }
}
