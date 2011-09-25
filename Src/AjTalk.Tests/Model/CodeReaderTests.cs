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

            Assert.IsInstanceOfType(model.Elements.First(), typeof(ClassModel));
            Assert.IsInstanceOfType(model.Elements.Skip(1).First(), typeof(MethodModel));
            Assert.IsInstanceOfType(model.Elements.Skip(2).First(), typeof(MethodModel));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut02.st")]
        public void ProcessFileOut02()
        {
            ChunkReader chunkReader = new ChunkReader(@"FileOut02.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            Assert.IsNotNull(model.GetClass("Object"));
            Assert.AreEqual(9, model.Elements.Count());

            Assert.IsInstanceOfType(model.Elements.First(), typeof(ClassModel));

            foreach (var element in model.Elements.Skip(1))
                Assert.IsInstanceOfType(element, typeof(MethodModel));
        }
    }
}
