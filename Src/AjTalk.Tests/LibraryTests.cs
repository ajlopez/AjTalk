namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [DeploymentItem(@"Library\Object.st")]
    [DeploymentItem(@"Library\Behavior.st")]
    [DeploymentItem(@"Library\Class.st")]
    [DeploymentItem(@"Library\Test.st")]
    public class LibraryTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.LoadFile(@"Object.st");
            this.LoadFile(@"Behavior.st");
            this.LoadFile(@"Class.st");
            this.LoadFile(@"Test.st");
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.IsNotNull(this.machine.GetGlobalObject("Test"));
            IClass cls = (IClass)this.machine.GetGlobalObject("Object");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
            cls = (IClass)this.machine.GetGlobalObject("Class");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
            cls = (IClass)this.machine.GetGlobalObject("Test");
            Assert.IsNotNull(cls.GetInstanceMethod("error:"));
            Assert.IsNotNull(cls.GetClassMethod("error:"));
        }

        [TestMethod]
        [ExpectedException(typeof(ErrorException), "error")]
        public void RaiseError()
        {
            Parser parser = new Parser("Test error: 'error'");
            parser.CompileBlock().Execute(this.machine, null);
        }

        [TestMethod]
        [DeploymentItem(@"LibraryTests\TestFail.st")]
        [ExpectedException(typeof(ErrorException), "assertAreEqual")]
        public void RaiseIfTwoNotEqualThree()
        {
            this.LoadFile("TestFail.st");
        }

        [TestMethod]
        [DeploymentItem(@"LibraryTests\TestObject.st")]
        public void TestObject()
        {
            this.LoadFile("TestObject.st");
        }

        [TestMethod]
        [DeploymentItem(@"LibraryTests\Data.st")]
        public void Data()
        {
            this.LoadFile("Data.st");
        }

        [TestMethod]
        [DeploymentItem(@"LibraryTests\TestBehavior.st")]
        public void TestBehavior()
        {
            this.LoadFile("TestBehavior.st");
        }

        [TestMethod]
        [DeploymentItem(@"LibraryTests\TestClass.st")]
        public void TestClass()
        {
            this.LoadFile("TestClass.st");
        }

        private void LoadFile(string filename)
        {
            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(this.machine);
        }
    }
}
