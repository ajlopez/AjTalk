namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class CodeReader
    {
        ChunkReader reader;

        public CodeReader(ChunkReader reader)
        {
            this.reader = reader;
        }

        public void Process(CodeModel model)
        {
            for (string chunk = this.reader.GetChunk(); chunk != null; chunk = this.reader.GetChunk())
            {
                bool isreader = false;

                if (chunk.StartsWith("!")) {
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
            if (expression.Selector.StartsWith("subclass:"))
            {
                SymbolExpression symbol = (SymbolExpression) expression.Arguments.First();
                ClassModel @class = new ClassModel(symbol.Symbol, null, null, null);
                model.AddElement(@class);
            }
        }
    }
}
