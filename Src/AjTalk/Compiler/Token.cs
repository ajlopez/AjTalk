namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Token
    {
        public TokenType Type { get; set; }

        public string Value { get; set; }

        public bool IsName() { return this.Type == TokenType.Name; }

        public bool IsOperator()
        {
            return this.Type == TokenType.Operator ||
                (this.Type == TokenType.Punctuation && this.Value == "|");
        }
    }
}
