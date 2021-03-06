﻿namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class AgentObject : BaseObject
    {
        // TODO 100 is hard coded
        private MessageQueue queue = new MessageQueue(100);

        public AgentObject()
            : base()
        {
            this.Launch();
        }

        public AgentObject(IBehavior behavior, int nvars)
            : base(behavior, nvars)
        {
            this.Launch();
        }

        public AgentObject(IBehavior behavior, object[] vars)
            : base(behavior, vars)
        {
            this.Launch();
        }

        public MessageQueue MessageQueue { get { return this.queue; } }

        public void Launch()
        {
            Thread thread = new Thread(new ThreadStart(this.Execute));
            thread.IsBackground = true;
            thread.Start();
        }

        public override object ExecuteMethod(Machine machine, IMethod method, object[] arguments)
        {
            Message message = new Message(machine, method, arguments);
            this.queue.PostMessage(message);
            return null;    // TODO what to return?
        }

        public override object ExecuteMethod(Interpreter interpreter, IMethod method, object[] arguments)
        {
            Message message = new Message(interpreter.Machine, method, arguments);
            this.queue.PostMessage(message);
            return null;    // TODO what to return?
        }

        private void Execute()
        {
            while (true)
            {
                try
                {
                    Message message = this.queue.GetMessage();
                    message.Method.Execute(message.Machine, this, message.Arguments);
                }
                catch (Exception ex)
                {
                    // TODO review output
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}

