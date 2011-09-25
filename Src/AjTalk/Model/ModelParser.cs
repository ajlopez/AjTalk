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
        private ClassModel @class;
        private bool isClassMethod;

        public ModelParser(Lexer tok)
        {
            this.tokenizer = tok;
        }

        public ModelParser(string text)
            : this(new Lexer(text))
        {
            this.source = text;
        }

        public MethodModel ParseMethod(ClassModel @class, bool isClassMethod)
        {
            this.@class = @class;
            this.isClassMethod = isClassMethod;
            return this.ParseMethod();
        }

        public MethodModel ParseMethod()
        {
            string name = this.ParseNameOrOperator();
            string selector;
            IList<string> parameterNames = new List<string>();
            IList<string> localVariables = new List<string>();

            if (IsUnarySelector(name))
                selector = name;
            else if (IsBinarySelector(name)) 
            {
                selector = name;
                parameterNames.Add(this.ParseSimpleName());
            }
            else
            {
                selector = name;

                parameterNames.Add(this.ParseSimpleName());

                name = this.TryParseMultipleKeywordSelector();

                while (name != null) 
                {
                    selector += name;
                    parameterNames.Add(this.ParseSimpleName());
                    name = this.TryParseMultipleKeywordSelector();
                }
            }

            if (this.TryParseBar())
            {
                string varname;

                while ((varname = this.TryParseSimpleName()) != null)
                {
                    localVariables.Add(varname);
                }

                this.ParseBar();
            }

            IExpression body = this.ParseExpressions();

            MethodModel model = new MethodModel(selector, parameterNames, localVariables, body, this.@class, this.isClassMethod);

            Token token = this.NextToken();

            if (token != null)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return model;
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
            {
                // TODO refactor
                if (token.Type != TokenType.Punctuation || (token.Value != "]" && token.Value != ")"))
                    throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

                this.PushToken(token);
            }

            return expression;
        }

        public IExpression ParseExpression()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Operator && token.Value == "^")
                return new ReturnExpression(this.ParseMultipleKeywordExpression());

            this.PushToken(token);

            IExpression expression = this.ParseMultipleKeywordExpression();
            return expression;
        }

        private static bool IsUnarySelector(string name)
        {
            return char.IsLetter(name[0]) && !name.EndsWith(":");
        }

        private static bool IsBinarySelector(string name)
        {
            // TODO Review which selectors are binary operators
            return !char.IsLetter(name[0]);
        }

        private static bool IsMultipleKeywordSelector(string name)
        {
            return name.EndsWith(":");
        }

        private IExpression ParseMultipleKeywordExpression()
        {
            IExpression model = this.ParseBinaryExpression();

            if (model == null)
                return model;

            string selector = this.TryParseMultipleKeywordSelector();

            if (selector == null)
                return model;

            string name = selector;
            List<IExpression> arguments = new List<IExpression>();

            while (selector != null)
            {
                arguments.Add(this.ParseBinaryExpression());
                selector = this.TryParseMultipleKeywordSelector();
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

            if (expression is ILeftValue && this.TryParseSet())
            {
                return new SetExpression((ILeftValue) expression, this.ParseExpression());
            }

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

                    if (this.@class != null && this.isClassMethod == false && this.@class.InstanceVariableNames.Contains(token.Value))
                        return new InstanceVariableExpression(token.Value);

                    if (this.@class != null && this.isClassMethod == true && this.@class.ClassVariableNames.Contains(token.Value))
                        return new ClassVariableExpression(token.Value, this.@class);

                    return new VariableExpression(token.Value);

                case TokenType.String:
                    return new ConstantExpression(token.Value);

                case TokenType.Symbol:
                    return new SymbolExpression(token.Value);

                case TokenType.Operator:
                    if (token.Value == "<")
                        return this.ParsePrimitive();
                    break;

                case TokenType.Punctuation:
                    if (token.Value == "[")
                        return this.ParseBlock();
                    if (token.Value == "(")
                    {
                        IExpression expression = this.ParseExpression();
                        Token lasttoken = this.NextToken();
                        if (lasttoken == null || lasttoken.Type != TokenType.Punctuation || lasttoken.Value != ")")
                            throw new ParserException("Expected ')'");
                        return expression;
                    }
                    break;

                case TokenType.Integer:
                    return new ConstantExpression(Convert.ToInt32(token.Value, CultureInfo.InvariantCulture));
            }

            this.PushToken(token);

            return null;
        }

        private Token NextToken()
        {
            return this.tokenizer.NextToken();
        }

        private void PushToken(Token token)
        {
            this.tokenizer.PushToken(token);
        }

        private IExpression ParseBlock()
        {
            IExpression body = this.ParseExpressions();
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Punctuation || token.Value != "]")
                throw new ParserException("Expected ']'");

            return new BlockExpression(body);
        }

        private IExpression ParsePrimitive()
        {
            this.ParseToken(TokenType.Name, "primitive:");
            int primitive = this.ParseInteger();
            this.ParseToken(TokenType.Operator, ">");

            return new PrimitiveExpression(primitive);
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

        private string ParseName()
        {
            Token token = this.NextToken();

            if (token == null)
                throw new ParserException("Expected name");

            if (token.Type != TokenType.Name)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return token.Value;
        }

        private string ParseSimpleName()
        {
            Token token = this.NextToken();

            if (token == null)
                throw new ParserException("Expected name");

            if (token.Type != TokenType.Name || IsMultipleKeywordSelector(token.Value))
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return token.Value;
        }

        private string ParseNameOrOperator()
        {
            Token token = this.NextToken();

            if (token == null)
                throw new ParserException("Expected name or operator");

            if (token.Type != TokenType.Name && token.Type != TokenType.Operator)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return token.Value;
        }

        private void ParseBar()
        {
            Token token = this.NextToken();

            if (token == null)
                throw new ParserException("Expected '|'");

            if (token.Type != TokenType.Punctuation || token.Value != "|")
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));
        }

        private string TryParseMultipleKeywordSelector()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Name && IsMultipleKeywordSelector(token.Value))
                return token.Value;

            this.PushToken(token);

            return null;
        }

        private string TryParseSimpleName()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type != TokenType.Name || IsMultipleKeywordSelector(token.Value))
            {
                this.PushToken(token);
                return null;
            }

            return token.Value;
        }

        private bool TryParseBar()
        {
            Token token = this.NextToken();

            if (token == null)
                return false;

            if (token.Type != TokenType.Punctuation || token.Value != "|")
            {
                this.PushToken(token);
                return false;
            }

            return true;
        }

        private bool TryParseSet()
        {
            Token token = this.NextToken();

            if (token == null)
                return false;

            if (token.Type != TokenType.Operator || token.Value != ":=")
            {
                this.PushToken(token);
                return false;
            }

            return true;
        }

        private void ParseToken(TokenType type, string value)
        {
            Token token = this.NextToken();

            if (token == null || token.Type != type || token.Value != value)
                throw new ParserException(string.Format("Expected '{0}'", value));
        }

        private int ParseInteger()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Integer)
                throw new ParserException("Integer Expected");

            return Convert.ToInt32(token.Value, CultureInfo.InvariantCulture);
        }
    }
}
