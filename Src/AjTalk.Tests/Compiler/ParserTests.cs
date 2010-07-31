namespace AjTalk.Tests.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Compiler;
    using AjTalk.Language;

    using AjTalk.Tests.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParserTests
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
                    Parser compiler = new Parser(method);
                    compiler.CompileInstanceMethod(cls);
                }
            }

            return cls;
        }

        [TestMethod]
        public void Create()
        {
            Parser compiler = new Parser("x ^x");

            Assert.IsNotNull(compiler);
        }

        [TestMethod]
        public void CompileMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Parser compiler = new Parser("x ^x");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
        }

        [TestMethod]
        public void CompileMethodWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Parser compiler = new Parser("x | temp | temp := x. ^temp");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x"));
        }

        [TestMethod]
        public void CompileSetMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Parser compiler = new Parser("x: newX x := newX");
            compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("x:"));
        }

        [TestMethod]
        public void CompileSimpleCommand()
        {
            Parser compiler = new Parser("nil invokeWith: 10");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinition()
        {
            Parser compiler = new Parser("nil subclass: #Object");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinitionWithInstances()
        {
            Parser compiler = new Parser("nil subclass: #Object instanceVariables: 'a b c'");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommands()
        {
            Parser compiler = new Parser("nil invokeWith: 10. Global := 20");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileBlock()
        {
            Parser compiler = new Parser("nil ifFalse: [self halt]");
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
        public void CompileBlockWithParameter()
        {
            Parser compiler = new Parser(" :a | a doSomething");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(1, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(String));
            Assert.AreEqual("doSomething", constant);
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

            Parser compiler = new Parser("nil ifFalse: [GlobalName := 'foo']");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNotNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteInstSize()
        {
            Machine machine = new Machine();

            object nil = machine.GetGlobalObject("nil");

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ((IClass)nil).DefineInstanceMethod(new DoesNotUnderstandMethod(machine));

            Parser compiler = new Parser("^nil new instSize");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExecuteInstSizeInRectangle()
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

            Parser compiler = new Parser("^aRectangle instSize");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ExecuteInstAt()
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

            IObject iobj = (IObject) cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            iobj[0] = 100;

            Parser compiler = new Parser("^aRectangle instAt: 0");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ExecuteInstAtPut()
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

            IObject iobj = (IObject) cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            Parser compiler = new Parser("aRectangle instAt: 0 put: 200");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.AreEqual(200, iobj[0]);
            Assert.IsNull(iobj[1]);
        }

        [TestMethod]
        public void ExecuteBasicNew()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            machine.SetGlobalObject("Rectangle", cls);

            Parser compiler = new Parser("^Rectangle basicNew");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object obj = block.Execute(machine, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)obj).Behavior);
        }

        [TestMethod]
        public void CompileMethods()
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
        public void RunMethods()
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

            IObject obj = (IObject) cls.NewObject();

            cls.GetInstanceMethod("x:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);

            cls.GetInstanceMethod("y:").Execute(obj, new object[] { 20 });

            Assert.AreEqual(20, obj[1]);

            Assert.AreEqual(10, cls.GetInstanceMethod("x").Execute(obj, new object[] { }));
            Assert.AreEqual(20, cls.GetInstanceMethod("y").Execute(obj, new object[] { }));
        }

        [TestMethod]
        public void CompileMultiCommandMethod()
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
        public void CompileMultiCommandMethodWithLocal()
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
        public void RunMultiCommandMethod()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide x := newSide. y := newSide"
                });

            Assert.IsNotNull(cls);

            IObject obj = (IObject) cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }

        [TestMethod]
        public void RunMultiCommandMethodWithLocal()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] 
                {
                    "side: newSide | temp | temp := newSide. x := temp. y := temp"
                });

            Assert.IsNotNull(cls);

            IObject obj = (IObject) cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }
    }
}

