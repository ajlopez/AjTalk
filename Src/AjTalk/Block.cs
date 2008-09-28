using System;
using System.Collections.Generic;
using System.Text;

namespace AjTalk
{
    public class Block : IBlock
    {
        private byte[] bytecodes;
        private short nextbytecode;
        private List<object> constants = new List<object>();
        private List<string> argnames = new List<string>();
        private List<string> localnames = new List<string>();
        private List<string> globalnames = new List<string>();

        public int Arity
        {
            get
            {
                return this.argnames.Count;
            }
        }

        public int NoLocals
        {
            get
            {
                if (this.localnames == null)
                    return 0;

                return this.localnames.Count;
            }
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

            if (p >= 0)
                return (byte)p;

            constants.Add(obj);

            return (byte)(constants.Count - 1);
        }

        public byte CompileGlobal(string globalname)
        {
            int p = globalnames.IndexOf(globalname);

            if (p >= 0)
                return (byte)p;

            globalnames.Add(globalname);

            return (byte)(globalnames.Count - 1);
        }

        public void CompileGetConstant(object obj)
        {
            CompileByteCode(ByteCode.GetConstant, CompileConstant(obj));
        }

        private void CompileByte(byte b)
        {
            if (bytecodes == null)
            {
                bytecodes = new byte[] { b };
                nextbytecode = 1;
                return;
            }

            if (nextbytecode >= bytecodes.Length)
            {
                byte[] aux = new byte[bytecodes.Length + 10];
                Array.Copy(bytecodes, aux, bytecodes.Length);
                bytecodes = aux;
            }

            bytecodes[nextbytecode++] = b;
        }

        public void CompileByteCode(ByteCode b)
        {
            CompileByte((byte)b);
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

            if (p < 0)
                return 1;

            byte n = 0;

            foreach (char ch in msgname)
                if (ch == ':')
                    n++;

            return n;
        }

        public void CompileSend(string msgname)
        {
            CompileByteCode(ByteCode.Send, CompileConstant(msgname), MessageArity(msgname));
        }

        // TODO how to implements super, sender
        public virtual object Execute(Machine machine, object[] args)
        {
            return (new ExecutionBlock(machine, null, this, args)).Execute();
        }

        protected bool TryCompileGet(string name)
        {
            if (name == "self")
            {
                CompileByteCode(ByteCode.GetSelf);
                return true;
            }

            int p;

            if (localnames != null)
            {
                p = localnames.IndexOf(name);

                if (p >= 0)
                {
                    CompileByteCode(ByteCode.GetLocal, (byte)p);
                    return true;
                }
            }

            if (argnames != null)
            {
                p = argnames.IndexOf(name);

                if (p >= 0)
                {
                    CompileByteCode(ByteCode.GetArgument, (byte)p);
                    return true;
                }
            }

            return false;
        }

        public virtual void CompileGet(string name)
        {
            if (TryCompileGet(name))
                return;

            CompileByteCode(ByteCode.GetGlobalVariable, this.CompileGlobal(name));
        }

        protected bool TryCompileSet(string name)
        {
            int p;

            if (localnames != null)
            {
                p = localnames.IndexOf(name);

                if (p >= 0)
                {
                    CompileByteCode(ByteCode.SetLocal, (byte)p);
                    return true;
                }
            }

            if (argnames != null)
            {
                p = argnames.IndexOf(name);

                if (p >= 0)
                {
                    CompileByteCode(ByteCode.SetArgument, (byte)p);
                    return true;
                }
            }

            return false;
        }

        public virtual void CompileSet(string name)
        {
            if (TryCompileSet(name))
                return;

            CompileByteCode(ByteCode.SetGlobalVariable, CompileGlobal(name));
        }

        public byte[] ByteCodes
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

        public string GetGlobalName(int ng)
        {
            return globalnames[ng];
        }
    }
}
