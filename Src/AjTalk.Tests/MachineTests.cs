namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void ShouldBeCreated()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine);
        }

        [TestMethod]
        public void ShouldHasGlobals()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine.GetGlobalObject("nil"));
            //Assert.IsNotNull(machine.GetGlobalObject("Object"));
            //Assert.IsNotNull(machine.GetGlobalObject("Class"));
        }

        [TestMethod]
        public void ShouldCreateClass()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass", cls.Name);
            Assert.AreEqual(-1, cls.GetInstanceVariableOffset("x"));
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("nil", cls.SuperClass.Name);
        }

        [TestMethod]
        public void ShouldSetGlobalVariable()
        {
            Machine machine = new Machine();

            machine.SetGlobalObject("One", 1);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void ShouldGetNullIfGlobalVariableDoesNotExists()
        {
            Machine machine = new Machine();

            Assert.IsNull(machine.GetGlobalObject("InexistenteGlobal"));
        }
    }
}

