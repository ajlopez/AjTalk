using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Hosting
{
    public class ClientObject : IObject
    {
        private IHost host;
        private IObject obj;

        public ClientObject(IHost host, IObject obj)
        {
            this.host = host;
            this.obj = obj;
        }

        public object SendMessage(string name, object[] parameters)
        {
            return this.host.Invoke(this.obj, name, parameters);
        }

        public IBehavior Behavior
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int n]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
