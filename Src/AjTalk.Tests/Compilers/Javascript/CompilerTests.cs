namespace AjTalk.Tests.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compilers;
    using AjTalk.Compilers.Javascript;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompilerTests
    {
        private Compiler compiler;
        private StringWriter writer;

        [TestInitialize]
        public void Setup()
        {
            this.writer = new StringWriter();
            this.compiler = new Compiler(new SourceWriter(this.writer));
        }

        [TestMethod]
        public void CompileSimpleAddMethod()
        {
            MethodModel method = ParseMethod("with: a with: b ^a+b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function _with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return send(a, '+', [b]);"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileSimpleSubtractMethod()
        {
            MethodModel method = ParseMethod("with: a with: b ^a-b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function _with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return send(a, '-', [b]);"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileSimpleMultiplyMethod()
        {
            MethodModel method = ParseMethod("with: a with: b ^a*b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function _with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return send(a, '*', [b]);"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileAssocOperatorMethod()
        {
            MethodModel method = ParseMethod("-> a ^a");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function ->(a)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return a;"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileEqualOperatorMethod()
        {
            MethodModel method = ParseMethod("= a ^a");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function =(a)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return a;"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileNotEqualOperatorMethod()
        {
            MethodModel method = ParseMethod("~= a ^a");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function ~=(a)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return a;"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileVariableWithReservedWordClass()
        {
            IExpression expression = ParseExpression("class");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "__class__"));
        }

        [TestMethod]
        public void CompileBlockAsTarget()
        {
            IExpression expression = ParseExpression("[a > 0] whileTrue: [b := b + 1]");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(function() {"));
        }

        [TestMethod]
        public void CompileNotEqualOperator()
        {
            IExpression expression = ParseExpression("a ~~ b");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(a, '~~', [b])"));
        }

        [TestMethod]
        public void CompileCharacter()
        {
            IExpression expression = ParseExpression("$@");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "'@'"));
        }

        [TestMethod]
        public void CompileAtOperator()
        {
            IExpression expression = ParseExpression("a @ b");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(a, '@', [b])"));
        }

        [TestMethod]
        public void CompileAtOperatorInExpression()
        {
            IExpression expression = ParseExpression("self asString displayAt: 0@100");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(send(self, '_asString'), '_displayAt_', [send(0, '@', [100])])"));
        }

        [TestMethod]
        public void CompileSimpleSendMessageToInteger()
        {
            IExpression expression = ParseExpression("1 add: 2");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(1, '_add_', [2])"));
        }

        [TestMethod]
        public void CompileSimpleSendMessageToBoolean()
        {
            IExpression expression = ParseExpression("false foo: 2");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(false, '_foo_', [2])"));
        }

        [TestMethod]
        public void CompileSimpleExpressionWithBinaryAndKeywordMessages()
        {
            IExpression expression = ParseExpression("index >= 1 and: 2");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(send(index, '>=', [1]), '_and_', [2])"));
        }

        [TestMethod]
        public void CompileSimpleExpressionWithTwoBinaryMessages()
        {
            IExpression expression = ParseExpression("index + 1 * 2");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send(send(index, '+', [1]), '*', [2])"));
        }

        [TestMethod]
        public void CompileSimpleSendMessageToString()
        {
            IExpression expression = ParseExpression("'foo' add: 2");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "send('foo', '_add_', [2])"));
        }

        [TestMethod]
        public void CompileSimpleMethodWithSet()
        {
            MethodModel method = ParseMethod("with: a with: b a := b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function _with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "a = b;"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileSimpleClass()
        {
            ClassModel @class = new ClassModel("AClass", null, null, null);
            this.compiler.CompileClass(@class);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function AClassClass()"));
            Assert.IsTrue(ContainsLine(output, "function AClass()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "this._class = new AClassClass();"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileSimpleClassWithInstanceVariables()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>() { "x", "y" }, new List<string>());
            this.compiler.CompileClass(@class);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function AClass()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "}"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.x = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.y = null;"));
        }

        [TestMethod]
        public void CompileSimpleClassWithClassVariables()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>(), new List<string>() { "x", "y" });
            this.compiler.CompileClass(@class);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function AClass()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "}"));
            Assert.IsTrue(ContainsLine(output, "AClassClass.x = null;"));
            Assert.IsTrue(ContainsLine(output, "AClassClass.y = null;"));
        }

        [TestMethod]
        public void CompileSimpleClassWithSimpleMethod()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>() { "x", "y" }, new List<string>());
            ModelParser parser = new ModelParser("x ^x");
            MethodModel method = parser.ParseMethod(@class, false);
            @class.InstanceMethods.Add(method);
            this.compiler.CompileClass(@class);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function AClass()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "}"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.x = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.y = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype['_x'] = function()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return this.x;"));
            Assert.IsTrue(ContainsLine(output, "};"));
        }

        [TestMethod]
        public void CompileSimpleClassWithSimpleSetMethod()
        {
            ClassModel @class = new ClassModel("AClass", null, new List<string>() { "x", "y" }, new List<string>());
            ModelParser parser = new ModelParser("x: newX x := newX");
            MethodModel method = parser.ParseMethod(@class, false);
            @class.InstanceMethods.Add(method);
            this.compiler.CompileClass(@class);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function AClass()"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "}"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.x = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.y = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.prototype['_x_'] = function(newX)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "var self = this;"));
            Assert.IsTrue(ContainsLine(output, "this.x = newX;"));
            Assert.IsTrue(ContainsLine(output, "};"));
        }

        [TestMethod]
        public void CompilePrimitiveInMethod()
        {
            MethodModel method = ParseMethod("= b <primitive: 60> ^self value equals: b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "var _primitive = Primitive60(self, b);"));
            Assert.IsTrue(ContainsLine(output, "if (_primitive) return _primitive.value;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void CompileFileOut01()
        {
            ChunkReader chunkReader = new ChunkReader(@"FileOut01.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Object()"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut02.st")]
        public void CompileFileOut02()
        {
            ChunkReader chunkReader = new ChunkReader(@"FileOut02.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Object()"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakObject.st")]
        public void CompileSqueakObject()
        {
            ChunkReader chunkReader = new ChunkReader(@"SqueakObject.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Object()"));
            Assert.IsTrue(ContainsLine(output, "exports.Object = Object;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakKernelObjects.st")]
        public void CompileSqueakKernelObjects()
        {
            ChunkReader chunkReader = new ChunkReader(@"SqueakKernelObjects.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Object()"));
            Assert.IsTrue(ContainsLine(output, "function Boolean()"));
            Assert.IsTrue(ContainsLine(output, "exports.Object = Object;"));
            Assert.IsTrue(ContainsLine(output, "exports.Boolean = Boolean;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        public void CompilePharoCoreKernelObjects()
        {
            ChunkReader chunkReader = new ChunkReader(@"PharoCoreKernelObjects.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Object()"));
            Assert.IsTrue(ContainsLine(output, "function Boolean()"));
            Assert.IsTrue(ContainsLine(output, "exports.Object = Object;"));
            Assert.IsTrue(ContainsLine(output, "exports.Boolean = Boolean;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCorePoint.st")]
        public void CompilePharoCorePoint()
        {
            ChunkReader chunkReader = new ChunkReader(@"PharoCorePoint.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Point()"));
            Assert.IsTrue(ContainsLine(output, "exports.Point = Point;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreRectangle.st")]
        public void CompilePharoCoreRectangle()
        {
            ChunkReader chunkReader = new ChunkReader(@"PharoCoreRectangle.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "function Rectangle()"));
            Assert.IsTrue(ContainsLine(output, "exports.Rectangle = Rectangle;"));
        }

        private static MethodModel ParseMethod(string text)
        {
            ModelParser parser = new ModelParser(text);
            return parser.ParseMethod();
        }

        private static IExpression ParseExpression(string text)
        {
            ModelParser parser = new ModelParser(text);
            return parser.ParseExpression();
        }

        private static bool ContainsLine(string text, string line)
        {
            StringReader reader = new StringReader(text);

            string ln;

            while ((ln = reader.ReadLine()) != null)
                if (line == ln.Trim())
                    return true;

            return false;
        }
    }
}
