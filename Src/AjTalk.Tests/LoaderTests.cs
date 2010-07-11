namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoaderTests
    {
        [TestMethod]
        public void BeCreated()
        {
            Loader loader = new Loader(new StringReader(string.Empty));

            Assert.IsNotNull(loader);
        }

        [TestMethod]
        public void GetEmptyLine()
        {
            Loader loader = new Loader(new StringReader("\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetTwoLinesBlock()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!\nline 3\nline 4\n!\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("line 3\nline 4\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void GetBlockAndInmediate()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!inmediate!\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("inmediate", loader.GetInmediateText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Loader loader = new Loader(new StringReader("One := 1\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void ExecuteBlockWithTwoCommands()
        {
            Loader loader = new Loader(new StringReader("One := 1.\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void ExecuteTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("One := 1.\n!\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObject.st")]
        public void ExecuteSetObjectFile()
        {
            Loader loader = new Loader(@"SetObject.st");
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetDotNetObject.st")]
        public void ExecuteSetDotNetObjectFile()
        {
            Loader loader = new Loader(@"SetDotNetObject.st");
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("FileInfo");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.IO.FileInfo));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObjects.st")]
        public void ExecuteSetObjectsFile()
        {
            Loader loader = new Loader(@"SetObjects.st");
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclass.st")]
        public void ExecuteDefineSubclassFile()
        {
            Loader loader = new Loader(@"DefineSubclass.st");

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Object"));

            loader.LoadAndExecute(machine);

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclassWithVariables.st")]
        public void ExecuteDefineSubclassWithVariablesFile()
        {
            Loader loader = new Loader(@"DefineSubclassWithVariables.st");

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangle.st")]
        public void ExecuteDefineRectangleFile()
        {
            Loader loader = new Loader(@"DefineRectangle.st");

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(2, cls.GetInstanceVariableOffset("width"));
            Assert.AreEqual(3, cls.GetInstanceVariableOffset("height"));

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
            Assert.IsNotNull(cls.GetInstanceMethod("y"));
            Assert.IsNotNull(cls.GetInstanceMethod("y:"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineClassSubclass.st")]
        public void ExecuteDefineClassSubclassFile()
        {
            Loader loader = new Loader(@"DefineClassSubclass.st");

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Rectangle"));

            loader.LoadAndExecute(machine);

            object obj = machine.GetGlobalObject("Rectangle");

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IClass));

            IClass cls = (IClass)obj;

            Assert.AreEqual(0, cls.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, cls.GetInstanceVariableOffset("y"));
            Assert.AreEqual(2, cls.GetInstanceVariableOffset("width"));
            Assert.AreEqual(3, cls.GetInstanceVariableOffset("height"));

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
            Assert.IsNotNull(cls.GetInstanceMethod("y"));
            Assert.IsNotNull(cls.GetInstanceMethod("y:"));
            Assert.IsNotNull(cls.GetInstanceMethod("width"));
            Assert.IsNotNull(cls.GetInstanceMethod("height"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\Library1.st")]
        public void LoadLibrary()
        {
            Loader loader = new Loader(@"Library1.st");

            Machine machine = CreateMachine();

            Assert.IsNull(machine.GetGlobalObject("Object"));
            Assert.IsNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNull(machine.GetGlobalObject("Class"));
            Assert.IsNull(machine.GetGlobalObject("Metaclass"));

            loader.LoadAndExecute(machine);

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
            Assert.IsNotNull(machine.GetGlobalObject("Behavior"));
            Assert.IsNotNull(machine.GetGlobalObject("ClassDescription"));
            Assert.IsNotNull(machine.GetGlobalObject("Class"));
            Assert.IsNotNull(machine.GetGlobalObject("Metaclass"));
        }

        private static Machine CreateMachine()
        {
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));
            return machine;
        }
    }
}

