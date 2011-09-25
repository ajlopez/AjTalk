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

        public override void Visit(ClassModel @class)
        {
            this.writer.WriteLine(string.Format("function {0}()", @class.Name));
            this.writer.WriteLine("{");
            this.writer.WriteLine("}");

            foreach (string name in @class.InstanceVariableNames)
                this.writer.WriteLine(string.Format("{0}.prototype.{1} = null;", @class.Name, name));

            foreach (string name in @class.ClassVariableNames)
                this.writer.WriteLine(string.Format("{0}.{1} = null;", @class.Name, name));

            foreach (MethodModel method in @class.InstanceMethods)
                method.Visit(this);
        }

        public override void Visit(MethodModel method)
        {
            if (method.Class != null)
            {
                this.writer.Write(string.Format("{0}.prototype.{1} = function(", method.Class.Name, ToMethodName(method.Selector)));
            }
            else
            {
                this.writer.Write(string.Format("function {0}(", ToMethodName(method.Selector)));
            }

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

            if (method.Class != null)
                this.writer.WriteLine("};");
            else
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

        public override void Visit(BlockExpression expression)
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
            this.writer.Write("self");
        }

        public override void Visit(SetExpression expression)
        {
            expression.LeftValue.Visit(this);
            this.writer.Write(" = ");
            expression.Expression.Visit(this);
            this.writer.WriteLine(";");
        }

        public override void Visit(SymbolExpression expression)
        {
            throw new NotImplementedException();
        }

        public override void Visit(VariableExpression expression)
        {
            this.writer.Write(expression.Name);
        }

        public override void Visit(InstanceVariableExpression expression)
        {
            this.writer.Write(string.Format("this.{0}", expression.Name));
        }

        public override void Visit(ClassVariableExpression expression)
        {
            this.writer.Write(string.Format("{0}.{1}", expression.Class.Name, expression.Name));
        }

        private static string ToMethodName(string name)
        {
            name = name.Replace(":", "_");
            name = "$" + name;

            return name;
        }

        private static string ToVariableName(string name)
        {
            return "_" + name;
        }
    }
}

