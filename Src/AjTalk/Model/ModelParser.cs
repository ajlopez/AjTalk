namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using System.Globalization;

    public class ModelParser
    {
        private Lexer tokenizer;
        private string source;

        public ModelParser(Lexer tok)
        {
            this.tokenizer = tok;
        }

        public ModelParser(string text)
            : this(new Lexer(text))
        {
            this.source = text;
        }

        public IExpression ParseExpression()
        {
            IExpression model = this.ParseMultipleExpression();
            return model;
        }

        private static bool IsUnarySelector(string name)
        {
            return !name.EndsWith(":");
        }

        private IExpression ParseMultipleExpression()
        {
            IExpression model = this.ParseSimpleExpression();

            if (model == null)
                return model;

            string selector = this.TryParseMultipleSelector();

            if (selector == null)
                return model;

            string name = selector;
            List<IExpression> arguments = new List<IExpression>();

            while (selector != null)
            {
                arguments.Add(this.ParseSimpleExpression());
                selector = this.TryParseMultipleSelector();
                if (selector != null)
                    name += selector;
            }

            return new MessageExpression(model, name, arguments);
        }

        private IExpression ParseSimpleExpression()
        {
            IExpression model = this.ParseHeadExpression();

            if (model == null)
                return model;

            string selector = this.TryParseUnarySelector();

            while (selector != null)
            {
                model = new MessageExpression(model, selector, null);
                selector = this.TryParseUnarySelector();
            }

            return model;
        }

        private IExpression ParseHeadExpression()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            switch (token.Type)
            {
                case TokenType.Name:
                    if (token.Value == "self")
                        return new SelfExpression();

                    return new InstanceVariableExpression(token.Value);

                case TokenType.String:
                    return new ConstantExpression(token.Value);

                case TokenType.Integer:
                    return new ConstantExpression(Convert.ToInt32(token.Value, CultureInfo.InvariantCulture));
            }

            throw new ParserException(string.Format("Unknown '{0}'", token.Value));
        }

        private Token NextToken()
        {
            return this.tokenizer.NextToken();
        }

        private void PushToken(Token token)
        {
            this.tokenizer.PushToken(token);
        }

        private string TryParseUnarySelector()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Name && IsUnarySelector(token.Value))
                return token.Value;

            this.PushToken(token);

            return null;
        }

        private string TryParseMultipleSelector()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Name && !IsUnarySelector(token.Value))
                return token.Value;

            this.PushToken(token);

            return null;
        }
    }
}
