namespace AjTalk.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContextTests
    {
        [TestMethod]
        public void GetNullIfUndefined()
        {
            Context context = new Context();

            Assert.IsNull(context.GetValue("Foo"));
        }

        [TestMethod]
        public void SetGetValue()
        {
            Context context = new Context();
            context.SetValue("One", 1);
            Assert.AreEqual(1, context.GetValue("One"));
        }

        [TestMethod]
        public void HasValue()
        {
            Context context = new Context();
            context.SetValue("One", 1);
            Assert.IsTrue(context.HasValue("One"));
            Assert.IsFalse(context.HasValue("Foo"));
        }
    }
}
