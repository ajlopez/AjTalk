namespace AjTalk.Tests.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Compiler;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void Create()
        {
            Lexer tok = new Lexer("token");
            Assert.IsNotNull(tok);
        }

        [TestMethod]
        public void ProcessEmptyString()
        {
            Lexer tokenizer = new Lexer(string.Empty);
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ProcessBlank()
        {
            Lexer tokenizer = new Lexer(" ");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void SkipComment()
        {
            Lexer tokenizer = new Lexer("\"This is a comment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void SkipMultiLineComment()
        {
            Lexer tokenizer = new Lexer("\"This is a \n a multi-line\ncomment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ProcessOneToken()
        {
            Lexer tokenizer = new Lexer("token");
            Token token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessOneTokenWithSpacesAndComment()
        {
            Lexer tokenizer = new Lexer(" \"This is a token \" token \"This another comment\"");
            Token token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessTwoTokens()
        {
            Lexer tokenizer = new Lexer("token1 token2");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token1", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token2", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessString()
        {
            Lexer tokenizer = new Lexer("'string'");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("string", token.Value);
            Assert.AreEqual(TokenType.String, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessSymbol()
        {
            Lexer tokenizer = new Lexer("#aSymbol");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("aSymbol", token.Value);
            Assert.AreEqual(TokenType.Symbol, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessSpecialName()
        {
            Lexer tokenizer = new Lexer("@System.IO.FileInfo");

            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("@System.IO.FileInfo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessComplexSymbol()
        {
            Lexer tokenizer = new Lexer("#aSymbol:with:many>chars");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("aSymbol:with:many>chars", token.Value);
            Assert.AreEqual(TokenType.Symbol, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ProcessTwoSymbols()
        {
            Lexer tokenizer = new Lexer("#aSymbol #anotherSymbol");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("aSymbol", token.Value);
            Assert.AreEqual(TokenType.Symbol, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("anotherSymbol", token.Value);
            Assert.AreEqual(TokenType.Symbol, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNull(token);
        }

        [TestMethod]
        [ExpectedException(typeof(LexerException))]
        public void ProcessNotClosedString()
        {
            Lexer tokenizer = new Lexer("'string");
            Token token;

            token = tokenizer.NextToken();
        }

        [TestMethod]
        public void ProcessInteger()
        {
            Lexer tokenizer = new Lexer("10");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("10", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);
        }

        [TestMethod]
        public void ProcessOperator()
        {
            Lexer tokenizer = new Lexer("+");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [TestMethod]
        public void ProcessSetOperator()
        {
            Lexer tokenizer = new Lexer(":=");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(":=", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [TestMethod]
        public void ProcessOperators()
        {
            string opers = "^<>:=-+*/&";

            string opers2 = string.Empty;

            foreach (char ch in opers)
            {
                opers2 += ch;
                opers2 += ' ';
            }

            Lexer tokenizer = new Lexer(opers2);
            Token token;

            for (int k = 0; k < opers.Length; k++)
            {
                token = tokenizer.NextToken();
                Assert.IsNotNull(token);
                Assert.AreEqual(opers[k], token.Value[0]);
                Assert.AreEqual(1, token.Value.Length);
                Assert.AreEqual(TokenType.Operator, token.Type);
            }
        }

        [TestMethod]
        public void ProcessPunctuation()
        {
            Lexer tokenizer = new Lexer(".");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(".", token.Value);
            Assert.AreEqual(TokenType.Punctuation, token.Type);
        }

        [TestMethod]
        public void ProcessPunctuations()
        {
            string punct = "().|[]";
            Lexer tokenizer = new Lexer(punct);
            Token token;

            for (int k = 0; k < punct.Length; k++) 
            {
                token = tokenizer.NextToken();
                Assert.IsNotNull(token);
                Assert.AreEqual(punct[k], token.Value[0]);
                Assert.AreEqual(1, token.Value.Length);
                Assert.AreEqual(TokenType.Punctuation, token.Type);
            }
        }

        [TestMethod]
        public void ProcessTokenAndString()
        {
            Lexer tokenizer = new Lexer("token 'string'");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("string", token.Value);
            Assert.AreEqual(TokenType.String, token.Type);
        }

        [TestMethod]
        public void ParseDotNetObjectAndMethod()
        {
            Lexer tokenizer = new Lexer("@System.FileInfo !new: 'FooBar.txt'");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("@System.FileInfo", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("!new:", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("FooBar.txt", token.Value);
            Assert.AreEqual(TokenType.String, token.Type);
        }
    }
}
