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
                    result = block.Execute(this.machine, null);

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

                return obj.SendMessage(msgname, args);
            }
            finally
            {
                Machine.SetCurrent(current);
            }
        }
    }
}
