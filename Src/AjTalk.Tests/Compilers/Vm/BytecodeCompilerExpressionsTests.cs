namespace AjTalk.Tests.Compilers.Vm
{
    using System.Collections.Generic;
    using AjTalk.Compilers.Vm;
    using AjTalk.Language;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BytecodeCompilerExpressionsTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\Expressions.txt")]
        public void CompileExpressions()
        {
            IList<ExpressionResult> results = ExpressionResult.LoadExpressionResults("Expressions.txt");

            foreach (var result in results)
            {
                ModelParser parser = new ModelParser(result.Text);
                Block block = new Block();
                BytecodeCompiler compiler = new BytecodeCompiler(block);
                compiler.CompileExpression(parser.ParseExpression());
                result.ValidateBlock(block);
            }
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Blocks.txt")]
        public void CompileBlocks()
        {
            IList<ExpressionResult> results = ExpressionResult.LoadExpressionResults("Blocks.txt");

            foreach (var result in results)
            {
                ModelParser parser = new ModelParser(result.Text);
                Block block = new Block();
                BytecodeCompiler compiler = new BytecodeCompiler(block);
                compiler.CompileExpression(parser.ParseBlock());
                result.ValidateBlock(block);
            }
        }
    }
}
