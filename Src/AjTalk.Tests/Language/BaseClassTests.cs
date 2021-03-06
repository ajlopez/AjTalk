﻿namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseClassTest 
    {
        [TestMethod]
        public void Create()
        {
            Machine machine = new Machine();
            BaseClass bclass = new BaseClass("Class", machine);
            Assert.IsNotNull(bclass);
            Assert.AreEqual("Class", bclass.Name);
            Assert.AreEqual(machine, bclass.Machine);
            Assert.IsNull(bclass.SuperClass);
            Assert.AreEqual(0, bclass.NoInstanceVariables);
            Assert.AreSame(machine.CurrentEnvironment, bclass.Scope);
        }

        [TestMethod]
        public void CreateInEnvironment()
        {
            Machine machine = new Machine();
            Context environment = new Context(machine.Environment);
            machine.CurrentEnvironment = environment;
            BaseClass bclass = new BaseClass("Class", machine);
            Assert.IsNotNull(bclass);
            Assert.AreEqual("Class", bclass.Name);
            Assert.AreEqual(machine, bclass.Machine);
            Assert.IsNull(bclass.SuperClass);
            Assert.AreEqual(0, bclass.NoInstanceVariables);
            Assert.AreSame(machine.CurrentEnvironment, bclass.Scope);

            machine.CurrentEnvironment = null;
        }

        [TestMethod]
        public void DefineAndCreateAgent()
        {
            Machine machine = new Machine();
            BaseClass bclass = new BaseClass("Agent", machine);
            bclass.IsAgentClass = true;

            object result = bclass.NewObject();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AgentObject));

            AgentObject agent = (AgentObject)result;
            Assert.AreEqual(bclass, agent.Behavior);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseIfNameIsNull()
        {
            Machine machine = new Machine();
            BaseClass bclass = new BaseClass(null, machine);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseIfMachineIsNull()
        {
            BaseClass bclass = new BaseClass("Class", null);
        }

        [TestMethod]
        public void DefineInstanceVariables()
        {
            Machine machine = new Machine();
            BaseClass bclass = new BaseClass("Class", machine);

            bclass.DefineInstanceVariable("x");
            bclass.DefineInstanceVariable("y");

            Assert.AreEqual(2, bclass.NoInstanceVariables);
            Assert.AreEqual(0, bclass.GetInstanceVariableOffset("x"));
            Assert.AreEqual(1, bclass.GetInstanceVariableOffset("y"));
            Assert.AreEqual(-1, bclass.GetInstanceVariableOffset("z"));
            Assert.AreEqual("x y", bclass.GetInstanceVariableNamesAsString());
            Assert.AreEqual(string.Empty, bclass.GetClassVariableNamesAsString());
            Assert.AreEqual(null, bclass.GetClassVariableNames());

            var result = bclass.GetInstanceVariableNames();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("x", result.ElementAt(0));
            Assert.AreEqual("y", result.ElementAt(1));
        }

        [TestMethod]
        public void DefineClassVariables()
        {
            Machine machine = new Machine();
            IClass bclass = machine.CreateClass("MyClass");

            bclass.DefineClassVariable("Count");
            bclass.DefineClassVariable("Items");

            Assert.AreEqual(0, bclass.Behavior.NoInstanceVariables);
            Assert.AreEqual(0, bclass.NoVariables);
            Assert.AreEqual(2, bclass.NoClassVariables);

            Assert.AreEqual(0, bclass.GetClassVariableOffset("Count"));
            Assert.AreEqual(1, bclass.GetClassVariableOffset("Items"));
            Assert.AreEqual(-1, bclass.GetClassVariableOffset("Z"));

            Assert.AreEqual(0, ((IClassDescription)bclass.Behavior).GetClassVariableOffset("Count"));
            Assert.AreEqual(1, ((IClassDescription)bclass.Behavior).GetClassVariableOffset("Items"));
            Assert.AreEqual(-1, ((IClassDescription)bclass.Behavior).GetClassVariableOffset("Z"));

            Assert.AreEqual("Count Items", bclass.GetClassVariableNamesAsString());
            Assert.AreEqual("Count Items", ((IClassDescription)bclass.Behavior).GetClassVariableNamesAsString());
            Assert.AreEqual(string.Empty, bclass.GetInstanceVariableNamesAsString());
            Assert.AreEqual(null, bclass.GetInstanceVariableNames());

            var result = bclass.GetClassVariableNames();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Count", result.ElementAt(0));
            Assert.AreEqual("Items", result.ElementAt(1));

            result = ((IClassDescription)bclass.Behavior).GetClassVariableNames();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Count", result.ElementAt(0));
            Assert.AreEqual("Items", result.ElementAt(1));
        }

        [TestMethod]
        public void GetSetClassVariables()
        {
            Machine machine = new Machine();
            IClass bclass = new BaseClass("MyClass", machine);

            bclass.DefineClassVariable("Count");
            bclass.DefineClassVariable("Items");

            int countoffset = bclass.GetClassVariableOffset("Count");
            int itemsoffset = bclass.GetClassVariableOffset("Items");

            Assert.AreEqual(0, countoffset);
            Assert.AreEqual(1, itemsoffset);

            bclass.SetClassVariable(countoffset, 1);
            bclass.SetClassVariable(itemsoffset, "foo");

            Assert.AreEqual(1, bclass.GetClassVariable(countoffset));
            Assert.AreEqual("foo", bclass.GetClassVariable(itemsoffset));
        }

        [TestMethod]
        public void GetSetClassVariablesInSubclass()
        {
            Machine machine = new Machine();
            IClass bclass = new BaseClass("MyClass", machine);
            IClass bsubclass = new BaseClass(null, "MySubClass", bclass, machine, null);

            bclass.DefineClassVariable("Count");
            bclass.DefineClassVariable("Items");
            bsubclass.DefineClassVariable("Value");

            int countoffset = bsubclass.GetClassVariableOffset("Count");
            int itemsoffset = bsubclass.GetClassVariableOffset("Items");
            int valueoffset = bsubclass.GetClassVariableOffset("Value");

            Assert.AreEqual(0, countoffset);
            Assert.AreEqual(1, itemsoffset);
            Assert.AreEqual(2, valueoffset);

            bsubclass.SetClassVariable(countoffset, 1);
            bsubclass.SetClassVariable(itemsoffset, "foo");
            bsubclass.SetClassVariable(valueoffset, "value");

            Assert.AreEqual(1, bclass.GetClassVariable(countoffset));
            Assert.AreEqual("foo", bclass.GetClassVariable(itemsoffset));
            Assert.AreEqual(1, bsubclass.GetClassVariable(countoffset));
            Assert.AreEqual("foo", bsubclass.GetClassVariable(itemsoffset));
            Assert.AreEqual("value", bsubclass.GetClassVariable(valueoffset));
        }

        [TestMethod]
        public void GetDefineString()
        {
            Machine machine = new Machine();
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, machine);
            BaseClass bclass = new BaseClass(meta, "Class", null, machine, string.Empty);

            bclass.DefineInstanceVariable("x");
            bclass.DefineInstanceVariable("y");

            string definition = bclass.ToDefineString();

            Assert.IsNotNull(definition);
            Assert.IsTrue(definition.Contains("subclass: #Class"));
            Assert.IsTrue(definition.Contains("instanceVariableNames: 'x y'"));
            Assert.IsTrue(definition.Contains("classVariableNames: ''"));
            Assert.IsTrue(definition.Contains("poolDictionaries: ''"));
            Assert.IsTrue(definition.Contains("category: ''"));
        }

        [TestMethod]
        public void DefineSubclassAndGetDefineString()
        {
            Machine machine = new Machine();
            IMetaClass meta = BaseMetaClass.CreateMetaClass(null, machine);
            BaseClass oclass = new BaseClass(meta, "Object", null, machine, string.Empty);
            BaseClass bclass = new BaseClass(meta, "Class", oclass, machine, string.Empty);

            bclass.DefineInstanceVariable("x");
            bclass.DefineInstanceVariable("y");

            string definition = bclass.ToDefineString();

            Assert.IsNotNull(definition);
            Assert.IsTrue(definition.Contains("Object subclass: #Class"));
            Assert.IsTrue(definition.Contains("instanceVariableNames: 'x y'"));
            Assert.IsTrue(definition.Contains("classVariableNames: ''"));
            Assert.IsTrue(definition.Contains("poolDictionaries: ''"));
            Assert.IsTrue(definition.Contains("category: ''!"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void DefineClassAndGetItsOutputString()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st", new VmCompiler());
            Machine machine = new Machine();
            loader.LoadAndExecute(machine);

            BaseClass rectangle = (BaseClass)machine.GetGlobalObject("Rectangle");

            string output = rectangle.ToOutputString();

            Assert.IsNotNull(output);
            Assert.IsTrue(output.Contains("nil subclass:"));
            Assert.IsTrue(output.Contains("category: ''!"));
            Assert.IsTrue(output.Contains("!Rectangle class methods!"));
            Assert.IsTrue(output.Contains("!Rectangle methods!"));
            Assert.IsTrue(output.Contains("! !"));
            Assert.IsTrue(output.Contains("^x"));
            Assert.IsTrue(output.Contains("^y"));
            Assert.IsTrue(output.Contains("x := 10"));
            Assert.IsTrue(output.Contains("y := 20"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void DuplicateClassInOtherMachine()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st", new SimpleCompiler());
            Machine machine = new Machine();
            loader.LoadAndExecute(machine);

            BaseClass rectangle = (BaseClass)machine.GetGlobalObject("Rectangle");

            string output = rectangle.ToOutputString();

            Loader loader2 = new Loader(new StringReader(output), new VmCompiler());
            Machine machine2 = new Machine();
            loader2.LoadAndExecute(machine2);

            BaseClass rectangle2 = (BaseClass)machine2.GetGlobalObject("Rectangle");

            Assert.IsNotNull(rectangle2);
            Assert.IsNotNull(rectangle2.GetClassMethod("new"));
            Assert.IsNotNull(rectangle2.GetInstanceMethod("x"));
            Assert.IsNotNull(rectangle2.GetInstanceMethod("y"));
            Assert.IsNotNull(rectangle2.GetInstanceMethod("x:"));
            Assert.IsNotNull(rectangle2.GetInstanceMethod("y:"));
            Assert.IsNotNull(rectangle2.GetInstanceMethod("initialize"));

            Parser parser = new Parser("Rectangle new");
            Block block = parser.CompileBlock();
            object result = block.Execute(machine2, null);

            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(result, typeof(IObject));

            IObject iobj = (IObject)result;

            Assert.AreEqual(10, iobj[0]);
            Assert.AreEqual(20, iobj[1]);
        }
    }
}
