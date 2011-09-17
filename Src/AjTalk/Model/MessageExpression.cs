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

        public object Target { get { return this.target; } }

        public string Selector { get { return this.selector; } }

        public IEnumerable<IExpression> Arguments { get { return this.arguments; } }
    }
}
