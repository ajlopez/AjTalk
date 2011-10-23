namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrimitiveExpression : IExpression
    {
        private int primitive;

        public PrimitiveExpression(int primitive)
        {
            this.primitive = primitive;
        }

        public int Primitive { get { return this.primitive; } }

        public string AsString()
        {
            return string.Format("<primitive: {0}>", this.primitive);
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
