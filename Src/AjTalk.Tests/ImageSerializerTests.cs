namespace AjTalk.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Language;
    using System.IO;

    [TestClass]
    public class ImageSerializerTests
    {
        [TestMethod]
        public void SerializeDeserializeNil()
        {
            Assert.IsNull(this.Process(null));
        }

        [TestMethod]
        public void SerializeDeserializeInteger()
        {
            Assert.AreEqual(123, this.Process(123));
        }

        [TestMethod]
        public void SerializeDeserializeString()
        {
            Assert.AreEqual("text", this.Process("text"));
        }

        [TestMethod]
        public void SerializeDeserializeEmptyObject()
        {
            IObject obj = new BaseObject();
            var result = this.Process(obj);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(0, iobj.NoVariables);
        }

        private object Process(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            ImageSerializer serializer = new ImageSerializer(writer);
            serializer.Serialize(obj);
            writer.Close();
            stream = new MemoryStream(stream.ToArray());
            BinaryReader reader = new BinaryReader(stream);
            ImageSerializer deserializer = new ImageSerializer(reader);
            return deserializer.Deserialize();
        }
    }
}
