namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FreeBlockExpression : IExpression
    {
        private IEnumerable<IExpression> body;
        private IList<string> parameterNames;
        private IList<string> localVariables;

        public FreeBlockExpression(IList<string> parameterNames, IList<string> localVariables, IEnumerable<IExpression> body)
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
            string result = string.Empty;

            if (this.localVariables.Count > 0)
            {
                result += "|";
                foreach (var local in this.localVariables)
                    result += " " + local;

                result += " | ";
            }

            int nexpressions = 0;

            foreach (IExpression expression in this.body)
            {
                if (nexpressions > 0)
                    result += ". ";

                result += expression.AsString();
                nexpressions++;
            }

            return result;
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
