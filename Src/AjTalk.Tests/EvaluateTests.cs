using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using AjTalk.Compiler;
using AjTalk.Language;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading;

namespace AjTalk.Tests
{
    [TestClass]
    public class EvaluateTests
    {
        private Machine machine;

        [TestInitialize]
        public void Setup()
        {
            // TODO refactor machine factory
            this.machine = LoaderTests.CreateMachine();
        }

        [TestMethod]
        public void EvaluateInteger()
        {
            Assert.AreEqual(1, this.Evaluate("1"));
        }

        [TestMethod]
        public void EvaluateString()
        {
            Assert.AreEqual("foo", this.Evaluate("'foo'"));
        }

        [TestMethod]
        public void EvaluateBlockWithInteger()
        {
            Assert.AreEqual(1, this.Evaluate("[1] value"));
        }

        [TestMethod]
        public void EvaluateIntegerAdd()
        {
            Assert.AreEqual(4, this.Evaluate("1+3"));
        }

        [TestMethod]
        public void EvaluateIntegerToString()
        {
            Assert.AreEqual("1", this.Evaluate("1 toString"));
        }

        [TestMethod]
        public void EvaluateIntegerSubstring()
        {
            Assert.AreEqual("23", this.Evaluate("1234 toString substring: 1 with: 2"));
        }

        [TestMethod]
        public void EvaluateBlockWithIntegerParameter()
        {
            Assert.AreEqual(2, this.Evaluate("[:x | x] value: 2"));
        }

        [TestMethod]
        public void EvaluateBlockWithTwoIntegerParameters()
        {
            Assert.AreEqual(5, this.Evaluate("[:x :y | x + y] value: 2 value: 3"));
        }

        [TestMethod]
        public void EvaluateGlobalVariable()
        {
            this.machine.SetGlobalObject("One", 1);
            Assert.AreEqual(1, this.Evaluate("One"));
        }

