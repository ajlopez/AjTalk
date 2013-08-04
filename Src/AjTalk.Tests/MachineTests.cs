namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void InitializeMachine()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine.UndefinedObjectClass);
            Assert.IsNull(machine.ClassClass);

            Assert.IsNotNull(machine.Environment);

            var result = machine.GetGlobalObject("UndefinedObject");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IBehavior));
            Assert.IsInstanceOfType(result, typeof(BaseClass));

            var klass = (BaseClass)result;
            Assert.AreEqual("UndefinedObject", klass.Name);
            Assert.AreSame(klass, machine.UndefinedObjectClass);

            result = machine.GetGlobalObject("Machine");
            Assert.IsNotNull(result);
            Assert.AreSame(machine, result);

            result = machine.GetGlobalObject("Smalltalk");
            Assert.IsNotNull(result);
            Assert.AreSame(machine.Environment, result);

            Assert.AreSame(machine.Environment, machine.CurrentEnvironment);
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
            IClass cls = machine.CreateClass("TestClass", null, "x", "Count");

            Assert.IsNotNull(cls);
            Assert.AreEqual("TestClass", cls.Name);
            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(-1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(0, cls.GetClassVariableOffset("Count"));
            Assert.AreEqual(-1, cls.GetClassVariableOffset("y"));
            Assert.AreEqual("x", cls.GetInstanceVariableNamesAsString());
            Assert.AreEqual("Count", cls.GetClassVariableNamesAsString());
            Assert.AreEqual(0, cls.NoVariables);
            Assert.AreEqual(1, cls.NoClassVariables);

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
            Machine machine = new Machine(true);

            Assert.IsNotNull(Machine.Current);
            Assert.AreSame(Machine.Current, machine);
        }

        [TestMethod]
        public void CreateNotAsCurrent()
        {
            Machine machine = new Machine(false);

            Assert.AreNotSame(Machine.Current, machine);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        public void LoadLibrary2UsingLoadFile()
        {
            Machine machine = new Machine();

            machine.LoadFile("Library2.st");

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
            Assert.IsNotNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNotNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNotNull(machine.GetGlobalObject("Class"));
            Assert.IsNotNull(machine.GetGlobalObject("Metaclass"));
            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library2.st")]
        [DeploymentItem(@"CodeFiles\LoadLibrary2.st")]
        public void LoadLibrary2UsingFromAnotherFile()
        {
            Machine machine = new Machine();

            machine.LoadFile(@"LoadLibrary2.st");

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
            Assert.IsNotNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNotNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNotNull(machine.GetGlobalObject("Class"));
            Assert.IsNotNull(machine.GetGlobalObject("Metaclass"));
            Assert.IsNotNull(machine.GetGlobalObject("UndefinedObject"));
        }

        [TestMethod]
        [DeploymentItem("modules", "modules")]
        public void LoadModule1()
        {
            Machine machine = new Machine();

            machine.ImportModule("Module1");

            var result = machine.Environment.GetValue("Module1");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Context));

            var context = (Context)result;

            result = context.GetValue("Class1");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));
        }

        [TestMethod]
        [DeploymentItem("modules", "modules")]
        public void LoadModule2()
        {
            Machine machine = new Machine();

            machine.ImportModule("Module2");

            var result = machine.Environment.GetValue("Module2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Context));

            var context = (Context)result;

            result = context.GetValue("Class2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));
        }

        [TestMethod]
        [DeploymentItem("modules", "modules")]
        public void LoadModule2Submodule1()
        {
            Machine machine = new Machine();

            machine.ImportModule("Module2.Submodule1");

            var result = machine.Environment.GetValue("Module2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Context));

            var parent = (Context)result;

            result = parent.GetValue("Submodule1");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Context));

            var context = (Context)result;

            result = context.GetValue("Class21");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));
        }

        [TestMethod]
        [DeploymentItem("node_modules", "node_modules")]
        public void LoadModule3FromNodeModules()
        {
            Machine machine = new Machine();

            machine.ImportModule("Module3");

            var result = machine.Environment.GetValue("Module3");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Context));

            var context = (Context)result;

            result = context.GetValue("Class3");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));
        }
    }
}

