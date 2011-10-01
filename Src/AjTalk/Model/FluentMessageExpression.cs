namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FluentMessageExpression : IExpression
    {
        private IExpression target;
        private string selector;
        private IEnumerable<IExpression> arguments;

        public FluentMessageExpression(IExpression target, string selector, IEnumerable<IExpression> arguments)
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

        public string AsString()
        {
            // TODO Use string.Format
            if (this.arguments.Count() == 0)
                return this.target.AsString() + " " + this.selector;

            if (this.arguments.Count() == 1)
                return this.target.AsString() + " " + this.selector + " " + this.arguments.First().AsString();

            string []names = this.selector.Split(':');

            int k = 0;

            // TODO Use String Builder
            string result = this.target.AsString();

            foreach (IExpression expr in this.arguments)
            {
                result += " " + names[k] + ": " + expr.AsString();
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
