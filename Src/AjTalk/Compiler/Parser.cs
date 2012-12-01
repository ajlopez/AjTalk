namespace AjTalk.Compiler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AjTalk.Language;

    public class Parser
    {
        private Lexer tokenizer;
        private IList arguments = new ArrayList();
        private IList locals = new ArrayList();
        private string methodname;
        private Block block;
        private string source;

        public Parser(Lexer tok)
        {
            this.tokenizer = tok;
        }

        public Parser(string text)
            : this(new Lexer(text))
        {
            this.source = text;
        }

        public Block CompileBlock()
        {
            this.block = new Block(this.source);
            this.CompileBlockArguments();
            this.CompileLocals();
            
            // TODO review why to use this.locals instead of this.block.CompileLocal directly
            foreach (string argname in this.arguments)
                this.block.CompileArgument(argname);

            foreach (string locname in this.locals)
                this.block.CompileLocal(locname);

            this.CompileBody();

            return this.block;
        }

        public Method CompileInstanceMethod(IBehavior cls)
        {
            this.CompileMethod(cls);
            return (Method)this.block;
        }

        public Method CompileClassMethod(IBehavior cls)
        {
            this.CompileMethod(cls.MetaClass); // use metaclass
            return (Method)this.block;
        }

        private Token NextToken()
        {
            return this.tokenizer.NextToken();
        }

        private void PushToken(Token token)
        {
            this.tokenizer.PushToken(token);
        }

        private void CompileKeywordArguments()
        {
            Token token;

            this.methodname = string.Empty;

            while (true)
            {
                token = this.NextToken();

                if (token == null)
                {
                    return;
                }

                if (token.Type != TokenType.Name || !token.Value.EndsWith(":"))
                {
                    this.PushToken(token);
                    return;
                }

                this.methodname += token.Value;

                token = this.NextToken();

                if (token == null || token.Type != TokenType.Name)
                {
                    throw new ParserException("Argument expected");
                }

                this.arguments.Add(token.Value);
            }
        }

        private void CompileLocals()
        {
            Token token = this.NextToken();

            if (token == null)
            {
                return;
            }

            if (token.Value != "|")
            {
                this.PushToken(token);
                return;
            }

            token = this.NextToken();

            while (token != null && token.Value != "|")
            {
                if (token.Type != TokenType.Name)
                {
                    throw new ParserException("Local variable name expected");
                }

                this.locals.Add(token.Value);

                token = this.NextToken();
            }

            if (token == null)
            {
                throw new ParserException("'|' expected");
            }
        }

        private void CompileArguments()
        {
            Token token = this.NextToken();

            if (token == null)
            {
                throw new ParserException("Argument expected");
            }

            // TODO Review if this code is needed
            if (token.Type == TokenType.Operator || (token.Type == TokenType.Punctuation && token.Value == "|"))
            {
                this.methodname = token.Value;
                token = this.NextToken();
                if (token == null || token.Type != TokenType.Name)
                {
                    throw new ParserException("Argument expected");
                }

                this.arguments.Add(token.Value);

                return;
            }

            if (token.Type != TokenType.Name)
            {
                throw new ParserException("Argument expected");
            }

            if (token.Value.EndsWith(":"))
            {
                this.PushToken(token);
                this.CompileKeywordArguments();
                return;
            }

            this.methodname = token.Value;
        }

        private void CompileBlockArguments()
        {
            Token token;
            int nparameters = 0;

            for (token = this.NextToken(); token != null && (token.Type == TokenType.Parameter || token.Type == TokenType.Operator && token.Value == ":"); nparameters++, token = this.NextToken())
            {
                if (token.Type == TokenType.Parameter)
                    this.arguments.Add(token.Value);
                else
                    this.arguments.Add(this.CompileName());
            }

            if (nparameters > 0)
            {
                if (token == null)
                    throw new ParserException("Unexpected end of input");
                if (token.Type != TokenType.Punctuation || token.Value != "|")
                    throw new ParserException("Expected '|'");
            }
            else
                this.PushToken(token);
        }

        private string CompileName()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Name)
                throw new ParserException("Name expected");

            return token.Value;
        }

        private int CompileInteger()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Integer)
                throw new ParserException("Integer expected");

            return Convert.ToInt32(token.Value);
        }

        private string CompileString()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.String)
                throw new ParserException("String expected");

            return token.Value;
        }

        private int? TryCompileInteger()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Integer)
            {
                this.PushToken(token);
                return null;
            }

            return Convert.ToInt32(token.Value);
        }

        private void CompileTerm()
        {
            if (this.TryCompileToken(TokenType.Operator, "-"))
            {
                this.CompileTerm();
                this.block.CompileSend("minus");
                return;
            }

            Token token = this.NextToken();

            if (token == null)
            {
                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == ";")
            {
                this.block.CompileByteCode(ByteCode.ChainedSend);
                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "(")
            {
                this.CompileExpression();
                token = this.NextToken();
                if (token == null || token.Value != ")")
                {
                    throw new ParserException("')' expected");
                }

                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "#(")
            {
                this.block.CompileGetConstant(this.CompileCollection());

                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "#[")
            {
                this.CompileByteCollection();

                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "{")
            {
                this.CompileDynamicCollection();

                return;
            }

            if (token.Type == TokenType.Punctuation && token.Value == "[")
            {
                Parser newcompiler = new Parser(this.tokenizer);
                
                // TODO Review is the copy of argument and local names is needed
                newcompiler.arguments = new ArrayList(this.arguments);
                newcompiler.locals = new ArrayList(this.locals);

                Block newblock = newcompiler.CompileBlock();

                this.block.CompileGetBlock(newblock);
                return;
            }

            if (token.Type == TokenType.Integer)
            {
                long value = 0;
                int position = token.Value.IndexOf('r');

                if (position > 0)
                {
                    string strradix = token.Value.Substring(0, position);
                    string strnumber = token.Value.Substring(position + 1);
                    value = Convert.ToInt64(strnumber, Convert.ToInt32(strradix));
                }
                else
                    value = Convert.ToInt64(token.Value);

                if (value > int.MaxValue || value < int.MinValue)
                    this.block.CompileGetConstant(value);
                else
                    this.block.CompileGetConstant((int)value);

                return;
            }

            if (token.Type == TokenType.Real)
            {
                this.block.CompileGetConstant(Convert.ToDouble(token.Value));
                return;
            }

            if (token.Type == TokenType.String)
            {
                this.block.CompileGetConstant(token.Value);
                return;
            }

            // TODO Review compile of Symbol
            if (token.Type == TokenType.Symbol)
            {
                this.block.CompileGetConstant(token.Value);
                return;
            }

            if (token.Type == TokenType.Character)
            {
                this.block.CompileGetConstant(token.Value[0]);
                return;
            }

            if (token.Type == TokenType.Name)
            {
                this.block.CompileGet(token.Value);
                return;
            }

            if (token.Type == TokenType.DottedName)
            {
                string[] names = token.Value.Split('.');
                this.block.CompileByteCode(ByteCode.GetGlobalVariable, (byte)this.block.CompileGlobal(names[0]));

                foreach (var name in names.Skip(1)) 
                {
                    this.block.CompileGetConstant(name);
                    this.block.CompileSend("at:");
                }

                return;
            }

            if (token.Type == TokenType.Operator && token.Value == "<" && this.TryCompileToken(TokenType.Name, "primitive:"))
            {
                int? number = this.TryCompileInteger();

                if (number.HasValue)
                {
                    string error = null;
                    if (this.TryCompileToken(TokenType.Name, "error:"))
                        error = this.CompileName();

                    this.CompileToken(TokenType.Operator, ">");
                    if (error != null)
                        this.block.CompileByteCode(ByteCode.PrimitiveError, (byte)number.Value, (byte)this.block.CompileConstant(error));
                    else
                        this.block.CompileByteCode(ByteCode.Primitive, (byte)number.Value);
                    return;
                }

                string name = this.CompileString();
                this.CompileToken(TokenType.Name, "module:");
                string module = this.CompileString();
                this.CompileToken(TokenType.Operator, ">");

                this.block.CompileByteCode(ByteCode.NamedPrimitive, this.block.CompileConstant(name), this.block.CompileConstant(module));

                return;
            }

            throw new ParserException("Name expected");
        }

        private object[] CompileCollection()
        {
            Token token = this.NextToken();
            IList<object> elements = new List<object>();

            while (token != null)
            {
                switch (token.Type)
                {
                    case TokenType.Integer:
                        elements.Add(Convert.ToInt32(token.Value));
                        break;
                    case TokenType.Real:
                        elements.Add(Convert.ToDouble(token.Value));
                        break;
                    case TokenType.Symbol:
                    case TokenType.String:
                    case TokenType.Name:
                        elements.Add(token.Value);
                        break;

                    case TokenType.Punctuation:
                        if (token.Value == ")")
                            return elements.ToArray();

                        if (token.Value == "(")
                            elements.Add(this.CompileCollection());
                        else
                            throw new ParserException("Expected ')'");
                        break;
                    default:
                        throw new ParserException("Expected ')'");
                }

                token = this.NextToken();
            }

            return elements.ToArray();
        }
        
        private void CompileByteCollection()
        {
            IList<byte> bytes = new List<byte>();
            Token token = this.NextToken();

            while (token != null && !(token.Type == TokenType.Punctuation && token.Value == "]"))
            {
                switch (token.Type) 
                {
                    case TokenType.Integer:
                        bytes.Add((byte)Convert.ToInt32(token.Value));
                        break;
                    default:
                        throw new ParserException("Expected ']'");
                }

                token = this.NextToken();
            }

            this.block.CompileGetConstant(bytes.ToArray());
        }

        private void CompileDynamicCollection()
        {
            int nelements = 0;

            while (!this.TryCompileToken(TokenType.Punctuation, "}"))
            {
                if (nelements > 0)
                    this.CompileToken(TokenType.Punctuation, ".");

                this.CompileExpression();
                nelements++;
            }

            this.block.CompileByteCode(ByteCode.MakeCollection, (byte)nelements);
        }

        private void CompileUnaryExpression()
        {
            this.CompileTerm();

            Token token;

            token = this.NextToken();

            while (token != null && token.Type == TokenType.Name && !token.Value.EndsWith(":") && token.Value != "self")
            {
                this.block.CompileSend(token.Value);
                token = this.NextToken();
            }

            if (token != null)
            {
                this.PushToken(token);
            }
        }

        private void CompileBinaryExpression()
        {
            this.CompileUnaryExpression();

            string mthname;
            Token token;

            token = this.NextToken();

            while (token != null && (token.Type == TokenType.Operator || (token.Type == TokenType.Punctuation && token.Value == "|") || (token.Type == TokenType.Name && !token.Value.EndsWith(":") && token.Value != "self")))
            {
                mthname = token.Value;
                this.CompileUnaryExpression();

                if (token.Type == TokenType.Operator)
                    this.block.CompileBinarySend(mthname);
                else
                    this.block.CompileSend(mthname);

                token = this.NextToken();
            }

            if (token != null)
            {
                this.PushToken(token);
            }
        }

        private void CompileKeywordExpression()
        {
            this.CompileBinaryExpression();

            string mthname = string.Empty;
            Token token;

            token = this.NextToken();

            while (token != null && token.Type == TokenType.Name && token.Value.EndsWith(":"))
            {
                mthname += token.Value;
                this.CompileBinaryExpression();
                token = this.NextToken();
            }

            if (token != null)
            {
                this.PushToken(token);
            }

            if (mthname != string.Empty)
            {
                this.block.CompileSend(mthname);
            }
        }

        private void CompileExpression()
        {
            this.CompileKeywordExpression();

            while (this.TryPeekToken(TokenType.Punctuation, ";"))
                this.CompileKeywordExpression();
        }

        private bool CompileCommand()
        {
            Token token;

            token = this.NextToken();

            if (token == null)
            {
                return false;
            }

            if (token.Value == ".")
            {
                return true;
            }

            // TODO raise failure if not open block, and nested blocks
            if (token.Value == "]")
            {
                return false;
            }

            if (token.Value == "^")
            {
                this.CompileExpression();
                this.block.CompileByteCode(ByteCode.ReturnPop);
                return true;
            }

            if (token.Type == TokenType.Name)
            {
                Token token2 = this.NextToken();

                if (token2 != null && token2.Type == TokenType.Operator && token2.Value == ":=")
                {
                    this.CompileExpression();
                    this.block.CompileSet(token.Value);

                    return true;
                }

                this.PushToken(token2);
            }

            this.PushToken(token);

            this.CompileExpression();

            return true;
        }

        private void CompileBody()
        {
            while (this.CompileCommand())
            {
            }
        }

        private void CompileMethod(IBehavior cls)
        {
            this.CompileArguments();
            this.CompileLocals();

            this.block = new Method(cls, this.methodname, this.source);

            foreach (string argname in this.arguments)
            {
                this.block.CompileArgument(argname);
            }

            foreach (string locname in this.locals)
            {
                this.block.CompileLocal(locname);
            }

            this.CompileBody();
        }

        private void CompileBlockLocals()
        {
            foreach (string locname in this.locals)
                this.block.CompileLocal(locname);
        }

        private bool TryCompileToken(TokenType type, string value)
        {
            Token token = this.NextToken();

            if (token == null)
                return false;

            if (token.Type == type && token.Value == value) 
                return true;

            this.PushToken(token);

            return false;
        }

        private bool TryPeekToken(TokenType type, string value)
        {
            Token token = this.NextToken();
            this.PushToken(token);

            if (token == null)
                return false;

            if (token.Type == type && token.Value == value)
                return true;

            return false;
        }

        private void CompileToken(TokenType type, string value)
        {
            Token token = this.NextToken();

            if (token == null || (token.Type != type && token.Value != value))
                throw new ParserException(string.Format("Expected '{0}'", value));
        }
    }
}
