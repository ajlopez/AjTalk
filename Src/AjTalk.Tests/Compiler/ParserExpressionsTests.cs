namespace AjTalk.Tests.Compiler
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
    public class ParserExpressionsTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\Expressions.txt")]
        public void CompileExpressions()
        {
            IList<ExpressionResult> results = ExpressionResult.LoadExpressionResults("Expressions.txt");

            foreach (var result in results)
            {
                Parser parser = new Parser(result.Text);
                var block = parser.CompileBlock();
                Assert.IsNotNull(block);
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
                Parser parser = new Parser(result.Text);
                var block = parser.CompileBlock();
                Assert.IsNotNull(block);
                result.ValidateBlock(block);
            }
        }
    }
}
