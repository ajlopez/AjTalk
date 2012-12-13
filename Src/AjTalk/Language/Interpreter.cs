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

        public Interpreter(ExecutionContext context)
        {
            this.context = context;
        }

        public object Execute()
        {
            this.context.ip = 0;
            string mthname;
            object[] args;

            // TODO refactor lastreceiver process
            // TODO refactor switch
            if (this.context.block.Bytecodes != null)
                while (this.context.hasreturnvalue == false && this.context.ip < this.context.block.ByteCodes.Length)
                {
                    ByteCode bc = (ByteCode)this.context.block.ByteCodes[this.context.ip];
                    byte arg;

                    if (codes[(int)bc] != null)
                    {
                        codes[(int)bc](this.context);
                        this.context.ip++;
                        continue;
                    }

                    switch (bc)
                    {
                        case ByteCode.ReturnSub:
                            this.context.hasreturnvalue = true;
                            this.context.returnvalue = null;
                            break;
                        case ByteCode.ReturnPop:
                            this.context.hasreturnvalue = true;
                            this.context.returnvalue = this.context.Pop();
                            break;
                        case ByteCode.GetLocal:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            this.context.Push(this.context.GetLocal(arg));
                            break;
                        case ByteCode.GetSuper:
                            this.context.Push(super);
                            break;
                        case ByteCode.GetSelf:
                            if (this.context.nativeSelf != null)
                                this.context.Push(this.context.nativeSelf);
                            else
                                this.context.Push(this.context.self);
                            break;
                        case ByteCode.GetSuperClass:
                            this.context.Push(this.context.self.Behavior.SuperClass);
                            break;
                        case ByteCode.GetNil:
                            this.context.Push(null);
                            break;
                        case ByteCode.GetInstanceVariable:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            this.context.Push(this.context.self[arg]);
                            break;
                        case ByteCode.NewObject:
                            IBehavior ibeh = (IBehavior)this.context.Pop();
                            this.context.lastreceiver = ibeh;
                            this.context.Push(ibeh.NewObject());
                            break;
                        case ByteCode.Nop:
                            break;
                        case ByteCode.Pop:
                            this.context.Pop();
                            break;
                        case ByteCode.InstSize:
                            IObject iobj = (IObject)this.context.Pop();
                            this.context.lastreceiver = iobj;
                            this.context.Push(iobj.Behavior.NoInstanceVariables);
                            break;
                        case ByteCode.InstAt:
                            int pos = (int)this.context.Pop();
                            iobj = (IObject)this.context.Pop();
                            this.context.lastreceiver = iobj;
                            this.context.Push(iobj[pos]);
                            break;
                        case ByteCode.InstAtPut:
                            object par = this.context.Pop();
                            pos = (int)this.context.Pop();
                            iobj = (IObject)this.context.Pop();
                            this.context.lastreceiver = iobj;
                            iobj[pos] = par;
                            break;
                        case ByteCode.BasicAt:
                            pos = (int)this.context.Pop();
                            IIndexedObject indexedObj = (IIndexedObject)this.context.Pop();
                            this.context.lastreceiver = indexedObj;
                            this.context.Push(indexedObj.GetIndexedValue(pos));
                            break;
                        case ByteCode.BasicAtPut:
                            par = this.context.Pop();
                            pos = (int)this.context.Pop();
                            indexedObj = (IIndexedObject)this.context.Pop();
                            this.context.lastreceiver = indexedObj;
                            indexedObj.SetIndexedValue(pos, par);
                            break;
                        case ByteCode.ChainedSend:
                            this.context.Pop();
                            this.context.Push(this.context.lastreceiver);
                            break;
                        case ByteCode.Send:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            mthname = (string)this.context.block.GetConstant(arg);
                            this.context.ip++;

                            arg = this.context.block.ByteCodes[this.context.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.context.Pop();
                            }

                            object obj = this.context.Pop();
                            this.context.lastreceiver = obj;

                            if (obj == super)
                                //// TODO this.context.nativeSelf processing
                                this.context.Push(((IMethod)this.context.block).Behavior.SuperClass.SendMessageToObject(this.context.self, this.context.machine, mthname, args));
                            //// TODO this.context.machine is null in many tests, not in real world
                            else if (this.context.machine == null)
                                this.context.Push(((IObject)obj).SendMessage(null, mthname, args));
                            else
                                this.context.Push(this.context.machine.SendMessage(obj, mthname, args));

                            break;
                        case ByteCode.MakeCollection:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.context.Pop();
                            }

                            this.context.Push(new ArrayList(args));

                            break;
                        case ByteCode.NewDotNetObject:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];

                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.context.Pop();
                            }

                            obj = this.context.Pop();
                            this.context.lastreceiver = obj;

                            this.context.Push(DotNetObject.NewObject((Type)obj, args));

                            break;
                        case ByteCode.InvokeDotNetMethod:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            mthname = (string)this.context.block.GetConstant(arg);
                            this.context.ip++;

                            arg = this.context.block.ByteCodes[this.context.ip];
                            args = new object[arg];

                            for (int k = arg - 1; k >= 0; k--)
                            {
                                args[k] = this.context.Pop();
                            }

                            obj = this.context.Pop();
                            this.context.lastreceiver = obj;

                            Type type = obj as Type;

                            if (type != null)
                                this.context.Push(DotNetObject.SendNativeStaticMessage(type, mthname, args));
                            else
                                this.context.Push(DotNetObject.SendNativeMessage(this.context.machine, obj, mthname, args));

                            break;

                        case ByteCode.SetLocal:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            var value = this.context.Pop();
                            this.context.SetLocal(arg, value);
                            this.context.Push(value);
                            this.context.lastreceiver = null;
                            break;
                        case ByteCode.SetInstanceVariable:
                            this.context.ip++;
                            arg = this.context.block.ByteCodes[this.context.ip];
                            value = this.context.Pop();
                            this.context.self[arg] = value;
                            this.context.Push(value);
                            this.context.lastreceiver = this.context.self;
                            break;
                        case ByteCode.RaiseException:
                            throw (Exception)this.context.Pop();
                        default:
                            throw new Exception("Not implemented");
                    }

                    this.context.ip++;
                }

            if (this.context.hasreturnvalue)
            {
                if (this.context.block.Closure != null)
                {
                    this.context.block.Closure.hasreturnvalue = true;
                    this.context.block.Closure.returnvalue = this.context.returnvalue;
                }

                return this.context.returnvalue;
            }

            if (this.context.block.IsMethod)
                return this.context.self;

            if (this.context.stack.Count == 0)
                return null;

            return this.context.Pop();
        }

        private static void DoGetConstant(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            context.Push(context.block.GetConstant(arg));
        }

        private static void DoGetBlock(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];

            Block newblock = (Block)context.block.GetConstant(arg);

            newblock = newblock.Clone(context);

            context.Push(newblock);
        }

        private static void DoValue(ExecutionContext context)
        {
            Block newblock = (Block)context.Pop();

            context.lastreceiver = newblock;

            context.Push(new ExecutionContext(context.machine, context.Receiver, newblock, null).Execute());
        }

        private static void DoMultiValue(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];

            object[] args = new object[arg];

            for (int k = arg - 1; k >= 0; k--)
                args[k] = context.Pop();

            Block newblock = (Block)context.Pop();
            context.lastreceiver = newblock;

            context.Push(new ExecutionContext(context.machine, context.Receiver, newblock, args).Execute());
        }

        private static void DoGetArgument(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            context.Push(context.GetArgument(arg));
        }

        private static void DoSetArgument(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            var value = context.Pop();
            context.SetArgument(arg, value);
            context.lastreceiver = null;
        }

        private static void DoGetClass(ExecutionContext context)
        {
            object value = context.Pop();
            context.lastreceiver = value;

            if (value == null)
            {
                context.Push(context.machine.UndefinedObjectClass);
                return;
            }

            IObject iobj = value as IObject;

            if (iobj != null)
            {
                context.Push(iobj.Behavior);
                return;
            }

            var behavior = context.machine.GetNativeBehavior(value.GetType());

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
            context.lastreceiver = indexedObj;
            context.Push(indexedObj.BasicSize);
        }

        private static void DoGetGlobalVariable(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            string name = context.block.GetGlobalName(arg);
            object value;

            if (context.self != null)
                value = context.self.Behavior.Scope.GetValue(name);
            else
                value = context.machine.CurrentEnvironment.GetValue(name);

            context.Push(value);
        }

        private static void DoSetGlobalVariable(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            string name = context.block.GetGlobalName(arg);
            object value = context.Pop();

            if (context.self != null)
                context.self.Behavior.Scope.SetValue(name, value);
            else
                context.machine.CurrentEnvironment.SetValue(name, value);

            context.lastreceiver = value;
            context.Push(value);
        }

        private static void DoGetDotNetType(ExecutionContext context)
        {
            context.ip++;
            byte arg = context.block.ByteCodes[context.ip];
            context.Push(TypeUtilities.AsType(context.block.GetGlobalName(arg)));
        }
    }
}
