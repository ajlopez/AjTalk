namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void BeCreated()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass("Rectangle");

            Assert.IsNotNull(cls);
            Assert.AreEqual("Rectangle", cls.Name);
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNull(cls.GetClassMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("nil", cls.SuperClass.Name);
        }

        [TestMethod]
        public void BeCreatedWithSuperclass()
        {
            Machine machine = new Machine();

            IClass supercls = machine.CreateClass("Figure");
            IClass cls = machine.CreateClass("Rectangle", supercls);

            Assert.IsNotNull(cls);
            Assert.AreEqual("Rectangle", cls.Name);
            Assert.IsNull(cls.GetInstanceMethod("x"));
            Assert.IsNull(cls.GetClassMethod("x"));
            Assert.IsNotNull(cls.SuperClass);
            Assert.AreEqual("Figure", cls.SuperClass.Name);
        }

        [TestMethod]
        public void InheritsVariables()
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
        public void AvoidNullName()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass(null);
        }

        [TestMethod]
        public void AddInstanceVariable()
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
        public void AvoidDuplicatedInstanceVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("x");
        }

        [TestMethod]
        public void AddClassVariable()
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
        public void AvoidDuplicatedClassVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineClassVariable("x");
            cls.DefineClassVariable("x");
        }

        [TestMethod]
        public void CreateObject()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("y");
            IObject obj = (IObject) cls.NewObject();
            Assert.IsNotNull(obj);
            Assert.IsNull(obj[0]);
            Assert.IsNull(obj[1]);
        }

        [TestMethod]
        public void CreateBehavior()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Behavior");
            IObject obj = (IObject) cls.NewObject();
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(BaseBehavior));
            Assert.IsNotInstanceOfType(obj, typeof(BaseClassDescription));
        }

        [TestMethod]
        public void CreateClassDescription()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("ClassDescription");
            IObject obj = (IObject) cls.NewObject();
            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(BaseClassDescription));
            Assert.IsNotInstanceOfType(obj, typeof(BaseClass));
        }
    }
}

