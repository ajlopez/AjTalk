using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class BaseObjectTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            BaseObject bo = new BaseObject();

            Assert.IsNull(bo.Class);
        }
    }
}
