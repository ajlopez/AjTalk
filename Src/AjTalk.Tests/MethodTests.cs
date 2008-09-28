using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class MethodTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            IMethod mth = new Method(cls, "method1");

            Assert.IsNotNull(mth);
            Assert.AreEqual("method1",mth.Name);
            Assert.AreEqual(cls, mth.Class);
            Assert.AreEqual("TestClass", mth.Class.Name);
        }

        [Test]
        public void ShouldCompile()
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

        [Test]
        public void ShouldCompileWithoutClassAndGlobals()
        {
            Machine machine = new Machine();
            Method mth;

            mth = new Method("setGlobal:");
            mth.CompileArgument("newGlobal");
            mth.CompileGet("newGlobal");
            mth.CompileSet("Global");

            Assert.AreEqual("Global", mth.GetGlobalName(0));
        }

        [Test]
        public void ShouldCompileAndRunWithoutClassAndGlobals()
        {
            Machine machine = new Machine();
            Method mth;

            IClass clsobject = (IClass) machine.GetGlobalObject("Object");
            IObject anyobject = clsobject.NewObject();

            mth = new Method("setGlobal:");
            mth.CompileArgument("newGlobal");
            mth.CompileGet("newGlobal");
            mth.CompileSet("Global");

            mth.Execute(anyobject, new object[] { 10 });

            Assert.AreEqual(10, machine.GetGlobalObject("Global"));
        }

        [Test]
        public void ShouldCompileWithLocals()
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

        [Test]
        public void ShouldCompileAndRun()
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

            IObject obj = cls.NewObject();

            mth.Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
        }

        [Test]
        public void ShouldCompileWithLocalsAndRun()
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

            IObject obj = cls.NewObject();

            mth.Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
        }

        [Test]
        public void ShouldCompileGlobalName()
        {
            Method mth = new Method("test");
            byte p = mth.CompileGlobal("Class");

            Assert.AreEqual(0, p);
        }

        [Test]
        public void ShouldCompileGlobalNames()
        {
            Method mth = new Method("test");
            byte p1 = mth.CompileGlobal("Class");
            byte p2 = mth.CompileGlobal("Object");
            byte p3 = mth.CompileGlobal("Class");

            Assert.AreEqual(0, p1);
            Assert.AreEqual(1, p2);
            Assert.AreEqual(0, p3);
        }

        [Test]
        public void ShouldCompileGetGlobalVariable()
        {
            Method mth = new Method("test");
            mth.CompileGet("Class");
            mth.CompileGet("Object");

            byte p1 = mth.CompileGlobal("Object");
            byte p2 = mth.CompileGlobal("Class");

            Assert.AreEqual(1, p1);
            Assert.AreEqual(0, p2);
        }
    }
}

