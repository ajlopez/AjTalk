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
    public class VirtualMachineCompilerTests
    {
        private VirtualMachineCompiler compiler;
        private StringWriter writer;

        [TestInitialize]
        public void Setup()
        {
            this.writer = new StringWriter();
            this.compiler = new VirtualMachineCompiler(new SourceWriter(this.writer));
        }

        [TestMethod]
        public void CompileEmptyModel()
        {
            CodeModel model = new CodeModel();
            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            Assert.IsTrue(ContainsLine(output, "var ajtalk;"));
            Assert.IsTrue(ContainsLine(output, "var Smalltalk;"));
            Assert.IsTrue(ContainsLine(output, "if (typeof(ajtalk) === 'undefined')"));
            Assert.IsTrue(ContainsLine(output, "ajtalk = require('ajtalk.js');"));
            Assert.IsTrue(ContainsLine(output, "if (typeof(Smalltalk) === 'undefined')"));
            Assert.IsTrue(ContainsLine(output, "Smalltalk = ajtalk.Smalltalk;"));
        }

        [TestMethod]
        public void CompileSuperMethod()
        {
            MethodModel method = ParseMethod("with: a ^super with: a");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "Smalltalk.MyClass.defineMethod('with:', function(a)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return sendSuper(self, MyClass, 'with_', [a]);"));
            Assert.IsTrue(ContainsLine(output, "});"));
        }

        [TestMethod]
        public void CompileSimpleAddMethod()
        {
            MethodModel method = ParseMethod("with: a with: b ^a+b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "Smalltalk.MyClass.defineMethod('with:with:', function(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return a['+'](b);"));
            Assert.IsTrue(ContainsLine(output, "});"));
        }

        [TestMethod]
        public void CompileNativeAtPut()
        {
            IExpression expression = ParseExpression("p nat: 'x' put: 10");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "p['x'] = 10"));
        }

        [TestMethod]
        public void CompileNativeAt()
        {
            IExpression expression = ParseExpression("'foo' nat: 'length'");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "'foo'['length']"));
        }

        [TestMethod]
        public void CompileNativeApply()
        {
            IExpression expression = ParseExpression("p napply: 'toUpper'");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "p['toUpper']()"));
        }

        [TestMethod]
        public void CompileNativeApplyWith()
        {
            IExpression expression = ParseExpression("p napply: 'process' with: {x. y}");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "var __target = p;"));
            Assert.IsTrue(ContainsLine(output, "return __target['process'].apply(__target, [x, y]);"));
        }

        [TestMethod]
        public void CompileNativeNew()
        {
            IExpression expression = ParseExpression("MyClass nnew");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "var __target = MyClass;"));
            Assert.IsTrue(ContainsLine(output, "return __target.prototype.constructor.apply(__target, null);"));
        }

        [TestMethod]
        public void CompileNativeNewWithArgumentos()
        {
            IExpression expression = ParseExpression("MyClass nnew: {'foo'. 20}");
            expression.Visit(this.compiler);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "var __target = MyClass;"));
            Assert.IsTrue(ContainsLine(output, "return __target.prototype.constructor.apply(__target, ['foo', 20]);"));
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
            Assert.IsTrue(ContainsLine(output, "var ajtalk;"));
            Assert.IsTrue(ContainsLine(output, "var Smalltalk;"));
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
            Assert.IsTrue(ContainsLine(output, "Smalltalk.Object.subclass_instanceVariableNames_classVariableNames_('MessageSend', 'receiver selector arguments', '');"));
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
            Assert.IsTrue(ContainsLine(output, "Smalltalk.Object.subclass_instanceVariableNames_classVariableNames_('MessageSend', 'receiver selector arguments', '');"));
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
            Assert.IsTrue(ContainsLine(output, "Smalltalk.Object.subclass_instanceVariableNames_classVariableNames_('Point', 'x y', '');"));
            Assert.IsTrue(ContainsLine(output, "factor = 3['reciprocal']();"));            
        }

        private static MethodModel ParseMethod(string text)
        {
            ModelParser parser = new ModelParser(text);
            ClassModel classModel = new ClassModel("MyClass", null, null, null);
            return parser.ParseMethod(classModel, false);
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
