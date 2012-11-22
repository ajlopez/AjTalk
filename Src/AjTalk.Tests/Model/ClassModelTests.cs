namespace AjTalk.Tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassModelTests
    {
        [TestMethod]
        public void GetNames()
        {
            ClassModel @class = new ClassModel("AClass", string.Empty, new List<string>() { "x", "y" }, new List<string>() { "count" }, false, null, null);

            Assert.AreEqual("count", @class.ClassVariableNamesAsString);
            Assert.AreEqual("x y", @class.InstanceVariableNamesAsString);
            Assert.AreEqual(string.Empty, @class.Category);
            Assert.AreEqual(string.Empty, @class.PoolDictionariesAsString);
        }

        [TestMethod]
        public void GetEmptyNames()
        {
            ClassModel @class = new ClassModel("AClass", string.Empty, new List<string>(), new List<string>(), false, null, null);

            Assert.AreEqual(string.Empty, @class.ClassVariableNamesAsString);
            Assert.AreEqual(string.Empty, @class.InstanceVariableNamesAsString);
        }

        [TestMethod]
        public void GetEmptyNamesFromNull()
        {
            ClassModel @class = new ClassModel("AClass", string.Empty, null, null, false, null, null);

            Assert.AreEqual(string.Empty, @class.ClassVariableNamesAsString);
            Assert.AreEqual(string.Empty, @class.InstanceVariableNamesAsString);
        }
    }
}
