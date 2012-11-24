﻿namespace AjTalk.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Language;
    using System.IO;
    using AjTalk.Compiler;

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

        [TestMethod]
        public void SerializeDeserializeObjectWithNilVariables()
        {
            IObject obj = new BaseObject(null, new object[10]);
            var result = this.Process(obj);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(10, iobj.NoVariables);

            for (int k = 0; k < 10; k++)
                Assert.IsNull(iobj[k]);
        }

        [TestMethod]
        public void SerializeDeserializeObjectWithIntegerVariables()
        {
            IObject obj = new BaseObject(null, new object[4] { 0, 1, 2, 3 });
            var result = this.Process(obj);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;
            Assert.IsNull(iobj.Behavior);
            Assert.AreEqual(4, iobj.NoVariables);

            for (int k = 0; k < 4; k++)
                Assert.AreEqual(k, iobj[k]);
        }

        [TestMethod]
        public void SerializeDeserializeClass()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("MyClass");
            klass.DefineInstanceVariable("a");
            klass.DefineInstanceVariable("b");
            klass.DefineClassVariable("c");
            klass.DefineClassVariable("d");

            var result = this.Process(klass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var bclass = (BaseClass)result;

            Assert.AreEqual("MyClass", bclass.Name);
            Assert.IsNotNull(bclass.Behavior);
            Assert.AreEqual(0, bclass.GetInstanceVariableOffset("a"));
            Assert.AreEqual(1, bclass.GetInstanceVariableOffset("b"));
            Assert.AreEqual(0, bclass.GetClassVariableOffset("c"));
            Assert.AreEqual(1, bclass.GetClassVariableOffset("d"));
        }

        [TestMethod]
        public void SerializeDeserializeClassWithInstanceMethod()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("MyClass");
            Method method = (new VmCompiler()).CompileInstanceMethod("add: x to: y ^x + y", klass);
            klass.DefineInstanceMethod(method);

            machine = new Machine();
            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
            Assert.IsNull(machine.GetGlobalObject("MyClass"));
            var undefined = machine.GetGlobalObject("UndefinedObject");

            var result = this.Process(klass);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var bclass = (BaseClass)result;

            Assert.AreEqual("MyClass", bclass.Name);
            var bmethod = bclass.GetInstanceMethod("add:to:");
            Assert.IsNotNull(bmethod);

            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
            Assert.IsNotNull(machine.GetGlobalObject("MyClass"));
            Assert.AreEqual(undefined, machine.GetGlobalObject("UndefinedObject"));
        }

        [TestMethod]
        public void SerializeDeserializeObjectsWithCycle()
        {
            IObject obja = new BaseObject(null, 1);
            IObject objb = new BaseObject(null, 1);
            obja[0] = objb;
            objb[0] = obja;

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            ImageSerializer serializer = new ImageSerializer(writer);
            
            serializer.Serialize(obja);
            serializer.Serialize(objb);

            writer.Close();
            stream = new MemoryStream(stream.ToArray());
            BinaryReader reader = new BinaryReader(stream);
            
            ImageSerializer deserializer = new ImageSerializer(reader);
            
            var resulta = deserializer.Deserialize();
            var resultb = deserializer.Deserialize();

            Assert.IsNotNull(resulta);
            Assert.IsInstanceOfType(resulta, typeof(IObject));

            var iobja = (IObject)resulta;
            Assert.IsNull(iobja.Behavior);
            Assert.AreEqual(1, iobja.NoVariables);

            Assert.IsNotNull(resultb);
            Assert.IsInstanceOfType(resultb, typeof(IObject));

            var iobjb = (IObject)resultb;
            Assert.IsNull(iobjb.Behavior);
            Assert.AreEqual(1, iobjb.NoVariables);

            Assert.AreEqual(iobja, iobjb[0]);
            Assert.AreEqual(iobjb, iobja[0]);
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