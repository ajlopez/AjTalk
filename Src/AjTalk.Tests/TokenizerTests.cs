using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void ShouldBeCreate()
        {
            Tokenizer tok = new Tokenizer("token");
            Assert.IsNotNull(tok);
        }

        [Test]
        public void ShouldProcessBlank()
        {
            Tokenizer tokenizer = new Tokenizer("");
            Assert.IsNull(tokenizer.NextToken());
        }

        [Test]
        public void ShouldProcessBlank2()
        {
            Tokenizer tokenizer = new Tokenizer(" ");
            Assert.IsNull(tokenizer.NextToken());
        }

        [Test]
        public void ShouldProcessOneToken()
        {
            Tokenizer tokenizer = new Tokenizer("token");
            Token token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("token", token.Value);
            Assert.AreEqual(TokenType.Name, token.Type);
        }

        [Test]
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
        }

        [Test]
        public void ShouldProcessString()
        {
            Tokenizer tokenizer = new Tokenizer("'string'");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("string", token.Value);
            Assert.AreEqual(TokenType.String, token.Type);
        }

        [Test]
        [ExpectedException(typeof(TokenizerException))]
        public void ShouldProcessNotClosedString()
        {
            Tokenizer tokenizer = new Tokenizer("'string");
            Token token;

            token = tokenizer.NextToken();
        }

        [Test]
        public void ShouldProcessInteger()
        {
            Tokenizer tokenizer = new Tokenizer("10");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("10", token.Value);
            Assert.AreEqual(TokenType.Integer, token.Type);
        }

        [Test]
        public void ShouldProcessOperator()
        {
            Tokenizer tokenizer = new Tokenizer("+");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual("+", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [Test]
        public void ShouldProcessSetOperator()
        {
            Tokenizer tokenizer = new Tokenizer(":=");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(":=", token.Value);
            Assert.AreEqual(TokenType.Operator, token.Type);
        }

        [Test]
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

        [Test]
        public void ShouldProcessPunctuation()
        {
            Tokenizer tokenizer = new Tokenizer(".");
            Token token;

            token = tokenizer.NextToken();
            Assert.IsNotNull(token);
            Assert.AreEqual(".", token.Value);
            Assert.AreEqual(TokenType.Punctuation, token.Type);
        }

        [Test]
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

        [Test]
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

