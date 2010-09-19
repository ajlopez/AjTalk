using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Language;

namespace AjTalk.Tests.Language
{
    [TestClass]
    public class FunctionalMethodTests
    {
        [TestMethod]
        public void CreateAndExecuteFunctionalMethod()
        {
            int count = 0;
            FunctionalMethod method = new FunctionalMethod((IObject x, IObject y, object[] args) => ++count);

            Assert.IsNull(method.Name);
            Assert.IsNull(method.Class);

            object result = method.Execute(null, null, null);

            Assert.AreEqual(1, count);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CreateAndExecuteNativeFunctionalMethod()
        {
            int count = 0;
            FunctionalMethod method = new FunctionalMethod((object x, object[] args) => ++count);

            Assert.IsNull(method.Name);
            Assert.IsNull(method.Class);

            object result = method.ExecuteNative(null,null);

            Assert.AreEqual(1, count);
            Assert.AreEqual(1, result);
        }
    }
}
