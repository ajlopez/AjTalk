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
    }
}

