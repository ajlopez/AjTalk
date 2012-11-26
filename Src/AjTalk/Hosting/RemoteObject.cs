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

        public object SendMessage(string msgname, object[] args)
        {
            return this.obj.SendMessage(msgname, args);
        }
    }
}
