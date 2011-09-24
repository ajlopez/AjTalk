namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClassVariableExpression : ILeftValue
    {
        private string name;
        private ClassModel @class;

        public ClassVariableExpression(string name, ClassModel @class)
        {
            this.name = name;
            this.@class = @class;
        }

        public string Name { get { return this.name; } }

        public ClassModel Class { get { return this.@class; } }

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
