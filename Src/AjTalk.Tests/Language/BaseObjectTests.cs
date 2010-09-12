namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
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
    }
}
