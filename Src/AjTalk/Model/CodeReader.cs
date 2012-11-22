namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class CodeReader
    {
        private ChunkReader reader;

        public CodeReader(ChunkReader reader)
        {
            this.reader = reader;
        }

        public void Process(CodeModel model)
        {
            for (string chunk = this.reader.GetChunk(); chunk != null; chunk = this.reader.GetChunk())
            {
                bool isreader = false;

                if (chunk.StartsWith("!"))
                {
                    chunk = chunk.Substring(1);
                    isreader = true;
                }

                ModelParser parser = new ModelParser(chunk);
                IExpression expression = parser.ParseExpression();

                if (isreader)
                {
                    if (expression is MessageExpression && ((MessageExpression)expression).Selector.Contains("methodsFor:"))
                        this.ProcessMethods(model, (MessageExpression)expression);
                    else if (expression is MessageExpression && ((MessageExpression)expression).Selector.Contains("commentStamp:"))
                        this.ProcessComment(model, (MessageExpression)expression);
                    else
                        this.ProcessReader();
                }
                else
                {
                    if (expression is MessageExpression)
                        this.ProcessMessageExpression(model, (MessageExpression)expression);
                }
            }
        }

        private static IList<string> GetInstanceVariableNames(MessageExpression expression)
        {
            return GetNamesFromArgument(expression, "instanceVariableNames");
        }

        private static IList<string> GetClassVariableNames(MessageExpression expression)
        {
            return GetNamesFromArgument(expression, "classVariableNames");
        }

        private static IList<string> GetPoolDictionariesNames(MessageExpression expression)
        {
            return GetNamesFromArgument(expression, "poolDictionaries");
        }

        private static string GetCategory(MessageExpression expression)
        {
            return GetArgument(expression, "category");
        }

        private static string GetArgument(MessageExpression expression, string key)
        {
            string[] keys = expression.Selector.Split(':');

            for (int k = 0; k < keys.Length; k++)
                if (keys[k] == key)
                    return (string)((ConstantExpression)expression.Arguments.ElementAt(k)).Value;

            return null;
        }

        private static IList<string> GetNamesFromArgument(MessageExpression expression, string key)
        {
            string[]keys = expression.Selector.Split(':');

            for (int k = 0; k < keys.Length; k++)
                if (keys[k] == key)
                    return GetNames((ConstantExpression)expression.Arguments.ElementAt(k));

            return null;
        }

        private static IList<string> GetNames(ConstantExpression expression)
        {
            string names = (string)expression.Value;

            if (string.IsNullOrEmpty(names))
                return null;

            return names.Split(' ');
        }

        private void ProcessReader()
        {
            for (string chunk = this.reader.GetChunk(); chunk != null; chunk = this.reader.GetChunk())
                if (string.IsNullOrEmpty(chunk.Trim()))
                    break;
        }

        private void ProcessMethods(CodeModel model, MessageExpression expression)
        {
            string className = expression.Target.AsString();
            ClassModel @class = model.GetClass(className);

            for (string chunk = this.reader.GetChunk(); chunk != null; chunk = this.reader.GetChunk())
            {
                if (string.IsNullOrEmpty(chunk.Trim()))
                    break;
                ModelParser parser = new ModelParser(chunk);
                MethodModel method = parser.ParseMethod(@class, false);
                model.AddElement(method);
            }
        }

        private void ProcessComment(CodeModel model, MessageExpression expression)
        {
            this.reader.GetChunk();
        }

        private void ProcessMessageExpression(CodeModel model, MessageExpression expression)
        {
            // TODO implements weakSubclass
            if (expression.Selector.StartsWith("subclass:") || expression.Selector.StartsWith("weakSubclass:") || expression.Selector.StartsWith("variableSubclass:"))
            {
                bool isvariable = expression.Selector.StartsWith("variableSubclass:");
                SymbolExpression symbol = (SymbolExpression)expression.Arguments.First();
                VariableExpression variable = (VariableExpression)expression.Target;

                ClassModel super = null;

                if (variable.Name != null && variable.Name != symbol.Symbol)
                    //// TODO review quick hack if class is not defined yet
                    if (model.HasClass(variable.Name))
                        super = model.GetClass(variable.Name);

                ClassModel @class;

                if (super != null || variable.Name == null)
                    @class = new ClassModel(symbol.Symbol, super, GetInstanceVariableNames(expression), GetClassVariableNames(expression), isvariable, GetPoolDictionariesNames(expression), GetCategory(expression));
                else
                    @class = new ClassModel(symbol.Symbol, variable.Name, GetInstanceVariableNames(expression), GetClassVariableNames(expression), isvariable, GetPoolDictionariesNames(expression), GetCategory(expression));

                model.AddElement(@class);
            }
        }
    }
}
