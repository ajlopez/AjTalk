using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class ClassTests
    {
        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldAvoidNullName()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass(null);
        }

        [Test]
        public void ShouldAddInstanceVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("y");

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldAvoidDuplicatedInstanceVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineInstanceVariable("x");
        }

        [Test]
        public void ShouldAddClassVariable()
        {
            Machine machine = new Machine();

            IClass cls = machine.CreateClass("TestClass");
            cls.DefineClassVariable("x");
            cls.DefineClassVariable("y");

            Assert.AreEqual(0, cls.GetClassVariableOffset("x"));
            Assert.AreEqual(1, cls.GetClassVariableOffset("y"));
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldAvoidDuplicatedClassVariable()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineClassVariable("x");
            cls.DefineClassVariable("x");
        }

        [Test]
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

