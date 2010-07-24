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
    }
}
