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
            this.Name = "doesNotUnderstand:with:";
            this.Behavior = behavior;
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

        public object Execute(Machine machine, IObject self, object[] args)
        {
            return this.DoesNotUnderstand(machine, self, (string)args[0], (object[])args[1]);
        }

        public object Execute(Machine machine, object[] args)
        {
            throw new NotImplementedException();
        }

        public object ExecuteInProcess(Process process, object[] args)
        {
            throw new NotImplementedException();
        }

        public object ExecuteNative(Machine machine, object self, object[] args)
        {
            throw new NotImplementedException();
        }

        protected virtual object DoesNotUnderstand(Machine machine, IObject self, string msgname, object[] args)
        {
            if (machine.HostMachine != null)
            {
                IBehavior behavior = machine.HostMachine.GetAssociatedBehavior(self.Behavior);

                if (behavior != null) 
                {
                    IMethod method = behavior.GetInstanceMethod(msgname);

                    if (method != null)
                        return method.Execute(machine, self, args);

                    method = behavior.GetInstanceMethod(this.Name);

                    if (method != null)
                        return method.Execute(machine, self, new object[] { msgname, args });
                }
            }

            return DotNetObject.SendMessage(machine, self, msgname, args);
        }
    }
}
