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
        public const char SpecialCharMark = '$';

        private const string Operators = "^<>:=-+*/&~,\\";
        private const string Separators = "().|[];{}";

        private const char StringDelimiter = '\'';

        private const char CommentDelimeter = '"';

        private const char SymbolMark = '#';
        private const char ParameterMark = ':';

        private TextReader input;
        private Stack<int> stacked = new Stack<int>();
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

            int ch;

            ch = this.NextCharSkipBlanksAndComments();

            if (ch < 0)
                return null;

            if (char.IsLetter((char)ch) || ch == '_')
            {
                return this.NextName((char)ch);
            }

            if (char.IsDigit((char)ch))
            {
                return this.NextInteger((char)ch);
            }

            if (ch == StringDelimiter)
            {
                return this.NextString();
            }

            if (ch == SpecialCharMark)
            {
                int ch2 = this.NextChar();
                return new Token() { Type = TokenType.Character, Value = ((char)ch2).ToString() };
            }

            if (ch == SymbolMark)
            {
                int ch2 = this.NextChar();

                if (ch2 == '(')
                    return new Token() { Type = TokenType.Punctuation, Value = "#(" };
                if (ch2 == '[')
                    return new Token() { Type = TokenType.Punctuation, Value = "#[" };
                if (ch2 == '{')
                    return this.NextEnclosedSymbol();

                this.PushChar(ch2);

                return this.NextSymbol();
            }

            if (ch == ParameterMark)
            {
                int ch2 = this.PeekChar();

                if (ch2 < 0 || !char.IsLetter((char)ch2))
                {
                    return this.NextOperator((char)ch);
                }

                return this.NextParameter();
            }

            if (ch == SpecialDotNetTypeMark)
            {
                int ch2 = this.PeekChar();

                if (ch2 < 0 || !char.IsLetter((char)ch2) || !char.IsUpper((char)ch2))
                {
                    return this.NextOperator((char)ch);
                }

                return this.NextDotNetTypeName();
            }

            if (ch == SpecialDotNetInvokeMark)
            {
                return this.NextDotNetInvokeName();
            }

            if (Operators.IndexOf((char)ch) >= 0)
            {
                return this.NextOperator((char)ch);
            }

            if (Separators.IndexOf((char)ch) >= 0)
            {
                return this.NextPunctuation((char)ch);
            }

            throw new LexerException("Invalid Characater '" + (char)ch + "'");
        }

        private void PushChar(int ch)
        {
            this.stacked.Push(ch);
        }

        private int NextChar()
        {
            if (this.stacked.Count > 0)
                return this.stacked.Pop();

            int ch = this.input.Read();

            return ch;
        }

        private int PeekChar()
        {
            if (this.stacked.Count > 0)
                return this.stacked.Peek();

            int ch = this.input.Read();

            this.PushChar(ch);

            return ch;
        }

        private void SkipToControl()
        {
            int ch;

            ch = this.NextChar();

            while (ch >= 0 && !char.IsControl((char)ch))
            {
                ch = this.NextChar();
            }
        }

        private int NextCharSkipBlanks()
        {
            int ch;

            ch = this.NextChar();

            while (ch >= 0 && char.IsWhiteSpace((char)ch))
            {
                ch = this.NextChar();
            }

            return ch;
        }

        private int NextCharSkipBlanksAndComments()
        {
            int ch;

            ch = this.NextCharSkipBlanks();

            // Skip Comments
            while (ch >= 0 && ch == CommentDelimeter)
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

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && char.IsLetterOrDigit((char)ch))
            {
                sb.Append((char)ch);
                ch = this.NextChar();
            }

            if (ch >= 0 && ch == '.' && char.IsUpper(firstchar))
            {
                var peek = this.PeekChar();
                
                if (peek >= 0 && char.IsLetter((char)peek) && char.IsUpper((char)peek))
                {
                    sb.Append((char)ch);
                    return this.NextDottedName(sb.ToString());
                }

                this.PushChar(ch);
            }
            else if (ch >= 0 && ch == ':')
            {
                sb.Append((char)ch);
            }
            else
            {
                this.PushChar(ch);
            }

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextDottedName(string name)
        {
            StringBuilder sb = new StringBuilder(10);
            sb.Append(name);

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && char.IsLetterOrDigit((char)ch))
            {
                sb.Append((char)ch);
                ch = this.NextChar();
            }

            if (ch >= 0 && ch == '.')
            {
                var peek = this.PeekChar();
                if (peek >= 0 && char.IsLetter((char)peek) && char.IsUpper((char)peek))
                {
                    sb.Append((char)ch);
                    return this.NextDottedName(sb.ToString());
                }
            }

            this.PushChar(ch);

            Token token = new Token();
            token.Type = TokenType.DottedName;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextSymbol()
        {
            Token token = new Token();
            token.Type = TokenType.Symbol;

            token.Value = this.NextNameAsString();

            return token;
        }

        private Token NextEnclosedSymbol()
        {
            StringBuilder sb = new StringBuilder(10);

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && ch != '}')
            {
                sb.Append((char)ch);
                ch = this.NextChar();
            }

            if (ch != '}')
                new LexerException("Expected '}'");

            Token token = new Token();
            token.Type = TokenType.Symbol;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextParameter()
        {
            Token token = new Token();
            token.Type = TokenType.Parameter;
            token.Value = this.NextNameAsString();

            return token;
        }

        private string NextNameAsString()
        {
            StringBuilder sb = new StringBuilder();

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && !char.IsWhiteSpace((char)ch) && Separators.IndexOf((char)ch) < 0)
            {
                sb.Append((char)ch);
                ch = this.NextChar();
            }

            this.PushChar(ch);

            return sb.ToString();
        }

        private Token NextDotNetTypeName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SpecialDotNetTypeMark);

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && (char.IsLetterOrDigit((char)ch) || ch == '.'))
            {
                sb.Append((char)ch);
                ch = this.NextChar();
            }

            this.PushChar(ch);

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextDotNetInvokeName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SpecialDotNetInvokeMark);

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && (char.IsLetterOrDigit((char)ch) || ch == '_' || ch == ':'))
            {
                sb.Append((char)ch);
                if (ch == ':')
                    break;
                ch = this.NextChar();
            }

            if (ch >= 0 && ch != ':')
                this.PushChar(ch);

            Token token = new Token();
            token.Type = TokenType.Name;
            token.Value = sb.ToString();

            return token;
        }

        private Token NextString()
        {
            string value = string.Empty;

            int ch;

            while (true)
            {
                ch = this.NextChar();

                while (ch >= 0 && ch != StringDelimiter)
                {
                    value += (char)ch;
                    ch = this.NextChar();
                }

                if (ch < 0)
                    break;

                int ch2 = this.PeekChar();

                if (ch2 < 0)
                    break;

                if (ch2 != StringDelimiter)
                    break;

                this.NextChar();

                value += (char)ch;
            }

            if (ch < 0)
                throw new LexerException("Unclosed string");

            Token token = new Token();

            token.Type = TokenType.String;
            token.Value = value;

            return token;
        }

        private Token NextInteger(char firstdigit)
        {
            string value = new string(firstdigit, 1);

            int ch;

            ch = this.NextChar();

            while (ch >= 0 && char.IsDigit((char)ch))
            {
                value += (char)ch;
                ch = this.NextChar();
            }

            if (ch == '.') 
            { 
                int ch2 = this.PeekChar();
                
                if (ch2 >= 0 && char.IsDigit((char)ch2))
                    return this.NextReal(value + ".");
            }

            if (ch >= 0 && ch == 'r')
            {
                value += (char)ch;

                for (ch = this.NextChar(); ch >= 0 && char.IsLetterOrDigit((char)ch); ch = this.NextChar())
                    value += (char)ch;
            }

            this.PushChar(ch);

            Token token = new Token();
            token.Type = TokenType.Integer;
            token.Value = value;

            return token;
        }

        private Token NextReal(string value)
        {
            int ch;

            ch = this.NextChar();

            while (ch >= 0 && char.IsDigit((char)ch))
            {
                value += (char)ch;
                ch = this.NextChar();
            }

            this.PushChar(ch);

            Token token = new Token();
            token.Type = TokenType.Real;
            token.Value = value;

            return token;
        }

        private Token NextOperator(char firstchar)
        {
            string value = new string(firstchar, 1);

            if (firstchar != '^')
            {
                int ch;

                ch = this.NextChar();

                while (ch >= 0 && Operators.IndexOf((char)ch) >= 0)
                {
                    value += (char)ch;
                    ch = this.NextChar();
                }

                this.PushChar(ch);
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
