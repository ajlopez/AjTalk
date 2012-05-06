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
    public class NodeCompilerTests
    {
        private NodeCompiler compiler;
        private StringWriter writer;

        [TestInitialize]
        public void Setup()
        {
            this.writer = new StringWriter();
            this.compiler = new NodeCompiler(new SourceWriter(this.writer));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakObject.st")]
        public void CompileSqueakObjectForNodeJs()
        {
            ChunkReader chunkReader = new ChunkReader(@"SqueakObject.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            // TODO more tests
            Assert.IsTrue(ContainsLine(output, "var base = require('./js/ajtalk-base.js');"));
            Assert.IsTrue(ContainsLine(output, "var send = base.send;"));
            Assert.IsTrue(ContainsLine(output, "var sendSuper = base.sendSuper;"));
            Assert.IsTrue(ContainsLine(output, "var primitives = require('./js/ajtalk-primitives.js');"));

            Assert.IsTrue(ContainsLine(output, "function Object()"));

            Assert.IsTrue(ContainsLine(output, "exports.Object = Object;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        [DeploymentItem(@"CodeFiles\PharoCorePoint.st")]
        public void CompilePharoCorePointForNodeJs()
        {
            ChunkReader chunkCoreReader = new ChunkReader(@"PharoCoreKernelObjects.st");
            CodeReader coreReader = new CodeReader(chunkCoreReader);
            ChunkReader chunkReader = new ChunkReader(@"PharoCorePoint.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            coreReader.Process(model);
            reader.Process(model);

            this.compiler.Visit(model);
            this.writer.Close();
            string output = this.writer.ToString();

            Assert.IsTrue(ContainsLine(output, "var base = require('./js/ajtalk-base.js');"));
            Assert.IsTrue(ContainsLine(output, "var send = base.send;"));
            Assert.IsTrue(ContainsLine(output, "var sendSuper = base.sendSuper;"));
            Assert.IsTrue(ContainsLine(output, "var primitives = require('./js/ajtalk-primitives.js');"));

            Assert.IsTrue(ContainsLine(output, "function Point()"));
            Assert.IsTrue(ContainsLine(output, "PointClass.__super = ObjectClass;"));
            Assert.IsTrue(ContainsLine(output, "Point.__super = Object;"));
            Assert.IsTrue(ContainsLine(output, "PointClass.prototype.__proto__ = ObjectClass.prototype;"));
            Assert.IsTrue(ContainsLine(output, "Point.prototype.__proto__ = Object.prototype;"));
            Assert.IsTrue(ContainsLine(output, "exports.Point = Point;"));
            Assert.IsTrue(ContainsLine(output, "Point.prototype.$x = null;"));
            Assert.IsTrue(ContainsLine(output, "Point.prototype.$y = null;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakKernelObjects.st")]
        public void CompileSqueakKernelObjectsForNodeJs()
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

            // Class variables in Object
            Assert.IsTrue(ContainsLine(output, "ObjectClass.$DependentsFields = null;"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        public void CompilePharoCoreKernelObjectsForNodeJs()
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
            Assert.IsTrue(ContainsLine(output, "ObjectClass.__super = ProtoObjectClass;"));
            Assert.IsTrue(ContainsLine(output, "Object.__super = ProtoObject;"));
            Assert.IsTrue(ContainsLine(output, "ObjectClass.prototype.__proto__ = ProtoObjectClass.prototype;"));
            Assert.IsTrue(ContainsLine(output, "Object.prototype.__proto__ = ProtoObject.prototype;"));
            Assert.IsTrue(ContainsLine(output, "BooleanClass.prototype.__proto__ = ObjectClass.prototype;"));
            Assert.IsTrue(ContainsLine(output, "Boolean.prototype.__proto__ = Object.prototype;"));
            Assert.IsTrue(ContainsLine(output, "function Boolean()"));
            Assert.IsTrue(ContainsLine(output, "exports.Object = Object;"));
            Assert.IsTrue(ContainsLine(output, "exports.Boolean = Boolean;"));
            Assert.IsTrue(ContainsLine(output, "exports.ProtoObject = ProtoObject;"));
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
