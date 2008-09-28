using System;
using System.Collections;

namespace AjTalk
{
	public class ExecutionBlock
	{
		private Method method;
		private IObject self;
		private IObject receiver;
		private object [] arguments;
		private object [] locals;

		private int ip;
		private IList stack;

		public ExecutionBlock(IObject self, IObject receiver, Method method, object [] arguments) 
		{
			this.self = self;
			this.receiver = receiver;
			this.method = method;
			this.arguments = arguments;
			this.stack = new ArrayList(5);
			if (method.NoLocals>0)
				this.locals = new object[method.NoLocals];
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

			while (ip < method.ByteCodes.Length) 
			{
				ByteCode bc = (ByteCode) method.ByteCodes[ip];
				Byte arg;

				switch (bc) 
				{
					case ByteCode.ReturnSub:
						return null;
					case ByteCode.ReturnPop:
						return Top;
					case ByteCode.GetConstant:
						ip++;
						arg = method.ByteCodes[ip];
						Push(method.GetConstant(arg));
						break;
					case ByteCode.GetArgument:
						ip++;
						arg = method.ByteCodes[ip];
						Push(arguments[arg]);
						break;
					case ByteCode.GetClass:
						Push(receiver.Class);
						break;
					case ByteCode.GetClassVariable:
						throw new Exception("Not implemented");
                    case ByteCode.GetGlobalVariable:
						ip++;
						arg = method.ByteCodes[ip];
                        ((IObject)receiver).Class.Machine.GetGlobalObject(method.GetGlobalName(arg));
                        break;
                    case ByteCode.GetLocal:
						ip++;
						arg = method.ByteCodes[ip];
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
						arg = method.ByteCodes[ip];
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
					case ByteCode.Send:
						ip++;
						arg = method.ByteCodes[ip];
						string mthname;
						mthname = (string) method.GetConstant(arg);
						ip++;
						arg = method.ByteCodes[ip];
						object [] args = new object[arg];
						for (int k = arg-1; k>=0; k--)
							args[k] = Pop();
						IObject obj = (IObject) Pop();
						Push(obj.SendMessage(mthname,args));
						break;
					case ByteCode.SetArgument:				
						ip++;
						arg = method.ByteCodes[ip];
						arguments[arg] = Pop();
						break;
					case ByteCode.SetClassVariable:
						throw new Exception("Not implemented");
					case ByteCode.SetLocal:
						ip++;
						arg = method.ByteCodes[ip];
						locals[arg] = Pop();
						break;
                    case ByteCode.SetVariable:
						ip++;
						arg = method.ByteCodes[ip];
						receiver[arg] = Pop();
						break;
                    case ByteCode.SetGlobalVariable:
                        ip++;
                        arg = method.ByteCodes[ip];
                        ((IObject)receiver).Class.Machine.SetGlobalObject(method.GetGlobalName(arg), Pop());
                        break;
                    default:
						throw new Exception("Not implemented");
				}

				ip++;
			}

			return null;
		}
	}
}
