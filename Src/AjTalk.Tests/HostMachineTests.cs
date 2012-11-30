namespace AjTalk.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Language;

    [TestClass]
    public class HostMachineTests
    {
        [TestMethod]
        public void GetClassByClassName()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = machine.GetClass(klass.Name);

            Assert.IsNotNull(result);
            Assert.AreSame(klass, result);
        }

        [TestMethod]
        public void GetMetaClassByClassName()
        {
            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = machine.GetMetaClass(klass.Name);

            Assert.IsNotNull(result);
            Assert.AreSame(klass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedClassSameName()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass, result);
        }

        [TestMethod]
        public void GetAssociatedBehaviorUsingClass()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedBehavior(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass, result);
        }

        [TestMethod]
        public void GetAssociatedMetaClassSameName()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedBehaviorUsingMetaClass()
        {
            Machine hostmachine = new Machine();
            IClass hostklass = hostmachine.CreateClass("Rectangle");
            hostmachine.SetGlobalObject(hostklass.Name, hostklass);

            Machine machine = new Machine();
            IClass klass = machine.CreateClass("Rectangle");
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedBehavior(klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostklass.Behavior, result);
        }

        [TestMethod]
        public void GetAssociatedSuperClass()
        {
            Machine hostmachine = new Machine();
            IClass hostsuperclass = hostmachine.CreateClass("Figure");
            hostmachine.SetGlobalObject(hostsuperclass.Name, hostsuperclass);

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostsuperclass, result);
        }

        [TestMethod]
        public void NotAssociatedSuperClass()
        {
            Machine hostmachine = new Machine();

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedClass(klass);

            Assert.IsNotNull(result);
            Assert.AreSame(hostmachine.UndefinedObjectClass, result);
        }

        [TestMethod]
        public void GetAssociatedSuperMetaClass()
        {
            Machine hostmachine = new Machine();
            IClass hostsuperclass = hostmachine.CreateClass("Figure");
            hostmachine.SetGlobalObject(hostsuperclass.Name, hostsuperclass);

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostsuperclass.Behavior, result);
        }

        [TestMethod]
        public void NoAssociatedSuperMetaClass()
        {
            Machine hostmachine = new Machine();

            Machine machine = new Machine();
            IClass superclass = machine.CreateClass("Figure");
            machine.SetGlobalObject(superclass.Name, superclass);
            IClass klass = machine.CreateClass("Rectangle", superclass);
            machine.SetGlobalObject(klass.Name, klass);

            var result = hostmachine.GetAssociatedMetaClass((IMetaClass)klass.Behavior);

            Assert.IsNotNull(result);
            Assert.AreSame(hostmachine.UndefinedObjectClass.Behavior, result);
        }
    }
}
