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
            var method = compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Name);
            Assert.IsNotNull(method.ByteCodes);
        }

        [TestMethod]
        public void CompileMethodWithHorizontalBarAsName()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            Parser compiler = new Parser("| aBoolean ^aBoolean");
            var method = compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(method);
            Assert.AreEqual("|", method.Name);
            Assert.IsNotNull(method.ByteCodes);
        }

        [TestMethod]
        public void CompileMethodWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Parser compiler = new Parser("x | temp | temp := x. ^temp");
            var method = compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(method);
            Assert.AreEqual("x", method.Name);
            Assert.IsNotNull(method.ByteCodes);
        }

        [TestMethod]
        public void CompileSetMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            Parser compiler = new Parser("x: newX x := newX");
            var method = compiler.CompileInstanceMethod(cls);

            Assert.IsNotNull(method);
            Assert.AreEqual("x:", method.Name);
            Assert.IsNotNull(method.ByteCodes);
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
        public void CompileSimpleSendToSelf()
        {
            Parser compiler = new Parser("self invokeWith: 10");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(ByteCode.GetSelf, (ByteCode)block.ByteCodes[0]);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileInteger()
        {
            Parser compiler = new Parser("1");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
        }

        [TestMethod]
        public void CompileIntegerWithRadix()
        {
            Parser compiler = new Parser("16rFF");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetConstant 255", result[0]);
        }

        [TestMethod]
        public void CompileCharacter()
        {
            Parser compiler = new Parser("$+");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetConstant +", result[0]);
        }

        [TestMethod]
        public void CompileNegativeInteger()
        {
            Parser compiler = new Parser("-1");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("Send minus 0", result[1]);
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
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("GetConstant 2", result[1]);
            Assert.AreEqual("Send + 1", result[2]);
        }

        [TestMethod]
        public void CompileSimpleAt()
        {
            Parser compiler = new Parser("1 @ 2");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("GetConstant 2", result[1]);
            Assert.AreEqual("Send @ 1", result[2]);
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
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
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
            Assert.AreEqual(1, block.Arity);
            Assert.AreEqual("a", block.GetArgumentName(0));
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(1, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(string));
            Assert.AreEqual("doSomething", constant);
        }

        [TestMethod]
        public void CompileBlockWithParameterWithASpace()
        {
            Parser compiler = new Parser(" : a | a doSomething");
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
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(2, block.Arity);
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            Parser compiler = new Parser("nil ifNil: [GlobalName := 'foo']");
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

            Parser compiler = new Parser("^UndefinedObject new instSize");
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

            cls.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(machine, cls));

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

            cls.GetInstanceMethod("x:").Execute(null, obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);

            cls.GetInstanceMethod("y:").Execute(null, obj, new object[] { 20 });

            Assert.AreEqual(20, obj[1]);

            Assert.AreEqual(10, cls.GetInstanceMethod("x").Execute(null, obj, new object[] { }));
            Assert.AreEqual(20, cls.GetInstanceMethod("y").Execute(null, obj, new object[] { }));
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
            Machine machine = new Machine();

            IClass cls = CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector | sum | sum := 0. aVector do: [ :x | sum := sum + x ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(6, method.Execute(machine, obj, new object[] { new int[] { 1, 2, 3 } }));
        }

        [TestMethod]
        public void CompileAndEvaluateInnerBlockWithClosureUsingExternalArgument()
        {
            Machine machine = new Machine();

            IClass cls = CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector with: aNumber | sum | sum := 0. aVector do: [ :x | sum := sum + x + aNumber ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:with:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(9, method.Execute(machine, obj, new object[] { new int[] { 1, 2, 3 }, 1 }));
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

            cls.GetInstanceMethod("side:").Execute(null, obj, new object[] { 10 });

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

            cls.GetInstanceMethod("side:").Execute(null, obj, new object[] { 10 });

            Assert.AreEqual(10, obj[0]);
            Assert.AreEqual(10, obj[1]);
        }

        [TestMethod]
        public void CompileSimpleSetExpression()
        {
            Parser parser = new Parser("a := 1");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            Assert.AreEqual(ByteCode.SetGlobalVariable, (ByteCode)result.ByteCodes[2]);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual("SetGlobalVariable a", ops[1]);
        }

        [TestMethod]
        public void CompileBlockWithLocalVariable()
        {
            Parser parser = new Parser("|a| a := 1");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual("SetLocal a", ops[1]);
        }

        [TestMethod]
        public void CompileBlockInBrackets()
        {
            Parser parser = new Parser("[a := 1]");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual("GetBlock { GetConstant 1; SetGlobalVariable a }", ops[0]);
        }

        [TestMethod]
        public void CompileIntegerArray()
        {
            Parser parser = new Parser("#(1 2 3)");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.IsTrue(ops[0].StartsWith("GetConstant "));
        }

        [TestMethod]
        public void CompileSymbolArray()
        {
            Parser parser = new Parser("#(a b c)");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.IsTrue(ops[0].StartsWith("GetConstant "));
        }

        [TestMethod]
        public void CompileDynamicArray()
        {
            Parser parser = new Parser("{a. b. 3}");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(4, ops.Count);
            Assert.AreEqual("GetGlobalVariable a", ops[0]);
            Assert.AreEqual("GetGlobalVariable b", ops[1]);
            Assert.AreEqual("GetConstant 3", ops[2]);
            Assert.AreEqual("MakeCollection 3", ops[3]);
        }

        [TestMethod]
        public void CompileDynamicArrayWithChainedExpression()
        {
            Parser parser = new Parser("{a do: 1; do: 2; yourself. b. 3}");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(11, ops.Count);
            Assert.AreEqual("GetGlobalVariable a", ops[0]);
            Assert.AreEqual("GetConstant 1", ops[1]);
            Assert.AreEqual("Send do: 1", ops[2]);
            Assert.AreEqual("ChainedSend", ops[3]);
            Assert.AreEqual("GetConstant 2", ops[4]);
            Assert.AreEqual("Send do: 1", ops[5]);
            Assert.AreEqual("ChainedSend", ops[6]);
            Assert.AreEqual("Send yourself 0", ops[7]);
            Assert.AreEqual("GetGlobalVariable b", ops[8]);
            Assert.AreEqual("GetConstant 3", ops[9]);
            Assert.AreEqual("MakeCollection 3", ops[10]);
        }

        [TestMethod]
        public void CompileSumWithNegativeNumber()
        {
            Parser parser = new Parser("-1 + 0");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(4, ops.Count);
            Assert.AreEqual("GetConstant 1", ops[0]);
            Assert.AreEqual("Send minus 0", ops[1]);
            Assert.AreEqual("GetConstant 0", ops[2]);
            Assert.AreEqual("Send + 1", ops[3]);
        }

        [TestMethod]
        public void CompileSimpleOr()
        {
            Parser parser = new Parser("1 | 0");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(3, ops.Count);
            Assert.AreEqual("GetConstant 1", ops[0]);
            Assert.AreEqual("GetConstant 0", ops[1]);
            Assert.AreEqual("Send | 1", ops[2]);
        }

        [TestMethod]
        public void CompileSimpleEqual()
        {
            Parser parser = new Parser("1 = 2");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(3, ops.Count);
            Assert.AreEqual("GetConstant 1", ops[0]);
            Assert.AreEqual("GetConstant 2", ops[1]);
            Assert.AreEqual("Send = 1", ops[2]);
        }

        [TestMethod]
        public void CompileSimpleAssingWithEqual()
        {
            Parser parser = new Parser("result := value = value");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(4, ops.Count);
            Assert.AreEqual("GetGlobalVariable value", ops[0]);
            Assert.AreEqual("GetGlobalVariable value", ops[1]);
            Assert.AreEqual("Send = 1", ops[2]);
            Assert.AreEqual("SetGlobalVariable result", ops[3]);
        }

        [TestMethod]
        public void CompileNumericPrimitive()
        {
            Parser parser = new Parser("<primitive: 60>");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("Primitive 60", ops[0]);
        }

        [TestMethod]
        public void CompileNumericPrimitiveWithError()
        {
            Parser parser = new Parser("<primitive: 60 error:ec>");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("PrimitiveError 60 ec", ops[0]);
        }

        [TestMethod]
        public void CompileNamedPrimitive()
        {
            Parser parser = new Parser("<primitive: '' module:''>");
            var result = parser.CompileBlock();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("NamedPrimitive \"\" \"\"", ops[0]);
        }

        [TestMethod]
        public void CompileSimpleExpressionInParenthesis()
        {
            Parser compiler = new Parser("(1+2)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("GetConstant 2", result[1]);
            Assert.AreEqual("Send + 1", result[2]);
        }

        [TestMethod]
        public void CompileSimpleExpressionInParenthesisUsingYourself()
        {
            Parser compiler = new Parser("(1+2;yourself)");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(4, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("GetConstant 2", result[1]);
            Assert.AreEqual("Send + 1", result[2]);
            Assert.AreEqual("ChainedSend", result[3]);
            Assert.AreEqual("Send yourself 0", result[4]);
        }

        [TestMethod]
        public void CompileGetLocalInBlock()
        {
            Parser compiler = new Parser("| env | [env at: #MyGlobal] value");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.IsTrue(block.NoConstants > 0);
            var result = block.GetConstant(0);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Block));
            var decompiler = new BlockDecompiler((Block)result);
            var steps = decompiler.Decompile();
            Assert.IsTrue(steps.Contains("GetLocal env"));
        }

        [TestMethod]
        public void CompileDottedName()
        {
            Parser compiler = new Parser("Smalltalk.MyPackage.MyClass");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
            Assert.IsTrue(block.NoConstants > 0);
            var decompiler = new BlockDecompiler(block);
            var steps = decompiler.Decompile();
            Assert.IsNotNull(steps);
            Assert.AreEqual(5, steps.Count);
            Assert.AreEqual("GetGlobalVariable Smalltalk", steps[0]);
            Assert.AreEqual("GetConstant \"MyPackage\"", steps[1]);
            Assert.AreEqual("Send at: 1", steps[2]);
            Assert.AreEqual("GetConstant \"MyClass\"", steps[3]);
            Assert.AreEqual("Send at: 1", steps[4]);
        }

        [TestMethod]
        public void CompileBlockWithDot()
        {
            Parser compiler = new Parser("[. 1. 2]");
            Block block = compiler.CompileBlock();
            Assert.IsNotNull(block);
        }

        [TestMethod]
        public void CompileSuperNew()
        {
            Parser compiler = new Parser("new super new");
            Block block = compiler.CompileInstanceMethod(null);
            Assert.IsNotNull(block);
            var decompiler = new BlockDecompiler(block);
            var steps = decompiler.Decompile();
            Assert.IsNotNull(steps);
            Assert.AreEqual(2, steps.Count);
            Assert.AreEqual("GetSuper", steps[0]);
            Assert.AreEqual("Send new 0", steps[1]);
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
                    cls.DefineInstanceMethod(compiler.CompileInstanceMethod(cls));
                }
            }

            if (clsmethods != null)
            {
                foreach (string method in clsmethods)
                {
                    Parser compiler = new Parser(method);
                    cls.DefineClassMethod(compiler.CompileClassMethod(cls));
                }
            }

            return cls;
        }
    }
}

