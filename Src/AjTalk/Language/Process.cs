namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class Process
    {
        private Block block;
        private object[] arguments;
        private Machine machine;
        private Thread thread;
        private Interpreter interpreter;

        public Process(Block block, object[] arguments, Machine machine)
        {
            this.block = block;
            this.arguments = arguments;
            this.machine = machine;
        }

        public Block Block { get { return this.block; } }

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

        public object CallContext(ExecutionContext context)
        {
            this.interpreter.PushContext(context);
            return this.interpreter;
        }

        public object Execute()
        {
            ExecutionContext context = this.block.CreateContext(this.machine, this.arguments);
            this.interpreter = new Interpreter(context);

            return this.interpreter.Execute();
        }

        private void Run()
        {
            this.Execute();
        }
    }
}
