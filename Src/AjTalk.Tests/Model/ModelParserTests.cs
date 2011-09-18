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

            Assert.AreEqual("self", expression.AsString());
        }

        [TestMethod]
        public void ParseInstanceVariable()
        {
            ModelParser parser = new ModelParser("foo");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(VariableExpression));

            VariableExpression vexpression = (VariableExpression)expression;
            Assert.AreEqual("foo", vexpression.Name);

            Assert.AreEqual("foo", expression.AsString());
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

            Assert.AreEqual("'foo'", expression.AsString());
        }

        [TestMethod]
        public void ParseFalse()
        {
            ModelParser parser = new ModelParser("false");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual(false, cexpression.Value);

            Assert.AreEqual("false", expression.AsString());
        }

        [TestMethod]
        public void ParseTrue()
        {
            ModelParser parser = new ModelParser("true");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual(true, cexpression.Value);

            Assert.AreEqual("true", expression.AsString());
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

            Assert.AreEqual("123", expression.AsString());
        }

        [TestMethod]
        public void ParseUnaryMessage()
        {
            ModelParser parser = new ModelParser("x length");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(VariableExpression));
            Assert.AreEqual("length", mexpression.Selector);
            Assert.AreEqual(0, mexpression.Arguments.Count());

            Assert.AreEqual("x length", expression.AsString());
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

            Assert.IsInstanceOfType(mexpression.Target, typeof(VariableExpression));

            VariableExpression vexpression = (VariableExpression)mexpression.Target;
            Assert.AreEqual("r", vexpression.Name);

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

            Assert.IsInstanceOfType(mexpression.Target, typeof(VariableExpression));

            VariableExpression vexpression = (VariableExpression)mexpression.Target;
            Assert.AreEqual("r", vexpression.Name);

            Assert.AreEqual("width:height:", mexpression.Selector);
            Assert.AreEqual(2, mexpression.Arguments.Count());

            Assert.IsInstanceOfType(mexpression.Arguments.First(), typeof(ConstantExpression));

            ConstantExpression cexpression1 = (ConstantExpression)mexpression.Arguments.First();
            Assert.AreEqual(100, cexpression1.Value);

            Assert.IsInstanceOfType(mexpression.Arguments.Skip(1).First(), typeof(ConstantExpression));

            ConstantExpression cexpression2 = (ConstantExpression)mexpression.Arguments.Skip(1).First();
            Assert.AreEqual(200, cexpression2.Value);

            Assert.AreEqual("r width: 100 height: 200", expression.AsString());
        }

        [TestMethod]
        public void ParseAddMessage()
        {
            ModelParser parser = new ModelParser("10 + 20");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(ConstantExpression));

            ConstantExpression cleftexpression = (ConstantExpression)mexpression.Target;
            Assert.AreEqual(10, cleftexpression.Value);

            Assert.AreEqual("+", mexpression.Selector);
            Assert.AreEqual(1, mexpression.Arguments.Count());
            Assert.IsInstanceOfType(mexpression.Arguments.First(), typeof(ConstantExpression));

            ConstantExpression crightexpression = (ConstantExpression)mexpression.Arguments.First();
            Assert.AreEqual(20, crightexpression.Value);

            Assert.AreEqual("10 + 20", expression.AsString());
        }

        [TestMethod]
        public void ParseTwoExpressions()
        {
            ModelParser parser = new ModelParser("x do. y do");
            IExpression expression = parser.ParseExpressions();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(CompositeExpression));

            Assert.AreEqual("x do. y do", expression.AsString());
        }

        [TestMethod]
        public void ParseSimpleMethod()
        {
            ModelParser parser = new ModelParser("width: aWidth height: aHeight width do. heigth do");
            MethodModel method = parser.ParseMethod();

            Assert.IsNotNull(method);
            Assert.AreEqual("width:height:", method.Selector);
            Assert.AreEqual(2, method.ParameterNames.Count);
            Assert.AreEqual("aWidth", method.ParameterNames[0]);
            Assert.AreEqual("aHeight", method.ParameterNames[1]);
        }
    }
}
