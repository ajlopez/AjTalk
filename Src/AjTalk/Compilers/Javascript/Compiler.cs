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
        private SourceWriter writer;
        private int naux;

        public Compiler(SourceWriter writer)
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
            this.writer.WriteLineStart("{");
            this.writer.WriteLine("var self = this;");

            foreach (string locname in method.LocalVariables)
                this.writer.WriteLine(string.Format("var {0} = null", locname));

            int nauxbackup = this.naux;

            try
            {
                this.naux = 0;
                this.Visit(method.Body);
            }
            finally
            {
                this.naux = nauxbackup;
            }

            if (method.Class != null)
                this.writer.WriteLineEnd("};");
            else
                this.writer.WriteLineEnd("}");
        }

        public override void Visit(IEnumerable<IExpression> expressions)
        {
            if (expressions == null)
                return;

            foreach (var expr in expressions)
            {
                expr.Visit(this);
                this.writer.WriteLine(";");
            }
        }

        public override void Visit(ArrayExpression expression)
        {
            this.writer.Write("[");

            int nexpr = 0;

            foreach (IExpression expr in expression.Expressions)
            {
                if (nexpr != 0)
                    this.writer.Write(", ");
                expr.Visit(this);
                nexpr++;
            }

            this.writer.Write("]");
        }

        public override void Visit(DynamicArrayExpression expression)
        {
            this.writer.Write("[");

            int nexpr = 0;

            foreach (IExpression expr in expression.Expressions)
            {
                if (nexpr != 0)
                    this.writer.Write(", ");
                expr.Visit(this);
                nexpr++;
            }

            this.writer.Write("]");
        }

        public override void Visit(CodeModel model)
        {
            foreach (var element in model.Elements)
                element.Visit(this);
        }

        public override void Visit(ConstantExpression expression)
        {
            this.writer.Write(expression.AsString());
        }

        public override void Visit(BlockExpression expression)
        {
            // TODO block with parameters, return
            this.writer.Write("function(");
            int npars = 0;
            foreach (string parname in expression.ParameterNames)
            {
                if (npars > 0)
                    this.writer.Write(", ");
                this.writer.Write(parname);
                npars++;
            }
            this.writer.WriteLineStart(") {");

            foreach (string locname in expression.LocalVariables)
                this.writer.WriteLine(string.Format("var {0} = null;", locname));
            this.Visit(expression.Body);
            this.writer.WriteLineEnd("}");
        }

        public override void Visit(PrimitiveExpression expression)
        {
            // TODO implement primitive
            this.writer.WriteLine();
            this.writer.WriteLine("// " + expression.AsString());
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

            expression.Target.Visit(this);
            this.writer.Write(string.Format(".{0}(", ToMethodName(expression.Selector)));

            int narg = 0;
            foreach (var argument in expression.Arguments)
            {
                if (narg != 0)
                    this.writer.Write(", ");
                argument.Visit(this);
                narg++;
            }

            this.writer.Write(")");
        }

        public override void Visit(FluentMessageExpression expression)
        {
            this.writer.Write(string.Format("var _aux{0} = ", this.naux++));
            // TODO It's not implemented yet
            expression.Target.Visit(this);
        }

        public override void Visit(ReturnExpression expression)
        {
            this.writer.Write("return ");
            expression.Expression.Visit(this);
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
            // TODO review symbol implementation in Javascript
            this.writer.Write("'" + expression.Symbol + "'");
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

            // TODO review if needed $ at front
            return "$" + name;
        }

        private static string ToVariableName(string name)
        {
            return "_" + name;
        }
    }
}

