namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MethodModel
    {
        private string selector;
        private IList<string> parameterNames;
        private IList<string> localVariables;
        private IExpression body;

        public MethodModel(string selector, IList<string> parameterNames, IList<string> localVariables, IExpression body)
        {
            this.selector = selector;
            this.parameterNames = parameterNames;
            this.localVariables = localVariables;
            this.body = body;
        }

        public string Selector { get { return this.selector; } }

        public IList<string> ParameterNames { get { return this.parameterNames; } }

        public IList<string> LocalVariables { get { return this.localVariables; } }

        public IExpression Body { get { return this.body; } }
    }
}

