namespace AjTalk.Tests.Model
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Model;

    [TestClass]
    public class CodeReaderTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void ProcessFileOut01()
        {
            ChunkReader chunkReader = new ChunkReader(@"FileOut01.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            Assert.IsNotNull(model.GetClass("Object"));
            Assert.AreEqual(3, model.Elements.Count());
        }
    }
}
