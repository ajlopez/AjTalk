namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockExpression : IExpression
    {
        private IExpression body;

        public BlockExpression(IExpression body)
        {
            this.body = body;
        }

        public IExpression Body { get { return this.body; } }

        public string AsString()
        {
            return "[" + this.body.AsString() + "]";
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
