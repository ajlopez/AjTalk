namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ExecutionContext
    {
        public int InstructionPointer;
        public object LastReceiver = null;
        public bool HasReturnValue;
        public object ReturnValue;
        public ExecutionContext Sender;
        public IList Stack;

        private Block block;
        private Machine machine;
        private IObject self;
        private object[] arguments;
        private object[] locals;
        private object nativeSelf;

        public ExecutionContext(Machine machine, IObject self, Block block, object[] arguments)
            : this(block, arguments)
        {
            // this.self = receiver; // TODO review
            this.machine = machine;
            this.self = self;
        }

        public ExecutionContext(Machine machine, object nativeself, Block block, object[] arguments)
            : this(block, arguments)
        {
            this.machine = machine;
            this.nativeSelf = nativeself;
        }

        private ExecutionContext(Block block, object[] arguments)
        {
            this.block = block;
            this.Stack = new ArrayList(5);

            this.arguments = arguments;
            if (this.block.NoLocals > 0)
                this.locals = new object[this.block.NoLocals];
            else
                this.locals = null;

            // TODO refactor to no copy of arguments and locals
            this.arguments = arguments;

            if (block.Closure != null)
            {
                this.self = block.Closure.Self;
                this.nativeSelf = block.Closure.NativeSelf;

                int nlocs = block.NoLocals - block.Closure.NoLocals;

                if (nlocs > 0)
                    this.locals = new object[nlocs];
                else
                    this.locals = null;
            }
            else
            {
                if (this.block.NoLocals > 0)
                    this.locals = new object[this.block.NoLocals];
                else
                    this.locals = null;
            }
        }

        public IObject Self { get { return this.self; } }

        public object NativeSelf { get { return this.nativeSelf; } }

        public int NoLocals { get { return this.NoParentLocals + (this.locals == null ? 0 : this.locals.Length); } }

        public int NoParentLocals { get { return this.block.Closure == null ? 0 : this.block.Closure.NoLocals; } }

        public int NoArguments { get { return this.NoParentArguments + (this.arguments == null ? 0 : this.arguments.Length); } }

        public int NoParentArguments { get { return this.block.Closure == null ? 0 : this.block.Closure.NoArguments; } }

        public Block Block { get { return this.block; } }

        public Machine Machine { get { return this.machine; } }

        public IObject Receiver
        {
            get
            {
                if (this.self != null)
                    return this.self;

                if (this.block.Closure != null)
                    return this.block.Closure.Receiver;

                return null;
            }
        }

        public object Execute()
        {
            this.InstructionPointer = 0;
            return (new Interpreter(this)).Execute();
        }

        internal object GetLocal(int nlocal)
        {
            if (nlocal < this.NoParentLocals)
                return this.GetParentLocal(nlocal);
            return this.locals[nlocal - this.NoParentLocals];
        }

        internal object GetParentLocal(int nlocal)
        {
            return this.block.Closure.GetLocal(nlocal);
        }

        internal void SetLocal(int nlocal, object value)
        {
            if (nlocal < this.NoParentLocals)
                this.SetParentLocal(nlocal, value);
            else
                this.locals[nlocal - this.NoParentLocals] = value;
        }

        internal void SetArgument(int nargument, object value)
        {
            if (nargument < this.NoParentArguments)
                this.SetParentArgument(nargument, value);
            else
                this.arguments[nargument - this.NoParentArguments] = value;
        }

        internal void SetParentArgument(int nargument, object value)
        {
            this.block.Closure.SetArgument(nargument, value);
        }

        internal void SetParentLocal(int nlocal, object value)
        {
            this.block.Closure.SetLocal(nlocal, value);
        }

        internal object GetArgument(int nargument)
        {
            if (nargument < this.NoParentArguments)
                return this.GetParentArgument(nargument);
            return this.arguments[nargument - this.NoParentArguments];
        }

        internal object GetParentArgument(int nargument)
        {
            return this.block.Closure.GetArgument(nargument);
        }

        internal void Push(object obj)
        {
            this.Stack.Add(obj);
        }

        internal object Pop()
        {
            object obj = this.Stack[this.Stack.Count - 1];
            this.Stack.RemoveAt(this.Stack.Count - 1);
            return obj;
        }
    }
}
