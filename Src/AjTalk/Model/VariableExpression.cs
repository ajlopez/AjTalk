namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class VariableExpression : IExpression
    {
        private string name;

        public VariableExpression(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public string AsString()
        {
            return this.name;
        }
    }
}
