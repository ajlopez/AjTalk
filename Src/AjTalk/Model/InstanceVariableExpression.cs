namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InstanceVariableExpression : ILeftValue
    {
        private string name;

        public InstanceVariableExpression(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public string AsString()
        {
            return this.name;
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
