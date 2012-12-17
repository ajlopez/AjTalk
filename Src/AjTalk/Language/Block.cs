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
        private string sourcecode;
        private Block outer;
        private ExecutionContext closure;

        public Block()
        {
        }

        public Block(string sourcecode)
            : this(sourcecode, null)
        {
        }

        public Block(string sourcecode, Block outer)
        {
            this.sourcecode = sourcecode;
            this.outer = outer;
        }

        public string SourceCode { get { return this.sourcecode; } }

        public int Arity { get { return this.argnames.Count; } }

        public byte[] Bytecodes { get { return this.bytecodes; } }

        public virtual bool IsMethod { get { return false; } }

        public ICollection<string> ParameterNames { get { return this.argnames; } }

        public ICollection<string> LocalNames { get { return this.localnames; } }

        public ExecutionContext Closure { get { return this.closure; } }

        public ExecutionContext TopClosure
        {
            get
            {
                if (this.closure == null)
                    return null;

                var value = this.closure.Block.TopClosure;

                if (value == null)
                    return this.closure;

                return value;
            }
        }

        public Block OuterBlock { get { return this.outer; } }

        public IObject Receiver
        {
            get
            {
                if (this.Closure == null)
                    return null;
                return this.Closure.Receiver;
            }
        }

        public byte[] ByteCodes { get { return this.bytecodes; } }

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

        public int NoGlobalNames
        {
            get
            {
                if (this.globalnames == null)
                    return 0;

                return this.globalnames.Count;
            }
        }

        public static byte MessageArity(string msgname)
        {
            if (!Char.IsLetter(msgname[0]))
                return 1;

            int p = msgname.IndexOf(':');

            if (p < 0)
                return 0;

            byte n = 0;

            foreach (char ch in msgname)
                if (ch == ':')
                    n++;

            return n;
        }

        public Block Clone(ExecutionContext closure)
        {
            Block newblock = (Block)this.MemberwiseClone();

            newblock.closure = closure;
            return newblock;
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

        public void CompileByteCodeAt(ByteCode b, int position)
        {
            this.bytecodes[position] = (byte)b;
        }

        public void CompileJumpByteCode(ByteCode b, short jump)
        {
            this.CompileByte((byte)b);
            this.CompileByte((byte)(jump >> 8));
            this.CompileByte((byte)(jump & 0xff));
        }

        public void CompileJumpByteCodeAt(ByteCode b, short jump, int position)
        {
            this.bytecodes[position] = (byte)b;
            this.bytecodes[position + 1] = (byte)(jump >> 8);
            this.bytecodes[position + 2] = (byte)(jump & 0xff);
        }

        public void CompileBlockJumpByteCodeAt(ByteCode b, short jump, int position)
        {
            this.bytecodes[position] = (byte)ByteCode.Value;
            this.bytecodes[position + 1] = (byte)b;
            this.bytecodes[position + 2] = (byte)(jump >> 8);
            this.bytecodes[position + 3] = (byte)(jump & 0xff);
        }

        public void CompileInsert(int position, int count)
        {
            byte[] aux = new byte[this.bytecodes.Length + count];
            Array.Copy(this.bytecodes, aux, position);
            Array.Copy(this.bytecodes, position, aux, position + count, this.bytecodes.Length - position);
            this.bytecodes = aux;
            this.nextbytecode += (short)count;
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
                string rest = msgname.Substring(p + 1);
                if (string.IsNullOrEmpty(rest) || rest.StartsWith("with:"))
                    mthname = msgname.Substring(0, p);
                else
                    mthname = msgname.Replace(":", string.Empty);
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
                this.CompileByteCode(ByteCode.InstSize);
            else if (msgname == "instAt:")
                this.CompileByteCode(ByteCode.InstAt);
            else if (msgname == "instAt:put:")
                this.CompileByteCode(ByteCode.InstAtPut);
            else if (msgname == "basicNew")
                this.CompileByteCode(ByteCode.NewObject);
            else if (msgname == "basicSize")
                this.CompileByteCode(ByteCode.BasicSize);
            else if (msgname == "basicAt:")
                this.CompileByteCode(ByteCode.BasicAt);
            else if (msgname == "basicAt:put:")
                this.CompileByteCode(ByteCode.BasicAtPut);
            else if (msgname == "ifTrue:ifFalse:")
                this.CompileByteCode(ByteCode.IfTrueFalse);
            else if (msgname == "ifFalse:ifTrue:")
                this.CompileByteCode(ByteCode.IfFalseTrue);
            else if (msgname == "value")
                this.CompileByteCode(ByteCode.Value);
            else if (msgname.StartsWith("value:") && IsValueMessage(msgname))
                this.CompileByteCode(ByteCode.MultiValue, MessageArity(msgname));
            else if (msgname == "class")
                this.CompileByteCode(ByteCode.GetClass);
            else if (msgname == "raise")
                this.CompileByteCode(ByteCode.RaiseException);
            else
                this.CompileByteCode(ByteCode.Send, this.CompileConstant(msgname), MessageArity(msgname));
        }

        public void CompileBinarySend(string msgname)
        {
            this.CompileByteCode(ByteCode.Send, this.CompileConstant(msgname), 1);
        }

        public ExecutionContext CreateContext(Machine machine, object[] args)
        {
            return new ExecutionContext(machine, this.Receiver, this, args);
        }

        // TODO how to implements super, sender
        public virtual object Execute(Machine machine, object[] args)
        {
            return (new Interpreter(this.CreateContext(machine, args)).Execute());
        }

        public virtual object ExecuteInInterpreter(Interpreter interpreter, object[] args)
        {
            interpreter.PushContext(this.CreateContext(interpreter.Machine, args));
            return interpreter;
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

        public string GetLocalName(int nl)
        {
            return this.localnames[nl];
        }

        public string GetArgumentName(int na)
        {
            return this.argnames[na];
        }

        public virtual string GetInstanceVariableName(int n)
        {
            if (this.outer != null)
                return this.outer.GetInstanceVariableName(n);

            throw new NotSupportedException();
        }

        public virtual int GetInstanceVariableOffset(string name)
        {
            if (this.outer != null)
                return this.outer.GetInstanceVariableOffset(name);

            return -1;
        }

        protected bool TryCompileGet(string name)
        {
            if (name.Equals("false"))
            {
                this.CompileGetConstant(false);
                return true;
            }

            if (name.Equals("true"))
            {
                this.CompileGetConstant(true);
                return true;
            }

            if (name[0] == Lexer.SpecialDotNetTypeMark)
            {
                this.CompileGetDotNetType(name.Substring(1));
                return true;
            }

            if (name == "self")
            {
                this.CompileByteCode(ByteCode.GetSelf);
                return true;
            }

            if (name == "super")
            {
                this.CompileByteCode(ByteCode.GetSuper);
                return true;
            }

            if (name == "nil" || name == "null")
            {
                this.CompileByteCode(ByteCode.GetNil);
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

            p = this.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.GetInstanceVariable, (byte)p);
                return true;
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

            p = this.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.SetInstanceVariable, (byte)p);
                return true;
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
                byte[] aux = new byte[this.bytecodes.Length + 1];
                Array.Copy(this.bytecodes, aux, this.bytecodes.Length);
                this.bytecodes = aux;
            }

            this.bytecodes[this.nextbytecode++] = b;
        }
    }
}
