using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using AjTalk;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AjTalk.Tests
{
    /// <summary>
    /// Summary description for DotNetObjectTest
    /// </summary>
    [TestClass]
    public class DotNetObjectTest
    {
        [TestMethod]
        public void ShouldCreateAnObject()
        {
            Machine machine = new Machine();

            object obj = DotNetObject.SendMessage(machine.GetGlobalObject("System.IO.FileInfo"), "new:", new object[] { "AnyFile.txt" });

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
