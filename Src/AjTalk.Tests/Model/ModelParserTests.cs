namespace AjTalk.Tests.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Model;
    using AjTalk.Compiler;
    using System.IO;

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
        public void ParseVariable()
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
        public void ParseSymbol()
        {
            ModelParser parser = new ModelParser("#foo");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(SymbolExpression));

            SymbolExpression sexpression = (SymbolExpression)expression;
            Assert.AreEqual("foo", sexpression.Symbol);

            Assert.AreEqual("#foo", expression.AsString());
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
        public void ParsePrimitive()
        {
            ModelParser parser = new ModelParser("<primitive: 60>");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(PrimitiveExpression));

            PrimitiveExpression pexpression = (PrimitiveExpression)expression;
            Assert.AreEqual(60, pexpression.Primitive);

            Assert.AreEqual("<primitive: 60>", expression.AsString());
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
        public void ParseReturn()
        {
            ModelParser parser = new ModelParser("^10");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)expression;

            Assert.IsInstanceOfType(rexpression.Expression, typeof(ConstantExpression));
            Assert.AreEqual(10, ((ConstantExpression)rexpression.Expression).Value);
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
        public void ParseSet()
        {
            ModelParser parser = new ModelParser("a := b + c");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(SetExpression));

            SetExpression sexpression = (SetExpression)expression;
            Assert.AreEqual("a", sexpression.LeftValue.Name);
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
            Assert.AreEqual(0, method.LocalVariables.Count);
        }

        [TestMethod]
        public void ParseMethodWithBinaryOperator()
        {
            ModelParser parser = new ModelParser("+ aNumber aNumber do. ^aNumber");
            MethodModel method = parser.ParseMethod();

            Assert.IsNotNull(method);
            Assert.AreEqual("+", method.Selector);
            Assert.AreEqual(1, method.ParameterNames.Count);
            Assert.AreEqual("aNumber", method.ParameterNames[0]);
            Assert.AreEqual(0, method.LocalVariables.Count);
            Assert.IsInstanceOfType(method.Body, typeof(CompositeExpression));
        }

        [TestMethod]
        public void ParseMethodWithLocalVariables()
        {
            ModelParser parser = new ModelParser("doSomething | a b c | ^10");
            MethodModel method = parser.ParseMethod();

            Assert.IsNotNull(method);
            Assert.AreEqual("doSomething", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
            Assert.AreEqual(3, method.LocalVariables.Count);
            Assert.AreEqual("a", method.LocalVariables[0]);
            Assert.AreEqual("b", method.LocalVariables[1]);
            Assert.AreEqual("c", method.LocalVariables[2]);
            Assert.IsInstanceOfType(method.Body, typeof(ReturnExpression));
        }

        [TestMethod]
        public void ParseSimpleBlock()
        {
            ModelParser parser = new ModelParser("[ a := 1. b := 2]");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(BlockExpression));

            BlockExpression bexpression = (BlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body, typeof(CompositeExpression));
            Assert.AreEqual(0, bexpression.ParameterNames.Count);
            Assert.AreEqual(0, bexpression.LocalVariables.Count);
        }

        [TestMethod]
        public void ParseBlockWithParameters()
        {
            ModelParser parser = new ModelParser("[ :a :b | ^a + b]");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(BlockExpression));

            BlockExpression bexpression = (BlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body, typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.ParameterNames.Count);
            Assert.AreEqual("a", bexpression.ParameterNames[0]);
            Assert.AreEqual("b", bexpression.ParameterNames[1]);
            Assert.AreEqual(0, bexpression.LocalVariables.Count);
        }

        [TestMethod]
        public void ParseBlockWithParametersAndLocalVariables()
        {
            ModelParser parser = new ModelParser("[ :a :b | | x y | ^a + b]");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(BlockExpression));

            BlockExpression bexpression = (BlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body, typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.ParameterNames.Count);
            Assert.AreEqual("a", bexpression.ParameterNames[0]);
            Assert.AreEqual("b", bexpression.ParameterNames[1]);
            Assert.AreEqual(2, bexpression.LocalVariables.Count);
            Assert.AreEqual("x", bexpression.LocalVariables[0]);
            Assert.AreEqual("y", bexpression.LocalVariables[1]);
        }

        [TestMethod]
        public void ParseBlockWithLocalVariables()
        {
            ModelParser parser = new ModelParser("[ | x y | ^a + b]");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(BlockExpression));

            BlockExpression bexpression = (BlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body, typeof(ReturnExpression));
            Assert.AreEqual(0, bexpression.ParameterNames.Count);
            Assert.AreEqual(2, bexpression.LocalVariables.Count);
            Assert.AreEqual("x", bexpression.LocalVariables[0]);
            Assert.AreEqual("y", bexpression.LocalVariables[1]);
        }

        [TestMethod]
        public void ParseInstanceMethodReturningInstanceVariable()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>() { "x", "y" }, new List<string>());
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod(@class, false);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
            Assert.AreEqual(0, method.LocalVariables.Count);
            Assert.IsInstanceOfType(method.Body, typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)method.Body;
            Assert.IsInstanceOfType(rexpression.Expression, typeof(InstanceVariableExpression));
        }

        [TestMethod]
        public void ParseClassMethodReturningClassVariable()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>(), new List<string>() { "x", "y" });
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod(@class, true);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
            Assert.AreEqual(0, method.LocalVariables.Count);
            Assert.IsInstanceOfType(method.Body, typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)method.Body;
            Assert.IsInstanceOfType(rexpression.Expression, typeof(ClassVariableExpression));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\ProtoObject.st")]
        public void ParseProtoObjectSubclassObject()
        {
            Lexer lexer = new Lexer(new StreamReader("ProtoObject.st"));
            ModelParser parser = new ModelParser(lexer);
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;

            Assert.AreEqual("subclass:instanceVariableNames:classVariableNames:poolDictionaries:category:", mexpression.Selector);
        }
    }
}
