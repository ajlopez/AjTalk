namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SetExpression : IExpression
    {
        private VariableExpression leftValue;
        private IExpression expression;

        public SetExpression(VariableExpression leftValue, IExpression expression)
        {
            this.leftValue = leftValue;
            this.expression = expression;
        }

        public VariableExpression LeftValue { get { return this.leftValue; } }

        public IExpression Expression { get { return this.expression; } }

        public string AsString()
        {
            return this.leftValue.AsString() + " := " + this.expression.AsString();
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
