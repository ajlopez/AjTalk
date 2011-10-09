namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MessageExpression : IExpression
    {
        private IExpression target;
        private string selector;
        private IEnumerable<IExpression> arguments;

        public MessageExpression(IExpression target, string selector, IEnumerable<IExpression> arguments)
        {
            this.target = target;
            this.selector = selector;

            if (arguments == null)
                this.arguments = new List<IExpression>();
            else
                this.arguments = arguments;
        }

        public IExpression Target { get { return this.target; } }

        public string Selector { get { return this.selector; } }

        public IEnumerable<IExpression> Arguments { get { return this.arguments; } }

        public bool IsUnaryMessage { get { return this.arguments.Count() == 0; } }

        public bool IsBinaryMessage { get { return this.arguments.Count() == 1 && !char.IsLetter(this.selector[0]); } }

        public bool IsKeywordMessage { get { return !this.IsUnaryMessage && !this.IsBinaryMessage; } }

        public string AsString()
        {
            // TODO Use String Builder
            string result = this.target.AsString();

            if (this.target is MessageExpression)
            {
                MessageExpression mexpr = (MessageExpression)this.target;

                if ((this.IsUnaryMessage && (mexpr.IsBinaryMessage || mexpr.IsKeywordMessage)) ||
                    (this.IsBinaryMessage && mexpr.IsKeywordMessage) ||
                    (this.IsKeywordMessage && mexpr.IsKeywordMessage))
                    result = "(" + result + ")";
            }

            // TODO Use string.Format
            if (this.arguments.Count() == 0)
                return result + " " + this.selector;

            if (this.IsBinaryMessage)
            {
                IExpression arg = this.arguments.First();
                string argresult = arg.AsString();

                if (arg is MessageExpression && (((MessageExpression)arg).IsBinaryMessage || ((MessageExpression)arg).IsKeywordMessage))
                    argresult = "(" + argresult + ")";

                return result + " " + this.selector + " " + argresult;
            }

            string []names = this.selector.Split(':');

            int k = 0;

            foreach (IExpression expr in this.arguments)
            {
                string exprresult = expr.AsString();

                if (expr is MessageExpression && ((MessageExpression)expr).IsKeywordMessage)
                    exprresult = "(" + exprresult + ")";

                result += " " + names[k] + ": " + exprresult;
                k++;
            }

            return result;
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
