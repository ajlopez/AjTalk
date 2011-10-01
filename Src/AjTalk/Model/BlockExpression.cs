namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockExpression : IExpression
    {
        private IExpression body;
        private IList<string> parameterNames;
        private IList<string> localVariables;

        public BlockExpression(IList<string> parameterNames, IList<string> localVariables, IExpression body)
        {
            this.parameterNames = parameterNames;
            this.localVariables = localVariables;
            this.body = body;
        }

        public IList<string> ParameterNames { get { return this.parameterNames; } }

        public IList<string> LocalVariables { get { return this.localVariables; } }

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
