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
    public class LibTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.LoadFile(@"lib\Library.st");
        }

        [TestMethod]
        public void EvaluateBlockWithReturn()
        {
            Assert.AreEqual(3, this.Evaluate("|sum| sum := 0. #(1 2 3) do: [ :item | sum := sum + item. item == 2 ifTrue:[^sum]]. ^sum"));
        }

        [TestMethod]
        public void EvaluateNestedBlockWithReturn()
        {
            Assert.AreEqual(3, this.Evaluate("|sum| sum := 0. #(1 2 3) do: [ :item | sum := sum + item. [item == 2 ifTrue:[^sum]] value]. ^sum"));
        }

        [TestMethod]
        public void EvaluateObjectSuperclass()
        {
            Assert.IsNull(this.Evaluate("Object superclass"));
        }

        [TestMethod]
        public void EvaluateInheritsFrom()
        {
            IClass objcls = (IClass)this.machine.GetGlobalObject("Object");
            IClass rectcls = this.machine.CreateClass("Rectangle", objcls, "x y width rect", "");
            this.machine.SetGlobalObject("Rectangle", rectcls);
            Assert.AreEqual(true, this.Evaluate("Rectangle inheritsFrom: Object"));
        }

        private void LoadFile(string filename)
        {
            Loader loader = new Loader(filename, new VmCompiler());
            loader.LoadAndExecute(this.machine);
        }

        private object Evaluate(string text)
        {
            return this.Evaluate(text, this.machine);
        }

        private object Evaluate(string text, Machine machine)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            Process process = new Process(block, null, machine);
            return process.Execute();
        }
    }
}
