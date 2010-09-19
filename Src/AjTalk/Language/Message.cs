using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Language
{
    public class Message
    {
        private IMethod method;
        private object[] arguments;

        public Message(IMethod method, object[] arguments)
        {
            this.method = method;
            this.arguments = arguments;
        }

        public IMethod Method { get { return this.method; } }
        public object[] Arguments { get { return this.arguments; } }
    }
}
