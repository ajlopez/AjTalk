namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void ShouldBeCreated()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass("Rectangle");

            Assert.IsNotNull(cls);
            Assert.AreEqual("Rectangle", cls.Name);
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNull(cls.GetClassMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("Class", cls.SuperClass.Name);
        }

        [TestMethod]
        public void ShouldBeCreatedWithSuperclass()
        {
            Machine machine = new Machine();

            IClass supercls = machine.CreateClass("Figure");
            IClass cls = machine.CreateClass("Rectangle",supercls);

            Assert.IsNotNull(cls);
            Assert.AreEqual("Rectangle", cls.Name);
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNull(cls.GetClassMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("Figure", cls.SuperClass.Name);
        }

        [TestMethod]
        public void ShouldInheritsVariables()
        {
            Machine machine = new Machine();

            IClass supercls = machine.CreateClass("Figure");
            supercls.DefineInstanceVariable("x");
            supercls.DefineInstanceVariable("y");

            IClass cls = machine.CreateClass("Rectangle", supercls);
            cls.DefineInstanceVariable("width");
            cls.DefineInstanceVariable("height");

            Assert.IsNotNull(cls);
            Assert.AreEqual("Rectangle", cls.Name);

            Assert.AreEqual(0, supercls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, supercls.GetInstanceVariableOffset("y"));

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(2, cls.GetInstanceVariableOffset("width"));
            Assert.AreEqual(3, cls.GetInstanceVariableOffset("height"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldAvoidNullName()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass(null);
        }

        [TestMethod]
        public void ShouldAddInstanceVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("y");

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldAvoidDuplicatedInstanceVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("x");
        }

        [TestMethod]
        public void ShouldAddClassVariable()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass("TestClass");
            cls.DefineClassVariable("x");
            cls.DefineClassVariable("y");

            Assert.AreEqual(0, cls.GetClassVariableOffset("x"));
            Assert.AreEqual(1, cls.GetClassVariableOffset("y"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldAvoidDuplicatedClassVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineClassVariable("x");
            cls.DefineClassVariable("x");
        }

        [TestMethod]
        public void ShouldCreateObject()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("y");
            IObject obj = cls.NewObject();
            Assert.IsNotNull(obj);
            Assert.IsNull(obj[0]);
            Assert.IsNull(obj[1]);
        }
    }
}

