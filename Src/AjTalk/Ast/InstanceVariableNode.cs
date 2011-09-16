namespace AjTalk.Ast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class InstanceVariableNode : INode
    {
        private string name;

        public InstanceVariableNode(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}
