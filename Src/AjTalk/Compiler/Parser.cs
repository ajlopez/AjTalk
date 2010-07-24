namespace AjTalk.Compiler
{
    using System;
    using System.Collections;

    public class Parser
    {
        private Lexer tokenizer;
        private IList arguments = new ArrayList();
        private IList locals = new ArrayList();
        private string methodname;
        private Block block;

        public Parser(Lexer tok)
        {
            this.tokenizer = tok;
        }

        public Parser(string text)
            : this(new Lexer(text))
        {
        }

        public Block CompileBlock()
        {
            this.block = new Block();
            this.CompileBlockArguments();
            this.CompileBody();

            return this.block;
        }

        public void CompileInstanceMethod(IClass cls)
        {
            this.CompileMethod(cls);
            cls.DefineInstanceMethod((IMethod)this.block);
        }

        // TODO Review implementation, use DefineClassMethod instead
        public void CompileClassMethod(IClass cls)
        {
            this.CompileMethod(cls.MetaClass); // use metaclass
            cls.DefineClassMethod((IMethod)this.block);
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
            if (token.Type == TokenType.Operator)
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
            Token token = this.NextToken();

            while (true)
            {
                if (token == null)
                    throw new ParserException("Unexpected end of input");

                if (token.Value == "|")
                    return;

                if (token.Type != TokenType.Operator || token.Value != ":")
                {
                    PushToken(token);
                    return;
                }

                this.block.CompileArgument(this.CompileName());

                token = this.NextToken();
            }
        }

        private string CompileName()
        {
            Token token = this.NextToken();

            if (token == null || token.Type != TokenType.Name)
                throw new ParserException("Name expected");

            return token.Value;
        }

        private void CompileTerm()
        {
            Token token = this.NextToken();

            if (token == null)
            {
                return;
            }

            if (token.Value == "(")
            {
                this.CompileExpression();
                token = this.NextToken();
                if (token == null || token.Value != ")")
                {
                    throw new ParserException("')' expected");
                }

                return;
            }

            if (token.Value == "[")
            {
                Parser newcompiler = new Parser(this.tokenizer);
                newcompiler.arguments = this.arguments;
                newcompiler.locals = this.locals;

                Block newblock = newcompiler.CompileBlock();

                this.block.CompileGetBlock(newblock);
                return;
            }

            if (token.Type == TokenType.Integer)
            {
                this.block.CompileGetConstant(Convert.ToInt32(token.Value));
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

            if (token.Type == TokenType.Name)
            {
                if (token.Value[0] == Lexer.SpecialDotNetTypeMark)
                {
                    this.block.CompileGetDotNetType(token.Value.Substring(1));
                    return;
                }

                this.block.CompileGet(token.Value);
                return;
            }

            throw new ParserException("Name expected");
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

            while (token != null && (token.Type == TokenType.Operator || (token.Type == TokenType.Name && !token.Value.EndsWith(":") && token.Value != "self")))
            {
                mthname = token.Value;
                this.CompileUnaryExpression();

                if (mthname == "+")
                {
                    this.block.CompileByteCode(ByteCode.Add);
                }
                else if (mthname == "-")
                {
                    this.block.CompileByteCode(ByteCode.Substract);
                }
                else if (mthname == "*")
                {
                    this.block.CompileByteCode(ByteCode.Multiply);
                }
                else if (mthname == "/")
                {
                    this.block.CompileByteCode(ByteCode.Divide);
                }
                else
                {
                    this.block.CompileSend(mthname);
                }

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

                if (token2.Type == TokenType.Operator && token2.Value == ":=")
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

        private void CompileMethod(IClass cls)
        {
            this.CompileArguments();
            this.CompileLocals();

            this.block = new Method(cls, this.methodname);

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
    }
}

