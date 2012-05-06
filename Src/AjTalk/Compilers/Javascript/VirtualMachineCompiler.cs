namespace AjTalk.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public class VirtualMachineCompiler : Compiler
    {
        public VirtualMachineCompiler(SourceWriter writer)
            : base(writer)
        {
        }

        public override void Visit(CodeModel model)
        {
            // TODO Review Node.js dependent preface code
            this.WriteLineStart("(function(exports, top) {");

            this.WriteLineStart("function initialize(ajtalk) {");
            this.WriteLine("var Smalltalk = ajtalk.Smalltalk;");

            base.Visit(model);

            this.WriteLineEnd("}");
            this.WriteLine();
            this.WriteLine("exports.initialize = initialize;");
            this.WriteLine();

            this.WriteLineEnd("})(typeof exports == 'undefined' ? this['ajtalk'] = {} : exports,");
            this.WriteLine("typeof global == 'undefined' ? this : global");
            this.WriteLine(");");
        }

        public override void Visit(ClassModel @class)
        {
            // TODO review
            if (@class.SuperClass == null)
                return;

            string instanceVariableNames = string.Empty;
            string classVariableNames = string.Empty;

            if (@class.InstanceVariableNames != null && @class.InstanceVariableNames.Count > 0)
            {
                instanceVariableNames = @class.InstanceVariableNames.First();

                foreach (var name in @class.InstanceVariableNames.Skip(1))
                    instanceVariableNames += " " + name;
            }

            if (@class.ClassVariableNames != null && @class.ClassVariableNames.Count > 0)
            {
                classVariableNames = @class.ClassVariableNames.First();

                foreach (var name in @class.ClassVariableNames.Skip(1))
                    classVariableNames += " " + name;
            }

            this.WriteLine(string.Format("Smalltalk.{0}.subclass_instanceVariablesNames_classVariablesNames('{1}', '{2}', '{3}');",
                @class.SuperClass.Name,
                @class.Name,
                instanceVariableNames,
                classVariableNames));

            foreach (MethodModel method in @class.InstanceMethods)
                method.Visit(this);
        }

        public override void Visit(MethodModel method)
        {
            if (method.Class != null)
            {
                if (method.Class.Name.EndsWith(" class"))
                    this.Write(string.Format("Smalltalk.{0}.defineClassMethod('{1}', function(", method.Class.Name.Substring(0, method.Class.Name.Length - " class".Length), method.Selector));
                else
                    this.Write(string.Format("Smalltalk.{0}.defineMethod('{1}', function(", method.Class.Name, method.Selector));
            }
            else
            {
                this.Write(string.Format("function {0}(", ToMethodName(method.Selector)));
            }

            int nparameters = 0;

            foreach (string name in method.ParameterNames)
            {
                if (nparameters > 0)
                    this.Write(", ");
                this.Write(name);
                nparameters++;
            }

            this.WriteLine(")");
            this.WriteLineStart("{");
            this.WriteLine("var self = this;");

            // TODO Review local variable for block returns
            if (method.HasBlock())
                this.WriteLine("var __context = {};");

            this.WriteLine(string.Format("console.log('{0}');", ToMethodName(method.Selector)));

            foreach (string locname in method.LocalVariables)
                this.WriteLine(string.Format("var {0} = null", ToVariableName(locname)));

            MethodModel previousMethod = this.currentMethod;

            try
            {
                this.currentMethod = method;
                this.Visit(method.Body);
            }
            finally
            {
                this.currentMethod = previousMethod;
            }

            if (method.Class != null)
                this.WriteLineEnd("});");
            else
                this.WriteLineEnd("};");
        }

        public override void Visit(MessageExpression expression)
        {
            if (this.currentMethod != null && expression.Target is ILeftValue && ((ILeftValue)expression.Target).Name == "super")
            {
                base.Visit(expression);
                return;
            }

            expression.Target.Visit(this);

            if (char.IsLetter(expression.Selector[0]))
                this.Write(string.Format(".{0}(", ToMethodName(expression.Selector)));
            else
                this.Write(string.Format("['{0}'](", ToMethodName(expression.Selector)));

            int narg = 0;

            foreach (var argument in expression.Arguments)
            {
                if (narg > 0)
                    this.Write(", ");

                argument.Visit(this);

                narg++;
            }

            this.Write(")");
        }
    }
}
