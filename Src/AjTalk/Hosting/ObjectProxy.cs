using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Hosting
{
    [Serializable]
    public class ObjectProxy : IObject
    {
        [NonSerialized] private IHost host;
        [NonSerialized] private IObject obj;

        public ObjectProxy(IObject obj, IHost host)
        {
            this.obj = obj;
            this.HostId = host.Id;
            this.ObjectId = Guid.NewGuid();
        }

        public IObject Object { get { return this.obj; } }

        public Guid HostId { get; set; }
        public Guid ObjectId { get; set; }

        public object SendMessage(string name, object[] parameters)
        {
            if (this.host == null)
                this.host = Machine.Current.GetHost(this.HostId);

            return this.host.Invoke(this, name, parameters);
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
