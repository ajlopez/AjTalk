namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Compiler;
    using System.IO;

    [TestClass]
    public class BasicClassTest 
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

            AgentObject agent = (AgentObject) result;
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
            Assert.IsTrue(definition.Contains("category: ''"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void DefineClassAndGetItsOutputString()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st");
            Machine machine = new Machine();
            loader.LoadAndExecute(machine);

            BaseClass rectangle = (BaseClass) machine.GetGlobalObject("Rectangle");

            string output = rectangle.ToOutputString();

            Assert.IsNotNull(output);
            Assert.IsTrue(output.Contains("nil subclass:"));
            Assert.IsTrue(output.Contains("Rectangle class methods!"));
            Assert.IsTrue(output.Contains("Rectangle methods!"));
            Assert.IsTrue(output.Contains("^x"));
            Assert.IsTrue(output.Contains("^y"));
            Assert.IsTrue(output.Contains("x := 10"));
            Assert.IsTrue(output.Contains("y := 20"));
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void DuplicateClassInOtherMachine()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st");
            Machine machine = new Machine();
            loader.LoadAndExecute(machine);

            BaseClass rectangle = (BaseClass)machine.GetGlobalObject("Rectangle");

            string output = rectangle.ToOutputString();

            Loader loader2 = new Loader(new StringReader(output));
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
