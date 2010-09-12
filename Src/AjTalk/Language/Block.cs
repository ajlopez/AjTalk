namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk.Compiler;

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

        public int NoConstants
        {
            get
            {
                if (this.constants == null)
                {
                    return 0;
                }

                return this.constants.Count;
            }
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

        public void CompileGetBlock(object obj)
        {
            this.CompileByteCode(ByteCode.GetBlock, this.CompileConstant(obj));
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

        public void CompileInvokeDotNet(string msgname)
        {
            msgname = msgname.Substring(1);

            int p = msgname.IndexOf(':');

            string mthname;

            if (p >= 0)
            {
                mthname = msgname.Substring(0, p);
            }
            else
            {
                mthname = msgname;
            }

            if (mthname == "new")
            {
                this.CompileByteCode(ByteCode.NewDotNetObject, MessageArity(msgname));
            }
            else
            {
                this.CompileByteCode(ByteCode.InvokeDotNetMethod, this.CompileConstant(mthname), MessageArity(msgname));
            }
        }

        public void CompileSend(string msgname)
        {
            if (msgname[0] == Lexer.SpecialDotNetInvokeMark)
            {
                this.CompileInvokeDotNet(msgname);
                return;
            }

            if (msgname == "instSize")
            {
                this.CompileByteCode(ByteCode.InstSize);
            }
            else if (msgname == "instAt:")
            {
                this.CompileByteCode(ByteCode.InstAt);
            }
            else if (msgname == "instAt:put:")
            {
                this.CompileByteCode(ByteCode.InstAtPut);
            }
            else if (msgname == "basicNew")
            {
                this.CompileByteCode(ByteCode.NewObject);
            }
            else if (msgname == "basicSize")
            {
                this.CompileByteCode(ByteCode.BasicSize);
            }
            else if (msgname == "basicAt:")
            {
                this.CompileByteCode(ByteCode.BasicAt);
            }
            else if (msgname == "basicAt:put:")
            {
                this.CompileByteCode(ByteCode.BasicAtPut);
            }
            else if (msgname == "value")
            {
                this.CompileByteCode(ByteCode.Value);
            }
            else if (msgname.StartsWith("value:") && IsValueMessage(msgname))
            {
                this.CompileByteCode(ByteCode.MultiValue, MessageArity(msgname));
            }
            else if (msgname == "class")
            {
                this.CompileByteCode(ByteCode.GetClass);
            }
            else
            {
                this.CompileByteCode(ByteCode.Send, this.CompileConstant(msgname), MessageArity(msgname));
            }
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

        public virtual void CompileGetDotNetType(string name)
        {
            this.CompileByteCode(ByteCode.GetDotNetType, this.CompileGlobal(name));
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

        private static bool IsValueMessage(string msgname)
        {
            if (msgname == "value:")
                return true;

            if (msgname.StartsWith("value:"))
                return IsValueMessage(msgname.Substring(6));

            return false;
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