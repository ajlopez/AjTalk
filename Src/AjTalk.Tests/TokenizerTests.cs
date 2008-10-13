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
        public void ShouldBeCreate()
        {
            Tokenizer tok = new Tokenizer("token");
            Assert.IsNotNull(tok);
        }

        [TestMethod]
        public void ShouldProcessEmptyString()
        {
            Tokenizer tokenizer = new Tokenizer("");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ShouldProcessBlank()
        {
            Tokenizer tokenizer = new Tokenizer(" ");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ShouldSkipComment()
        {
            Tokenizer tokenizer = new Tokenizer("\"This is a comment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ShouldSkipMultiLineComment()
        {
            Tokenizer tokenizer = new Tokenizer("\"This is a \n a multi-line\ncomment\"");
            Assert.IsNull(tokenizer.NextToken());
        }

        [TestMethod]
        public void ShouldProcessOneToken()
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
        public void ShouldProcessOneTokenWithSpacesAndComment()
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
        public void ShouldProcessTwoTokens()
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
        public void ShouldProcessString()
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
        public void ShouldProcessSymbol()
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
        public void ShouldProcessComplexSymbol()
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
        public void ShouldProcessTwoSymbols()
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
        public void ShouldProcessNotClosedString()
        {
            Tokenizer tokenizer = new Tokenizer("'string");
            Token token;

            token = tokenizer.NextToken();
        }

        [TestMethod]
        public void ShouldProcessInteger()
        {
            Tokenizer tokenizer = new Tokenizer("10");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("10", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);
        }

        [TestMethod]
        public void ShouldProcessOperator()
        {
            Tokenizer tokenizer = new Tokenizer("+");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [TestMethod]
        public void ShouldProcessSetOperator()
        {
            Tokenizer tokenizer = new Tokenizer(":=");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(":=", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [TestMethod]
        public void ShouldProcessOperators()
        {
            string opers = "^<>:=-+*/&";

            string opers2 = "";

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
        public void ShouldProcessPunctuation()
        {
            Tokenizer tokenizer = new Tokenizer(".");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(".", token.Value);
            Assert.AreEqual(TokenType.Punctuation, token.Type);
        }

        [TestMethod]
        public void ShouldProcessPunctuations()
        {
            string punct = "().";
            Tokenizer tokenizer = new Tokenizer(punct);
            Token token;

            for (int k=0; k<punct.Length; k++) {
                token = tokenizer.NextToken();
                Assert.IsNotNull(token);
                Assert.AreEqual(punct[k], token.Value[0]);
                Assert.AreEqual(1, token.Value.Length);
                Assert.AreEqual(TokenType.Punctuation, token.Type);
            }
        }

        [TestMethod]
        public void ShouldProcessTokenAndString()
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
    }
}

