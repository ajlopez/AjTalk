namespace AjTalk.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AjTalk.Compiler;
    using AjTalk.Exceptions;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem(@"lib\Library.st")]
    public class LibraryEvaluateTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = LoaderTests.CreateMachine();
            this.LoadFile("Library.st");
        }

        [TestMethod]
        public void NilIsNilIsNotNil()
        {
            Assert.AreEqual(true, this.Evaluate("nil isNil"));
            Assert.AreEqual(false, this.Evaluate("nil isNotNil"));
        }

        [TestMethod]
        public void NilIfNilIfNotNil()
        {
            Assert.AreEqual(1, this.Evaluate("nil ifNil: [1]"));
            Assert.AreEqual(null, this.Evaluate("nil ifNotNil: [1]"));
        }

        [TestMethod]
        public void StringIsNilIsNotNil()
        {
            Assert.AreEqual(false, this.Evaluate("'foo' isNil"));
            Assert.AreEqual(true, this.Evaluate("'foo' isNotNil"));
        }

        [TestMethod]
        public void IntegerIsNilIsNotNil()
        {
            Assert.AreEqual(false, this.Evaluate("0 isNil"));
            Assert.AreEqual(true, this.Evaluate("1 isNotNil"));
        }

        [TestMethod]
        public void StringIfNilIfNotNil()
        {
            Assert.AreEqual(null, this.Evaluate("'foo' ifNil: [1]"));
            Assert.AreEqual(1, this.Evaluate("'foo' ifNotNil: [1]"));
        }

        [TestMethod]
        public void IntegerIfNilIfNotNil()
        {
            Assert.AreEqual(null, this.Evaluate("0 ifNil: [1]"));
            Assert.AreEqual(1, this.Evaluate("0 ifNotNil: [1]"));
        }

        [TestMethod]
        public void BooleanIfNilIfNotNil()
        {
            Assert.AreEqual(null, this.Evaluate("false ifNil: [1]"));
            Assert.AreEqual(1, this.Evaluate("true ifNotNil: [1]"));
        }

        [TestMethod]
        public void BooleanIsNilIsNotNil()
        {
            Assert.AreEqual(false, this.Evaluate("false isNil"));
            Assert.AreEqual(false, this.Evaluate("true isNil"));
            Assert.AreEqual(true, this.Evaluate("false isNotNil"));
            Assert.AreEqual(true, this.Evaluate("true isNotNil"));
        }

        private object Evaluate(string text)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(this.machine, null);
        }

        private object Evaluate(string text, Machine machine)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(machine, null);
        }

        private void LoadFile(string filename)
        {
            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(this.machine);
        }
    }
}
