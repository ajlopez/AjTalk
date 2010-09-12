namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Method : Block, IMethod
    {
        private string name;
        private IClassDescription mthclass;

        public Method(string name)
        {
            this.name = name;
        }

        public Method(IClassDescription cls, string name)
            : this(name)
        {
            this.mthclass = cls;
        }

        public IClassDescription Class
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
        public object Execute(IObject self, object[] args)
        {
            return this.Execute(self, self, args);
        }

        // TODO how to implements super, sender
        public object Execute(IObject self, IObject receiver, object[] args)
        {
            return (new ExecutionBlock(self, receiver, this, args)).Execute();
        }

        public object ExecuteNative(object self, object[] args)
        {
            throw new NotSupportedException();
        }

        private bool TryCompileGetVariable(string name)
        {
            if (this.mthclass == null)
            {
                return false;
            }

            int p = this.mthclass.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                CompileByteCode(ByteCode.GetVariable, (byte)p);
                return true;
            }

            // TODO Review if a class variable can be used in an instance method
            p = this.mthclass.GetClassVariableOffset(name);

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

            int p = this.mthclass.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.SetVariable, (byte)p);
                return true;
            }

            // TODO Is this code needed?
            p = this.mthclass.GetClassVariableOffset(name);

            if (p >= 0)
            {
                this.CompileByteCode(ByteCode.SetClassVariable, (byte)p);
                return true;
            }

            return false;
        }
    }
}
