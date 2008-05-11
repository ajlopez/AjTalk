using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class CompilerTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            Compiler compiler = new Compiler("x ^x");

            Assert.IsNotNull(compiler);
        }

        [Test]
        public void ShouldCompileMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Compiler compiler = new Compiler("x ^x");
            compiler.CompileMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
        }

        [Test]
        public void ShouldCompileSetMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Compiler compiler = new Compiler("x: newX x := newX");
            compiler.CompileMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
        }

        [Test]
        public void ShouldCompileMethods()
        {
            IClass cls = CompileClass("Rectangle", new string[] { "x", "y" },
                new string[] {
                    "x ^x",
                    "x: newX x := newX",
                    "y ^y",
                    "y: newY y := newY"
                });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
            Assert.IsNotNull(cls.GetInstanceMethod("y"));
            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
            Assert.IsNotNull(cls.GetInstanceMethod("y:"));
        }

        [Test]
        public void ShouldRunMethods()
        {
            IClass cls = CompileClass("Rectangle", new string[] { "x", "y" },
                new string[] {
                    "x ^x",
                    "x: newX x := newX",
                    "y ^y",
                    "y: newY y := newY"
                });

            Assert.IsNotNull(cls);

            IObject obj = cls.NewObject();

            cls.GetInstanceMethod("x:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);

            cls.GetInstanceMethod("y:").Execute(obj, new object[] { 20 });

            Assert.AreEqual(20, obj[1]);

            Assert.AreEqual(10, cls.GetInstanceMethod("x").Execute(obj, new object[] {}));
            Assert.AreEqual(20, cls.GetInstanceMethod("y").Execute(obj, new object[] {}));
        }

        [Test]
        public void ShouldCompileMultiCommandMethod()
        {
            IClass cls = CompileClass("Rectangle", new string[] { "x", "y" },
                new string[] {
                    "side: newSide x := newSide. y := newSide"
                });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [Test]
        public void ShouldRunMultiCommandMethod()
        {
            IClass cls = CompileClass("Rectangle", new string[] { "x", "y" },
                new string[] {
                    "side: newSide x := newSide. y := newSide"
                });

            Assert.IsNotNull(cls);

            IObject obj = cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }

        public static IClass CompileClass(string clsname, string[] varnames, string[] methods)
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass(clsname);

            if (varnames != null)
                foreach (string varname in varnames)
                    cls.DefineInstanceVariable(varname);

            if (methods != null)
                foreach (string method in methods)
                {
                    Compiler compiler = new Compiler(method);
                    compiler.CompileMethod(cls);
                }

            return cls;
        }
    }
}

