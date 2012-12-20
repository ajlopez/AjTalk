namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk;
    using AjTalk.Language;
    using AjTalk.Tests.NativeObjects;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DotNetObjectTest
    {
        [TestMethod]
        public void CreateAnObject()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.NewObject(Type.GetType("System.IO.FileInfo"), new object[] { "AnyFile.txt" });

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.IO.FileInfo));
        }

        [TestMethod]
        public void InvokeMethod()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.SendNativeMessage(machine, new System.IO.FileInfo("NonexistentFile.txt"), "exists", null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(bool));
            Assert.IsFalse((bool)obj);
        }

        [TestMethod]
        public void InvokeStaticMethod()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.SendNativeStaticMessage(typeof(System.IO.File), "exists", new object[] { "FooFile.txt" });

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(bool));
            Assert.IsFalse((bool)obj);
        }

        [TestMethod]
        public void InvokeGetProperty()
        {
            Rectangle rectangle = new Rectangle() { Width = 10, Height = 20 };
            object obj = DotNetObject.SendNativeMessage(null, rectangle, "width", null);
            Assert.AreEqual(10, obj);
        }

        [TestMethod]
        public void InvokeNativeAtOnArrayList()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            object obj = DotNetObject.SendNativeMessage(null, list, "nat", new object[] { 1 });
            Assert.AreEqual(2, obj);
        }

        [TestMethod]
        public void InvokeNativeAtOnObjectArray()
        {
            object[] list = new object[] { 1, 2, 3 };
            object obj = DotNetObject.SendNativeMessage(null, list, "nat", new object[] { 1 });
            Assert.AreEqual(2, obj);
        }

        [TestMethod]
        public void InvokeNativeAtPutIndexedProperty()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            object obj = DotNetObject.SendNativeMessage(null, list, "natput", new object[] { 1, 3 });
            Assert.AreEqual(3, obj);
            Assert.AreEqual(3, list[2]);
        }

        [TestMethod]
        public void InvokeSetProperty()
        {
            Rectangle rectangle = new Rectangle() { Width = 10, Height = 20 };
            DotNetObject.SendNativeMessage(null, rectangle, "width", new object[] { 15 });
            object obj = DotNetObject.SendNativeMessage(null, rectangle, "width", null);
            Assert.AreEqual(15, obj);
        }

        [TestMethod]
        public void InvokeDefaultProperty()
        {
            BaseObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            Assert.AreEqual(2, DotNetObject.SendNativeMessage(null, obj, string.Empty, new object[] { 1 }));
        }

        [TestMethod]
        public void InvokeNativeGet()
        {
            Rectangle rectangle = new Rectangle() { Width = 10, Height = 20 };
            Assert.AreEqual(10, DotNetObject.SendNativeMessage(null, rectangle, "nget", new object[] { "Width" }));
            Assert.AreEqual(20, DotNetObject.SendNativeMessage(null, rectangle, "nget", new object[] { "Height" }));
        }

        [TestMethod]
        public void InvokeNativeSet()
        {
            Rectangle rectangle = new Rectangle() { Width = 10, Height = 20 };
            Assert.AreEqual(11, DotNetObject.SendNativeMessage(null, rectangle, "nsetput", new object[] { "Width", 11 }));
            Assert.AreEqual(21, DotNetObject.SendNativeMessage(null, rectangle, "nsetput", new object[] { "Height", 21 }));
            Assert.AreEqual(11, rectangle.Width);
            Assert.AreEqual(21, rectangle.Height);
        }

        [TestMethod]
        public void GetEnum()
        {
            object result = DotNetObject.SendNativeStaticMessage(typeof(ByteCode), "Send", null);
            Assert.IsNotNull(result);
        }
    }
}
