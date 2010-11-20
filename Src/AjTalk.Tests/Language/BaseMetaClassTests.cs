using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Language;

namespace AjTalk.Tests.Language
{
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
            IMetaClass metaclass = new BaseMetaClass(null, this.machine, "");
            Assert.IsNull(metaclass.Behavior);
        }

        [TestMethod]
        public void CreateMetaClassWithVariables()
        {
            IMetaClass metaclass = new BaseMetaClass(null, this.machine, "x y");
            Assert.AreEqual(0, metaclass.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, metaclass.GetInstanceVariableOffset("y"));
            Assert.AreEqual("x y", metaclass.GetInstanceVariableNames());
        }

        [TestMethod]
        public void CreateMetaClassWithVariablesAndSpaces()
        {
            IMetaClass metaclass = new BaseMetaClass(null, this.machine, " x   y ");
            Assert.AreEqual(0, metaclass.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, metaclass.GetInstanceVariableOffset("y"));
            Assert.AreEqual("x y", metaclass.GetInstanceVariableNames());
        }

        [TestMethod]
        public void CreateClass()
        {
            IMetaClass metaclass = new BaseMetaClass(null, this.machine, "x y");
            IClass cls = metaclass.CreateClass("MyClass", "a b");
            Assert.AreEqual(cls.Behavior, metaclass);
            Assert.AreEqual("MyClass", cls.Name);
            Assert.AreEqual(cls.MetaClass, metaclass);
            Assert.AreEqual("a b", cls.GetInstanceVariableNames());
        }
    }
}
