namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Compiler;

    [TestClass]
    public class MachineTests
    {
        [TestMethod]
        public void InitializeMachine()
        {
            Machine machine = new Machine();

            Assert.IsNotNull(machine.UndefinedObjectClass);
            Assert.IsNull(machine.ClassClass);

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
        [DeploymentItem(@"CodeFiles\HostMachine.st")]
        [DeploymentItem(@"CodeFiles\HostedMachine.st")]
        public void CreateAndEvaluatedHostedObject()
        {
            Machine host = this.LoadMachine("HostMachine.st");
            Machine hosted = this.LoadMachine("HostedMachine.st");

            hosted.HostMachine = host;

            this.Evaluate(hosted, "rect := Rectangle new");
            var result = hosted.GetGlobalObject("rect");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            var iobj = (IObject)result;

            this.Evaluate(hosted, "rect x: 10");
            Assert.AreEqual(10, iobj[0]);
            this.Evaluate(hosted, "rect y: 20");
            Assert.AreEqual(20, iobj[1]);

            this.Evaluate(hosted, "rect width: 10");
            Assert.AreEqual(10, iobj[2]);
            this.Evaluate(hosted, "rect height: 30");
            Assert.AreEqual(30, iobj[3]);
            Assert.AreEqual(300, this.Evaluate(hosted, "rect area"));
        }

        private object Evaluate(Machine machine, string code)
        {
            SimpleCompiler compiler = new SimpleCompiler();
            Block block = compiler.CompileBlock(code);
            return block.Execute(machine, null);
        }

        private Machine LoadMachine(string filename)
        {
            Machine machine = new Machine();
            Loader loader = new Loader(filename, new SimpleCompiler());
            loader.LoadAndExecute(machine);
            return machine;
        }
    }
}

