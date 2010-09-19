namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class MessageQueue 
    {
        private Queue<Message> messages = new Queue<Message>();
        private int maxsize;

        public MessageQueue(int maxsize)
        {
            if (maxsize <= 0)
                throw new InvalidOperationException("MessageQueue needs a positive maxsize");

            this.maxsize = maxsize;
        }

        public void PostMessage(Message message)
        {
            lock (this)
            {
                while (this.messages.Count >= this.maxsize)
                    Monitor.Wait(this);

                this.messages.Enqueue(message);
                Monitor.PulseAll(this);
            }
        }

        public Message GetMessage()
        {
            lock (this)
            {
                while (this.messages.Count == 0)
                    Monitor.Wait(this);

                Message message = this.messages.Dequeue();
                Monitor.PulseAll(this);
                return message;
            }
        }
    }
}

