namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompilerTests
    {
        public static IClass CompileClass(string clsname, string[] varnames, string[] methods)
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass(clsname);

            if (varnames != null)
            {
                foreach (string varname in varnames)
                {
                    cls.DefineInstanceVariable(varname);
                }
            }

            if (methods != null)
            {
                foreach (string method in methods)
                {
                    Compiler compiler = new Compiler(method);
                    compiler.CompileInstanceMethod(cls);
                }
            }

            return cls;
        }

        [TestMethod]
        public void ShouldBeCreated()
        {
            Compiler compiler = new Compiler("x ^x");

            Assert.IsNotNull(compiler);
        }

        [TestMethod]
        public void ShouldCompileMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Compiler compiler = new Compiler("x ^x");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
        }

        [TestMethod]
        public void ShouldCompileMethodWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Compiler compiler = new Compiler("x | temp | temp := x. ^temp");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
        }

        [TestMethod]
        public void ShouldCompileSetMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Compiler compiler = new Compiler("x: newX x := newX");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
        }

        [TestMethod]
        public void ShouldCompileSimpleCommand()
        {
            Compiler compiler = new Compiler("nil invokeWith: 10");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void ShouldCompileSubClassDefinition()
        {
            Compiler compiler = new Compiler("nil subclass: #Object");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void ShouldCompileSubClassDefinitionWithInstances()
        {
            Compiler compiler = new Compiler("nil subclass: #Object instanceVariables: 'a b c'");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void ShouldCompileTwoCommands()
        {
            Compiler compiler = new Compiler("nil invokeWith: 10. Global := 20");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void ShouldCompileBlock()
        {
            Compiler compiler = new Compiler("nil ifFalse: [self halt]");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(2, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));
        }

        [TestMethod]
        public void ShouldExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

            Compiler compiler = new Compiler("nil ifFalse: [GlobalName := 'foo']");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNotNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ShouldExecuteInstSize()
        {
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

            Compiler compiler = new Compiler("^nil new instSize");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ShouldExecuteInstSizeInRectangle()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "x ^x",
                    "x: newX x := newX",
                    "y ^y",
                    "y: newY y := newY"
                });

            machine.SetGlobalObject("aRectangle", cls.NewObject());

            Compiler compiler = new Compiler("^aRectangle instSize");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ShouldExecuteInstAt()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "x ^x",
                    "x: newX x := newX",
                    "y ^y",
                    "y: newY y := newY"
                });

            IObject iobj = cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            iobj[0] = 100;

            Compiler compiler = new Compiler("^aRectangle instAt: 0");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ShouldExecuteInstAtPut()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "x ^x",
                    "x: newX x := newX",
                    "y ^y",
                    "y: newY y := newY"
                });

            IObject iobj = cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            Compiler compiler = new Compiler("aRectangle instAt: 0 put: 200");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.AreEqual(200, iobj[0]);
            Assert.IsNull(iobj[1]);
        }

        [TestMethod]
        public void ShouldExecuteBasicNew()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            machine.SetGlobalObject("Rectangle", cls);

            Compiler compiler = new Compiler("^Rectangle basicNew");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object obj = block.Execute(machine, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)obj).Behavior);
        }

        [TestMethod]
        public void ShouldCompileMethods()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
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

        [TestMethod]
        public void ShouldRunMethods()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
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

            Assert.AreEqual(10, cls.GetInstanceMethod("x").Execute(obj, new object[] { }));
            Assert.AreEqual(20, cls.GetInstanceMethod("y").Execute(obj, new object[] { }));
        }

        [TestMethod]
        public void ShouldCompileMultiCommandMethod()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide x := newSide. y := newSide"
                });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void ShouldCompileMultiCommandMethodWithLocal()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide | temp | temp := x. x := temp. y := temp"
                });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void ShouldRunMultiCommandMethod()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide x := newSide. y := newSide"
                });

            Assert.IsNotNull(cls);

            IObject obj = cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }

        [TestMethod]
        public void ShouldRunMultiCommandMethodWithLocal()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide | temp | temp := newSide. x := temp. y := temp"
                });

            Assert.IsNotNull(cls);

            IObject obj = cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }
    }
}

