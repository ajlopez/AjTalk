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
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleSum()
        {
            Parser compiler = new Parser("1 + 2");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleRealSum()
        {
            Parser compiler = new Parser("1.2 + 3.4");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleArithmeticWithParenthesis()
        {
            Parser compiler = new Parser("1 * (2 + 3)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(5, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(21, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoSimpleCommand()
        {
            Parser compiler = new Parser("a := 1. b := 2");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(2, block.NoGlobalNames);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesis()
        {
            Parser compiler = new Parser("a := b with: (anObject class)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBang()
        {
            Parser compiler = new Parser("a := b with: (anObject !nativeMethod)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(21, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBangKeyword()
        {
            Parser compiler = new Parser("a := b with: (anObject !nativeMethod: 1)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(21, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileAndExecuteTwoSimpleCommand()
        {
            Parser compiler = new Parser("a := 1. b := 2");
            Block block = compiler.CompileBlock();
            Machine machine = new Machine();
            block.Execute(machine, null);
            Assert.AreEqual(1, machine.GetGlobalObject("a"));
            Assert.AreEqual(2, machine.GetGlobalObject("b"));
        }

        [TestMethod]
        public void CompileGlobalVariable()
        {
            Parser compiler = new Parser("AClass");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinition()
        {
            Parser compiler = new Parser("nil subclass: #Object");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinitionWithInstances()
        {
            Parser compiler = new Parser("nil subclass: #Object instanceVariables: 'a b c'");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommands()
        {
            Parser compiler = new Parser("nil invokeWith: 10. Global := 20");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(1, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommandsUsingSemicolon()
        {
            Parser compiler = new Parser("nil invokeWith: 10; invokeWith: 20");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(21, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileBlockWithSourceCode()
        {
            string source = "nil invokeWith: 10; invokeWith: 20";
            Parser compiler = new Parser(source);
            Block block = compiler.CompileBlock();
            Assert.AreEqual(source, block.SourceCode);
        }

        [TestMethod]
        public void CompileBlock()
        {
            Parser compiler = new Parser("nil ifFalse: [self halt]");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(2, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.Arity);
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(11, newblock.ByteCodes.Length);
        }

        [TestMethod]
        public void CompileBlockWithParameter()
        {
            Parser compiler = new Parser(" :a | a doSomething");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(1, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(string));
            Assert.AreEqual("doSomething", constant);
        }

        [TestMethod]
        public void CompileBlockWithTwoParameters()
        {
            Parser compiler = new Parser(" :a :b | a+b");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(2, block.Arity);
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            Parser compiler = new Parser("nil ifFalse: [GlobalName := 'foo']");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNotNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfFalse()
        {
            Machine machine = new Machine();

            Parser compiler = new Parser("true ifFalse: [GlobalName := 'foo']");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfTrueIfFalse()
        {
            Machine machine = new Machine();

            Parser compiler = new Parser("true ifTrue: [GlobalName := 'bar'] ifFalse: [GlobalName := 'foo']");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.AreEqual("bar", machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteInstSize()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

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
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

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
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

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
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            Parser compiler = new Parser("aRectangle instAt: 0 put: 200");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.AreEqual(200, iobj[0]);
            Assert.IsNull(iobj[1]);
        }

        [TestMethod]
        public void ExecuteNew()
        {
            Machine machine = new Machine();

            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            cls.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(machine));

            machine.SetGlobalObject("Rectangle", cls);

            Parser compiler = new Parser("^Rectangle new");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object obj = block.Execute(machine, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)obj).Behavior);
        }

        [TestMethod]
        public void ExecuteRedefinedNew()
        {
            Machine machine = new Machine();

            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "initialize x := 10. y := 20" },
                new string[] { "new ^self basicNew initialize" });

            machine.SetGlobalObject("Rectangle", cls);

            Parser compiler = new Parser("^Rectangle new");
            Block block = compiler.CompileBlock();

            Assert.IsNotNull(block);

            object obj = block.Execute(machine, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)obj).Behavior);

            IObject iobj = (IObject)obj;

            Assert.AreEqual(2, iobj.Behavior.NoInstanceVariables);
            Assert.AreEqual(10, iobj[0]);
            Assert.AreEqual(20, iobj[1]);
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
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

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
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            Assert.IsNotNull(cls);

            IObject obj = (IObject)cls.NewObject();

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
                new string[] { "side: newSide x := newSide. y := newSide" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void CompileMultiCommandMethodWithLocal()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "side: newSide | temp | temp := x. x := temp. y := temp" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void CompileSameOperator()
        {
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "== aRect ^x == aRect x ifTrue: [^y == aRect y] ifFalse: [^false]" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("=="));
        }

        [TestMethod]
        public void CompileAndEvaluateInnerBlockWithClosure()
        {
            IClass cls = CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector | sum | sum := 0. aVector do: [ :x | sum := sum + x ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(6, method.Execute(obj, new object[] { new int[] { 1, 2, 3 } }));
        }

        [TestMethod]
        public void CompileAndEvaluateInnerBlockWithClosureUsingExternalArgument()
        {
            IClass cls = CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector with: aNumber | sum | sum := 0. aVector do: [ :x | sum := sum + x + aNumber ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:with:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(9, method.Execute(obj, new object[] { new int[] { 1, 2, 3 }, 1 }));
        }

        [TestMethod]
        public void RunMultiCommandMethod()
        {
            IClass cls = CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "side: newSide x := newSide. y := newSide" });

            Assert.IsNotNull(cls);

            IObject obj = (IObject)cls.NewObject();

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
                new string[] { "side: newSide | temp | temp := newSide. x := temp. y := temp" });

            Assert.IsNotNull(cls);

            IObject obj = (IObject)cls.NewObject();

            cls.GetInstanceMethod("side:").Execute(obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }

        internal static IClass CompileClass(string clsname, string[] varnames, string[] methods)
        {
            return CompileClass(clsname, varnames, methods, null);
        }

        internal static IClass CompileClass(string clsname, string[] varnames, string[] methods, string[] clsmethods)
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

            if (clsmethods != null)
            {
                foreach (string method in clsmethods)
                {
                    Parser compiler = new Parser(method);
                    compiler.CompileClassMethod(cls);
                }
            }

            return cls;
        }
    }
}

