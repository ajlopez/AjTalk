namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Method : Block, IMethod
    {
        private string name;
        private IBehavior mthclass;

        public Method(string name)
            : this(null, name, null)
        {
        }

        public Method(IBehavior cls, string name)
            : this(cls, name, null)
        {
        }

        public Method(IBehavior cls, string name, string source)
            : base(source)
        {
            this.name = name;
            this.mthclass = cls;
        }

        public IBehavior Behavior
        {
            get { return this.mthclass; }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override void CompileGet(string name)
        {
            if (this.TryCompileGet(name))
            {
                return;
            }

            if (this.TryCompileGetVariable(name))
            {
                return;
            }

            this.CompileByteCode(ByteCode.GetGlobalVariable, this.CompileGlobal(name));
        }

        public override void CompileSet(string name)
        {
            if (this.TryCompileSet(name))
            {
                return;
            }

            if (this.TryCompileSetVariable(name))
            {
                return;
            }

            this.CompileByteCode(ByteCode.SetGlobalVariable, CompileGlobal(name));
        }

        // TODO how to implements super, sender
        public override object Execute(Machine machine, object[] args)
        {
            throw new InvalidOperationException("A method needs a self object");
        }

        // TODO how to implements super, sender
        public object Execute(Machine machine, IObject self, object[] args)
        {
            return this.Execute(machine, self, self, args);
        }

        // TODO how to implements super, sender
        public object Execute(Machine machine, IObject self, IObject receiver, object[] args)
        {
            return (new ExecutionBlock(machine, self, receiver, this, args)).Execute();
        }

        public object ExecuteNative(Machine machine, object self, object[] args)
        {
            return new ExecutionBlock(machine, self, this, args).Execute();
        }

        public override string GetInstanceVariableName(int n)
        {
            return ((IClassDescription)this.mthclass).GetInstanceVariableNames().ElementAt(n);
        }

        public override string GetClassVariableName(int n)
        {
            return ((IClassDescription)this.mthclass).GetClassVariableNames().ElementAt(n);
        }

        private bool TryCompileGetVariable(string name)
        {
            if (this.mthclass == null)
            {
                return false;
            }

            IClassDescription cls = this.mthclass as IClassDescription;

            if (cls == null)
                return false;

            int p = cls.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                CompileByteCode(ByteCode.GetInstanceVariable, (byte)p);
                return true;
            }

            // TODO Review if a class variable can be used in an instance method
            p = cls.GetClassVariableOffset(name);

            if (p >= 0)
            {
                CompileByteCode(ByteCode.GetClassVariable, (byte)p);
                return true;
            }

            return false;
        }

        private bool TryCompileSetVariable(string name)
        {
            if (this.mthclass == null)
            {
                return false;
            }

            IClassDescription cls = this.mthclass as IClassDescription;

            if (cls == null)
                return false;

            int p = cls.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.SetInstanceVariable, (byte)p);
                return true;
            }

            // TODO Is this code needed?
            p = cls.GetClassVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.SetClassVariable, (byte)p);
                return true;
            }

            return false;
        }
    }
}
