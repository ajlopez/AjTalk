namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockExpression : IExpression
    {
        private IEnumerable<IExpression> body;
        private IList<string> parameterNames;
        private IList<string> localVariables;

        public BlockExpression(IList<string> parameterNames, IList<string> localVariables, IEnumerable<IExpression> body)
        {
            this.parameterNames = parameterNames;
            this.localVariables = localVariables;
            this.body = body;
        }

        public IList<string> ParameterNames { get { return this.parameterNames; } }

        public IList<string> LocalVariables { get { return this.localVariables; } }

        public IEnumerable<IExpression> Body { get { return this.body; } }

        // TODO use parameter names and local variables
        public string AsString()
        {
            // TODO Refactor to String Builder
            string result = "[";

            foreach (IExpression expression in this.body)
            {
                if (result != "")
                    result += ". ";

                result += expression.AsString();
            }

            return result + "]";
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
