using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using AjTalk.Compiler;
using AjTalk.Language;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AjTalk.Tests
{
    [TestClass]
    public class EvaluateTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            // TODO refactor machine factory
            this.machine = LoaderTests.CreateMachine();
        }

        [TestMethod]
        public void EvaluateInteger()
        {
            Assert.AreEqual(1, this.Evaluate("1"));
        }

        [TestMethod]
        public void EvaluateString()
        {
            Assert.AreEqual("foo", this.Evaluate("'foo'"));
        }

        [TestMethod]
        public void EvaluateBlockWithInteger()
        {
            Assert.AreEqual(1, this.Evaluate("[1] value"));
        }

        [TestMethod]
        public void EvaluateGlobalVariable()
        {
            this.machine.SetGlobalObject("One", 1);
            Assert.AreEqual(1, this.Evaluate("One"));
        }

        [TestMethod]
        public void EvaluateAssignment()
        {
            this.Evaluate("One := 1");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateAssignmentAndGlobal()
        {
            Assert.AreEqual(1, this.Evaluate("One := 1. One"));
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateTwoAssignments()
        {
            this.Evaluate("One := 1. Two := 2");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
            Assert.AreEqual(2, this.machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void CreateDotNetObject()
        {
            object result = this.Evaluate("@System.IO.FileInfo !new: 'afile.txt'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.IO.FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("afile.txt", fileinfo.Name);
        }

        [TestMethod]
        public void InvokeDotNetMethod()
        {
            object result = this.Evaluate("2 !toString");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void InvokeDotNetMethodWithParameters()
        {
            object result = this.Evaluate("'foobar' !substring: 1 with: 2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("oo", result);
        }

        [TestMethod]
        public void InvokeStaticDotNetMethod()
        {
            object result = this.Evaluate("@System.IO.File !exists: 'foobar'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool) result);
        }

        [TestMethod]
        public void DefineNativeBehavior()
        {
            object result = this.Evaluate("nil subclass: #List nativeType: @System.Collections.ArrayList");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NativeBehavior));

            NativeBehavior behavior = (NativeBehavior) result;

            Assert.AreEqual(typeof(System.Collections.ArrayList), behavior.NativeType);

            object newobj = behavior.CreateObject();

            Assert.IsNotNull(newobj);
            Assert.IsInstanceOfType(newobj, typeof(System.Collections.ArrayList));
        }

        private object Evaluate(string text)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(this.machine, null);
        }
    }
}
