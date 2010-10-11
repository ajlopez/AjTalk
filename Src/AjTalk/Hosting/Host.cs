using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;
using AjTalk.Compiler;
using System.IO;

namespace AjTalk.Hosting
{
    public class Host : MarshalByRefObject, IHost
    {
        private Guid id = Guid.NewGuid();
        private Machine machine;
        private Dictionary<IObject, Guid> objectids = new Dictionary<IObject, Guid>();
        private Dictionary<Guid, ObjectProxy> proxies = new Dictionary<Guid, ObjectProxy>();

        public Host()
        {
            this.machine = new Machine(false);
            this.machine.Host = this;
            if (Machine.Current != null)
                Machine.Current.RegisterHost(this);
        }

        public Host(Machine machine)
        {
            this.machine = machine;
            this.machine.Host = this;
            if (Machine.Current != null)
                Machine.Current.RegisterHost(this);
        }

        public Machine Machine { get { return this.machine; } }

        public Guid Id { get { return this.id; } }

        public virtual string Address { get { return ""; } } // TODO review

        public bool IsLocal { get { return true; } }

        public void Execute(string command)
        {
            Machine current = Machine.Current;
            Loader loader = new Loader(new StringReader(command));

            try
            {
                this.machine.SetCurrent();
                loader.LoadAndExecute(this.machine);
            }
            finally
            {
                Machine.SetCurrent(current);
            }
        }

        public object Evaluate(string command)
        {
            Machine current = Machine.Current;
            object result = null;

            try
            {
                this.machine.SetCurrent();
                Parser parser = new Parser(command);

                Block block = parser.CompileBlock();
                
                if (block != null)
                    result = block.Execute(machine, null);

                return result;
            }
            finally
            {
                Machine.SetCurrent(current);
            }
        }

        public object Invoke(IObject obj, string msgname, object[] args)
        {
            Machine current = Machine.Current;

            try
            {
                this.machine.SetCurrent();

                if (obj is ObjectProxy)
                {
                    ObjectProxy proxy = (ObjectProxy)obj;

                    if (proxy.HostId != this.Id)
                        throw new NotSupportedException();

                    return this.Invoke(proxy.ObjectId, msgname, args);
                }

                return obj.SendMessage(msgname, args);
            }
            finally
            {
                Machine.SetCurrent(current);
            }
        }

        private object Invoke(Guid objid, string msgname, params object[] arguments)
        {
            IObject receiver = (IObject)this.GetObject(objid);

            return receiver.SendMessage(msgname, arguments);
        }

        public object GetObject(Guid objid)
        {
            return this.proxies[objid].Object;
        }

        public object ResultToObject(IObject result)
        {
            if (result == null)
                return null;

            if (!(result is IObject))
                return result;

            if (this.objectids.ContainsKey(result))
                return this.objectids[result];

            ObjectProxy proxy = new ObjectProxy(result, this);

            this.objectids[result] = proxy.ObjectId;
            this.proxies[proxy.ObjectId] = proxy;

            return proxy;
        }
    }
}
