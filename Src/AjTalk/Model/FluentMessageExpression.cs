namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FluentMessageExpression : IExpression
    {
        private MessageExpression target;

        public FluentMessageExpression(MessageExpression target)
        {
            this.target = target;
        }

        public MessageExpression Target { get { return this.target; } }

        public string AsString()
        {
            return this.target.AsString() + ";";
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
