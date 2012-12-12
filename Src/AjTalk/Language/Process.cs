namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Process
    {
        private IBlock block;
        private object[] arguments;
        private Machine machine;
        private Thread thread;

        public Process(IBlock block, object[] arguments, Machine machine)
        {
            this.block = block;
            this.arguments = arguments;
            this.machine = machine;
        }

        public IBlock Block { get { return this.block; } }

        public object[] Arguments { get { return this.arguments; } }

        public Machine Machine { get { return this.machine; } }

        public void Start()
        {
            ThreadStart start = new ThreadStart(this.Run);
            this.thread = new Thread(start);
            this.thread.Start();
        }

        public void Resume()
        {
            if (this.thread == null)
                this.Start();
            else
                //// TODO Resume is obsolete
                this.thread.Resume();
        }

        private void Run()
        {
            this.block.Execute(this.machine, this.arguments);
        }
    }
}
