using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Hosting
{
    public class RemoteObject : MarshalByRefObject, IObject
    {
        private IObject obj;
        private Machine machine;

        public RemoteObject(IObject obj)
        {
            this.obj = obj;
            this.machine = Machine.Current;
        }

        public IBehavior Behavior
        {
            get { return this.obj.Behavior; }
        }

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
            Machine current = Machine.Current;
            Machine.SetCurrent(this.machine);
            try
            {
                return this.obj.SendMessage(msgname, args);
            }
            finally
            {
                Machine.SetCurrent(current);
            }
        }
    }
}
