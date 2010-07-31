using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using AjTalk.Language;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AjTalk.Tests.Language
{
    [TestClass]
    public class NativeBehaviorTests
    {
        [TestMethod]
        public void CreateObjectWithParameters()
        {
            NativeBehavior behavior = new NativeBehavior(null, new Machine(), typeof(FileInfo));

            object result = behavior.CreateObject(new object[] { "File.txt" });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("File.txt", fileinfo.Name);
        }
    }
}
