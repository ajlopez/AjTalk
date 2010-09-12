using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Language;

namespace AjTalk.Tests.Language
{
    [TestClass]
    public class BaseIndexedObjectTests
    {
        [TestMethod]
        public void SetAndGetIndexedValues()
        {
            BaseIndexedObject obj = new BaseIndexedObject();

            Assert.AreEqual(0, obj.BasicSize);

            obj.SetIndexedValue(0, 1);
            obj.SetIndexedValue(1, 2);

            Assert.AreEqual(1, obj.GetIndexedValue(0));
            Assert.AreEqual(2, obj.GetIndexedValue(1));
            Assert.IsNull(obj.GetIndexedValue(2));
            Assert.AreEqual(2, obj.BasicSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RaiseIfIndexIsNegative()
        {
            BaseIndexedObject obj = new BaseIndexedObject();
            obj.GetIndexedValue(-2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RaiseIfSetWithNegativeIndex()
        {
            BaseIndexedObject obj = new BaseIndexedObject();
            obj.SetIndexedValue(-3, "foo");
        }
    }
}
