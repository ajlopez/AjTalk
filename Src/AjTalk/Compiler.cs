using System;
using System.Collections;

namespace AjTalk
{
	/// <summary>
	/// Summary description for Compiler.
	/// </summary>
	public class Compiler
	{
		private Tokenizer tokenizer;
		private IList arguments = new ArrayList();
        private IList locals = new ArrayList();
		private string methodname;
		private Block block;

		public Compiler(Tokenizer tok)
		{
			tokenizer = tok;
		}

		public Compiler(string text) : this(new Tokenizer(text))
		{
		}

		private Token NextToken() 
		{
			return tokenizer.NextToken();
		}

		private void PushToken(Token token)
		{
			tokenizer.PushToken(token);
		}

		private void CompileKeywordArguments() 
		{
			Token token;

			methodname = "";

			while (true) 
			{
				token = NextToken();
				
				if (token==null)
					return;

				if (token.Type!=TokenType.Name || !token.Value.EndsWith(":")) 
				{
					PushToken(token);
					return;
				}

				methodname += token.Value;

				token = NextToken();

				if (token==null || token.Type!=TokenType.Name)
					throw new CompilerException("Argument expected");

				arguments.Add(token.Value);
			}
		}

        private void CompileLocals()
        {
            Token token = NextToken();

            if (token == null)
                return;

            if (token.Value != "|")
            {
                PushToken(token);
                return;
            }

            token = NextToken();

            while (token != null && token.Value != "|")
            {
                if (token.Type != TokenType.Name)
                    throw new CompilerException("Local variable name expected");

                locals.Add(token.Value);

                token = NextToken();
            }

            if (token == null)
                throw new CompilerException("'|' expected");
        }

		private void CompileArguments() 
		{
			Token token = NextToken();

			if (token==null)
				throw new CompilerException("Argument expected");

            // TODO Review if this code is needed
			if (token.Type == TokenType.Operator) 
			{
				methodname = token.Value;
				token = NextToken();
				if (token==null || token.Type!=TokenType.Name)
					throw new CompilerException("Argument expected");
				arguments.Add(token.Value);

				return;
			}

			if (token.Type != TokenType.Name)
				throw new CompilerException("Argument expected");

			if (token.Value.EndsWith(":")) 
			{
				PushToken(token);
				CompileKeywordArguments();
				return;
			}

			methodname = token.Value;
		}

		private void CompileTerm() 
		{
			Token token = NextToken();

			if (token==null)
				return;

			if (token.Value=="(") 
			{
				this.CompileExpression();
				token = NextToken();
				if (token==null || token.Value!=")")
					throw new CompilerException("')' expected");
				return;
			}

            if (token.Value == "[")
            {
                Compiler newcompiler = new Compiler(this.tokenizer);
                newcompiler.arguments = this.arguments;
                newcompiler.locals = this.locals;

                Block newblock = newcompiler.CompileBlock();

                block.CompileGetBlock(newblock);
                return;
            }

			if (token.Type==TokenType.Integer) 
			{
				block.CompileGetConstant(Convert.ToInt32(token.Value));
				return;
			}

			if (token.Type==TokenType.String)
			{
				block.CompileGetConstant(token.Value);
				return;
			}

            // TODO Review compile of Symbol
            if (token.Type == TokenType.Symbol)
            {
                block.CompileGetConstant(token.Value);
                return;
            }

			if (token.Type==TokenType.Name) 
			{
				block.CompileGet(token.Value);
				return;
			}

			throw new CompilerException("Name expected");
		}

		private void CompileUnaryExpression()
		{
			CompileTerm();

			Token token;

			token = NextToken();

			while (token!=null && token.Type==TokenType.Name && !token.Value.EndsWith(":") && token.Value!="self") 
			{
				block.CompileSend(token.Value);
				token = NextToken();
			}

			if (token!=null)
				PushToken(token);
		}

		private void CompileBinaryExpression() 
		{
			CompileUnaryExpression();

			string mthname;
			Token token;

			token = NextToken();

			while (token!=null && (token.Type==TokenType.Operator ||  (token.Type==TokenType.Name && !token.Value.EndsWith(":") && token.Value!="self"))) 
			{
				mthname = token.Value;
				CompileUnaryExpression();

                if (mthname == "+")
                    block.CompileByteCode(ByteCode.Add);
                else if (mthname == "-")
                    block.CompileByteCode(ByteCode.Substract);
                else if (mthname == "*")
                    block.CompileByteCode(ByteCode.Multiply);
                else if (mthname == "/")
                    block.CompileByteCode(ByteCode.Divide);
                else
                    block.CompileSend(mthname);

				token = NextToken();
			}

			if (token!=null)
				PushToken(token);
		}

		private void CompileKeywordExpression() 
		{
			CompileBinaryExpression();

			string mthname = "";
			Token token;

			token = NextToken();

			while (token!=null && token.Type==TokenType.Name && token.Value.EndsWith(":")) 
			{
				mthname += token.Value;
				CompileBinaryExpression();
				token = NextToken();
			}

			if (token!=null)
				PushToken(token);

			if (mthname != "")
				block.CompileSend(mthname);
		}

		private void CompileExpression() 
		{
			CompileKeywordExpression();
		}

		private bool CompileCommand() 
		{
			Token token;

			token = NextToken();

			if (token==null)
				return false;

			if (token.Value==".")
				return true;

            // TODO raise failure if not open block, and nested blocks
            if (token.Value == "]")
                return true;

            if (token.Value == "^") 
			{
				CompileExpression();
				block.CompileByteCode(ByteCode.ReturnPop);
				return true;
			}

            if (token.Type == TokenType.Name)
            {
                Token token2 = NextToken();

                if (token2.Type == TokenType.Operator && token2.Value == ":=")
                {
                    CompileExpression();
                    block.CompileSet(token.Value);

                    return true;
                }

                PushToken(token2);
            }

			PushToken(token);

			CompileExpression();

			return true;
		}

		private void CompileBody() 
		{
			while (CompileCommand())
				;
		}

        public Block CompileBlock()
        {
            block = new Block();
            CompileBody();

            return block;
        }

        private void CompileMethod(IClass cls)
        {
            CompileArguments();
            CompileLocals();

            block = new Method(cls, methodname);

            foreach (string argname in arguments)
                block.CompileArgument(argname);

            foreach (string locname in locals)
                block.CompileLocal(locname);

            CompileBody();
        }

		public void CompileInstanceMethod(IClass cls) 
		{
            CompileMethod(cls);
            cls.DefineInstanceMethod((IMethod) block);
        }

        // TODO Review implementation, use DefineClassMethod instead
        public void CompileClassMethod(IClass cls)
        {
            CompileMethod(cls.Class); // use metaclass
            cls.Class.DefineInstanceMethod((IMethod) block);
        }
    }

    public class CompilerException : Exception
    {
        public CompilerException(string message)
            : base(message)
        {
        }
    }
}

