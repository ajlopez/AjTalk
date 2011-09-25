namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IVisitor
    {
        void Visit(ClassModel @class);

        void Visit(MethodModel method);

        void Visit(CompositeExpression expression);

        void Visit(ConstantExpression expression);

        void Visit(MessageExpression expression);

        void Visit(ReturnExpression expression);

        void Visit(SelfExpression expression);

        void Visit(SetExpression expression);

        void Visit(VariableExpression expression);

        void Visit(SymbolExpression expression);

        void Visit(BlockExpression expression);

        void Visit(InstanceVariableExpression expression);

        void Visit(ClassVariableExpression expression);
    }
}

