namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void BeCreated()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine);
        }

        [TestMethod]
        public void HasGlobals()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine.UndefinedObjectClass);
        }

        [TestMethod]
        public void CreateClass()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass", cls.Name);
            Assert.AreEqual(-1, cls.GetInstanceVariableOffset("x"));
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.IsInstanceOfType(cls.SuperClass, typeof(IClass));
            Assert.AreEqual("UndefinedObject", ((IClass)cls.SuperClass).Name);
        }

        [TestMethod]
        public void CreateClassWithInstanceAndClassVariables()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass", null, "x", "count");

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass", cls.Name);
            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(-1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(0, cls.GetClassVariableOffset("count"));
            Assert.AreEqual(-1, cls.GetClassVariableOffset("y"));
            Assert.AreEqual("x", cls.GetInstanceVariableNamesAsString());
            Assert.AreEqual("count", cls.GetClassVariableNamesAsString());
            Assert.AreEqual(1, cls.NoVariables);

            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.IsInstanceOfType(cls.SuperClass, typeof(IClass));
            Assert.AreEqual("UndefinedObject", ((IClass)cls.SuperClass).Name);
        }

        [TestMethod]
        public void CreateIndexedClass()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass", true);

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass", cls.Name);
            Assert.AreEqual(-1, cls.GetInstanceVariableOffset("x"));
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.IsInstanceOfType(cls.SuperClass, typeof(IClass));
            Assert.AreEqual("UndefinedObject", ((IClass)cls.SuperClass).Name);

            object obj = cls.NewObject();

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IIndexedObject));
        }

        [TestMethod]
        public void SetGlobalVariable()
        {
            Machine machine = new Machine();

            machine.SetGlobalObject("One", 1);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void GetGlobalNames()
        {
            Machine machine = new Machine();

            machine.SetGlobalObject("One", 1);
            var names = machine.GetGlobalNames();

            Assert.IsNotNull(names);
            Assert.IsTrue(names.Contains("One"));
            Assert.IsTrue(names.Contains("UndefinedObject"));
        }

        [TestMethod]
        public void GetNullIfGlobalVariableDoesNotExists()
        {
            Machine machine = new Machine();

            Assert.IsNull(machine.GetGlobalObject("InexistenteGlobal"));
        }

        [TestMethod]
        public void CreateAsCurrent()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(Machine.Current);
            Assert.AreSame(Machine.Current, machine);
        }

        [TestMethod]
        public void CreateNotAsCurrent()
        {
            Machine machine = new Machine(false);

            Assert.AreNotSame(Machine.Current, machine);
        }
    }
}

