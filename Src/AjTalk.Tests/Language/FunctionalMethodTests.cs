namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FunctionalMethodTests
    {
        [TestMethod]
        public void CreateAndExecuteFunctionalMethod()
        {
            int count = 0;
            FunctionalMethod method = new FunctionalMethod((Machine machine, IObject x, IObject y, object[] args) => ++count);

            Assert.IsNull(method.Name);
            Assert.IsNull(method.Behavior);

            object result = method.Execute(null, null, null);

            Assert.AreEqual(1, count);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CreateAndExecuteNativeFunctionalMethod()
        {
            int count = 0;
            FunctionalMethod method = new FunctionalMethod((Machine machine, object x, object[] args) => ++count);

            Assert.IsNull(method.Name);
            Assert.IsNull(method.Behavior);

            object result = method.ExecuteNative(null, null, null);

            Assert.AreEqual(1, count);
            Assert.AreEqual(1, result);
        }
    }
}
