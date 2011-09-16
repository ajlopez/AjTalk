namespace AjTalk.Ast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class TreeParser
    {
        private Lexer tokenizer;
        private string source;

        public TreeParser(Lexer tok)
        {
            this.tokenizer = tok;
        }

        public TreeParser(string text)
            : this(new Lexer(text))
        {
            this.source = text;
        }

        public INode ParseNode()
        {
            Token token = this.NextToken();
            
            if (token == null)
                return null;

            if (token.Type == TokenType.Name)
            {
                if (token.Value == "self")
                    return new SelfNode();

                return new InstanceVariableNode(token.Value);
            }

            throw new ParserException(string.Format("Unknown '{0}'", token.Value));
        }

        private Token NextToken()
        {
            return this.tokenizer.NextToken();
        }
    }
}
