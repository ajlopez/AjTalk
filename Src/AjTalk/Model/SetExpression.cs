namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SetExpression : IExpression
    {
        private ILeftValue leftValue;
        private IExpression expression;

        public SetExpression(ILeftValue leftValue, IExpression expression)
        {
            this.leftValue = leftValue;
            this.expression = expression;
        }

        public ILeftValue LeftValue { get { return this.leftValue; } }

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
