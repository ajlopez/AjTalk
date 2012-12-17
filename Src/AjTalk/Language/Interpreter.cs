namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Interpreter
    {
        private static object super = new object();
        private static Action<ExecutionContext>[] codes;

        private ExecutionContext context;

        static Interpreter()
        {
            codes = new Action<ExecutionContext>[256];
            codes[(int)ByteCode.GetConstant] = DoGetConstant;
            codes[(int)ByteCode.GetBlock] = DoGetBlock;
            codes[(int)ByteCode.GetArgument] = DoGetArgument;
            codes[(int)ByteCode.SetArgument] = DoSetArgument;
            codes[(int)ByteCode.GetClass] = DoGetClass;
            codes[(int)ByteCode.BasicSize] = DoBasicSize;
            codes[(int)ByteCode.GetGlobalVariable] = DoGetGlobalVariable;
            codes[(int)ByteCode.SetGlobalVariable] = DoSetGlobalVariable;
            codes[(int)ByteCode.GetDotNetType] = DoGetDotNetType;
        }

        public Interpreter(ExecutionContext context)
        {
            this.context = context;
        }

        public Machine Machine { get { return this.context.Machine; } }

        public object Execute()
        {
            this.context.InstructionPointer = 0;
            string mthname;
            object[] args;

            // TODO refactor lastreceiver process
            // TODO refactor switch
            if (this.context.Block.Bytecodes != null)
                while (true)
                {
                    while (this.context.Sender != null && (this.context.HasReturnValue || this.context.Block.Bytecodes == null || this.context.InstructionPointer >= this.context.Block.ByteCodes.Length))
                    {
                        object retvalue = this.GetReturnValue();
                        this.PopContext(retvalue);
                        this.context.InstructionPointer++;
                    }

                    if (this.context.HasReturnValue || this.context.Block.Bytecodes == null || this.context.InstructionPointer >= this.context.Block.ByteCodes.Length)
                        break;

                    ByteCode bc = (ByteCode)this.context.Block.ByteCodes[this.context.InstructionPointer];
                    byte arg;

                    if (codes[(int)bc] != null)
                    {
                        codes[(int)bc](this.context);
                        this.context.InstructionPointer++;
                        continue;
                    }

                    switch (bc)
                    {
                        case ByteCode.ReturnSub:
                            this.context.HasReturnValue = true;
                            this.context.ReturnValue = null;

                            ExecutionContext retcontext = this.context.ReturnExecutionContext;

                            if (retcontext != null)
                            {
                                this.ReturnToContext(retcontext, null);
                                break;
                            }

                            break;
                        case ByteCode.ReturnPop:
                            this.context.HasReturnValue = true;
                            this.context.ReturnValue = this.context.Pop();

                            retcontext = this.context.ReturnExecutionContext;

                            if (retcontext != null)
                            {
                                this.ReturnToContext(retcontext, this.context.ReturnValue);
                                break;
                            }

                            break;
                        case ByteCode.Value:
                            Block newblock = (Block)this.context.Pop();

                            this.context.LastReceiver = newblock;

                            this.PushContext(newblock.CreateContext(this.context.Machine, null));
                            continue;

                        case ByteCode.MultiValue:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];

                            object[] mvargs = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                                mvargs[k] = this.context.Pop();

                            newblock = (Block)this.context.Pop();
                            this.context.LastReceiver = newblock;
                            this.PushContext(newblock.CreateContext(this.context.Machine, mvargs));

                            continue;

                        case ByteCode.GetLocal:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            this.context.Push(this.context.GetLocal(arg));
                            break;
                        case ByteCode.GetSuper:
                            this.context.Push(super);
                            break;
                        case ByteCode.GetSelf:
                            if (this.context.NativeSelf != null)
                                this.context.Push(this.context.NativeSelf);
                            else
                                this.context.Push(this.context.Self);
                            break;
                        case ByteCode.GetSuperClass:
                            this.context.Push(this.context.Self.Behavior.SuperClass);
                            break;
                        case ByteCode.GetNil:
                            this.context.Push(null);
                            break;
                        case ByteCode.GetInstanceVariable:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            this.context.Push(this.context.Self[arg]);
                            break;

                        case ByteCode.NewObject:
                            IBehavior ibeh = (IBehavior)this.context.Pop();
                            this.context.LastReceiver = ibeh;
                            this.context.Push(ibeh.NewObject());
                            break;

                        case ByteCode.Nop:
                            break;

                        case ByteCode.Pop:
                            this.context.Pop();

                            break;

                        case ByteCode.InstSize:
                            IObject iobj = (IObject)this.context.Pop();
                            this.context.LastReceiver = iobj;
                            this.context.Push(iobj.Behavior.NoInstanceVariables);
                            break;

                        case ByteCode.InstAt:
                            int pos = (int)this.context.Pop();
                            iobj = (IObject)this.context.Pop();
                            this.context.LastReceiver = iobj;
                            this.context.Push(iobj[pos]);
                            break;

                        case ByteCode.InstAtPut:
                            object par = this.context.Pop();
                            pos = (int)this.context.Pop();
                            iobj = (IObject)this.context.Pop();
                            this.context.LastReceiver = iobj;
                            iobj[pos] = par;
                            break;
                        case ByteCode.BasicAt:
                            pos = (int)this.context.Pop();
                            IIndexedObject indexedObj = (IIndexedObject)this.context.Pop();
                            this.context.LastReceiver = indexedObj;
                            this.context.Push(indexedObj.GetIndexedValue(pos));
                            break;
                        case ByteCode.BasicAtPut:
                            par = this.context.Pop();
                            pos = (int)this.context.Pop();
                            indexedObj = (IIndexedObject)this.context.Pop();
                            this.context.LastReceiver = indexedObj;
                            indexedObj.SetIndexedValue(pos, par);
                            break;
                        case ByteCode.ChainedSend:
                            this.context.Pop();
                            this.context.Push(this.context.LastReceiver);
                            break;
                        case ByteCode.Send:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            mthname = (string)this.context.Block.GetConstant(arg);
                            this.context.InstructionPointer++;

                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.context.Pop();
                            }

                            object obj = this.context.Pop();
                            this.context.LastReceiver = obj;

                            object value;

                            if (obj == super)
                                //// TODO this.context.nativeSelf processing
                                value = ((IMethod)this.context.Block).Behavior.SuperClass.SendMessageToObject(this.context.Self, this.context.Machine, mthname, args);
                            //// TODO this.context.Machine is null in many tests, not in real world
                            else if (this.context.Machine == null)
                                value = ((IObject)obj).SendMessage(null, mthname, args);
                            else
                                value = this.context.Machine.SendMessage(obj, mthname, args, this);

                            if (value == this)
                                continue;

                            this.context.Push(value);

                            break;
                        case ByteCode.MakeCollection:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                                args[k] = this.context.Pop();

                            this.context.Push(new ArrayList(args));

                            break;
                        case ByteCode.NewDotNetObject:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];

                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                                args[k] = this.context.Pop();

                            obj = this.context.Pop();
                            this.context.LastReceiver = obj;

                            this.context.Push(DotNetObject.NewObject((Type)obj, args));

                            break;

                        case ByteCode.InvokeDotNetMethod:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            mthname = (string)this.context.Block.GetConstant(arg);
                            this.context.InstructionPointer++;

                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                                args[k] = this.context.Pop();

                            obj = this.context.Pop();
                            this.context.LastReceiver = obj;

                            Type type = obj as Type;

                            if (type != null)
                                this.context.Push(DotNetObject.SendNativeStaticMessage(type, mthname, args));
                            else
                                this.context.Push(DotNetObject.SendNativeMessage(this.context.Machine, obj, mthname, args));

                            break;

                        case ByteCode.SetLocal:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            value = this.context.Pop();
                            this.context.SetLocal(arg, value);
                            this.context.Push(value);
                            this.context.LastReceiver = null;
                            break;

                        case ByteCode.JumpIfFalse:
                            bool cond = (bool)this.context.Pop();
                            this.context.InstructionPointer++;
                            int jump = this.context.Block.Bytecodes[this.context.InstructionPointer];
                            this.context.InstructionPointer++;
                            jump = jump * 256 + this.context.Block.Bytecodes[this.context.InstructionPointer];
                            
                            if (!cond)
                            {
                                this.context.InstructionPointer = jump;
                                continue;
                            }

                            break;

                        case ByteCode.JumpIfTrue:
                            cond = (bool)this.context.Pop();
                            this.context.InstructionPointer++;
                            jump = this.context.Block.Bytecodes[this.context.InstructionPointer];
                            this.context.InstructionPointer++;
                            jump = jump * 256 + this.context.Block.Bytecodes[this.context.InstructionPointer];

                            if (cond)
                            {
                                this.context.InstructionPointer = jump;
                                continue;
                            }

                            break;

                        case ByteCode.Jump:
                            this.context.InstructionPointer++;
                            jump = this.context.Block.Bytecodes[this.context.InstructionPointer];
                            this.context.InstructionPointer++;
                            jump = jump * 256 + this.context.Block.Bytecodes[this.context.InstructionPointer];
                            this.context.InstructionPointer = jump;
                            continue;

                        case ByteCode.SetInstanceVariable:
                            this.context.InstructionPointer++;
                            arg = this.context.Block.ByteCodes[this.context.InstructionPointer];
                            value = this.context.Pop();
                            this.context.Self[arg] = value;
                            this.context.Push(value);
                            this.context.LastReceiver = this.context.Self;
                            break;
                        case ByteCode.RaiseException:
                            throw (Exception)this.context.Pop();
                        default:
                            throw new Exception("Not implemented");
                    }

                    this.context.InstructionPointer++;
                }

            return this.GetReturnValue();
        }

        public void PushContext(ExecutionContext newcontext)
        {
            newcontext.Sender = this.context;
            this.context = newcontext;
        }

        public void PopContext(object retvalue)
        {
            this.context = this.context.Sender;
            this.context.Push(retvalue);
        }

        public void ReturnToContext(ExecutionContext retcontext, object retvalue)
        {
            this.context = retcontext;
            this.context.Push(retvalue);
        }

        private static void DoGetConstant(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            context.Push(context.Block.GetConstant(arg));
        }

        private static void DoGetBlock(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];

            Block newblock = (Block)context.Block.GetConstant(arg);

            newblock = newblock.Clone(context);

            context.Push(newblock);
        }

        private static void DoGetArgument(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            context.Push(context.GetArgument(arg));
        }

        private static void DoSetArgument(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            var value = context.Pop();
            context.SetArgument(arg, value);
            context.LastReceiver = null;
        }

        private static void DoGetClass(ExecutionContext context)
        {
            object value = context.Pop();
            context.LastReceiver = value;

            if (value == null)
            {
                context.Push(context.Machine.UndefinedObjectClass);
                return;
            }

            IObject iobj = value as IObject;

            if (iobj != null)
            {
                context.Push(iobj.Behavior);
                return;
            }

            var behavior = context.Machine.GetNativeBehavior(value.GetType());

            if (behavior != null)
            {
                context.Push(behavior);
                return;
            }

            context.Push(value.GetType());
        }

        private static void DoBasicSize(ExecutionContext context)
        {
            IIndexedObject indexedObj = (IIndexedObject)context.Pop();
            context.LastReceiver = indexedObj;
            context.Push(indexedObj.BasicSize);
        }

        private static void DoGetGlobalVariable(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            string name = context.Block.GetGlobalName(arg);
            object value;

            if (context.Self != null)
                value = context.Self.Behavior.Scope.GetValue(name);
            else
                value = context.Machine.CurrentEnvironment.GetValue(name);

            context.Push(value);
        }

        private static void DoSetGlobalVariable(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            string name = context.Block.GetGlobalName(arg);
            object value = context.Pop();

            if (context.Self != null)
                context.Self.Behavior.Scope.SetValue(name, value);
            else
                context.Machine.CurrentEnvironment.SetValue(name, value);

            context.LastReceiver = value;
            context.Push(value);
        }

        private static void DoGetDotNetType(ExecutionContext context)
        {
            context.InstructionPointer++;
            byte arg = context.Block.ByteCodes[context.InstructionPointer];
            context.Push(TypeUtilities.AsType(context.Block.GetGlobalName(arg)));
        }

        private object GetReturnValue()
        {
            if (this.context.HasReturnValue)
            {
                // TODO Review, only needed for some tests
                if (this.context.Block.Closure != null)
                {
                    this.context.Block.Closure.HasReturnValue = true;
                    this.context.Block.Closure.ReturnValue = this.context.ReturnValue;
                }

                return this.context.ReturnValue;
            }

            if (this.context.Block.IsMethod)
                return this.context.Self;

            if (this.context.Stack.Count == 0)
                return null;

            return this.context.Pop();
        }
    }
}
