using System;
using System.Collections;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Method.
	/// </summary>
	public class Method : IMethod
	{
		private string name;
		private IClass mthclass;
		private byte [] bytecodes;
		private short nextbytecode;
		private IList constants = new ArrayList(5);
		private IList argnames = new ArrayList(5);
		private IList localnames = new ArrayList(5);

		public Method(IClass cls, string name)
		{
			mthclass = cls;
			this.name = name;
		}

		public int Arity
		{
			get 
			{
				return argnames.Count;
			}
		}

		public int NoLocals
		{
			get 
			{
				if (localnames==null)
					return 0;

				return localnames.Count;
			}
		}

        public IClass Class
        {
            get { return mthclass; }
        }

		public void CompileArgument(string argname) 
		{
			if (argnames.Contains(argname))
				throw new Exception("Repeated Argument: " + argname);
			argnames.Add(argname);
		}

		public void CompileLocal(string localname)
		{
			if (localnames.Contains(localname))
				throw new Exception("Repeated Local: " + localname);
			localnames.Add(localname);
		}

		public byte CompileConstant(object obj)
		{
			int p = constants.IndexOf(obj);

			if (p>=0)
				return (byte) p;

			constants.Add(obj);

			return (byte) (constants.Count-1);
		}

		public void CompileGetConstant(object obj) 
		{
			CompileByteCode(ByteCode.GetConstant,CompileConstant(obj));
		}

		private void CompileByte(byte b)
		{
			if (bytecodes==null) 
			{
				bytecodes = new byte [] { b };
				nextbytecode = 1;
				return;
			}

			if (nextbytecode >= bytecodes.Length) 
			{
				byte [] aux = new byte[bytecodes.Length+10];
				Array.Copy(bytecodes,aux,bytecodes.Length);
				bytecodes=aux;
			}

			bytecodes[nextbytecode++] = b;
		}

		public void CompileByteCode(ByteCode b)
		{
			CompileByte((byte) b);
		}

		public void CompileByteCode(ByteCode b, byte arg) 
		{
			CompileByteCode(b);
			CompileByte(arg);
		}

		public void CompileByteCode(ByteCode b, byte arg1, byte arg2) 
		{
			CompileByteCode(b);
			CompileByte(arg1);
			CompileByte(arg2);
		}

		private byte MessageArity(string msgname) 
		{
			if (!Char.IsLetter(msgname[0]))
				return 2;

			int p = msgname.IndexOf(':');

			if (p<0)
				return 1;

			byte n=0;

			foreach (char ch in msgname)
				if (ch==':')
					n++;

			return n;
		}

		public void CompileSend(string msgname) 
		{
			CompileByteCode(ByteCode.Send,CompileConstant(msgname),MessageArity(msgname));
		}

		public void CompileGet(string name) 
		{
			if (name=="self") 
			{
				CompileByteCode(ByteCode.GetSelf);
				return;
			}

			int p;

			if (localnames!=null) 
			{
				p = localnames.IndexOf(name);

				if (p>=0) 
				{
					CompileByteCode(ByteCode.GetLocal,(byte) p);
					return;
				}
			}

			if (argnames!=null) 
			{
				p = argnames.IndexOf(name);

				if (p>=0) 
				{
					CompileByteCode(ByteCode.GetArgument,(byte) p);
					return;
				}
			}

			p = mthclass.GetInstanceVariableOffset(name);

			if (p>=0) 
			{
				CompileByteCode(ByteCode.GetVariable,(byte) p);
				return;
			}

			p = mthclass.GetClassVariableOffset(name);

			if (p>=0) 
			{
				CompileByteCode(ByteCode.GetClassVariable,(byte) p);
				return;
			}

			throw new Exception("Unknown '" + name + "'");
		}

		public void CompileSet(string name) 
		{
			int p;

			if (localnames!=null) 
			{
				p = localnames.IndexOf(name);

				if (p>=0) 
				{
					CompileByteCode(ByteCode.SetLocal,(byte) p);
					return;
				}
			}

			if (argnames!=null) 
			{
				p = argnames.IndexOf(name);

				if (p>=0) 
				{
					CompileByteCode(ByteCode.SetArgument,(byte) p);
					return;
				}
			}

			p = mthclass.GetInstanceVariableOffset(name);

			if (p>=0) 
			{
				CompileByteCode(ByteCode.SetVariable,(byte) p);
				return;
			}

			p = mthclass.Class.GetInstanceVariableOffset(name);

			if (p>=0) 
			{
				CompileByteCode(ByteCode.SetClassVariable,(byte) p);
				return;
			}

			throw new CompilerException("Unknown '" + name + "'");
		}

		public byte [] ByteCodes 
		{
			get 
			{
				return bytecodes;
			}
		}

		public object GetConstant(int nc) 
		{
			return constants[nc];
		}

		#region IMethod Members

		public string Name
		{
			get
			{
				return name;
			}
		}

		public object Execute(IObject self, IObject receiver, object[] args)
		{
			return (new ExecutionBlock(self,receiver,this,args)).Execute();
		}

        // TODO how to implements super, sender

		public object Execute(IObject receiver, object[] args)
		{
			return (new ExecutionBlock(receiver,receiver,this,args)).Execute();
		}

		#endregion
	}
}
