namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using AjTalk;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseObjectTests
    {
        [TestMethod]
        public void Create()
        {
            BaseObject bo = new BaseObject();

            Assert.IsNull(bo.Behavior);
        }

        [TestMethod]
        public void CreateWithVariables()
        {
            BaseObject bo = new BaseObject(null, new object[] { 1, 2, 3 });

            Assert.AreEqual(1, bo[0]);
            Assert.AreEqual(2, bo[1]);
            Assert.AreEqual(3, bo[2]);
        }

        [TestMethod]
        public void CreateWithVariablesAndClass()
        {
            Machine machine = new Machine();
            BaseClass cls = new BaseClass("MyClass", machine);
            BaseObject bo = new BaseObject(cls, new object[] { 1, 2, 3 });

            Assert.AreEqual(1, bo[0]);
            Assert.AreEqual(2, bo[1]);
            Assert.AreEqual(3, bo[2]);

            Assert.AreEqual(cls, bo.Behavior);
        }

        [TestMethod]
        public void DefineObjectMethod()
        {
            Machine machine = new Machine();
            BaseClass cls = new BaseClass("MyClass", machine);
            BaseObject bo = (BaseObject)cls.NewObject();

            Assert.AreEqual(cls, bo.Behavior);

            IMethod method = new Method(cls, "mymethod");

            bo.DefineObjectMethod(method);

            Assert.AreNotEqual(cls, bo.Behavior);
            Assert.IsNotNull(bo.Behavior.GetInstanceMethod("mymethod"));
            Assert.AreEqual(method, bo.Behavior.GetInstanceMethod("mymethod"));

            Assert.AreNotEqual(cls, method.Behavior);
            Assert.AreEqual(bo.Behavior, method.Behavior);

            Assert.IsTrue(bo.IsPrototype);
            Assert.AreEqual(true, bo.SendMessage(machine, "isPrototype", null));
        }

        [TestMethod]
        public void SerializeAndDeserializeSimpleObject()
        {
            Machine machine = new Machine();
            BaseClass cls = new BaseClass("MyClass", machine);
            BaseObject bo = new BaseObject(cls, new object[] { 1, 2, 3 });

            BinaryFormatter formatter = new BinaryFormatter();
            BaseObject bo2;
            Machine machine2;
            BaseClass cls2;

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, bo);
                stream.Seek(0, SeekOrigin.Begin);
                machine2 = new Machine(true);
                Assert.AreSame(Machine.Current, machine2);
                cls2 = new BaseClass("MyClass", machine2);
                machine2.SetGlobalObject("MyClass", cls2);
                bo2 = (BaseObject)formatter.Deserialize(stream);
            }

            Assert.AreEqual(1, bo2[0]);
            Assert.AreEqual(2, bo2[1]);
            Assert.AreEqual(3, bo2[2]);
            Assert.IsNotNull(bo2.Behavior);
            Assert.AreSame(cls2, bo2.Behavior);

            Assert.AreEqual(cls, bo.Behavior);
        }

        [TestMethod]
        public void SerializeAndDeserializeCompositeObject()
        {
            Machine machine = new Machine(true);
            BaseClass cls = new BaseClass("MyClass", machine);
            BaseObject bso1 = new BaseObject(cls, new object[] { 1, 2, 3 });
            BaseObject bso2 = new BaseObject(cls, new object[] { 2, 3, 4 });
            BaseObject bso3 = new BaseObject(cls, new object[] { 4, 5, 6 });
            BaseObject bo = new BaseObject(cls, new object[] { bso1, bso2, bso3, bso2 });
            bso3[2] = bo;

            BinaryFormatter formatter = new BinaryFormatter();
            BaseObject bo2;
            Machine machine2;
            BaseClass cls2;

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, bo);
                stream.Seek(0, SeekOrigin.Begin);
                machine2 = new Machine(true);
                Assert.AreSame(Machine.Current, machine2);
                cls2 = new BaseClass("MyClass", machine2);
                machine2.SetGlobalObject("MyClass", cls2);
                bo2 = (BaseObject)formatter.Deserialize(stream);
            }

            Assert.IsNotNull(bo2[0]);
            Assert.IsNotNull(bo2[1]);
            Assert.IsNotNull(bo2[2]);
            Assert.IsNotNull(bo2[3]);

            Assert.AreEqual(bo2[1], bo2[3]);

            Assert.IsNotNull(bo2.Behavior);
            Assert.AreSame(cls2, bo2.Behavior);

            Assert.IsInstanceOfType(bo2[0], typeof(BaseObject));
            Assert.IsInstanceOfType(bo2[1], typeof(BaseObject));
            Assert.IsInstanceOfType(bo2[2], typeof(BaseObject));
            Assert.IsInstanceOfType(bo2[3], typeof(BaseObject));

            BaseObject bso32 = (BaseObject)bo2[2];
            Assert.AreSame(cls2, bso32.Behavior);
            Assert.AreSame(bo2, bso32[2]);

            Assert.AreEqual(cls, bo.Behavior);
        }
    }
}
