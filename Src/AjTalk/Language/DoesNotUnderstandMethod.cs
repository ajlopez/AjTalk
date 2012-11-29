namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    public class DoesNotUnderstandMethod : IMethod
    {
        public DoesNotUnderstandMethod(Machine machine, IBehavior behavior)
        {
            this.Name = "doesNotUnderstand:";
            this.Behavior = behavior;
            this.Machine = machine;
        }

        public string Name
        {
            get;
            private set;
        }

        public string SourceCode { get { return null; } }

        public byte[] Bytecodes { get { return null; } }
        
        public IBehavior Behavior
        {
            get;
            set;
        }

        public Machine Machine { get; private set; }

        public object Execute(IObject self, object[] args)
        {
            return this.Execute(self, self, args);
        }

        public object Execute(IObject self, IObject receiver, object[] args)
        {
            return this.DoesNotUnderstand(self, receiver, (string)args[0], (object[])args[1]);
        }

        public object Execute(Machine machine, object[] args)
        {
            throw new NotImplementedException();
        }

        public object ExecuteNative(object self, object[] args)
        {
            throw new NotImplementedException();
        }

        protected virtual object DoesNotUnderstand(IObject self, IObject receiver, string msgname, object[] args)
        {
            if (msgname.Equals("ifFalse:"))
            {
                IBlock block = (IBlock)args[0];
                block.Execute(this.Machine, null);
                
                // TODO return block value??
                return this.Machine.GetGlobalObject("nil");
            }

            if (msgname.Equals("class"))
            {
                return self.Behavior;
            }

            return DotNetObject.SendMessage(this.Machine, self, msgname, args);
        }
    }
}
