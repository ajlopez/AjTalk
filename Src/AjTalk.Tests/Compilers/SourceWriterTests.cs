namespace AjTalk.Tests.Compilers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Compilers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SourceWriterTests
    {
        private StringWriter swriter;
        private SourceWriter writer;

        [TestInitialize]
        public void Setup()
        {
            this.swriter = new StringWriter();
            this.writer = new SourceWriter(this.swriter);
        }

        [TestMethod]
        public void WriteLine()
        {
            this.writer.WriteLine("foo");
            string[] lines = this.GetLines();
            Assert.IsTrue(lines.Contains("foo"));
        }

        [TestMethod]
        public void WriteFunctionWithIndent()
        {
            this.writer.WriteLine("foo()");
            this.writer.WriteLineStart("{");
            this.writer.WriteLine("a = 1;");
            this.writer.Write("b");
            this.writer.WriteLine(";");
            this.writer.WriteLineEnd("}");
            string[] lines = this.GetLines();
            Assert.IsTrue(lines.Contains("foo()"));
            Assert.IsTrue(lines.Contains("{"));
            Assert.IsTrue(lines.Contains("    a = 1;"));
            Assert.IsTrue(lines.Contains("    b;"));
            Assert.IsTrue(lines.Contains("}"));
            Assert.IsFalse(lines.Contains(string.Empty));
        }

        private string[] GetLines()
        {
            this.swriter.Close();
            string text = this.swriter.ToString();
            IList<string> lines = new List<string>();
            StringReader reader = new StringReader(text);

            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                lines.Add(line);

            return lines.ToArray();
        }
    }
}

