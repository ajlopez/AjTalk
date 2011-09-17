namespace AjTalk.Tests.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Model;

    [TestClass]
    public class ModelParserTests
    {
        [TestMethod]
        public void ParseSelf()
        {
            ModelParser parser = new ModelParser("self");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(SelfExpression));
        }

        [TestMethod]
        public void ParseInstanceVariable()
        {
            ModelParser parser = new ModelParser("foo");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(InstanceVariableExpression));

            InstanceVariableExpression ivexpression = (InstanceVariableExpression)expression;
            Assert.AreEqual("foo", ivexpression.Name);
        }

        [TestMethod]
        public void ParseString()
        {
            ModelParser parser = new ModelParser("'foo'");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual("foo", cexpression.Value);
        }

        [TestMethod]
        public void ParseInteger()
        {
            ModelParser parser = new ModelParser("123");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual(123, cexpression.Value);
        }

        [TestMethod]
        public void ParseUnaryMessage()
        {
            ModelParser parser = new ModelParser("x length");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(InstanceVariableExpression));
            Assert.AreEqual("length", mexpression.Selector);
            Assert.AreEqual(0, mexpression.Arguments.Count());
        }

        [TestMethod]
        public void ParseTwoUnaryMessage()
        {
            ModelParser parser = new ModelParser("x length asString");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(MessageExpression));
            Assert.AreEqual("asString", mexpression.Selector);
            Assert.AreEqual(0, mexpression.Arguments.Count());
        }

        [TestMethod]
        public void ParseMessageWithOneArgument()
        {
            ModelParser parser = new ModelParser("r width: 100");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(InstanceVariableExpression));

            InstanceVariableExpression ivexpression = (InstanceVariableExpression)mexpression.Target;
            Assert.AreEqual("r", ivexpression.Name);

            Assert.AreEqual("width:", mexpression.Selector);
            Assert.AreEqual(1, mexpression.Arguments.Count());
            Assert.IsInstanceOfType(mexpression.Arguments.First(), typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)mexpression.Arguments.First();
            Assert.AreEqual(100, cexpression.Value);
        }

        [TestMethod]
        public void ParseMessageWithTwoArguments()
        {
            ModelParser parser = new ModelParser("r width: 100 height: 200");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(InstanceVariableExpression));

            InstanceVariableExpression ivexpression = (InstanceVariableExpression)mexpression.Target;
            Assert.AreEqual("r", ivexpression.Name);

            Assert.AreEqual("width:height:", mexpression.Selector);
            Assert.AreEqual(2, mexpression.Arguments.Count());

            Assert.IsInstanceOfType(mexpression.Arguments.First(), typeof(ConstantExpression));

            ConstantExpression cexpression1 = (ConstantExpression)mexpression.Arguments.First();
            Assert.AreEqual(100, cexpression1.Value);

            Assert.IsInstanceOfType(mexpression.Arguments.Skip(1).First(), typeof(ConstantExpression));

            ConstantExpression cexpression2 = (ConstantExpression)mexpression.Arguments.Skip(1).First();
            Assert.AreEqual(200, cexpression2.Value);
        }
    }
}
