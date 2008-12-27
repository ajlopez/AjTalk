namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AjTalk;

    class DoesNotUnderstandMethod : IMethod
    {
        public DoesNotUnderstandMethod(Machine machine)
        {
            this.Name = "doesNotUnderstand:";
            this.Class = (IClass)machine.GetGlobalObject("nil");
            this.Machine = machine;
        }

        public string Name
        {
            get;
            private set;
        }
        
        public IClass Class
        {
            get;
            private set;
        }

        private Machine Machine { get; set; }

        public object Execute(IObject self, object[] args)
        {
            return this.Execute(self, self, args);
        }

        public object Execute(IObject self, IObject receiver, object[] args)
        {
            return this.DoesNotUnderstand(self, receiver, (string) args[0], (object []) args[1]);
        }

        public object Execute(Machine machine, object[] args)
        {
            throw new NotImplementedException();
        }

        private object DoesNotUnderstand(IObject self, IObject receiver, string msgname, object[] args)
        {
            if (msgname.Equals("new"))
            {
                return ((IClass)self).NewObject();
            }

            if (msgname.Equals("subclass:"))
            {
                IClass newclass = this.Machine.CreateClass((string) args[0], (IClass)self);
                this.Machine.SetGlobalObject(newclass.Name, newclass);
                return newclass;
            }

            if (msgname.Equals("ifFalse:"))
            {
                ExecutionBlock block = (ExecutionBlock) args[0];
                block.Execute();
                // TODO return block value??
                return this.Machine.GetGlobalObject("nil");
            }

            if (msgname.Equals("subclass:instanceVariableNames:") ||
                msgname.Equals("subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:"))
            {
                IClass newclass = this.Machine.CreateClass((string)args[0], (IClass)self);

                string[] varnames = ((string)args[1]).Split(' ');

                foreach (string varname in varnames)
                {
                    if (!string.IsNullOrEmpty(varname))
                        newclass.DefineInstanceVariable(varname);
                }

                this.Machine.SetGlobalObject(newclass.Name, newclass);
                return newclass;
            }

            throw new InvalidOperationException(string.Format("Does not understand {0}", msgname));
        }
    }
}
