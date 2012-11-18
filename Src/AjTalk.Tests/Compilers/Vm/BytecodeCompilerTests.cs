namespace AjTalk.Tests.Compilers.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compilers.Vm;
    using AjTalk.Language;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BytecodeCompilerTests
    {
        private Block block;
        private BytecodeCompiler compiler;

        [TestInitialize]
        public void Setup()
        {
            this.block = new Block();
            this.compiler = new BytecodeCompiler(this.block);
        }

        [TestMethod]
        public void CompileSimpleCommand()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(0, this.block.Arity);
        }
    }
}
