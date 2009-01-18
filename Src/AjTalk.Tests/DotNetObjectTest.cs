namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DotNetObjectTest
    {
        [TestMethod]
        public void ShouldCreateAnObject()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.NewObject(Type.GetType("System.IO.FileInfo"), new object[] { "AnyFile.txt" });

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.IO.FileInfo));
        }

        [TestMethod]
        public void ShouldInvokeMethod()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.SendMessage(new System.IO.FileInfo("NonexistentFile.txt"), "exists", null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(bool));
            Assert.IsFalse((bool)obj);
        }
    }
}
