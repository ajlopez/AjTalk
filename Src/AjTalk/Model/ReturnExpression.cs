namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReturnExpression : IExpression
    {
        private IExpression expression;

        public ReturnExpression(IExpression expression)
        {
            this.expression = expression;
        }

        public IExpression Expression { get { return this.expression; } }

        public string AsString()
        {
            return "^" + this.expression.AsString();
        }
    }
}
