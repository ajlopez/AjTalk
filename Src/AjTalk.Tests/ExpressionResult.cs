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

    public class ExpressionResult
    {
        private string text;
        private IList<string> compiled = new List<string>();

        public ExpressionResult(string text)
        {
            this.text = text;
        }

        public string Text { get { return this.text; } }

        public static IList<ExpressionResult> LoadExpressionResults(string filename)
        {
            var lines = File.ReadAllLines(filename);
            IList<ExpressionResult> list = new List<ExpressionResult>();
            ExpressionResult result = null;

            foreach (var line in lines)
            {
                if (result == null)
                    result = new ExpressionResult(line);
                else if (!string.IsNullOrEmpty(line))
                    if (line.StartsWith("-"))
                    {
                        list.Add(result);
                        result = null;
                    }
                    else
                        result.AddCompiledLine(line);
            }

            if (result != null)
                list.Add(result);

            return list;
        }

        public void AddCompiledLine(string line)
        {
            this.compiled.Add(line);
        }

        public void ValidateBlock(Block block)
        {
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(this.compiled.Count, result.Count, this.text);

            for (int k = 0; k < this.compiled.Count; k++)
                Assert.AreEqual(this.compiled[k], result[k], this.text);
        }
    }
}
