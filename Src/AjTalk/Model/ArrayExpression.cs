namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ArrayExpression : IExpression
    {
        private IEnumerable<IExpression> expressions;

        public ArrayExpression(IEnumerable<IExpression> expressions)
        {
            this.expressions = expressions;
        }

        public IEnumerable<IExpression> Expressions { get { return this.expressions; } }

        public object[] AsObjectArray()
        {
            IList<object> objects = new List<object>();

            foreach (var expr in this.expressions)
            {
                if (expr is ConstantExpression)
                    objects.Add(((ConstantExpression)expr).Value);
                else if (expr is SymbolExpression)
                    objects.Add(((SymbolExpression)expr).Symbol);
                else if (expr is VariableExpression)
                    objects.Add(((VariableExpression)expr).Name);
                else if (expr is ArrayExpression)
                    objects.Add(((ArrayExpression)expr).AsObjectArray());
                else
                    throw new InvalidOperationException();
            }

            return objects.ToArray();
        }

        public string AsString()
        {
            // TODO Refactor to String Builder
            string result = "#(";

            foreach (IExpression expression in this.expressions)
            {
                if (result != "#(")
                    result += " ";

                if (expression is SymbolExpression)
                    result += ((SymbolExpression)expression).Symbol;
                else if (expression is ArrayExpression)
                    result += expression.AsString().Substring(1);
                else
                    result += expression.AsString();
            }

            return result + ")";
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