        [TestMethod]
        public void EvaluateAssignment()
        {
            this.Evaluate("One := 1");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateAssignmentAndGlobal()
        {
            Assert.AreEqual(1, this.Evaluate("One := 1. One"));
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void EvaluateTwoAssignments()
        {
            this.Evaluate("One := 1. Two := 2");
            Assert.AreEqual(1, this.machine.GetGlobalObject("One"));
            Assert.AreEqual(2, this.machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void CreateDotNetObject()
        {
            object result = this.Evaluate("@System.IO.FileInfo !new: 'afile.txt'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.IO.FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("afile.txt", fileinfo.Name);
        }

        [TestMethod]
        public void CreateDotNetObjectUsingNew()
        {
            object result = this.Evaluate("@System.IO.FileInfo new: 'afile.txt'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(System.IO.FileInfo));

            FileInfo fileinfo = (FileInfo)result;

            Assert.AreEqual("afile.txt", fileinfo.Name);
        }

        [TestMethod]
        public void InvokeDotNetMethod()
        {
            object result = this.Evaluate("2 !toString");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void InvokeDotNetMethodWithParameters()
        {
            object result = this.Evaluate("'foobar' !substring: 1 with: 2");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("oo", result);
        }

        [TestMethod]
        public void InvokeStaticDotNetMethod()
        {
            object result = this.Evaluate("@System.IO.File !exists: 'foobar'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool) result);
        }

        [TestMethod]
        public void InvokeStaticDotNetMethodUsingMessage()
        {
            object result = this.Evaluate("@System.IO.File exists: 'foobar'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void DefineClass()
        {
            object result = this.Evaluate("nil subclass: #Object");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Object", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
        }

        [TestMethod]
        public void DefineClassWithInstanceClassVariablesAndCategory()
        {
            object result = this.Evaluate("nil subclass: #MyClass instanceVariableNames: 'x y' classVariableNames: 'z' poolDictionaries: '' category:'MyCategory'");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("MyClass", clss.Name);
            Assert.AreEqual(2, clss.NoInstanceVariables);
            Assert.AreEqual(1, clss.MetaClass.NoInstanceVariables);
            Assert.AreEqual("MyCategory", clss.Category);
        }

        [TestMethod]
        public void DefineClassesUsingSemicolon()
        {
            Assert.IsNull(this.machine.GetGlobalObject("Class1"));
            Assert.IsNull(this.machine.GetGlobalObject("Class2"));

            object result = this.Evaluate("nil subclass: #Class1; subclass: #Class2");

            Assert.IsNotNull(this.machine.GetGlobalObject("Class1"));
            Assert.IsNotNull(this.machine.GetGlobalObject("Class2"));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Class2", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
        }

        [TestMethod]
        public void BasicNewObject()
        {
            IClass clss = (IClass) this.Evaluate("nil subclass: #Object");
            object result = this.Evaluate("Object new");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IObject));

            IObject obj = (IObject) result;
            Assert.AreEqual(clss, obj.Behavior);
        }

        [TestMethod]
        public void DefineNativeBehavior()
        {
            object result = this.Evaluate("nil subclass: #List nativeType: @System.Collections.ArrayList");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NativeBehavior));

            NativeBehavior behavior = (NativeBehavior) result;

            Assert.AreEqual(typeof(System.Collections.ArrayList), behavior.NativeType);

            object newobj = behavior.CreateObject();

            Assert.IsNotNull(newobj);
            Assert.IsInstanceOfType(newobj, typeof(System.Collections.ArrayList));
        }

        [TestMethod]
        public void DefineAgent()
        {
            object result = this.Evaluate("nil agent: #Agent");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IClass));

            IClass clss = (IClass)result;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Agent", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
            Assert.IsInstanceOfType(clss, typeof(BaseClass));

            BaseClass baseclass = (BaseClass) clss;

            Assert.IsTrue(baseclass.IsAgentClass);
        }

        [TestMethod]
        public void CreateAgent()
        {
            object result = this.Evaluate("nil agent: #Agent. Agent new");

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AgentObject));

            AgentObject agent = (AgentObject)result;

            Assert.IsInstanceOfType(agent.Behavior, typeof(IClass));

            IClass clss = (IClass) agent.Behavior;

            Assert.IsNotNull(clss.Behavior);
            Assert.IsNotNull(clss.MetaClass);
            Assert.AreEqual("Agent", clss.Name);
            Assert.AreEqual(0, clss.NoInstanceVariables);
            Assert.IsInstanceOfType(clss, typeof(BaseClass));

            BaseClass baseclass = (BaseClass)clss;

            Assert.IsTrue(baseclass.IsAgentClass);
        }

        [TestMethod]
        public void CreateAndInvokeAgent()
        {
            ManualResetEvent handle = new ManualResetEvent(false);
            Thread thread = null;

            object aclass = this.Evaluate("nil agent: #Agent");

            Assert.IsNotNull(aclass);
            Assert.IsInstanceOfType(aclass, typeof(IBehavior));

            IBehavior behavior = (IBehavior)aclass;

            behavior.DefineInstanceMethod(new FunctionalMethod("sethandle", null, (self, receiver, args) => { thread = Thread.CurrentThread;  return handle.Set(); }));

            object result = this.Evaluate("Agent new sethandle");

            handle.WaitOne();
            Assert.IsNull(result);
            Assert.IsNotNull(thread);
            Assert.AreNotSame(Thread.CurrentThread, thread);
        }

        [TestMethod]
        public void EvaluateFalseAsFalse()
        {
            object result = this.Evaluate("false");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }

        [TestMethod]
        public void EvaluateTrueAsTrue()
        {
            object result = this.Evaluate("true");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void GetSystemConsole()
        {
            object result = this.Evaluate("@System.Console");
            Assert.AreEqual(result, typeof(System.Console));
        }

        private object Evaluate(string text)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            return block.Execute(this.machine, null);
        }
    }
}
