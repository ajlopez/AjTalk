namespace AjTalk.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public class Compiler : AbstractCompiler
    {
        private TextWriter writer;

        public Compiler(TextWriter writer)
        {
            this.writer = writer;
        }

        public override void Visit(MethodModel method)
        {
            this.writer.Write(string.Format("function {0}(", ToMethodName(method.Selector)));

            int nparameters = 0;

            foreach (string name in method.ParameterNames)
            {
                if (nparameters > 0)
                    this.writer.Write(", ");
                this.writer.Write(name);
                nparameters++;
            }

            this.writer.WriteLine(")");
            this.writer.WriteLine("{");
            method.Body.Visit(this);
            this.writer.WriteLine("}");
        }

        public override void Visit(CompositeExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(ConstantExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(MessageExpression expression)
        {
            string selector = expression.Selector;

            if (!char.IsLetter(selector[0]) && expression.Arguments.Count() == 1)
            {
                expression.Target.Visit(this);
                this.writer.Write(" " + selector + " ");
                expression.Arguments.First().Visit(this);
                return;
            }

            throw new NotImplementedException();
        }

        public override void Visit(ReturnExpression expression)
        {
            this.writer.Write("return ");
            expression.Expression.Visit(this);
            this.writer.WriteLine(";");
        }

        public override void Visit(SelfExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(SetExpression expression)
        {
            expression.LeftValue.Visit(this);
            this.writer.Write(" = ");
            expression.Expression.Visit(this);
            this.writer.WriteLine(";");
        }

        public override void Visit(VariableExpression expression)
        {
            this.writer.Write(expression.Name);
        }

        private static string ToMethodName(string name)
        {
            name = name.Replace(":", "_");
            name = "$" + name;

            if (name.EndsWith("_"))
                name = name.Substring(0, name.Length - 1);

            return name;
        }

        private static string ToVariableName(string name)
        {
            return "_" + name;
        }
    }
}
