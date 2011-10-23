namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrimitiveExpression : IExpression
    {
        private int number;
        private string name;
        private string module;

        public PrimitiveExpression(int number)
        {
            this.number = number;
        }

        public PrimitiveExpression(string name, string module)
        {
            this.name = name;
            this.module = module;
        }

        public int Number { get { return this.number; } }

        public string Name { get { return this.name; } }

        public string Module { get { return this.module; } }

        public string AsString()
        {
            return string.Format("<primitive: {0}>", this.number);
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
