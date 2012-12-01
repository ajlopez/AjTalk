namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ExecutionBlock
    {
        private static Action<ExecutionBlock>[] codes;

        private Block block;
        private Machine machine;
        private IObject self;
        private IObject receiver;
        private object[] arguments;
        private object[] locals;
        private object nativeSelf;
        private object lastreceiver = null;

        private int ip;
        private IList stack;

        static ExecutionBlock()
        {
            codes = new Action<ExecutionBlock>[256];
            codes[(int)ByteCode.GetConstant] = DoGetConstant;
            codes[(int)ByteCode.GetBlock] = DoGetBlock;
            codes[(int)ByteCode.Value] = DoValue;
            codes[(int)ByteCode.MultiValue] = DoMultiValue;
            codes[(int)ByteCode.GetArgument] = DoGetArgument;
            codes[(int)ByteCode.GetClass] = DoGetClass;
            codes[(int)ByteCode.BasicSize] = DoBasicSize;
            codes[(int)ByteCode.GetGlobalVariable] = DoGetGlobalVariable;
            codes[(int)ByteCode.SetGlobalVariable] = DoSetGlobalVariable;
            codes[(int)ByteCode.GetDotNetType] = DoGetDotNetType;
        }

        public ExecutionBlock(Machine machine, IObject receiver, Block block, object[] arguments)
            : this(block, arguments)
        {
            // this.self = receiver; // TODO review
            this.machine = machine;
            this.receiver = receiver;
        }

        public ExecutionBlock(Machine machine, IObject self, IObject receiver, Block block, object[] arguments)
            : this(block, arguments)
        {
            this.self = self;
            this.machine = machine;
            this.receiver = receiver;
        }

        public ExecutionBlock(Machine machine, object nativeself, Block block, object[] arguments)
            : this(block, arguments)
        {
            this.machine = machine;
            this.nativeSelf = nativeself;
        }

        private ExecutionBlock(Block block, object[] arguments)
        {
            this.block = block;
            this.stack = new ArrayList(5);

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

        private object Top
        {
            get
            {
                return this.stack[this.stack.Count - 1];
            }
        }

        public object Execute()
        {
            this.ip = 0;
            string mthname;
            object[] args;

            // TODO refactor lastreceiver process
            // TODO refactor switch
            if (this.block.Bytecodes != null)
                while (this.ip < this.block.ByteCodes.Length)
                {
                    ByteCode bc = (ByteCode)this.block.ByteCodes[this.ip];
                    byte arg;

                    if (codes[(int)bc] != null)
                    {
                        codes[(int)bc](this);
                        this.ip++;
                        continue;
                    }

                    switch (bc)
                    {
                        case ByteCode.ReturnSub:
                            return null;
                        case ByteCode.ReturnPop:
                            return this.Top;
                        case ByteCode.GetClassVariable:
                            throw new Exception("Not implemented");
                        case ByteCode.GetLocal:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            this.Push(this.GetLocal(arg));
                            break;
                        case ByteCode.GetSelf:
                            if (this.nativeSelf != null)
                                this.Push(this.nativeSelf);
                            else
                                this.Push(this.self);
                            break;
                        case ByteCode.GetSuperClass:
                            this.Push(this.receiver.Behavior.SuperClass);
                            break;
                        case ByteCode.GetNil:
                            this.Push(null);
                            break;
                        case ByteCode.GetInstanceVariable:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            this.Push(this.receiver[arg]);
                            break;
                        case ByteCode.NewObject:
                            IBehavior ibeh = (IBehavior)this.Pop();
                            this.lastreceiver = ibeh;
                            this.Push(ibeh.NewObject());
                            break;
      
                        // TODO remove, no primitive methods
    /*
                        case ByteCode.Add:
                            int y = (int)this.Pop();
                            int x = (int)this.Pop();
                            this.lastreceiver = x;
                            this.Push(x + y);
                            break;
                        case ByteCode.Substract:
                            y = (int)this.Pop();
                            x = (int)this.Pop();
                            this.lastreceiver = x;
                            this.Push(x - y);
                            break;
                        case ByteCode.Multiply:
                            y = (int)this.Pop();
                            x = (int)this.Pop();
                            this.lastreceiver = x;
                            this.Push(x * y);
                            break;
                        case ByteCode.Divide:
                            y = (int)this.Pop();
                            x = (int)this.Pop();
                            this.lastreceiver = x;
                            this.Push(x / y);
                            break;
     */
                        case ByteCode.Nop:
                            break;
                        case ByteCode.Pop:
                            this.Pop();
                            break;
                        case ByteCode.InstSize:
                            IObject iobj = (IObject)this.Pop();
                            this.lastreceiver = iobj;
                            this.Push(iobj.Behavior.NoInstanceVariables);
                            break;
                        case ByteCode.InstAt:
                            int pos = (int)this.Pop();
                            iobj = (IObject)this.Pop();
                            this.lastreceiver = iobj;
                            this.Push(iobj[pos]);
                            break;
                        case ByteCode.InstAtPut:
                            object par = this.Pop();
                            pos = (int)this.Pop();
                            iobj = (IObject)this.Pop();
                            this.lastreceiver = iobj;
                            iobj[pos] = par;
                            break;
                        case ByteCode.BasicAt:
                            pos = (int)this.Pop();
                            IIndexedObject indexedObj = (IIndexedObject)this.Pop();
                            this.lastreceiver = indexedObj;
                            this.Push(indexedObj.GetIndexedValue(pos));
                            break;
                        case ByteCode.BasicAtPut:
                            par = this.Pop();
                            pos = (int)this.Pop();
                            indexedObj = (IIndexedObject)this.Pop();
                            this.lastreceiver = indexedObj;
                            indexedObj.SetIndexedValue(pos, par);
                            break;
                        case ByteCode.ChainedSend:
                            // TODO Review if the last result should be removed from stack
                            this.Push(this.lastreceiver);
                            break;
                        case ByteCode.Send:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            mthname = (string)this.block.GetConstant(arg);
                            this.ip++;

                            arg = this.block.ByteCodes[this.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.Pop();
                            }

                            object obj = this.Pop();
                            this.lastreceiver = obj;

                            // TODO this.machine is null in many tests, not in real world
                            if (this.machine == null)
                                this.Push(((IObject)obj).SendMessage(null, mthname, args));
                            else
                                this.Push(this.machine.SendMessage(obj, mthname, args));

                            break;
                        case ByteCode.MakeCollection:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.Pop();
                            }

                            this.Push(new ArrayList(args));

                            break;
                        case ByteCode.NewDotNetObject:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];

                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.Pop();
                            }

                            obj = this.Pop();
                            this.lastreceiver = obj;

                            this.Push(DotNetObject.NewObject((Type)obj, args));

                            break;
                        case ByteCode.InvokeDotNetMethod:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            mthname = (string)this.block.GetConstant(arg);
                            this.ip++;

                            arg = this.block.ByteCodes[this.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.Pop();
                            }

                            obj = this.Pop();
                            this.lastreceiver = obj;

                            Type type = obj as Type;

                            if (type != null)
                                this.Push(DotNetObject.SendNativeStaticMessage(type, mthname, args));
                            else
                                this.Push(DotNetObject.SendNativeMessage(this.machine, obj, mthname, args));

                            break;
                        
                        // TODO review argument has no set
                        // case ByteCode.SetArgument:
                        //    this.ip++;
                        //    arg = this.block.ByteCodes[this.ip];
                        //    this.arguments[arg] = this.Pop();
                        //    this.lastreceiver = null;
                        //    break;
                        case ByteCode.SetClassVariable:
                            throw new Exception("Not implemented");
                        case ByteCode.SetLocal:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            this.SetLocal(arg, this.Pop());
                            this.lastreceiver = null;
                            break;
                        case ByteCode.SetInstanceVariable:
                            this.ip++;
                            arg = this.block.ByteCodes[this.ip];
                            this.receiver[arg] = this.Pop();
                            this.lastreceiver = this.receiver;
                            break;
                        case ByteCode.RaiseException:
                            throw (Exception)this.Pop();
                        default:
                            throw new Exception("Not implemented");
                    }

                this.ip++;
            }

            if (this.self == null && this.stack.Count > 0)
                return this.Pop();

            return this.self;
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

        private static void DoGetConstant(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(execblock.block.GetConstant(arg));
        }

        private static void DoGetBlock(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];

            Block newblock = (Block)execblock.block.GetConstant(arg);
            newblock = new Block(newblock, execblock);

            execblock.Push(newblock);
        }

        private static void DoValue(ExecutionBlock execblock)
        {
            Block newblock = (Block)execblock.Pop();

            execblock.lastreceiver = newblock;

            if (newblock.Closure != null || execblock.self == null)
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.receiver, newblock, null).Execute());
            else
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.self, execblock.receiver, newblock, null).Execute());
        }

        private static void DoMultiValue(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];

            object[] args = new object[arg];

            for (int k = arg - 1; k >= 0; k--)
                args[k] = execblock.Pop();

            Block newblock = (Block)execblock.Pop();
            execblock.lastreceiver = newblock;

            if (newblock.Closure != null || execblock.self == null)
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.receiver, newblock, args).Execute());
            else
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.self, execblock.receiver, newblock, args).Execute());
        }

        private static void DoGetArgument(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(execblock.GetArgument(arg));
        }

        private static void DoGetClass(ExecutionBlock execblock)
        {
            IObject iobj = (IObject)execblock.Pop();
            execblock.lastreceiver = iobj;
            execblock.Push(iobj.Behavior);
        }

        private static void DoBasicSize(ExecutionBlock execblock)
        {
            IIndexedObject indexedObj = (IIndexedObject)execblock.Pop();
            execblock.lastreceiver = indexedObj;
            execblock.Push(indexedObj.BasicSize);
        }

        private static void DoGetGlobalVariable(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            string name = execblock.block.GetGlobalName(arg);
            object value;

            if (execblock.self != null)
                value = execblock.self.Behavior.Scope.GetValue(name);
            else
                value = execblock.machine.CurrentEnvironment.GetValue(name);

            execblock.Push(value);
        }

        private static void DoSetGlobalVariable(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            string name = execblock.block.GetGlobalName(arg);
            object value = execblock.Pop();

            if (execblock.self != null)
                execblock.self.Behavior.Scope.SetValue(name, value);
            else
                execblock.machine.CurrentEnvironment.SetValue(name, value);

            execblock.lastreceiver = value;
        }

        private static void DoGetDotNetType(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(TypeUtilities.AsType(execblock.block.GetGlobalName(arg)));
        }

        private void Push(object obj)
        {
            this.stack.Add(obj);
        }

        private object Pop()
        {
            object obj = this.stack[this.stack.Count - 1];
            this.stack.RemoveAt(this.stack.Count - 1);
            return obj;
        }
    }
}
