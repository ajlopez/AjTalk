namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Text;

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

        public override object ExecuteMethod(IMethod method, object[] arguments)
        {
            Message message = new Message(method, arguments);
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
                    message.Method.Execute(this, this, message.Arguments);
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

