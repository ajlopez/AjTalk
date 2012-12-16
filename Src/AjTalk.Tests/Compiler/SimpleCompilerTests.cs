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
    public class SimpleCompilerTests
    {
        private SimpleCompiler compiler;

        [TestInitialize]
        public void Setup()
        {
            this.compiler = new SimpleCompiler();
        }

        [TestMethod]
        public void CompileInstanceMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            var method = this.compiler.CompileInstanceMethod("x ^x", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
            Assert.AreEqual("x ^x", method.SourceCode);
            var result = (new BlockDecompiler(method)).Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("GetInstanceVariable x", result[0]);
            Assert.AreEqual("ReturnPop", result[1]);
        }

        [TestMethod]
        public void CompileInstanceVariableInBlockInsideAMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            var method = this.compiler.CompileInstanceMethod("x ^[x] value", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
            Assert.AreEqual("x ^[x] value", method.SourceCode);
            Assert.IsTrue(method.NoConstants > 0);
            Assert.IsInstanceOfType(method.GetConstant(0), typeof(Block));
            var block = (Block)method.GetConstant(0);
            var result = (new BlockDecompiler(block)).Decompile();
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetInstanceVariable x", result[0]);
        }

        [TestMethod]
        public void CompileClassMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineClassVariable("x");
            var method = this.compiler.CompileClassMethod("x ^x", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
            Assert.AreEqual("x ^x", method.SourceCode);
        }

        [TestMethod]
        public void CompileMethodWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            var method = this.compiler.CompileInstanceMethod("x | temp | temp := x. ^temp", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
        }

        [TestMethod]
        public void CompileSetMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            var method = this.compiler.CompileInstanceMethod("x: newX x := newX", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
        }

        [TestMethod]
        public void CompileSimpleCommand()
        {
            Block block = this.compiler.CompileBlock("nil invokeWith: 10");
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(6, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleSendToSelf()
        {
            Block block = this.compiler.CompileBlock("self invokeWith: 10");
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(6, block.ByteCodes.Length);
            Assert.AreEqual(ByteCode.GetSelf, (ByteCode)block.ByteCodes[0]);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileInteger()
        {
            Block block = this.compiler.CompileBlock("1");
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
        public void CompileNegativeInteger()
        {
            Block block = this.compiler.CompileBlock("-1");
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
            Block block = this.compiler.CompileBlock("1 + 2");
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(7, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleRealSum()
        {
            Block block = this.compiler.CompileBlock("1.2 + 3.4");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(7, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleArithmeticWithParenthesis()
        {
            Block block = this.compiler.CompileBlock("1 * (2 + 3)");
            Assert.IsNotNull(block);
            Assert.AreEqual(5, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(12, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoSimpleCommand()
        {
            Block block = this.compiler.CompileBlock("a := 1. b := 2");
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(2, block.NoGlobalNames);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(8, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesis()
        {
            Block block = this.compiler.CompileBlock("a := b with: (anObject class)");
            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(10, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBang()
        {
            Block block = this.compiler.CompileBlock("a := b with: (anObject !nativeMethod)");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(12, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBangKeyword()
        {
            Block block = this.compiler.CompileBlock("a := b with: (anObject !nativeMethod: 1)");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoGlobalNames);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(14, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileAndExecuteTwoSimpleCommand()
        {
            Block block = this.compiler.CompileBlock("a := 1. b := 2");
            Machine machine = new Machine();
            block.Execute(machine, null);
            Assert.AreEqual(1, machine.GetGlobalObject("a"));
            Assert.AreEqual(2, machine.GetGlobalObject("b"));
        }

        [TestMethod]
        public void CompileGlobalVariable()
        {
            Block block = this.compiler.CompileBlock("AClass");
            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(2, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinition()
        {
            Block block = this.compiler.CompileBlock("nil subclass: #Object");
            Assert.IsNotNull(block);
            Assert.AreEqual(2, block.NoConstants);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(6, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinitionWithInstances()
        {
            Block block = this.compiler.CompileBlock("nil subclass: #Object instanceVariables: 'a b c'");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(8, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommands()
        {
            Block block = this.compiler.CompileBlock("nil invokeWith: 10. Global := 20");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(1, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(10, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommandsUsingSemicolon()
        {
            Block block = this.compiler.CompileBlock("nil invokeWith: 10; invokeWith: 20");
            Assert.IsNotNull(block);
            Assert.AreEqual(3, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(12, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileBlockWithSourceCode()
        {
            string source = "nil invokeWith: 10; invokeWith: 20";
            Block block = this.compiler.CompileBlock(source);
            Assert.AreEqual(source, block.SourceCode);
        }

        [TestMethod]
        public void CompileBlock()
        {
            Block block = this.compiler.CompileBlock("nil ifFalse: [self halt]");

            Assert.IsNotNull(block);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(4, block.ByteCodes.Length);
            Assert.AreEqual(0, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.Arity);
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(4, newblock.ByteCodes.Length);
        }

        [TestMethod]
        public void CompileBlockWithParameter()
        {
            Block block = this.compiler.CompileBlock(" :a | a doSomething");

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(5, block.ByteCodes.Length);
            Assert.AreEqual(1, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(string));
            Assert.AreEqual("doSomething", constant);
        }

        [TestMethod]
        public void CompileBlockWithParameterWithASpace()
        {
            Block block = this.compiler.CompileBlock(" : a | a doSomething");

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(1, block.NoConstants);
            Assert.AreEqual(1, block.Arity);
            Assert.AreEqual("a", block.GetArgumentName(0));
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(5, block.ByteCodes.Length);
            Assert.AreEqual(1, block.Arity);

            object constant = block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(string));
            Assert.AreEqual("doSomething", constant);
        }

        [TestMethod]
        public void CompileBlockWithTwoParameters()
        {
            Block block = this.compiler.CompileBlock(" :a :b | a+b");

            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.AreEqual(0, block.NoGlobalNames);
            Assert.AreEqual(1, block.NoConstants);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(7, block.ByteCodes.Length);
            Assert.AreEqual(2, block.Arity);
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            Block block = this.compiler.CompileBlock("nil ifNil: [GlobalName := 'foo']");

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNotNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfFalse()
        {
            Machine machine = new Machine();

            Block block = this.compiler.CompileBlock("true ifFalse: [GlobalName := 'foo']");

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.IsNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfTrueIfFalse()
        {
            Machine machine = new Machine();

            Block block = this.compiler.CompileBlock("true ifTrue: [GlobalName := 'bar'] ifFalse: [GlobalName := 'foo']");

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

            Block block = this.compiler.CompileBlock("^UndefinedObject new instSize");

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExecuteInstSizeInRectangle()
        {
            Machine machine = new Machine();
            IClass cls = this.CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            machine.SetGlobalObject("aRectangle", cls.NewObject());

            Block block = this.compiler.CompileBlock("^aRectangle instSize");

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ExecuteInstAt()
        {
            Machine machine = new Machine();
            IClass cls = this.CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            iobj[0] = 100;

            Block block = this.compiler.CompileBlock("^aRectangle instAt: 0");

            Assert.IsNotNull(block);

            object result = block.Execute(machine, null);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ExecuteInstAtPut()
        {
            Machine machine = new Machine();
            IClass cls = this.CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            Block block = this.compiler.CompileBlock("aRectangle instAt: 0 put: 200");

            Assert.IsNotNull(block);

            block.Execute(machine, null);

            Assert.AreEqual(200, iobj[0]);
            Assert.IsNull(iobj[1]);
        }

        [TestMethod]
        public void ExecuteNew()
        {
            Machine machine = new Machine();

            IClass cls = this.CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            cls.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(machine, cls));

            machine.SetGlobalObject("Rectangle", cls);

            Block block = this.compiler.CompileBlock("^Rectangle new");

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

            IClass cls = this.CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "initialize x := 10. y := 20" },
                new string[] { "new ^self basicNew initialize" });

            machine.SetGlobalObject("Rectangle", cls);

            Block block = this.compiler.CompileBlock("^Rectangle new");

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
            IClass cls = this.CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            machine.SetGlobalObject("Rectangle", cls);

            Block block = this.compiler.CompileBlock("^Rectangle basicNew");

            Assert.IsNotNull(block);

            object obj = block.Execute(machine, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(IObject));
            Assert.AreEqual(cls, ((IObject)obj).Behavior);
        }

        [TestMethod]
        public void CompileMethods()
        {
            IClass cls = this.CompileClass(
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
            IClass cls = this.CompileClass(
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
            IClass cls = this.CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "side: newSide x := newSide. y := newSide" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void CompileMultiCommandMethodWithLocal()
        {
            IClass cls = this.CompileClass(
                "Rectangle", 
                new string[] { "x", "y" },
                new string[] { "side: newSide | temp | temp := x. x := temp. y := temp" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("side:"));
        }

        [TestMethod]
        public void CompileSameOperator()
        {
            IClass cls = this.CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "== aRect ^x == aRect x ifTrue: [^y == aRect y] ifFalse: [^false]" });

            Assert.IsNotNull(cls);

            Assert.IsNotNull(cls.GetInstanceMethod("=="));
        }

        [TestMethod]
        public void CompileAndEvaluateInnerBlockWithClosure()
        {
            IClass cls = this.CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector | sum | sum := 0. aVector do: [ :x | sum := sum + x ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(6, method.Execute(cls.Machine, obj, new object[] { new int[] { 1, 2, 3 } }));
        }

        [TestMethod]
        public void CompileAndEvaluateInnerBlockWithClosureUsingExternalArgument()
        {
            IClass cls = this.CompileClass(
                "Adder",
                new string[] { },
                new string[] { "add: aVector with: aNumber | sum | sum := 0. aVector do: [ :x | sum := sum + x + aNumber ]. ^sum" });

            Assert.IsNotNull(cls);

            IMethod method = cls.GetInstanceMethod("add:with:");
            Assert.IsNotNull(method);
            IObject obj = (IObject)cls.NewObject();
            Assert.AreEqual(9, method.Execute(cls.Machine, obj, new object[] { new int[] { 1, 2, 3 }, 1 }));
        }

        [TestMethod]
        public void RunMultiCommandMethod()
        {
            IClass cls = this.CompileClass(
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
            IClass cls = this.CompileClass(
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
            var result = this.compiler.CompileBlock("a := 1");
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
            var result = this.compiler.CompileBlock("|a| a := 1");
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
            var result = this.compiler.CompileBlock("[a := 1]");
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
            var result = this.compiler.CompileBlock("#(1 2 3)");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("GetConstant System.Object[]", ops[0]);
        }

        [TestMethod]
        public void CompileDynamicArray()
        {
            var result = this.compiler.CompileBlock("{a. b. 3}");
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
        public void CompileSumWithNegativeNumber()
        {
            var result = this.compiler.CompileBlock("-1 + 0");
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
            var result = this.compiler.CompileBlock("1 | 0");
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
            var result = this.compiler.CompileBlock("1 = 2");
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
            var result = this.compiler.CompileBlock("result := value = value");
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
            var result = this.compiler.CompileBlock("<primitive: 60>");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(result);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("Primitive 60", ops[0]);
        }

        [TestMethod]
        public void CompileSimpleExpressionInParenthesis()
        {
            var block = this.compiler.CompileBlock("(1+2)");
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
            var block = this.compiler.CompileBlock("(1+2;yourself)");
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
            Block block = this.compiler.CompileBlock("| env | [env at: #MyGlobal] value");
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
            Block block = this.compiler.CompileBlock("Smalltalk.MyPackage.MyClass");
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
            Block block = this.compiler.CompileBlock("[. 1. 2]");
            Assert.IsNotNull(block);
        }

        [TestMethod]
        public void CompileSuperNew()
        {
            Block block = this.compiler.CompileInstanceMethod("new super new", null);
            Assert.IsNotNull(block);
            var decompiler = new BlockDecompiler(block);
            var steps = decompiler.Decompile();
            Assert.IsNotNull(steps);
            Assert.AreEqual(2, steps.Count);
            Assert.AreEqual("GetSuper", steps[0]);
            Assert.AreEqual("Send new 0", steps[1]);
        }

        [TestMethod]
        public void CompileWhileFalse()
        {
            Block block = this.compiler.CompileBlock(":arg | [arg < 3] whileFalse: [arg := arg + 1]");
            Assert.IsNotNull(block);
            Assert.AreEqual(13, block.Bytecodes.Length);
            var decompiler = new BlockDecompiler(block);
            var steps = decompiler.Decompile();
            Assert.IsNotNull(steps);
            Assert.AreEqual(7, steps.Count);
            Assert.AreEqual("GetBlock { GetArgument arg; GetConstant 3; Send < 1 }", steps[0]);
            Assert.AreEqual("Value", steps[1]);
            Assert.AreEqual("JumpIfTrue 13", steps[2]);
            Assert.AreEqual("GetBlock { GetArgument arg; GetConstant 1; Send + 1; SetArgument arg }", steps[3]);
            Assert.AreEqual("Value", steps[4]);
            Assert.AreEqual("Pop", steps[5]);
            Assert.AreEqual("Jump 0", steps[6]);
        }

        [TestMethod]
        public void CompileWhileTrue()
        {
            Block block = this.compiler.CompileBlock(":arg | [arg < 3] whileTrue: [arg := arg + 1]");
            Assert.IsNotNull(block);
            Assert.AreEqual(13, block.Bytecodes.Length);
            var decompiler = new BlockDecompiler(block);
            var steps = decompiler.Decompile();
            Assert.IsNotNull(steps);
            Assert.AreEqual(7, steps.Count);
            Assert.AreEqual("GetBlock { GetArgument arg; GetConstant 3; Send < 1 }", steps[0]);
            Assert.AreEqual("Value", steps[1]);
            Assert.AreEqual("JumpIfFalse 13", steps[2]);
            Assert.AreEqual("GetBlock { GetArgument arg; GetConstant 1; Send + 1; SetArgument arg }", steps[3]);
            Assert.AreEqual("Value", steps[4]);
            Assert.AreEqual("Pop", steps[5]);
            Assert.AreEqual("Jump 0", steps[6]);
        }

        internal IClass CompileClass(string clsname, string[] varnames, string[] methods)
        {
            return this.CompileClass(clsname, varnames, methods, null);
        }

        internal IClass CompileClass(string clsname, string[] varnames, string[] methods, string[] clsmethods)
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
                foreach (string method in methods)
                    cls.DefineInstanceMethod(this.compiler.CompileInstanceMethod(method, cls));

            if (clsmethods != null)
                foreach (string method in clsmethods)
                    cls.DefineClassMethod(this.compiler.CompileClassMethod(method, cls));

            return cls;
        }
    }
}

