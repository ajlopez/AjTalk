namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NativeBehaviorTests
    {
        [TestMethod]
        public void CreateObjectWithParameters()
        {
            Machine machine = new Machine();
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, machine);
            NativeBehavior behavior = new NativeBehavior(meta, null, machine, typeof(FileInfo));

            object result = behavior.CreateObject(new object[] { "File.txt" });

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("File.txt", fileinfo.Name);
        }
    }
}
