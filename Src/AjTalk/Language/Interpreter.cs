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
        private static Action<ExecutionBlock>[] codes;

        private ExecutionBlock execblock;

        static Interpreter()
        {
            codes = new Action<ExecutionBlock>[256];
            codes[(int)ByteCode.GetConstant] = DoGetConstant;
            codes[(int)ByteCode.GetBlock] = DoGetBlock;
            codes[(int)ByteCode.Value] = DoValue;
            codes[(int)ByteCode.MultiValue] = DoMultiValue;
            codes[(int)ByteCode.GetArgument] = DoGetArgument;
            codes[(int)ByteCode.SetArgument] = DoSetArgument;
            codes[(int)ByteCode.GetClass] = DoGetClass;
            codes[(int)ByteCode.BasicSize] = DoBasicSize;
            codes[(int)ByteCode.GetGlobalVariable] = DoGetGlobalVariable;
            codes[(int)ByteCode.SetGlobalVariable] = DoSetGlobalVariable;
            codes[(int)ByteCode.GetDotNetType] = DoGetDotNetType;
        }

        public Interpreter(ExecutionBlock execblock)
        {
            this.execblock = execblock;
        }

        public object Execute()
        {
            this.execblock.ip = 0;
            string mthname;
            object[] args;

            // TODO refactor lastreceiver process
            // TODO refactor switch
            if (this.execblock.block.Bytecodes != null)
                while (this.execblock.hasreturnvalue == false && this.execblock.ip < this.execblock.block.ByteCodes.Length)
                {
                    ByteCode bc = (ByteCode)this.execblock.block.ByteCodes[this.execblock.ip];
                    byte arg;

                    if (codes[(int)bc] != null)
                    {
                        codes[(int)bc](this.execblock);
                        this.execblock.ip++;
                        continue;
                    }

                    switch (bc)
                    {
                        case ByteCode.ReturnSub:
                            this.execblock.hasreturnvalue = true;
                            this.execblock.returnvalue = null;
                            break;
                        case ByteCode.ReturnPop:
                            this.execblock.hasreturnvalue = true;
                            this.execblock.returnvalue = this.execblock.Pop();
                            break;
                        case ByteCode.GetLocal:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            this.execblock.Push(this.execblock.GetLocal(arg));
                            break;
                        case ByteCode.GetSuper:
                            this.execblock.Push(super);
                            break;
                        case ByteCode.GetSelf:
                            if (this.execblock.nativeSelf != null)
                                this.execblock.Push(this.execblock.nativeSelf);
                            else
                                this.execblock.Push(this.execblock.self);
                            break;
                        case ByteCode.GetSuperClass:
                            this.execblock.Push(this.execblock.self.Behavior.SuperClass);
                            break;
                        case ByteCode.GetNil:
                            this.execblock.Push(null);
                            break;
                        case ByteCode.GetInstanceVariable:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            this.execblock.Push(this.execblock.self[arg]);
                            break;
                        case ByteCode.NewObject:
                            IBehavior ibeh = (IBehavior)this.execblock.Pop();
                            this.execblock.lastreceiver = ibeh;
                            this.execblock.Push(ibeh.NewObject());
                            break;
                        case ByteCode.Nop:
                            break;
                        case ByteCode.Pop:
                            this.execblock.Pop();
                            break;
                        case ByteCode.InstSize:
                            IObject iobj = (IObject)this.execblock.Pop();
                            this.execblock.lastreceiver = iobj;
                            this.execblock.Push(iobj.Behavior.NoInstanceVariables);
                            break;
                        case ByteCode.InstAt:
                            int pos = (int)this.execblock.Pop();
                            iobj = (IObject)this.execblock.Pop();
                            this.execblock.lastreceiver = iobj;
                            this.execblock.Push(iobj[pos]);
                            break;
                        case ByteCode.InstAtPut:
                            object par = this.execblock.Pop();
                            pos = (int)this.execblock.Pop();
                            iobj = (IObject)this.execblock.Pop();
                            this.execblock.lastreceiver = iobj;
                            iobj[pos] = par;
                            break;
                        case ByteCode.BasicAt:
                            pos = (int)this.execblock.Pop();
                            IIndexedObject indexedObj = (IIndexedObject)this.execblock.Pop();
                            this.execblock.lastreceiver = indexedObj;
                            this.execblock.Push(indexedObj.GetIndexedValue(pos));
                            break;
                        case ByteCode.BasicAtPut:
                            par = this.execblock.Pop();
                            pos = (int)this.execblock.Pop();
                            indexedObj = (IIndexedObject)this.execblock.Pop();
                            this.execblock.lastreceiver = indexedObj;
                            indexedObj.SetIndexedValue(pos, par);
                            break;
                        case ByteCode.ChainedSend:
                            this.execblock.Pop();
                            this.execblock.Push(this.execblock.lastreceiver);
                            break;
                        case ByteCode.Send:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            mthname = (string)this.execblock.block.GetConstant(arg);
                            this.execblock.ip++;

                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.execblock.Pop();
                            }

                            object obj = this.execblock.Pop();
                            this.execblock.lastreceiver = obj;

                            if (obj == super)
                                //// TODO this.execblock.nativeSelf processing
                                this.execblock.Push(((IMethod)this.execblock.block).Behavior.SuperClass.SendMessageToObject(this.execblock.self, this.execblock.machine, mthname, args));
                            //// TODO this.execblock.machine is null in many tests, not in real world
                            else if (this.execblock.machine == null)
                                this.execblock.Push(((IObject)obj).SendMessage(null, mthname, args));
                            else
                                this.execblock.Push(this.execblock.machine.SendMessage(obj, mthname, args));

                            break;
                        case ByteCode.MakeCollection:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.execblock.Pop();
                            }

                            this.execblock.Push(new ArrayList(args));

                            break;
                        case ByteCode.NewDotNetObject:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];

                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.execblock.Pop();
                            }

                            obj = this.execblock.Pop();
                            this.execblock.lastreceiver = obj;

                            this.execblock.Push(DotNetObject.NewObject((Type)obj, args));

                            break;
                        case ByteCode.InvokeDotNetMethod:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            mthname = (string)this.execblock.block.GetConstant(arg);
                            this.execblock.ip++;

                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.execblock.Pop();
                            }

                            obj = this.execblock.Pop();
                            this.execblock.lastreceiver = obj;

                            Type type = obj as Type;

                            if (type != null)
                                this.execblock.Push(DotNetObject.SendNativeStaticMessage(type, mthname, args));
                            else
                                this.execblock.Push(DotNetObject.SendNativeMessage(this.execblock.machine, obj, mthname, args));

                            break;

                        case ByteCode.SetLocal:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            var value = this.execblock.Pop();
                            this.execblock.SetLocal(arg, value);
                            this.execblock.Push(value);
                            this.execblock.lastreceiver = null;
                            break;
                        case ByteCode.SetInstanceVariable:
                            this.execblock.ip++;
                            arg = this.execblock.block.ByteCodes[this.execblock.ip];
                            value = this.execblock.Pop();
                            this.execblock.self[arg] = value;
                            this.execblock.Push(value);
                            this.execblock.lastreceiver = this.execblock.self;
                            break;
                        case ByteCode.RaiseException:
                            throw (Exception)this.execblock.Pop();
                        default:
                            throw new Exception("Not implemented");
                    }

                    this.execblock.ip++;
                }

            if (this.execblock.hasreturnvalue)
            {
                if (this.execblock.block.Closure != null)
                {
                    this.execblock.block.Closure.hasreturnvalue = true;
                    this.execblock.block.Closure.returnvalue = this.execblock.returnvalue;
                }

                return this.execblock.returnvalue;
            }

            if (this.execblock.block.IsMethod)
                return this.execblock.self;

            if (this.execblock.stack.Count == 0)
                return null;

            return this.execblock.Pop();
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

            newblock = newblock.Clone(execblock);

            execblock.Push(newblock);
        }

        private static void DoValue(ExecutionBlock execblock)
        {
            Block newblock = (Block)execblock.Pop();

            execblock.lastreceiver = newblock;

            execblock.Push(new ExecutionBlock(execblock.machine, execblock.Receiver, newblock, null).Execute());
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

            execblock.Push(new ExecutionBlock(execblock.machine, execblock.Receiver, newblock, args).Execute());
        }

        private static void DoGetArgument(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(execblock.GetArgument(arg));
        }

        private static void DoSetArgument(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            var value = execblock.Pop();
            execblock.SetArgument(arg, value);
            execblock.lastreceiver = null;
        }

        private static void DoGetClass(ExecutionBlock execblock)
        {
            object value = execblock.Pop();
            execblock.lastreceiver = value;

            if (value == null)
            {
                execblock.Push(execblock.machine.UndefinedObjectClass);
                return;
            }

            IObject iobj = value as IObject;

            if (iobj != null)
            {
                execblock.Push(iobj.Behavior);
                return;
            }

            var behavior = execblock.machine.GetNativeBehavior(value.GetType());

            if (behavior != null)
            {
                execblock.Push(behavior);
                return;
            }

            execblock.Push(value.GetType());
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
            execblock.Push(value);
        }

        private static void DoGetDotNetType(ExecutionBlock execblock)
        {
            execblock.ip++;
            byte arg = execblock.block.ByteCodes[execblock.ip];
            execblock.Push(TypeUtilities.AsType(execblock.block.GetGlobalName(arg)));
        }
    }
}
