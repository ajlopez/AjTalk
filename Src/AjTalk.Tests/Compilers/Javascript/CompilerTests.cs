namespace AjTalk.Tests.Compilers.Javascript
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;
    using AjTalk.Compilers.Javascript;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class CompilerTests
    {
        private Compiler compiler;
        private StringWriter writer;

        [TestInitialize]
        public void Setup()
        {
            this.writer = new StringWriter();
            this.compiler = new Compiler(this.writer);
        }

        [TestMethod]
        public void CompileSimpleMethod()
        {
            MethodModel method = ParseMethod("with: a with: b ^a+b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function $with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "return a + b;"));
            Assert.IsTrue(ContainsLine(output, "}"));
        }

        [TestMethod]
        public void CompileSimpleMethodWithSet()
        {
            MethodModel method = ParseMethod("with: a with: b a := b");
            this.compiler.CompileMethod(method);
            this.writer.Close();
            string output = this.writer.ToString();
            Assert.IsTrue(ContainsLine(output, "function $with_with_(a, b)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "a = b;"));
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
            Assert.IsTrue(ContainsLine(output, "AClass.x = null;"));
            Assert.IsTrue(ContainsLine(output, "AClass.y = null;"));
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
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.$x = function()"));
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
            Assert.IsTrue(ContainsLine(output, "AClass.prototype.$x_ = function(newX)"));
            Assert.IsTrue(ContainsLine(output, "{"));
            Assert.IsTrue(ContainsLine(output, "this.x = newX;"));
            Assert.IsTrue(ContainsLine(output, "};"));
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

        private static MethodModel ParseMethod(string text)
        {
            ModelParser parser = new ModelParser(text);
            return parser.ParseMethod();
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
