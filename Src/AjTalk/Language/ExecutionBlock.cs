namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ExecutionBlock
    {
        private Block block;
        private Machine machine;
        private IObject self;
        private IObject receiver;
        private object[] arguments;
        private object[] locals;
        private object nativeSelf;
        private object lastreceiver = null;
        private static Action<ExecutionBlock>[] codes;

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
            codes[(int)ByteCode.GetDotNetType] = DoGetDotNetType;
        }

        public ExecutionBlock(Machine machine, IObject receiver, Block block, object[] arguments)
            : this(block, arguments)
        {
            this.self = null;
            this.machine = machine;
            this.receiver = receiver;
        }

        public ExecutionBlock(IObject self, IObject receiver, Block block, object[] arguments)
            : this(block, arguments)
        {
            this.self = self;
            this.machine = self.Behavior.Machine;
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
            this.arguments = arguments;
            this.stack = new ArrayList(5);
            if (this.block.NoLocals > 0)
            {
                this.locals = new object[this.block.NoLocals];
            }
            else
            {
                this.locals = null;
            }
        }

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
                        this.Push(this.locals[arg]);
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
                    case ByteCode.GetVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(this.receiver[arg]);
                        break;
                    case ByteCode.NewObject:
                        IBehavior ibeh = (IBehavior) this.Pop();
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

                        iobj = obj as IObject;

                        if (iobj == null)
                            this.Push(DotNetObject.SendMessage(this.machine, obj, mthname, args));
                        else
                            this.Push(iobj.SendMessage(mthname, args));

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
                            this.Push(DotNetObject.SendNativeMessage(obj, mthname, args));

                        break;
                    case ByteCode.SetArgument:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.arguments[arg] = this.Pop();
                        this.lastreceiver = null;
                        break;
                    case ByteCode.SetClassVariable:
                        throw new Exception("Not implemented");
                    case ByteCode.SetLocal:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.locals[arg] = this.Pop();
                        this.lastreceiver = null;
                        break;
                    case ByteCode.SetVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.receiver[arg] = this.Pop();
                        this.lastreceiver = receiver;
                        break;
                    case ByteCode.SetGlobalVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.machine.SetGlobalObject(this.block.GetGlobalName(arg), this.Pop());
                        this.lastreceiver = this.machine.GetGlobalObject(this.block.GetGlobalName(arg));
                        break;
                    default:
                        throw new Exception("Not implemented");
                }

                this.ip++;
            }

            if (this.self == null && this.stack.Count > 0)
                return this.Pop();

            return this.self;
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

            execblock.Push(newblock);
        }

        private static void DoValue(ExecutionBlock execblock)
        {
            Block newblock = (Block)execblock.Pop();            
            execblock.lastreceiver = newblock;

            if (execblock.self == null)
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.receiver, newblock, null).Execute());
            else
                execblock.Push(new ExecutionBlock(execblock.self, execblock.receiver, newblock, null).Execute());
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

            if (execblock.self == null)
                execblock.Push(new ExecutionBlock(execblock.machine, execblock.receiver, newblock, args).Execute());
            else
                execblock.Push(new ExecutionBlock(execblock.self, execblock.receiver, newblock, args).Execute());
        }

        private static void DoGetArgument(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(execblock.arguments[arg]);
        }

        private static void DoGetClass(ExecutionBlock execblock)
        {
            IObject iobj = (IObject) execblock.Pop();
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
            execblock.Push(execblock.machine.GetGlobalObject(execblock.block.GetGlobalName(arg)));
        }

        private static void DoGetDotNetType(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(TypeUtilities.AsType(execblock.block.GetGlobalName(arg)));
        }
    }
}
