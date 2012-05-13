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
            Assert.IsTrue(ContainsLine(output, "ajtalk = require('./lib/ajtalk.js');"));
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
