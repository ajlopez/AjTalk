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
        private static IDictionary<string, string> operatorNames = new Dictionary<string, string>()
        {
            { "->", "assoc" },
            { "=", "equal" },
            { "~=", "notequal" },
            { "@", "at" }
        };

        private static IDictionary<string, string> jsOperators = new Dictionary<string, string>()
        {
            { "~~", "!==" }
        };

        private SourceWriter writer;
        private MethodModel currentMethod;

        public Compiler(SourceWriter writer)
        {
            this.writer = writer;
        }

        public override void Visit(ClassModel @class)
        {
            this.writer.WriteLine(string.Format("function {0}Class()", @class.Name));
            this.writer.WriteLineStart("{");
            this.writer.WriteLineEnd("}");

            this.writer.WriteLine(string.Format("function {0}()", @class.Name));
            this.writer.WriteLineStart("{");
            this.writer.WriteLine(string.Format("this._class = new {0}Class();", @class.Name));
            this.writer.WriteLineEnd("}");

            foreach (string name in @class.InstanceVariableNames)
                this.writer.WriteLine(string.Format("{0}.prototype.{1} = null;", @class.Name, name));

            // TODO Review class variables. Where? Now at Class function (not prototype)
            foreach (string name in @class.ClassVariableNames)
                this.writer.WriteLine(string.Format("{0}Class.{1} = null;", @class.Name, name));

            foreach (MethodModel method in @class.InstanceMethods)
                method.Visit(this);
        }

        public override void Visit(MethodModel method)
        {
            if (method.Class != null)
            {
                if (method.Class.Name.EndsWith(" class"))
                    this.writer.Write(string.Format("{0}Class.prototype.{1} = function(", method.Class.Name.Substring(0, method.Class.Name.Length - " class".Length), ToMethodName(method.Selector)));
                else
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
            this.writer.WriteLine(string.Format("console.log('{0}');", ToMethodName(method.Selector)));

            foreach (string locname in method.LocalVariables)
                this.writer.WriteLine(string.Format("var {0} = null", ToVariableName(locname)));

            MethodModel previousModel = this.currentMethod;

            try
            {
                this.currentMethod = method;
                this.Visit(method.Body);
            }
            finally
            {
                this.currentMethod = previousModel;
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

            this.writer.WriteLine();

            foreach (var element in model.Elements)
            {
                if (!(element is ClassModel))
                    continue;

                this.writer.WriteLine(string.Format("exports.{0} = {0};", ((ClassModel)element).Name));
            }
        }

        public override void Visit(ConstantExpression expression)
        {
            if (expression.Value is char)
                this.writer.Write(string.Format("'{0}'", expression.Value));
            else
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
            this.writer.Write(string.Format("var _primitive = Primitive{0}(self", expression.Primitive));

            foreach (var parameter in this.currentMethod.ParameterNames)
            {
                this.writer.Write(", ");
                this.writer.Write(parameter);
            }

            this.writer.WriteLine(");");
            this.writer.WriteLine("if (_primitive) return _primitive.value;");
        }

        public override void Visit(MessageExpression expression)
        {
            string selector = expression.Selector;
            bool nested = false;

            if (expression.Target is MessageExpression && ((MessageExpression)expression.Target).IsBinaryMessage)
                nested = true;
            else if (expression.Target is SetExpression)
                nested = true;
            else if (expression.Target is BlockExpression)
                nested = true;

            if (!char.IsLetter(selector[0]) && expression.Arguments.Count() == 1)
            {
                if (nested)
                    this.writer.Write("(");

                // TODO Refactor: repeated code below
                if (expression.Target is ConstantExpression)
                {
                    ConstantExpression cexpr = (ConstantExpression)expression.Target;

                    // TODO other types, scape characters in string
                    if (cexpr.Value is String)
                        this.writer.Write(string.Format("String({0})", cexpr.AsString()));
                    else if (cexpr.Value is int)
                        this.writer.Write(string.Format("Number({0})", cexpr.Value));
                    else if (cexpr.Value is bool)
                        this.writer.Write(string.Format("Boolean({0})", cexpr.Value));
                }
                else
                    expression.Target.Visit(this);

                if (nested)
                    this.writer.Write(")");

                if (OperatorHasMethodName(selector))
                {
                    this.writer.Write("." + OperatorToMethodName(selector) + "(");
                    expression.Arguments.First().Visit(this);
                    this.writer.Write(")");
                }
                else
                {
                    this.writer.Write(" " + OperatorToJsOperator(selector) + " ");
                    expression.Arguments.First().Visit(this);
                }

                return;
            }

            if (expression.Target is ConstantExpression)
            {
                ConstantExpression cexpr = (ConstantExpression)expression.Target;

                // TODO other types, scape characters in string
                if (cexpr.Value is String)
                    this.writer.Write(string.Format("String({0})", cexpr.AsString()));
                else if (cexpr.Value is int)
                    this.writer.Write(string.Format("Number({0})", cexpr.Value));
                else if (cexpr.Value is bool)
                    this.writer.Write(string.Format("Boolean({0})", cexpr.Value.ToString().ToLower()));
            }
            else
            {
                if (nested)
                    this.writer.Write("(");
                expression.Target.Visit(this);
                if (nested)
                    this.writer.Write(")");
            }

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
            this.writer.Write("(function () {");
            this.writer.Write("var _aux = ");
            // TODO It's not implemented yet
            expression.Target.Visit(this);
            this.writer.Write(";");
            MessageExpression msg = new MessageExpression(new VariableExpression("_aux"), expression.Target.Selector, expression.Target.Arguments);
            this.writer.Write("return _aux;})()");
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
            //this.writer.WriteLine(";");
        }

        public override void Visit(SymbolExpression expression)
        {
            // TODO review symbol implementation in Javascript
            this.writer.Write("'" + expression.Symbol + "'");
        }

        public override void Visit(VariableExpression expression)
        {
            this.writer.Write(ToVariableName(expression.Name));
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
            if (!char.IsLetter(name[0]))
                return OperatorToMethodName(name);

            name = name.Replace(":", "_");

            // TODO review if needed $ at front
            return "$" + name;
        }

        private static string OperatorToMethodName(string name)
        {
            return "$_" + operatorNames[name] + "_";
        }

        private static bool OperatorHasMethodName(string name)
        {
            return operatorNames.ContainsKey(name);
        }

        private static string OperatorToJsOperator(string name)
        {
            if (jsOperators.ContainsKey(name))
                return jsOperators[name];

            return name;
        }

        private static string ToVariableName(string name)
        {
            if (name == "class")
                return "__class__";
            if (name == "new")
                return "__new__";

            return name;
        }
    }
}

