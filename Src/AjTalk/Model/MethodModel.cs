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
        private IEnumerable<IExpression> body;
        private ClassModel @class;
        private bool isClassMethod;

        // TODO Remove this constructor?
        public MethodModel(string selector, IList<string> parameterNames, IList<string> localVariables, IEnumerable<IExpression> body)
            : this(selector, parameterNames, localVariables, body, null, false)
        {
        }

        public MethodModel(string selector, IList<string> parameterNames, IList<string> localVariables, IEnumerable<IExpression> body, ClassModel @class, bool isClassMethod)
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

        public IEnumerable<IExpression> Body { get { return this.body; } }

        public ClassModel Class { get { return this.@class; } }

        public bool IsClassMethod { get { return this.isClassMethod; } }

        public bool HasBlock()
        {
            return this.HasBlock(this.body);
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public bool HasBlock(IEnumerable<IExpression> expressions)
        {
            if (expressions == null)
                return false;

            foreach (var expression in expressions)
            {
                if (expression is BlockExpression)
                    return true;
                if (expression is MessageExpression)
                    if (this.HasBlock(((MessageExpression)expression).Arguments))
                        return true;
            }

            return false;
        }
    }
}

