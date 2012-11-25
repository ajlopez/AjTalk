namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChunckReaderProcessorTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\Chunks.st")]
        public void CountChunks()
        {
            ChunkReader reader = new ChunkReader(@"Chunks.st");
            int count = 0;
            ChunkReaderProcessor processor = new ChunkReaderProcessor((Machine machine, ICompiler compiler, string text) => { count++; });
            processor.Process(reader, null, null);
            Assert.AreEqual(3, count);
            count = 0;
            processor.Process(reader, null, null);
            Assert.AreEqual(2, count);
        }
    }
}
