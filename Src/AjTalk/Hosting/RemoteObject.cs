namespace AjTalk.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;

    public class RemoteObject : MarshalByRefObject, IObject, IObjectDecorator
    {
        private IObject obj;
        private Machine machine;

        public RemoteObject(IObject obj, Machine machine)
        {
            this.obj = obj;
            this.machine = machine;
        }

        public IBehavior Behavior
        {
            get { return this.obj.Behavior; }
        }

        public IObject InnerObject
        {
            get { return this.obj; }
        }

        public int NoVariables { get { return this.obj.NoVariables; } }

        public object this[int n]
        {
            get
            {
                return this.obj[n];
            }

            set
            {
                this.obj[n] = value;
            }
        }

        public object SendMessage(Machine machine, string msgname, object[] args)
        {
            return this.obj.SendMessage(machine, msgname, args);
        }

        public object ExecuteMethod(Machine machine, IMethod method, object[] arguments)
        {
            return this.obj.ExecuteMethod(machine, method, arguments);
        }

        public object ExecuteMethod(Interpreter interpreter, IMethod method, object[] arguments)
        {
            return this.obj.ExecuteMethod(interpreter, method, arguments);
        }

        public void DefineObjectMethod(IMethod method)
        {
            this.obj.DefineObjectMethod(method);
        }
    }
}
