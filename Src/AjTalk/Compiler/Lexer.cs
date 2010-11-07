namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Lexer
    {
        public const char SpecialDotNetTypeMark = '@';
        public const char SpecialDotNetInvokeMark = '!';

        private const string Operators = "^<>:=-+*/&";
        private const string Separators = "().|[];";

        private const char StringDelimiter = '\'';

        private const char CommentDelimeter = '"';

        private const char SymbolMark = '#';

        private TextReader input;
        private char lastchar;
        private bool haschar;
        private Stack<Token> tokenstack = new Stack<Token>();

        public Lexer(TextReader input)
        {
            this.input = input;
        }

        public Lexer(string text)
            : this(new StringReader(text))
        {
        }

        public void PushToken(Token token)
        {
            this.tokenstack.Push(token);
        }

        public Token NextToken()
        {
            if (this.tokenstack.Count > 0)
            {
                return this.tokenstack.Pop();
            }

            char ch;

            try
            {
                ch = this.NextCharSkipBlanksAndComments();

                if (Char.IsLetter(ch) || ch == '_')
                {
                    return this.NextName(ch);
                }

                if (Char.IsDigit(ch))
                {
                    return this.NextInteger(ch);
                }

                if (ch == StringDelimiter)
                {
                    return this.NextString();
                }

                if (ch == SymbolMark)
                {
                    char ch2 = this.NextChar();

                    if (ch2 == '(')
                        return new Token() { Type = TokenType.Punctuation, Value = "#(" };

                    this.PushChar(ch2);

                    return this.NextSymbol();
                }

                if (ch == SpecialDotNetTypeMark)
                {
                    return this.NextDotNetTypeName();
                }

                if (ch == SpecialDotNetInvokeMark)
                {
                    return this.NextDotNetInvokeName();
                }

                if (Operators.IndexOf(ch) >= 0)
                {
                    return this.NextOperator(ch);
                }

                if (Separators.IndexOf(ch) >= 0)
                {
                    return this.NextPunctuation(ch);
                }

                throw new LexerException("Invalid Characater '" + ch + "'");
            }
            catch (EndOfInputException)
            {
                return null;
            }
        }

        private void PushChar(char ch)
        {
            this.lastchar = ch;
            this.haschar = true;
        }

        private char NextChar()
        {
            if (this.haschar)
            {
                this.haschar = false;
                return this.lastchar;
            }

            int ch = this.input.Read();

            if (ch < 0)
            {
                throw new EndOfInputException();
            }

            return (char)ch;
        }

        private void SkipToControl()
        {
            char ch;

            ch = this.NextChar();

            while (!Char.IsControl(ch))
            {
                ch = this.NextChar();
            }
        }

        private char NextCharSkipBlanks()
        {
            char ch;

            ch = this.NextChar();

            while (Char.IsWhiteSpace(ch))
            {
                ch = this.NextChar();
            }

            return ch;
        }

        private char NextCharSkipBlanksAndComments()
        {
            char ch;

            ch = this.NextCharSkipBlanks();

            // Skip Comments
            while (ch == CommentDelimeter)
            {
                ch = this.NextChar();

                while (ch != CommentDelimeter)
                {
                    ch = this.NextChar();
                }

                // After comment, skip blanks again
                ch = this.NextCharSkipBlanks();
            }

            return ch;
        }

        private Token NextName(char firstchar)
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append(firstchar);

            try
            {
                char ch;

                ch = this.NextChar();

                while (Char.IsLetterOrDigit(ch))
                {
                    sb.Append(ch);
                    ch = this.NextChar();
                }

                if (ch == ':')
                {
                    sb.Append(ch);
                }
                else
                {
                    this.PushChar(ch);
                }
            }
            catch (EndOfInputException)
            {
            }

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextSymbol()
        {
            StringBuilder sb = new StringBuilder();

            try
            {
                char ch;

                ch = this.NextChar();

                while (!Char.IsWhiteSpace(ch) && Separators.IndexOf(ch)<0)
                {
                    sb.Append(ch);
                    ch = this.NextChar();
                }

                this.PushChar(ch);
            }
            catch (EndOfInputException)
            {
            }

            Token token = new Token();
            token.Type = TokenType.Symbol;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextDotNetTypeName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SpecialDotNetTypeMark);

            try
            {
                char ch;

                ch = this.NextChar();

                while (!Char.IsWhiteSpace(ch))
                {
                    sb.Append(ch);
                    ch = this.NextChar();
                }

                this.PushChar(ch);
            }
            catch (EndOfInputException)
            {
            }

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextDotNetInvokeName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SpecialDotNetInvokeMark);

            try
            {
                char ch;

                ch = this.NextChar();

                while (Char.IsLetterOrDigit(ch) || ch=='_' || ch==':')
                {
                    sb.Append(ch);
                    if (ch == ':')
                        break;
                    ch = this.NextChar();
                }

                if (ch != ':')
                    this.PushChar(ch);
            }
            catch (EndOfInputException)
            {
            }

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextString()
        {
            string value = string.Empty;

            char ch;

            try
            {
                ch = this.NextChar();

                while (ch != StringDelimiter)
                {
                    value += ch;
                    ch = this.NextChar();
                }
            }
            catch (EndOfInputException)
            {
                throw new LexerException("\"\'\" expected");
            }

            Token token = new Token();

            token.Type = TokenType.String;
            token.Value = value;

            return token;
        }

        private Token NextInteger(char firstdigit)
        {
            string value = new string(firstdigit, 1);

            char ch;

            try
            {
                ch = this.NextChar();

                while (Char.IsDigit(ch))
                {
                    value += ch;
                    ch = this.NextChar();
                }

                this.PushChar(ch);
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
            string value = new string(firstchar, 1);

            char ch;

            try
            {
                ch = this.NextChar();

                while (Operators.IndexOf(ch) >= 0)
                {
                    value += ch;
                    ch = this.NextChar();
                }

                this.PushChar(ch);
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
            token.Value = new string(ch, 1);
            token.Type = TokenType.Punctuation;

            return token;
        }
    }
}

