namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Tests.NativeObjects;

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

            object obj = DotNetObject.SendNativeMessage(new System.IO.FileInfo("NonexistentFile.txt"), "exists", null);

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
            object obj = DotNetObject.SendNativeMessage(rectangle, "width", null);
            Assert.AreEqual(10, obj);
        }

        [TestMethod]
        public void InvokeSetProperty()
        {
            Rectangle rectangle = new Rectangle() { Width = 10, Height = 20 };
            DotNetObject.SendNativeMessage(rectangle, "width", new object[] { 15 });
            object obj = DotNetObject.SendNativeMessage(rectangle, "width", null);
            Assert.AreEqual(15, obj);
        }

        [TestMethod]
        public void GetEnum()
        {
            object result = DotNetObject.SendNativeStaticMessage(typeof(ByteCode), "Send", null);
            Assert.IsNotNull(result);
        }
    }
}
