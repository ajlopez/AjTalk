namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    [DeploymentItem("AssertTests", "AssertTests")]
    public class AssertTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.LoadFile(@"AssertTests\Library.st");
        }

        [TestMethod]
        public void ArithmeticAsserts()
        {
            DoAssert("Arithmetic");
        }

        [TestMethod]
        public void StringAsserts()
        {
            DoAssert("String");
        }

        [TestMethod]
        public void CharAsserts()
        {
            DoAssert("Char");
        }

        [TestMethod]
        public void BooleanAsserts()
        {
            DoAssert("Boolean");
        }

        [TestMethod]
        public void ArrayListAsserts()
        {
            DoAssert("ArrayList");
        }

        [TestMethod]
        public void ObjectAsserts()
        {
            DoAssert("Object");
        }

        [TestMethod]
        public void SmalltalkAsserts()
        {
            DoAssert("Smalltalk");
        }

        [TestMethod]
        public void LoadEnvironmentTests()
        {
            VmCompiler compiler = new VmCompiler();
            var block = compiler.CompileBlock(File.ReadAllText("AssertTests\\EnvironmentTests.st"));
            Assert.IsNotNull(block);
            Assert.IsTrue(block.NoConstants > 0);
        }

        [TestMethod]
        public void EnvironmentAsserts()
        {
            DoAssert("Environment");
        }

        private void DoAssert(string filename)
        {
            this.LoadFile(@"AssertTests\" + filename + "Tests.st");
        }

        private void LoadFile(string filename)
        {
            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(this.machine);
        }
    }
}
