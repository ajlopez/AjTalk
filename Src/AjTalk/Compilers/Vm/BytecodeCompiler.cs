namespace AjTalk.Compilers.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;

    public class BytecodeCompiler : AbstractCompiler
    {
        private Block block;

        public BytecodeCompiler(Block block)
        {
            this.block = block;
        }

        public override void Visit(AjTalk.Model.ClassModel @class)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.MethodModel method)
        {
            throw new NotImplementedException();
        }

        public override void Visit(IEnumerable<AjTalk.Model.IExpression> expressions)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.ArrayExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.DynamicArrayExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.ConstantExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.MessageExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.FluentMessageExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.ReturnExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.SelfExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.SetExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.VariableExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.SymbolExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.InstanceVariableExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.ClassVariableExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.BlockExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.PrimitiveExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(AjTalk.Model.CodeModel expression)
        {
            throw new NotImplementedException();
        }
    }
}
