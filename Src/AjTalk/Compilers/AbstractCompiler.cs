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

        public abstract void Visit(ClassModel @class);

        public abstract void Visit(MethodModel method);

        public abstract void Visit(CompositeExpression expression);

        public abstract void Visit(ConstantExpression expression);

        public abstract void Visit(MessageExpression expression);

        public abstract void Visit(ReturnExpression expression);

        public abstract void Visit(SelfExpression expression);

        public abstract void Visit(SetExpression expression);

        public abstract void Visit(VariableExpression expression);

        public abstract void Visit(InstanceVariableExpression expression);

        public abstract void Visit(ClassVariableExpression expression);
    }
}
