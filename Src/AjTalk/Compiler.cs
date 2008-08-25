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
		private Method method;

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
				CompileExpression();
				token = NextToken();
				if (token==null || token.Value!=")")
					throw new CompilerException("')' expected");
				return;
			}

			if (token.Type==TokenType.Integer) 
			{
				method.CompileGetConstant(Convert.ToInt32(token.Value));
				return;
			}

			if (token.Type==TokenType.String)
			{
				method.CompileGetConstant(token.Value);
				return;
			}

			if (token.Type==TokenType.Name) 
			{
				method.CompileGet(token.Value);
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
				method.CompileSend(token.Value);
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
                    method.CompileByteCode(ByteCode.Add);
                else if (mthname == "-")
                    method.CompileByteCode(ByteCode.Substract);
                else if (mthname == "*")
                    method.CompileByteCode(ByteCode.Multiply);
                else if (mthname == "/")
                    method.CompileByteCode(ByteCode.Divide);
                else
                    method.CompileSend(mthname);

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
				method.CompileSend(mthname);
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

			if (token.Value=="^") 
			{
				CompileExpression();
				method.CompileByteCode(ByteCode.ReturnPop);
				return true;
			}

            if (token.Type == TokenType.Name)
            {
                Token token2 = NextToken();

                if (token2.Type == TokenType.Operator && token2.Value == ":=")
                {
                    CompileExpression();
                    method.CompileSet(token.Value);

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

		public void CompileMethod(IClass cls) 
		{
			CompileArguments();
            CompileLocals();

			method = new Method(cls, methodname);

			foreach (string argname in arguments)
				method.CompileArgument(argname);

            foreach (string locname in locals)
                method.CompileLocal(locname);

			cls.DefineInstanceMethod(method);

			CompileBody();
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

