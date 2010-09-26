﻿namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            BaseClass bclass = new BaseClass("Class", machine);

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
            BaseClass oclass = new BaseClass("Object", machine);
            BaseClass bclass = new BaseClass("Class", oclass, machine);

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
    }
}
