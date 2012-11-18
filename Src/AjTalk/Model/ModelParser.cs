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

            IEnumerable<IExpression> body = this.ParseExpressions();

            MethodModel model = new MethodModel(selector, parameterNames, localVariables, body, this.@class, this.isClassMethod);

            Token token = this.NextToken();

            if (token != null)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            return model;
        }

        public IEnumerable<IExpression> ParseExpressions()
        {
            IExpression expression = this.ParseExpression();

            if (expression == null)
                return null;

            List<IExpression> expressions = new List<IExpression>();
            expressions.Add(expression);

            if ((this.TryParseDot() || expression is PrimitiveExpression) && this.IsNotEndOfInput())
            {
                IExpression expr = this.ParseExpression();

                if (expr != null)
                {
                    expressions.Add(expr);

                    while (this.TryParseDot() && this.IsNotEndOfInput())
                    {
                        expr = this.ParseExpression();

                        if (expr == null)
                            break;

                        expressions.Add(expr);
                    }
                }
            }

            Token token = this.NextToken();

            if (token != null) 
            {
                // TODO refactor
                if (token.Type != TokenType.Punctuation || (token.Value != "]" && token.Value != ")" && token.Value != "}"))
                    throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

                this.PushToken(token);
            }

            return expressions;
        }

        public IExpression ParseExpression()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Operator && token.Value == "^")
                return new ReturnExpression(this.ParseExpression());

            this.PushToken(token);

            IExpression expression = this.ParseHeadExpression();

            if (expression is PrimitiveExpression)
                return expression;
            
            return this.ParseExpression(expression);
        }

        private IExpression ParseExpression(IExpression target)
        {
            IExpression expression = this.ParseMultipleKeywordExpression(target);

            Token token = this.NextToken();

            while (token != null && token.Type == TokenType.Punctuation && token.Value == ";")
            {
                expression = this.ParseFluentExpression(expression);
                token = this.NextToken();
            }

            this.PushToken(token);

            return expression;
        }

        private IExpression ParseFluentExpression(IExpression target)
        {
            IExpression expr = target;

            if (target is MessageExpression)
                expr = new FluentMessageExpression((MessageExpression)target);

            return this.ParseMultipleKeywordExpression(expr);
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
            IExpression expression = this.ParseHeadExpression();
            return this.ParseMultipleKeywordExpression(expression);
        }

        private IExpression ParseBinaryExpression()
        {
            IExpression expression = this.ParseHeadExpression();

            if (expression == null)
                return null;

            return this.ParseBinaryExpression(expression);
        }

        private IExpression ParseSimpleExpression()
        {
            IExpression expression = this.ParseHeadExpression();

            if (expression == null)
                return expression;

            return this.ParseSimpleExpression(expression);
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
                    if (token.Value == "nil" || token.Value == "null")
                        return new ConstantExpression(null);

                    if (this.@class != null && this.isClassMethod == false && this.@class.InstanceVariableNames.Contains(token.Value))
                        return new InstanceVariableExpression(token.Value);

                    if (this.@class != null && this.isClassMethod == true && this.@class.ClassVariableNames.Contains(token.Value))
                        return new ClassVariableExpression(token.Value, this.@class);

                    return new VariableExpression(token.Value);

                case TokenType.String:
                    return new ConstantExpression(token.Value);

                case TokenType.Character:
                    return new ConstantExpression(token.Value[0]);

                case TokenType.Symbol:
                    return new SymbolExpression(token.Value);

                case TokenType.Operator:
                    if (token.Value == "<")
                        return this.ParsePrimitive();
                    if (token.Value == "-")
                        return new MessageExpression(this.ParseHeadExpression(), "-", null);
                    break;

                case TokenType.Punctuation:
                    if (token.Value == "[")
                        return this.ParseBlock();

                    if (token.Value == "#(")
                        return this.ParseArray();

                    if (token.Value == "{")
                        return this.ParseDynamicArray();
                        
                    if (token.Value == "(")
                    {
                        IExpression expression = this.ParseExpression();
                        Token lasttoken = this.NextToken();
                        if (lasttoken == null || lasttoken.Type != TokenType.Punctuation || lasttoken.Value != ")")
                        {
                            this.PushToken(lasttoken);
                            return this.ParseExpression(expression);
                        }
                        return expression;
                    }
                    break;

                case TokenType.Integer:
                    return new ConstantExpression(Convert.ToInt32(token.Value, CultureInfo.InvariantCulture));

                case TokenType.Real:
                    return new ConstantExpression(Convert.ToDouble(token.Value, CultureInfo.InvariantCulture));
            }

            this.PushToken(token);

            return null;
        }

        private IExpression ParseArray()
        {
            IList<IExpression> items = new List<IExpression>();

            for (IExpression item = this.ParseCollectionItem(); item != null; item = this.ParseCollectionItem())
                items.Add(item);

            this.ParseToken(TokenType.Punctuation, ")");

            return new ArrayExpression(items);
        }

        private IExpression ParseDynamicArray()
        {
            IEnumerable<IExpression> items = this.ParseExpressions();

            this.ParseToken(TokenType.Punctuation, "}");

            return new DynamicArrayExpression(items);
        }

        private IExpression ParseCollectionItem()
        {
            Token token = this.NextToken();

            if (token == null)
                return null;

            if (token.Type == TokenType.Punctuation && token.Value == ")")
            {
                this.PushToken(token);
                return null;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "(")
                return this.ParseArray();

            // TODO review if operators in collections are symbols or not
            if (token.Type == TokenType.Name || token.Type == TokenType.Operator)
                return new SymbolExpression(token.Value);

            if (token.Type == TokenType.Symbol)
                throw new ParserException(string.Format("Unexpected '{0}'", token.Value));

            if (token.Type == TokenType.Integer)
                return new ConstantExpression(Convert.ToInt32(token.Value, CultureInfo.InvariantCulture));

            if (token.Type == TokenType.Real)
                return new ConstantExpression(Convert.ToDouble(token.Value, CultureInfo.InvariantCulture));

            return new ConstantExpression(token.Value);
        }

        private IExpression ParseMultipleKeywordExpression(IExpression target)
        {
            IExpression model = this.ParseBinaryExpression(target);

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

        private IExpression ParseBinaryExpression(IExpression target)
        {
            IExpression expression = this.ParseSimpleExpression(target);

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

        private IExpression ParseSimpleExpression(IExpression expression)
        {
            if (expression is ILeftValue && this.TryParseSet())
            {
                return new SetExpression((ILeftValue)expression, this.ParseExpression());
            }

            string selector = this.TryParseUnarySelector();

            while (selector != null)
            {
                expression = new MessageExpression(expression, selector, null);
                selector = this.TryParseUnarySelector();
            }

            return expression;
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
            IList<string> parameterNames = this.ParseBlockParameters();
            IList<string> localVariables = this.ParseBlockLocalVariables();
            IEnumerable<IExpression> body = this.ParseExpressions();
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Punctuation || token.Value != "]")
                throw new ParserException("Expected ']'");

            return new BlockExpression(parameterNames, localVariables, body);
        }

        private IList<string> ParseBlockParameters()
        {
            IList<string> parameterNames = new List<string>();

            Token token = this.NextToken();

            while (token != null && token.Type == TokenType.Parameter)
            {
                parameterNames.Add(token.Value);
                token = this.NextToken();
            }

            if (parameterNames.Count == 0)
                this.PushToken(token);
            else if (token == null || token.Type != TokenType.Punctuation || token.Value != "|")
                throw new ParserException("Expected '|'");

            return parameterNames;
        }

        private IList<string> ParseBlockLocalVariables()
        {
            IList<string> localVariables = new List<string>();

            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Punctuation || token.Value != "|")
            {
                this.PushToken(token);
                return localVariables;
            }
            
            token = this.NextToken();

            while (token != null && token.Type == TokenType.Name)
            {
                localVariables.Add(token.Value);
                token = this.NextToken();
            }

            if (token == null || token.Type != TokenType.Punctuation || token.Value != "|")
                throw new ParserException("Expected '|'");

            return localVariables;
        }

        private IExpression ParsePrimitive()
        {
            this.ParseToken(TokenType.Name, "primitive:");
            int number;
            string name;
            string module;
            IExpression primitive = null;

            Token token = this.NextToken();

            if (token.Type == TokenType.Integer)
            {
                number = Convert.ToInt32(token.Value, CultureInfo.InvariantCulture);
                primitive = new PrimitiveExpression(number);
            }
            else if (token.Type == TokenType.String)
            {
                name = token.Value;
                this.ParseToken(TokenType.Name, "module:");
                module = this.ParseString();
                primitive = new PrimitiveExpression(name, module);
            }
            else
                throw new ParserException("String or Number expected in Primitive");

            this.ParseToken(TokenType.Operator, ">");

            return primitive;
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

            if (token.Type == TokenType.Punctuation && token.Value == "|")
                return token.Value;

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

            if (!token.IsName() && !token.IsOperator())
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

        private bool IsNotEndOfInput()
        {
            Token token = this.NextToken();

            if (token == null)
                return false;

            this.PushToken(token);

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

        private string ParseString()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.String)
                throw new ParserException("String Expected");

            return token.Value;
        }
    }
}
