namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectOperatorsTests
    {
        [TestMethod]
        public void ArithmeticOperatorsWithIntegers()
        {
            Assert.AreEqual(3, ObjectOperators.Add(1, 2));
            Assert.AreEqual(-1, ObjectOperators.Substract(1, 2));
            Assert.AreEqual(2, ObjectOperators.Multiply(1, 2));
            Assert.AreEqual(2.0, ObjectOperators.Divide(6, 3));
            Assert.AreEqual(2, ObjectOperators.IntDivide(6, 3));
            Assert.AreEqual(2, ObjectOperators.Mod(5, 3));
            Assert.AreEqual(true, ObjectOperators.Equals(3, 3));
            Assert.AreEqual(false, ObjectOperators.Equals(2, 3));
        }

        [TestMethod]
        public void AddOperatorWithString()
        {
            Assert.AreEqual("foobar", ObjectOperators.Add("foo", "bar"));
            Assert.AreEqual("foo1", ObjectOperators.Add("foo", 1));
            Assert.AreEqual("1foo", ObjectOperators.Add(1, "foo"));
        }
    }
}
