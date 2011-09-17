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

        public IExpression ParseExpressions()
        {
            IExpression expression = this.ParseExpression();

            if (expression == null)
                return null;

            if (this.TryParseDot())
            {
                List<IExpression> expressions = new List<IExpression>();
                expressions.Add(expression);
                expressions.Add(this.ParseExpression());

                while (this.TryParseDot())
                {
                    expressions.Add(this.ParseExpression());
                }

                expression = new CompositeExpression(expressions);
            }

            Token token = this.NextToken();

            if (token != null)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return expression;
        }

        public IExpression ParseExpression()
        {
            IExpression expression = this.ParseMultipleExpression();
            return expression;
        }

        private static bool IsUnarySelector(string name)
        {
            return !name.EndsWith(":");
        }

        private static bool IsBinarySelector(string name)
        {
            // TODO Review which selectors are binary operators
            return true;
        }

        private IExpression ParseMultipleExpression()
        {
            IExpression model = this.ParseBinaryExpression();

            if (model == null)
                return model;

            string selector = this.TryParseMultipleSelector();

            if (selector == null)
                return model;

            string name = selector;
            List<IExpression> arguments = new List<IExpression>();

            while (selector != null)
            {
                arguments.Add(this.ParseBinaryExpression());
                selector = this.TryParseMultipleSelector();
                if (selector != null)
                    name += selector;
            }

            return new MessageExpression(model, name, arguments);
        }

        private IExpression ParseBinaryExpression()
        {
            IExpression expression = this.ParseSimpleExpression();

            if (expression == null)
                return expression;

            string selector = this.TryParseBinarySelector();

            while (selector != null)
            {
                List<IExpression> arguments = new List<IExpression>();
                arguments.Add(this.ParseSimpleExpression());
                expression = new MessageExpression(expression, selector, arguments);
                selector = this.TryParseBinarySelector();
            }

            return expression;
        }

        private IExpression ParseSimpleExpression()
        {
            IExpression expression = this.ParseHeadExpression();

            if (expression == null)
                return expression;

            string selector = this.TryParseUnarySelector();

            while (selector != null)
            {
                expression = new MessageExpression(expression, selector, null);
                selector = this.TryParseUnarySelector();
            }

            return expression;
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
                    if (token.Value == "true")
                        return new ConstantExpression(true);
                    if (token.Value == "false")
                        return new ConstantExpression(false);

                    return new VariableExpression(token.Value);

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

        private string TryParseBinarySelector()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Operator && IsBinarySelector(token.Value))
                return token.Value;

            this.PushToken(token);

            return null;
        }

        private bool TryParseDot()
        {
            Token token = this.NextToken();

            if (token == null)
                return false;

            if (token.Type == TokenType.Punctuation && token.Value == ".")
                return true;

            this.PushToken(token);

            return false;
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
