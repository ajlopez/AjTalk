namespace AjTalk.Compilers.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using AjTalk.Model;

    public class BytecodeCompiler : AbstractCompiler
    {
        private Block block;

        public BytecodeCompiler(Block block)
        {
            this.block = block;
        }

        public override void Visit(ClassModel @class)
        {
            throw new NotImplementedException();
        }

        public override void Visit(MethodModel method)
        {
            throw new NotImplementedException();
        }

        public override void Visit(IEnumerable<IExpression> expressions)
        {
            throw new NotImplementedException();
        }

        public override void Visit(ArrayExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(DynamicArrayExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(ConstantExpression expression)
        {
            if (expression.Value == null)
                this.block.CompileByteCode(ByteCode.GetNil);
            else
                this.block.CompileGetConstant(expression.Value);
        }

        public override void Visit(MessageExpression expression)
        {
            expression.Target.Visit(this);
            
            foreach (var arg in expression.Arguments)
                arg.Visit(this);

            if (expression.IsBinaryMessage)
                this.block.CompileBinarySend(expression.Selector);
            else
                this.block.CompileSend(expression.Selector);
        }

        public override void Visit(FluentMessageExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(ReturnExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(SelfExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(SetExpression expression)
        {
            expression.Expression.Visit(this);
            this.block.CompileSet(expression.LeftValue.Name);
        }

        public override void Visit(VariableExpression expression)
        {
            this.block.CompileGet(expression.Name);
        }

        public override void Visit(SymbolExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(InstanceVariableExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(ClassVariableExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(BlockExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(PrimitiveExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(CodeModel expression)
        {
            throw new NotImplementedException();
        }
    }
}
