namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InstanceVariableExpression : IExpression
    {
        private string name;

        public InstanceVariableExpression(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
