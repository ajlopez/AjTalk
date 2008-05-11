using System;
using System.IO;
using System.Collections.Generic;

namespace AjTalk
{
	public enum TokenType : int 
	{
		Name = 0,
		Integer = 1,
		String = 2,
		Punctuation = 3,
		Operator = 4
	}

	public class Token
	{
		public TokenType Type;
		public string Value;
	}

	public class EndOfInputException : Exception
	{
		public EndOfInputException() : base("End of Input")
		{
		}
	}

	public class TokenizerException : Exception 
	{
		public TokenizerException(string msg) : base(msg) 
		{
		}
	}

	/// <summary>
	/// Summary description for Tokenizer.
	/// </summary>
	public class Tokenizer
	{
		private TextReader input;
		private char lastchar;
		private bool haschar;
        private Stack<Token> tokenstack = new Stack<Token>();

		private const string operators = "^<>:=-+*/&";
		private const string separators = "().";

        private const char stringdelimeter = '\'';

		public Tokenizer(TextReader input)
		{
			this.input = input;
		}

		public Tokenizer(string text) : this(new StringReader(text))
		{
		}

		private void PushChar(char ch)
		{
			lastchar = ch;
			haschar = true;
		}

		private char NextChar() 
		{
			if (haschar) 
			{
				haschar = false;
				return lastchar;
			}

			int ch = input.Read();

			if (ch<0)
				throw new EndOfInputException();

			return ((char) ch);
		}

		private void SkipToControl()
		{
			char ch;

			ch = NextChar();

			while (!Char.IsControl(ch))
				ch = NextChar();
		}

		private char NextCharSkipBlanks() 
		{
			char ch;

			ch = NextChar();

			while (Char.IsWhiteSpace(ch))
				ch = NextChar();

			return ch;
		}

		private Token NextName(char firstchar) 
		{
			string name = new String(firstchar,1);

			try 
			{
				char ch;

				ch = NextChar();

				while (Char.IsLetterOrDigit(ch)) 
				{
					name += ch;
					ch = NextChar();
				}

				if (ch==':')
					name += ch;
				else
					PushChar(ch);
			}
			catch (EndOfInputException) 
			{
			}

			Token token = new Token();
			token.Type=TokenType.Name;
			token.Value = name;

			return token;
		}

		private Token NextString() 
		{
			string value = "";

			char ch;

            try
            {
                ch = NextChar();

                while (ch != stringdelimeter)
                {
                    value += ch;
                    ch = NextChar();
                }
            }
            catch (EndOfInputException)
            {
                throw new TokenizerException("\"\'\" expected");
            }

			Token token = new Token();

			token.Type = TokenType.String;
			token.Value = value;

			return token;
		}

		private Token NextInteger(char firstdigit) 
		{
			string value = new String(firstdigit,1);

			char ch;

			try 
			{
				ch = NextChar();

				while (Char.IsDigit(ch)) 
				{
					value += ch;
					ch = NextChar();
				}
				PushChar(ch);
			}
			catch (EndOfInputException) 
			{
			}

			Token token = new Token();
			token.Type = TokenType.Integer;
			token.Value = value;

			return token;
		}

		private Token NextOperator(char firstchar) 
		{
			string value = new String(firstchar,1);

			char ch;

			try 
			{
				ch = NextChar();

                while (operators.IndexOf(ch) >= 0)
                {
                    value += ch;
                    ch = NextChar();
                }

				PushChar(ch);
			}
			catch (EndOfInputException) 
			{
			}

			Token token = new Token();
			token.Type = TokenType.Operator;
			token.Value = value;

			return token;
		}

		private Token NextPunctuation(char ch) 
		{
			Token token = new Token();
			token.Value = new string(ch,1);
			token.Type = TokenType.Punctuation;

			return token;
		}

		public void PushToken(Token token) 
		{
            tokenstack.Push(token);
		}

		public Token NextToken() 
		{
            if (tokenstack.Count > 0)
                return tokenstack.Pop();

			char ch;

			try 
			{
				ch = NextCharSkipBlanks();

				if (Char.IsLetter(ch) || ch=='_')
					return NextName(ch);

				if (Char.IsDigit(ch))
					return NextInteger(ch);

                if (ch == stringdelimeter)
                    return NextString();

				if (operators.IndexOf(ch)>=0)
					return NextOperator(ch);

				if (separators.IndexOf(ch)>=0)
					return NextPunctuation(ch);

				throw new TokenizerException("Invalid Characater '" + ch + "'");
			}
			catch (EndOfInputException) 
			{
				return null;
			}
		}
	}
}

