namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class LoaderTests
    {
        [TestMethod]
        public void ShouldBeCreated()
        {
            Loader loader = new Loader(new StringReader(""));

            Assert.IsNotNull(loader);
        }

        [TestMethod]
        public void ShouldGetEmptyLine()
        {
            Loader loader = new Loader(new StringReader("\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldGetTwoLinesBlock()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldGetTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!\nline 3\nline 4\n!\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("line 3\nline 4\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldGetBlockAndInmediate()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!inmediate!\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("inmediate", loader.GetInmediateText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldExecuteBlock()
        {
            Loader loader = new Loader(new StringReader("One := 1\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void ShouldExecuteBlockWithTwoCommands()
        {
            Loader loader = new Loader(new StringReader("One := 1.\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void ShouldExecuteTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("One := 1.\n!\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObject.st")]
        public void ShouldExecuteSetObjectFile()
        {
            Loader loader = new Loader(@"SetObject.st");
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SetObjects.st")]
        public void ShouldExecuteSetObjectsFile()
        {
            Loader loader = new Loader(@"SetObjects.st");
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclass.st")]
        public void ShouldExecuteDefineSubclassFile()
        {
            Loader loader = new Loader(@"DefineSubclass.st");
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

            Assert.IsNull(machine.GetGlobalObject("Object"));

            loader.LoadAndExecute(machine);

            Assert.IsNotNull(machine.GetGlobalObject("Object"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineSubclassWithVariables.st")]
        public void ShouldExecuteDefineSubclassWithVariablesFile()
        {
            Loader loader = new Loader(@"DefineSubclassWithVariables.st");
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

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
        public void ShouldExecuteDefineRectangleFile()
        {
            Loader loader = new Loader(@"DefineRectangle.st");
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

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
        public void ShouldExecuteDefineClassSubclassFile()
        {
            Loader loader = new Loader(@"DefineClassSubclass.st");
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

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
    }
}

