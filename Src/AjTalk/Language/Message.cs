namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Message
    {
        private Machine machine;
        private IMethod method;
        private object[] arguments;

        public Message(Machine machine, IMethod method, object[] arguments)
        {
            this.machine = machine;
            this.method = method;
            this.arguments = arguments;
        }

        public Machine Machine { get { return this.machine; } }

        public IMethod Method { get { return this.method; } }
        
        public object[] Arguments { get { return this.arguments; } }
    }
}
