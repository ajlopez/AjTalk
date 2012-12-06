namespace AjTalk.Tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void ParseReal()
        {
            ModelParser parser = new ModelParser("12.34");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual(12.34, cexpression.Value);

            Assert.AreEqual("12.34", expression.AsString());
        }

        [TestMethod]
        public void ParseCharacter()
        {
            ModelParser parser = new ModelParser("$a");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.AreEqual('a', cexpression.Value);

            Assert.AreEqual("$a", expression.AsString());
        }

        [TestMethod]
        public void ParseNil()
        {
            ModelParser parser = new ModelParser("nil");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ConstantExpression));

            ConstantExpression cexpression = (ConstantExpression)expression;
            Assert.IsNull(cexpression.Value);

            Assert.AreEqual("nil", expression.AsString());
        }

        [TestMethod]
        public void ParseNestedExpression()
        {
            ModelParser parser = new ModelParser("((elementType = #systemSlot))");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("elementType = #systemSlot", expression.AsString());
        }

        [TestMethod]
        public void ParseNestedBinaryExpression()
        {
            ModelParser parser = new ModelParser("((elementType = #systemSlot) | (elementType == #userSlot))");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("elementType = #systemSlot | (elementType == #userSlot)", expression.AsString());
        }

        [TestMethod]
        public void ParseExpressionWithPrecedences()
        {
            ModelParser parser = new ModelParser("self asString displayAt: 0@100");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("self asString displayAt: 0 @ 100", expression.AsString());
        }

        [TestMethod]
        public void ParseExpressionWithBinaryAndUnaryMessage()
        {
            ModelParser parser = new ModelParser("index <= self size");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("index <= self size", expression.AsString());
        }

        [TestMethod]
        public void ParseExpressionWithBinaryAndKeywordMessageWithBlock()
        {
            ModelParser parser = new ModelParser("index >= 1 and: [index <= self size]");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("index >= 1 and: [index <= self size]", expression.AsString());
        }

        [TestMethod]
        public void ParseExpressionWithKeywordMessages()
        {
            ModelParser parser = new ModelParser("index and: (foo and: 2)");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.AreEqual("index and: (foo and: 2)", expression.AsString());
        }

        [TestMethod]
        public void ParseUnaryMinusExpression()
        {
            ModelParser parser = new ModelParser("-3");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;
            Assert.IsTrue(mexpression.IsUnaryMessage);

            Assert.AreEqual("-3", expression.AsString());
        }

        [TestMethod]
        public void ParseNativeMethodExpression()
        {
            ModelParser parser = new ModelParser("a !native");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;
            Assert.IsTrue(mexpression.IsUnaryMessage);

            Assert.AreEqual("a !native", expression.AsString());
        }

        [TestMethod]
        public void ParseNativeKeywordMethodExpression()
        {
            ModelParser parser = new ModelParser("a !native: 1");
            IExpression expression = parser.ParseExpression();
            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;
            Assert.IsTrue(mexpression.IsKeywordMessage);

            Assert.AreEqual("a !native: 1", expression.AsString());
        }

        [TestMethod]
        public void ParsePrimitive()
        {
            ModelParser parser = new ModelParser("<primitive: 60>");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(PrimitiveExpression));

            PrimitiveExpression pexpression = (PrimitiveExpression)expression;
            Assert.AreEqual(60, pexpression.Number);

            Assert.AreEqual("<primitive: 60>", expression.AsString());
        }

        [TestMethod]
        public void ParseNamedPrimitive()
        {
            ModelParser parser = new ModelParser("<primitive: 'Prim' module: 'Module'>");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(PrimitiveExpression));

            PrimitiveExpression pexpression = (PrimitiveExpression)expression;
            Assert.AreEqual(0, pexpression.Number);
            Assert.AreEqual("Prim", pexpression.Name);
            Assert.AreEqual("Module", pexpression.Module);

            Assert.AreEqual("<primitive: 'Prim' module: 'Module'>", expression.AsString());
        }

        [TestMethod]
        public void ParsePrimitiveWithExpression()
        {
            ModelParser parser = new ModelParser("<primitive: 60> a := 1");
            IEnumerable<IExpression> expressions = parser.ParseExpressions();

            Assert.IsNotNull(expressions);
            Assert.AreEqual(2, expressions.Count());
            Assert.IsInstanceOfType(expressions.First(), typeof(PrimitiveExpression));

            Assert.AreEqual("<primitive: 60>", expressions.First().AsString());
            Assert.AreEqual("a := 1", expressions.Skip(1).First().AsString());
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
            IEnumerable<IExpression> expressions = parser.ParseExpressions();

            Assert.IsNotNull(expressions);

            Assert.AreEqual(2, expressions.Count());
            Assert.AreEqual("x do", expressions.First().AsString());
            Assert.AreEqual("y do", expressions.Skip(1).First().AsString());
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
        public void ParseSimpleReturnMethod()
        {
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod();

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
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
            Assert.IsNotNull(method.Body);
            Assert.AreEqual(2, method.Body.Count());
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
            Assert.IsInstanceOfType(method.Body.First(), typeof(ReturnExpression));
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
            Assert.AreEqual(2, bexpression.Body.Count());
            Assert.AreEqual(0, bexpression.ParameterNames.Count);
            Assert.AreEqual(0, bexpression.LocalVariables.Count);

            Assert.AreEqual("[a := 1. b := 2]", expression.AsString());
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
            Assert.IsInstanceOfType(bexpression.Body.First(), typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.ParameterNames.Count);
            Assert.AreEqual("a", bexpression.ParameterNames[0]);
            Assert.AreEqual("b", bexpression.ParameterNames[1]);
            Assert.AreEqual(0, bexpression.LocalVariables.Count);

            Assert.AreEqual("[ :a :b | ^a + b]", expression.AsString());
        }

        [TestMethod]
        public void ParseBlockWithParametersWithSpaces()
        {
            ModelParser parser = new ModelParser("[ : a : b | ^a + b]");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(BlockExpression));

            BlockExpression bexpression = (BlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body.First(), typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.ParameterNames.Count);
            Assert.AreEqual("a", bexpression.ParameterNames[0]);
            Assert.AreEqual("b", bexpression.ParameterNames[1]);
            Assert.AreEqual(0, bexpression.LocalVariables.Count);

            Assert.AreEqual("[ :a :b | ^a + b]", expression.AsString());
        }

        [TestMethod]
        public void ParseFluentExpression()
        {
            ModelParser parser = new ModelParser("self do: 1 with: 2; do: 2 with: 3");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;
            Assert.IsInstanceOfType(mexpression.Target, typeof(FluentMessageExpression));
            Assert.IsNull(parser.ParseExpression());
            Assert.AreEqual("self do: 1 with: 2; do: 2 with: 3", expression.AsString());
        }

        [TestMethod]
        public void ParseFluentExpressionInReturn()
        {
            ModelParser parser = new ModelParser("^self do: 1 with: 2; yourself");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)expression;
            Assert.IsInstanceOfType(rexpression.Expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)rexpression.Expression;

            Assert.IsInstanceOfType(mexpression.Target, typeof(FluentMessageExpression));
            Assert.IsNull(parser.ParseExpression());
            Assert.AreEqual("^self do: 1 with: 2; yourself", expression.AsString());
        }

        [TestMethod]
        public void ParseTwoFluentExpressions()
        {
            ModelParser parser = new ModelParser("self do: 1 with: 2; do: 2 with: 3; do: 3 with: 4");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(MessageExpression));

            MessageExpression mexpression = (MessageExpression)expression;
            Assert.IsInstanceOfType(mexpression.Target, typeof(FluentMessageExpression));
            Assert.IsNull(parser.ParseExpression());
            Assert.AreEqual("self do: 1 with: 2; do: 2 with: 3; do: 3 with: 4", expression.AsString());
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
            Assert.IsInstanceOfType(bexpression.Body.First(), typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.ParameterNames.Count);
            Assert.AreEqual("a", bexpression.ParameterNames[0]);
            Assert.AreEqual("b", bexpression.ParameterNames[1]);
            Assert.AreEqual(2, bexpression.LocalVariables.Count);
            Assert.AreEqual("x", bexpression.LocalVariables[0]);
            Assert.AreEqual("y", bexpression.LocalVariables[1]);

            Assert.AreEqual("[ :a :b | | x y | ^a + b]", expression.AsString());
        }

        [TestMethod]
        public void ParseFreeBlockWithLocalVariables()
        {
            ModelParser parser = new ModelParser("| x y | ^a + b");
            IExpression expression = parser.ParseBlock();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(FreeBlockExpression));

            FreeBlockExpression bexpression = (FreeBlockExpression)expression;

            Assert.IsNotNull(bexpression.Body);
            Assert.IsInstanceOfType(bexpression.Body.First(), typeof(ReturnExpression));
            Assert.AreEqual(2, bexpression.LocalVariables.Count);
            Assert.AreEqual("x", bexpression.LocalVariables[0]);
            Assert.AreEqual("y", bexpression.LocalVariables[1]);

            Assert.AreEqual("| x y | ^a + b", expression.AsString());
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
            Assert.IsInstanceOfType(bexpression.Body.First(), typeof(ReturnExpression));
            Assert.AreEqual(0, bexpression.ParameterNames.Count);
            Assert.AreEqual(2, bexpression.LocalVariables.Count);
            Assert.AreEqual("x", bexpression.LocalVariables[0]);
            Assert.AreEqual("y", bexpression.LocalVariables[1]);

            Assert.AreEqual("[ | x y | ^a + b]", expression.AsString());
        }

        [TestMethod]
        public void ParseInstanceMethodReturningInstanceVariable()
        {
            ClassModel @class = new ClassModel("AClass", (ClassModel)null, new List<string>() { "x", "y" }, new List<string>(), false, null, null);
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod(@class, false);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
            Assert.AreEqual(0, method.LocalVariables.Count);
            Assert.IsInstanceOfType(method.Body.First(), typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)method.Body.First();
            Assert.IsInstanceOfType(rexpression.Expression, typeof(InstanceVariableExpression));
        }

        [TestMethod]
        public void ParseClassMethodReturningClassVariable()
        {
            ClassModel @class = new ClassModel("AClass", (ClassModel)null, new List<string>(), new List<string>() { "x", "y" }, false, null, null);
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod(@class, true);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Selector);
            Assert.AreEqual(0, method.ParameterNames.Count);
            Assert.AreEqual(0, method.LocalVariables.Count);
            Assert.IsInstanceOfType(method.Body.First(), typeof(ReturnExpression));

            ReturnExpression rexpression = (ReturnExpression)method.Body.First();
            Assert.IsInstanceOfType(rexpression.Expression, typeof(ClassVariableExpression));
        }

        [TestMethod]
        public void ParseIntegerArray()
        {
            ModelParser parser = new ModelParser("#(1 2 3)");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ArrayExpression));

            ArrayExpression cexpression = (ArrayExpression)expression;
            Assert.AreEqual(3, cexpression.Expressions.Count());

            foreach (IExpression item in cexpression.Expressions)
                Assert.IsInstanceOfType(item, typeof(ConstantExpression));

            Assert.AreEqual("#(1 2 3)", expression.AsString());
        }

        [TestMethod]
        public void ParseSymbolAndStringArray()
        {
            ModelParser parser = new ModelParser("#('option1' do1:)");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ArrayExpression));

            ArrayExpression cexpression = (ArrayExpression)expression;
            Assert.AreEqual(2, cexpression.Expressions.Count());

            Assert.IsInstanceOfType(cexpression.Expressions.First(), typeof(ConstantExpression));
            Assert.IsInstanceOfType(cexpression.Expressions.Skip(1).First(), typeof(SymbolExpression));

            Assert.AreEqual("#('option1' do1:)", expression.AsString());
        }

        [TestMethod]
        public void ParseExplicitSymbolAndStringArray()
        {
            ModelParser parser = new ModelParser("#('option1' #do)");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ArrayExpression));

            ArrayExpression cexpression = (ArrayExpression)expression;
            Assert.AreEqual(2, cexpression.Expressions.Count());

            Assert.IsInstanceOfType(cexpression.Expressions.First(), typeof(ConstantExpression));
            Assert.IsInstanceOfType(cexpression.Expressions.Skip(1).First(), typeof(SymbolExpression));

            Assert.AreEqual("#('option1' do)", expression.AsString());
        }

        [TestMethod]
        public void ParseOperatorArray()
        {
            ModelParser parser = new ModelParser("#(- +)");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ArrayExpression));

            ArrayExpression cexpression = (ArrayExpression)expression;
            Assert.AreEqual(2, cexpression.Expressions.Count());

            Assert.IsInstanceOfType(cexpression.Expressions.First(), typeof(SymbolExpression));
            Assert.IsInstanceOfType(cexpression.Expressions.Skip(1).First(), typeof(SymbolExpression));

            Assert.AreEqual("#(- +)", expression.AsString());
        }

        [TestMethod]
        public void ParseArrayOfArrays()
        {
            ModelParser parser = new ModelParser("#((1 2 3) (1 2 3) (1 2 3))");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(ArrayExpression));

            ArrayExpression cexpression = (ArrayExpression)expression;
            Assert.AreEqual(3, cexpression.Expressions.Count());

            foreach (IExpression item in cexpression.Expressions)
                Assert.IsInstanceOfType(item, typeof(ArrayExpression));

            Assert.AreEqual("#((1 2 3) (1 2 3) (1 2 3))", expression.AsString());
        }

        [TestMethod]
        public void ParseDynamicIntegerArray()
        {
            ModelParser parser = new ModelParser("{1. 2. 3}");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(DynamicArrayExpression));

            DynamicArrayExpression cexpression = (DynamicArrayExpression)expression;
            Assert.AreEqual(3, cexpression.Expressions.Count());

            foreach (IExpression item in cexpression.Expressions)
                Assert.IsInstanceOfType(item, typeof(ConstantExpression));

            Assert.AreEqual("{1. 2. 3}", expression.AsString());
        }

        [TestMethod]
        public void ParseDynamicArrayWithExpressions()
        {
            ModelParser parser = new ModelParser("{1+2. 2->5. a do: 1}");
            IExpression expression = parser.ParseExpression();

            Assert.IsNotNull(expression);
            Assert.IsInstanceOfType(expression, typeof(DynamicArrayExpression));

            DynamicArrayExpression cexpression = (DynamicArrayExpression)expression;
            Assert.AreEqual(3, cexpression.Expressions.Count());

            Assert.AreEqual("{1 + 2. 2 -> 5. a do: 1}", expression.AsString());
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

        [TestMethod]
        public void CompileBlockWithDot()
        {
            Lexer lexer = new Lexer("[. 1. 2]");
            ModelParser parser = new ModelParser(lexer);
            var result = parser.ParseBlock();
            Assert.IsNotNull(result);
        }
    }
}
