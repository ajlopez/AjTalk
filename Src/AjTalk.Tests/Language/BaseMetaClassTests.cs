namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseMetaClassTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
        }

        [TestMethod]
        public void CreateMetaClass()
        {
            IMetaClass metaclass = new BaseMetaClass(null, null, this.machine, string.Empty);
            Assert.IsNull(metaclass.Behavior);
        }

        [TestMethod]
        public void CreateMetaClassWithVariables()
        {
            IMetaClass metaclass = new BaseMetaClass(null, null, this.machine, "x y");
            Assert.AreEqual(0, metaclass.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, metaclass.GetInstanceVariableOffset("y"));
            Assert.AreEqual("x y", metaclass.GetInstanceVariableNamesAsString());
        }

        [TestMethod]
        public void CreateMetaClassWithVariablesAndSpaces()
        {
            IMetaClass metaclass = new BaseMetaClass(null, null, this.machine, " x   y ");
            Assert.AreEqual(0, metaclass.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, metaclass.GetInstanceVariableOffset("y"));
            Assert.AreEqual("x y", metaclass.GetInstanceVariableNamesAsString());
        }

        [TestMethod]
        public void CreateClass()
        {
            IMetaClass metaclass = new BaseMetaClass(null, null, this.machine, "x y");
            IClass cls = metaclass.CreateClass("MyClass", "a b");
            Assert.AreEqual(cls.Behavior, metaclass);
            Assert.AreEqual("MyClass", cls.Name);
            Assert.AreEqual(cls.MetaClass, metaclass);
            Assert.AreEqual("a b", cls.GetInstanceVariableNamesAsString());
        }
    }
}
