namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DynamicArrayExpression : IExpression
    {
        private IEnumerable<IExpression> expressions;

        public DynamicArrayExpression(IEnumerable<IExpression> expressions)
        {
            this.expressions = expressions;
        }

        public IEnumerable<IExpression> Expressions { get { return this.expressions; } }

        public string AsString()
        {
            // TODO Refactor to String Builder
            string result = "{";

            foreach (IExpression expression in this.expressions)
            {
                if (result != "{")
                    result += ". ";

                result += expression.AsString();
            }

            return result + "}";
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
