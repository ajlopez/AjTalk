namespace AjTalk.Language
{
    using System;
    using System.Collections;

    public class ExecutionBlock
    {
        private Block block;
        private Machine machine;
        private IObject self;
        private IObject receiver;
        private object[] arguments;
        private object[] locals;

        private int ip;
        private IList stack;

        public ExecutionBlock(Machine machine, IObject receiver, Block block, object[] arguments)
        {
            this.self = null;
            this.machine = machine;
            this.receiver = receiver;
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

        public ExecutionBlock(IObject self, IObject receiver, Block block, object[] arguments)
        {
            this.self = self;
            this.machine = self.Behavior.Machine;
            this.receiver = receiver;
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

            while (this.ip < this.block.ByteCodes.Length)
            {
                ByteCode bc = (ByteCode)this.block.ByteCodes[this.ip];
                byte arg;

                switch (bc)
                {
                    case ByteCode.ReturnSub:
                        return null;
                    case ByteCode.ReturnPop:
                        return this.Top;
                    case ByteCode.GetConstant:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(this.block.GetConstant(arg));
                        break;
                    case ByteCode.GetBlock:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];

                        Block newblock = (Block)this.block.GetConstant(arg);

                        this.Push(newblock);

                        break;
                    case ByteCode.Value:
                        newblock = (Block)this.Pop();

                        if (this.self == null)
                        {
                            this.Push(new ExecutionBlock(this.machine, this.receiver, newblock, null).Execute());
                        }
                        else
                        {
                            this.Push(new ExecutionBlock(this.self, this.receiver, newblock, null).Execute());
                        }

                        break;
                    case ByteCode.MultiValue:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];

                        args = new object[arg];

                        for (int k = arg - 1; k >= 0; k--)
                        {
                            args[k] = this.Pop();
                        }

                        newblock = (Block)this.Pop();

                        if (this.self == null)
                        {
                            this.Push(new ExecutionBlock(this.machine, this.receiver, newblock, args).Execute());
                        }
                        else
                        {
                            this.Push(new ExecutionBlock(this.self, this.receiver, newblock, args).Execute());
                        }

                        break;
                    case ByteCode.GetArgument:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(this.arguments[arg]);
                        break;
                    case ByteCode.GetClass:
                        this.Push(((IObject) this.Pop()).Behavior);
                        break;
                    case ByteCode.BasicSize:
                        IIndexedObject indexedObj = (IIndexedObject)this.Pop();
                        this.Push(indexedObj.BasicSize);
                        break;
                    case ByteCode.GetClassVariable:
                        throw new Exception("Not implemented");
                    case ByteCode.GetGlobalVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(this.machine.GetGlobalObject(this.block.GetGlobalName(arg)));
                        break;
                    case ByteCode.GetDotNetType:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(Type.GetType(this.block.GetGlobalName(arg)));
                        break;
                    case ByteCode.GetLocal:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.Push(this.locals[arg]);
                        break;
                    case ByteCode.GetSelf:
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
                        this.Push(((IBehavior)this.Pop()).NewObject());
                        break;
                    case ByteCode.Add:
                        int y = (int)this.Pop();
                        int x = (int)this.Pop();
                        this.Push(x + y);
                        break;
                    case ByteCode.Substract:
                        y = (int)this.Pop();
                        x = (int)this.Pop();
                        this.Push(x - y);
                        break;
                    case ByteCode.Multiply:
                        y = (int)this.Pop();
                        x = (int)this.Pop();
                        this.Push(x * y);
                        break;
                    case ByteCode.Divide:
                        y = (int)this.Pop();
                        x = (int)this.Pop();
                        this.Push(x / y);
                        break;
                    case ByteCode.Nop:
                        break;
                    case ByteCode.Pop:
                        this.Pop();
                        break;
                    case ByteCode.InstSize:
                        IObject iobj = (IObject)this.Pop();
                        this.Push(iobj.Behavior.NoInstanceVariables);
                        break;
                    case ByteCode.InstAt:
                        int pos = (int)this.Pop();
                        iobj = (IObject)this.Pop();
                        this.Push(iobj[pos]);
                        break;
                    case ByteCode.InstAtPut:
                        object par = this.Pop();
                        pos = (int)this.Pop();
                        iobj = (IObject)this.Pop();
                        iobj[pos] = par;
                        break;
                    case ByteCode.BasicAt:
                        pos = (int)this.Pop();
                        indexedObj = (IIndexedObject)this.Pop();
                        this.Push(indexedObj.GetIndexedValue(pos));
                        break;
                    case ByteCode.BasicAtPut:
                        par = this.Pop();
                        pos = (int)this.Pop();
                        indexedObj = (IIndexedObject)this.Pop();
                        indexedObj.SetIndexedValue(pos, par);
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

                        iobj = obj as IObject;

                        this.Push(iobj.SendMessage(mthname, args));

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

                        this.Push(DotNetObject.SendMessage(obj, mthname, args));

                        break;
                    case ByteCode.SetArgument:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.arguments[arg] = this.Pop();
                        break;
                    case ByteCode.SetClassVariable:
                        throw new Exception("Not implemented");
                    case ByteCode.SetLocal:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.locals[arg] = this.Pop();
                        break;
                    case ByteCode.SetVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.receiver[arg] = this.Pop();
                        break;
                    case ByteCode.SetGlobalVariable:
                        this.ip++;
                        arg = this.block.ByteCodes[this.ip];
                        this.machine.SetGlobalObject(this.block.GetGlobalName(arg), this.Pop());
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
    }
}
