namespace AjTalk.Compilers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public abstract class AbstractCompiler : ICompiler, IVisitor
    {
        public void CompileClass(ClassModel @class)
        {
            @class.Visit(this);
        }

        public void CompileMethod(MethodModel method)
        {
            method.Visit(this);
        }

        public void CompileExpression(IExpression expression)
        {
            expression.Visit(this);
        }

        public void CompileExpressions(IEnumerable<IExpression> expressions)
        {
            foreach (var expr in expressions)
                expr.Visit(this);
        }

        public abstract void Visit(ClassModel @class);

        public abstract void Visit(MethodModel method);

        public abstract void Visit(IEnumerable<IExpression> expressions);

        public abstract void Visit(ArrayExpression expression);

        public abstract void Visit(DynamicArrayExpression expression);

        public abstract void Visit(ConstantExpression expression);

        public abstract void Visit(MessageExpression expression);

        public abstract void Visit(FluentMessageExpression expression);

        public abstract void Visit(ReturnExpression expression);

        public abstract void Visit(SelfExpression expression);

        public abstract void Visit(SetExpression expression);

        public abstract void Visit(VariableExpression expression);

        public abstract void Visit(SymbolExpression expression);

        public abstract void Visit(InstanceVariableExpression expression);

        public abstract void Visit(ClassVariableExpression expression);

        public abstract void Visit(BlockExpression expression);

        public abstract void Visit(PrimitiveExpression expression);

        public abstract void Visit(CodeModel expression);

        public abstract void Visit(FreeBlockExpression expression);
    }
}
