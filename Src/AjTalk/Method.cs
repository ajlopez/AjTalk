using System;
using System.Collections;
using System.Collections.Generic;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Method.
	/// </summary>
	public class Method : Block, IMethod
	{
		private string name;
		private IClass mthclass;

        public Method(string name)
        {
            this.name = name;
        }

		public Method(IClass cls, string name) : this(name)
		{
			this.mthclass = cls;
		}

        public IClass Class
        {
            get { return this.mthclass; }
        }

        private bool TryCompileGetVariable(string name)
        {
            if (this.mthclass == null)
                return false;

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

        public override void CompileGet(string name)
        {
            if (TryCompileGet(name))
                return;

            if (TryCompileGetVariable(name))
                return;

            CompileByteCode(ByteCode.GetGlobalVariable, this.CompileGlobal(name));
        }

        private bool TryCompileSetVariable(string name)
        {
            if (mthclass == null)
                return false;

            int p = mthclass.GetInstanceVariableOffset(name);

            if (p >= 0)
            {
                CompileByteCode(ByteCode.SetVariable, (byte)p);
                return true;
            }

            // TODO Is this code needed?
            p = mthclass.GetClassVariableOffset(name);

            if (p >= 0)
            {
                CompileByteCode(ByteCode.SetClassVariable, (byte)p);
                return true;
            }

            return false;
        }

        public override void CompileSet(string name)
        {
            if (TryCompileSet(name))
                return;

            if (TryCompileSetVariable(name))
                return;

            CompileByteCode(ByteCode.SetGlobalVariable, CompileGlobal(name));
        }

        public string Name
		{
			get
			{
				return name;
			}
		}

        // TODO how to implements super, sender
        public override object Execute(Machine machine, object[] args)
        {
            throw new InvalidOperationException("A method needs a self object");
        }

        // TODO how to implements super, sender
        public object Execute(IObject self, object[] args)
        {
            return Execute(self, self, args);
        }

        // TODO how to implements super, sender
        public object Execute(IObject self, IObject receiver, object[] args)
        {
            return (new ExecutionBlock(self, receiver, this, args)).Execute();
        }
    }
}
