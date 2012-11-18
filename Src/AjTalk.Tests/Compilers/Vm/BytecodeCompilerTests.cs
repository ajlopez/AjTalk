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

        [TestMethod]
        public void CompileTwoSimpleCommand()
        {
            ModelParser parser = new ModelParser("a := 1. b := 2");
            this.compiler.CompileExpressions(parser.ParseExpressions());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(2, this.block.NoGlobalNames);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesis()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject class)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(1, this.block.NoConstants);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBang()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject !nativeMethod)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(21, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBangKeyword()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject !nativeMethod: 1)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(21, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileAndExecuteTwoSimpleCommand()
        {
            ModelParser parser = new ModelParser("a := 1. b := 2");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Machine machine = new Machine();
            this.block.Execute(machine, null);
            Assert.AreEqual(1, machine.GetGlobalObject("a"));
            Assert.AreEqual(2, machine.GetGlobalObject("b"));
        }

        [TestMethod]
        public void CompileGlobalVariable()
        {
            ModelParser parser = new ModelParser("AClass");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(1, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinition()
        {
            ModelParser parser = new ModelParser("nil subclass: #Object");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinitionWithInstances()
        {
            ModelParser parser = new ModelParser("nil subclass: #Object instanceVariables: 'a b c'");
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
        public void CompileTwoCommands()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10. Global := 20");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(1, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommandsUsingSemicolon()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10; invokeWith: 20");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(21, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileBlock()
        {
            ModelParser parser = new ModelParser("nil ifFalse: [self halt]");
            this.compiler.CompileExpression(parser.ParseExpression());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);

            object constant = this.block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.Arity);
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(11, newblock.ByteCodes.Length);
        }

        [TestMethod]
        public void CompileBlockWithParameter()
        {
            ModelParser parser = new ModelParser("[ :a | a doSomething ]");
            this.compiler.CompileExpression(parser.ParseExpression());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(0, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(1, this.block.NoConstants);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(11, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);

            object constant = this.block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.NoGlobalNames);
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.AreEqual(1, newblock.NoConstants);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(11, newblock.ByteCodes.Length);
            Assert.AreEqual(1, newblock.Arity);
        }
    }
}
