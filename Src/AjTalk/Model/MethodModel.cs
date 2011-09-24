namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MethodModel : IVisitable
    {
        private string selector;
        private IList<string> parameterNames;
        private IList<string> localVariables;
        private IExpression body;
        private ClassModel @class;
        private bool isClassMethod;

        // TODO Remove this constructor?
        public MethodModel(string selector, IList<string> parameterNames, IList<string> localVariables, IExpression body)
            : this(selector, parameterNames, localVariables, body, null, false)
        {
        }

        public MethodModel(string selector, IList<string> parameterNames, IList<string> localVariables, IExpression body, ClassModel @class, bool isClassMethod)
        {
            this.selector = selector;
            this.parameterNames = parameterNames;
            this.localVariables = localVariables;
            this.body = body;
            this.@class = @class;
            this.isClassMethod = isClassMethod;
        }

        public string Selector { get { return this.selector; } }

        public IList<string> ParameterNames { get { return this.parameterNames; } }

        public IList<string> LocalVariables { get { return this.localVariables; } }

        public IExpression Body { get { return this.body; } }

        public ClassModel Class { get { return this.@class; } }

        public bool IsClassMethod { get { return this.isClassMethod; } }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

