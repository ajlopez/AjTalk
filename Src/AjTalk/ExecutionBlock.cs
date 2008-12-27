using System;
using System.Collections;

namespace AjTalk
{
	public class ExecutionBlock
	{
		private Block block;
        private Machine machine;
		private IObject self;
		private IObject receiver;
		private object [] arguments;
		private object [] locals;

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
                this.locals = new object[this.block.NoLocals];
            else
                this.locals = null;
        }

		public ExecutionBlock(IObject self, IObject receiver, Block block, object [] arguments) 
		{
			this.self = self;
            this.machine = self.Class.Machine;
			this.receiver = receiver;
			this.block = block;
			this.arguments = arguments;
			this.stack = new ArrayList(5);
			if (this.block.NoLocals>0)
				this.locals = new object[this.block.NoLocals];
			else
				this.locals = null;
		}

		private object Top 
		{
			get 
			{
				return stack[stack.Count-1];
			}
		}

		private void Push(object obj) 
		{
			stack.Add(obj);
		}

		private object Pop() 
		{
			object obj = stack[stack.Count-1];
			stack.RemoveAt(stack.Count-1);
			return obj;
		}

		public object Execute() 
		{
			ip = 0;

			while (ip < block.ByteCodes.Length) 
			{
				ByteCode bc = (ByteCode) block.ByteCodes[ip];
				Byte arg;

				switch (bc) 
				{
					case ByteCode.ReturnSub:
						return null;
					case ByteCode.ReturnPop:
						return Top;
					case ByteCode.GetConstant:
						ip++;
						arg = block.ByteCodes[ip];
						Push(block.GetConstant(arg));
						break;
                    case ByteCode.GetBlock:
						ip++;
						arg = block.ByteCodes[ip];
						
                        Block newblock = (Block) block.GetConstant(arg);

                        if (this.self == null)
                        {
                            Push(new ExecutionBlock(this.machine, this.receiver, newblock, this.arguments));
                        }
                        else
                        {
                            Push(new ExecutionBlock(this.self, this.receiver, newblock, this.arguments));
                        }

                        break;
					case ByteCode.GetArgument:
						ip++;
						arg = block.ByteCodes[ip];
						Push(arguments[arg]);
						break;
					case ByteCode.GetClass:
						Push(receiver.Class);
						break;
					case ByteCode.GetClassVariable:
						throw new Exception("Not implemented");
                    case ByteCode.GetGlobalVariable:
						ip++;
						arg = block.ByteCodes[ip];
                        Push(machine.GetGlobalObject(block.GetGlobalName(arg)));
                        break;
                    case ByteCode.GetLocal:
						ip++;
						arg = block.ByteCodes[ip];
						Push(locals[arg]);
						break;
					case ByteCode.GetSelf:
						Push(self);
						break;
					case ByteCode.GetSuperClass:
						Push(receiver.Class.SuperClass);
						break;
					case ByteCode.GetVariable:
						ip++;
						arg = block.ByteCodes[ip];
						Push(receiver[arg]);
						break;
					case ByteCode.NewObject:
						Push(((IClass) receiver).NewObject());
						break;
					case ByteCode.Add:
						int y = (int) Pop();
						int x = (int) Pop();
						Push(x+y);
						break;
					case ByteCode.Substract:
						y = (int) Pop();
						x = (int) Pop();
						Push(x-y);
						break;
					case ByteCode.Multiply:
						y = (int) Pop();
						x = (int) Pop();
						Push(x*y);
						break;
					case ByteCode.Divide:
						y = (int) Pop();
						x = (int) Pop();
						Push(x/y);
						break;
					case ByteCode.Nop:
						break;
					case ByteCode.Pop:
						Pop();
						break;
                    case ByteCode.InstSize:
                        IObject iobj = (IObject) Pop();
                        Push(iobj.Class.NoInstanceVariables);
                        break;
                    case ByteCode.InstAt:
                        int pos = (int) Pop();
                        iobj = (IObject) Pop();
                        Push(iobj[pos]);
                        break;
                    case ByteCode.InstAtPut:
                        object par = Pop();
                        pos = (int) Pop();
                        iobj = (IObject)Pop();
                        iobj[pos] = par;
                        break;
                    case ByteCode.Send:
						ip++;
						arg = block.ByteCodes[ip];
						string mthname;
						mthname = (string) block.GetConstant(arg);
						ip++;

						arg = block.ByteCodes[ip];
						object [] args = new object[arg];

						for (int k = arg-1; k>=0; k--)
							args[k] = Pop();

                        object obj = Pop();

						iobj = obj as IObject;

                        if (iobj != null)
                            Push(iobj.SendMessage(mthname, args));
                        else
                            Push(DotNetObject.SendMessage(obj, mthname, args));

						break;
					case ByteCode.SetArgument:				
						ip++;
						arg = block.ByteCodes[ip];
						arguments[arg] = Pop();
						break;
					case ByteCode.SetClassVariable:
						throw new Exception("Not implemented");
					case ByteCode.SetLocal:
						ip++;
						arg = block.ByteCodes[ip];
						locals[arg] = Pop();
						break;
                    case ByteCode.SetVariable:
						ip++;
						arg = block.ByteCodes[ip];
						receiver[arg] = Pop();
						break;
                    case ByteCode.SetGlobalVariable:
                        ip++;
                        arg = block.ByteCodes[ip];
                        machine.SetGlobalObject(block.GetGlobalName(arg), Pop());
                        break;
                    default:
						throw new Exception("Not implemented");
				}

				ip++;
			}

			return this.self;
		}
	}
}
