namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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

        public byte[] ByteCodes
        {
            get
            {
                return this.bytecodes;
            }
        }

        public int NoLocals
        {
            get
            {
                if (this.localnames == null)
                {
                    return 0;
                }

                return this.localnames.Count;
            }
        }

        public void CompileArgument(string argname)
        {
            if (this.argnames.Contains(argname))
            {
                throw new Exception("Repeated Argument: " + argname);
            }

            this.argnames.Add(argname);
        }

        public void CompileLocal(string localname)
        {
            if (this.localnames.Contains(localname))
            {
                throw new Exception("Repeated Local: " + localname);
            }

            this.localnames.Add(localname);
        }

        public byte CompileConstant(object obj)
        {
            int p = this.constants.IndexOf(obj);

            if (p >= 0)
            {
                return (byte)p;
            }

            this.constants.Add(obj);

            return (byte)(this.constants.Count - 1);
        }

        public byte CompileGlobal(string globalname)
        {
            int p = this.globalnames.IndexOf(globalname);

            if (p >= 0)
            {
                return (byte)p;
            }

            this.globalnames.Add(globalname);

            return (byte)(this.globalnames.Count - 1);
        }

        public void CompileGetConstant(object obj)
        {
            this.CompileByteCode(ByteCode.GetConstant, this.CompileConstant(obj));
        }

        public void CompileByteCode(ByteCode b)
        {
            this.CompileByte((byte)b);
        }

        public void CompileByteCode(ByteCode b, byte arg)
        {
            this.CompileByteCode(b);
            this.CompileByte(arg);
        }

        public void CompileByteCode(ByteCode b, byte arg1, byte arg2)
        {
            this.CompileByteCode(b);
            this.CompileByte(arg1);
            this.CompileByte(arg2);
        }

        public void CompileSend(string msgname)
        {
            this.CompileByteCode(ByteCode.Send, this.CompileConstant(msgname), MessageArity(msgname));
        }

        // TODO how to implements super, sender
        public virtual object Execute(Machine machine, object[] args)
        {
            return (new ExecutionBlock(machine, null, this, args)).Execute();
        }

        public virtual void CompileGet(string name)
        {
            if (this.TryCompileGet(name))
            {
                return;
            }

            this.CompileByteCode(ByteCode.GetGlobalVariable, this.CompileGlobal(name));
        }

        public virtual void CompileSet(string name)
        {
            if (this.TryCompileSet(name))
            {
                return;
            }

            this.CompileByteCode(ByteCode.SetGlobalVariable, this.CompileGlobal(name));
        }

        public object GetConstant(int nc)
        {
            return this.constants[nc];
        }

        public string GetGlobalName(int ng)
        {
            return this.globalnames[ng];
        }

        protected bool TryCompileGet(string name)
        {
            if (name == "self")
            {
                this.CompileByteCode(ByteCode.GetSelf);
                return true;
            }

            int p;

            if (this.localnames != null)
            {
                p = this.localnames.IndexOf(name);

                if (p >= 0)
                {
                    this.CompileByteCode(ByteCode.GetLocal, (byte)p);

                    return true;
                }
            }

            if (this.argnames != null)
            {
                p = this.argnames.IndexOf(name);

                if (p >= 0)
                {
                    this.CompileByteCode(ByteCode.GetArgument, (byte)p);
                    return true;
                }
            }

            return false;
        }

        protected bool TryCompileSet(string name)
        {
            int p;

            if (this.localnames != null)
            {
                p = this.localnames.IndexOf(name);

                if (p >= 0)
                {
                    this.CompileByteCode(ByteCode.SetLocal, (byte)p);
                    return true;
                }
            }

            if (this.argnames != null)
            {
                p = this.argnames.IndexOf(name);

                if (p >= 0)
                {
                    this.CompileByteCode(ByteCode.SetArgument, (byte)p);
                    return true;
                }
            }

            return false;
        }

        public static byte MessageArity(string msgname)
        {
            if (!Char.IsLetter(msgname[0]))
            {
                return 2;
            }

            int p = msgname.IndexOf(':');

            if (p < 0)
            {
                return 0;
            }

            byte n = 0;

            foreach (char ch in msgname)
            {
                if (ch == ':')
                {
                    n++;
                }
            }

            return n;
        }

        private void CompileByte(byte b)
        {
            if (this.bytecodes == null)
            {
                this.bytecodes = new byte[] { b };
                this.nextbytecode = 1;
                return;
            }

            if (this.nextbytecode >= this.bytecodes.Length)
            {
                byte[] aux = new byte[this.bytecodes.Length + 10];
                Array.Copy(this.bytecodes, aux, this.bytecodes.Length);
                this.bytecodes = aux;
            }

            this.bytecodes[this.nextbytecode++] = b;
        }
    }
}
