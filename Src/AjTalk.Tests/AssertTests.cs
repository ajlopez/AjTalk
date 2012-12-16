namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem("lib", "lib")]
    [DeploymentItem("AssertTests", "AssertTests")]
    public class AssertTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.LoadFile(@"lib\Library.st");
        }

        [TestMethod]
        public void ArithmeticAsserts()
        {
            DoAssert("Arithmetic");
        }

        [TestMethod]
        public void IntegerAsserts()
        {
            DoAssert("Integer");
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
        public void ObjectListAsserts()
        {
            DoAssert("ObjectList");
        }

        [TestMethod]
        public void ObjectDictionaryAsserts()
        {
            DoAssert("ObjectDictionary");
        }

        [TestMethod]
        [Ignore]
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
        [DeploymentItem("modules", "modules")]
        public void ModuleAsserts()
        {
            DoAssert("Module");
        }

        [TestMethod]
        [DeploymentItem("modules", "modules")]
        public void WebSideAsserts()
        {
            DoAssert("WebSide");
        }

        [TestMethod]
        public void SemaphoreAsserts()
        {
            DoAssert("Semaphore");
        }

        [TestMethod]
        public void ProcessAsserts()
        {
            DoAssert("Process");
        }

        [TestMethod]
        public void TransactionAsserts()
        {
            DoAssert("Transaction");
        }

        [TestMethod]
        public void DynamicObjectAsserts()
        {
            DoAssert("DynamicObject");
        }

        [TestMethod]
        public void RunTestsUsingMachineLoadFile()
        {
            this.machine.LoadFile("AssertTests\\RunTests.st");
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

        [TestMethod]
        public void WebServerAsserts()
        {
            this.LoadFile(@"AssertTests\WebServer.st");
            DoAssert("WebServer");
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
