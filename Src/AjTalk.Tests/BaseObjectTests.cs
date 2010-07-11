namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

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
    }
}
