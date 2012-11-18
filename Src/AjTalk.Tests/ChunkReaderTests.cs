namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChunkReaderTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void ReadFirstChunk()
        {
            ChunkReader reader = new ChunkReader(@"FileOut01.st");

            string chunk = reader.GetChunk();

            Assert.IsNotNull(chunk);
            Assert.IsTrue(chunk.StartsWith("'"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void ReadChunksWithExclamationMarksAndSpace()
        {
            ChunkReader reader = new ChunkReader(@"FileOut01.st");

            string chunk = reader.GetChunk();

            Assert.IsNotNull(chunk);
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            Assert.IsTrue(chunk.StartsWith("!"));
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            Assert.IsTrue(chunk.StartsWith("!"));
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            chunk = reader.GetChunk();
            Assert.IsNotNull(chunk);
            Assert.AreEqual(" ", chunk);
        }
    }
}
