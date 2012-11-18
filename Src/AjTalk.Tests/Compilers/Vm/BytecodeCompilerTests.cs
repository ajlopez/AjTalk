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
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleSum()
        {
            ModelParser parser = new ModelParser("1 + 2");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleRealSum()
        {
            ModelParser parser = new ModelParser("1.2 + 3.4");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleArithmeticWithParenthesis()
        {
            ModelParser parser = new ModelParser("1 * (2 + 3)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(5, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(21, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }
    }
}
