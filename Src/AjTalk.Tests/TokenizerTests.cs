namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TokenizerTests
    {
        [TestMethod]
        public void Create()
        {
            Tokenizer tok = new Tokenizer("token");
            Assert.IsNotNull(tok);
        }

        [TestMethod]
        public void ProcessEmptyString()
        {
            Tokenizer tokenizer = new Tokenizer(string.Empty);
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ProcessBlank()
        {
            Tokenizer tokenizer = new Tokenizer(" ");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void SkipComment()
        {
            Tokenizer tokenizer = new Tokenizer("\"This is a comment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void SkipMultiLineComment()
        {
            Tokenizer tokenizer = new Tokenizer("\"This is a \n a multi-line\ncomment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ProcessOneToken()
        {
            Tokenizer tokenizer = new Tokenizer("token");
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
            Tokenizer tokenizer = new Tokenizer(" \"This is a token \" token \"This another comment\"");
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
            Tokenizer tokenizer = new Tokenizer("token1 token2");
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
            Tokenizer tokenizer = new Tokenizer("'string'");
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
            Tokenizer tokenizer = new Tokenizer("#aSymbol");
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
            Tokenizer tokenizer = new Tokenizer("@System.IO.FileInfo");

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
            Tokenizer tokenizer = new Tokenizer("#aSymbol:with:many>chars");
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
            Tokenizer tokenizer = new Tokenizer("#aSymbol #anotherSymbol");
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
        [ExpectedException(typeof(TokenizerException))]
        public void ProcessNotClosedString()
        {
            Tokenizer tokenizer = new Tokenizer("'string");
            Token token;

            token = tokenizer.NextToken();
        }

        [TestMethod]
        public void ProcessInteger()
        {
            Tokenizer tokenizer = new Tokenizer("10");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("10", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);
        }

        [TestMethod]
        public void ProcessOperator()
        {
            Tokenizer tokenizer = new Tokenizer("+");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [TestMethod]
        public void ProcessSetOperator()
        {
            Tokenizer tokenizer = new Tokenizer(":=");
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

            Tokenizer tokenizer = new Tokenizer(opers2);
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
            Tokenizer tokenizer = new Tokenizer(".");
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
            Tokenizer tokenizer = new Tokenizer(punct);
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
            Tokenizer tokenizer = new Tokenizer("token 'string'");
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
            Tokenizer tokenizer = new Tokenizer("@System.FileInfo !new: 'FooBar.txt'");
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

