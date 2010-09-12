namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MethodTests
    {
        [TestMethod]
        public void BeCreated()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            IMethod mth = new Method(cls, "method1");

            Assert.IsNotNull(mth);
            Assert.AreEqual("method1", mth.Name);
            Assert.AreEqual(cls, mth.Class);
            Assert.AreEqual("TestClass", ((IClass) mth.Class).Name);
        }

        [TestMethod]
        public void Compile()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Method mth;

            mth = new Method(cls, "x:");
            mth.CompileArgument("newX");
            mth.CompileGet("newX");
            mth.CompileSet("x");

            cls.DefineInstanceMethod(mth);

            Assert.AreEqual(mth, cls.GetInstanceMethod("x:"));
        }

        [TestMethod]
        public void CompileWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Method mth;

            mth = new Method(cls, "x:");
            mth.CompileArgument("newX");
            mth.CompileLocal("l");
            mth.CompileGet("newX");
            mth.CompileSet("l");
            mth.CompileGet("l");
            mth.CompileSet("x");

            cls.DefineInstanceMethod(mth);

            Assert.AreEqual(mth, cls.GetInstanceMethod("x:"));
        }

        [TestMethod]
        public void CompileAndRun()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Method mth;

            mth = new Method(cls, "x:");
            mth.CompileArgument("newX");
            mth.CompileGet("newX");
            mth.CompileSet("x");

            cls.DefineInstanceMethod(mth);

            IObject obj = (IObject) cls.NewObject();

            mth.Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
        }

        [TestMethod]
        public void CompileWithLocalsAndRun()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Method mth;

            mth = new Method(cls, "x:");
            mth.CompileArgument("newX");
            mth.CompileLocal("l");
            mth.CompileGet("newX");
            mth.CompileSet("l");
            mth.CompileGet("l");
            mth.CompileSet("x");

            cls.DefineInstanceMethod(mth);

            IObject obj = (IObject) cls.NewObject();

            mth.Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
        }

        [TestMethod]
        public void CompileGlobalName()
        {
            Method mth = new Method("test");
            byte p = mth.CompileGlobal("Class");

            Assert.AreEqual(0, p);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NotRunWithMachine()
        {
            Machine machine = new Machine();

            Method method;

            method = new Method("invalidMethod");
            method.CompileArgument("newX");
            method.CompileGet("newX");
            method.CompileSet("GlobalX");

            method.Execute(machine, new object[] { 10 });
        }
    }
}

