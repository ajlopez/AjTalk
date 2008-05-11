using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class MachineTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine);
        }

        [Test]
        public void ShouldCreateClass()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass",cls.Name);
            Assert.AreEqual(-1,cls.GetInstanceVariableOffset("x"));
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("Class", cls.SuperClass.Name);
        }
    }
}

