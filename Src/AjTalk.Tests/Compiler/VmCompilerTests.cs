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
    public class VmCompilerTests
    {
        private VmCompiler compiler;

        [TestInitialize]
        public void Setup()
        {
            this.compiler = new VmCompiler();
        }

        [TestMethod]
        public void CompileMethod()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("Rectangle");
            cls.DefineInstanceVariable("x");
            var method = this.compiler.CompileInstanceMethod("x ^x", cls);
            Assert.IsNotNull(method);
            Assert.IsNotNull(method.ByteCodes);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
            Assert.AreEqual(ByteCode.GetSelf, (ByteCode)block.ByteCodes[0]);
            Assert.AreEqual(0, block.Arity);
        }

        [TestMethod]
        public void CompileSimpleSum()
        {
            Block block = this.compiler.CompileBlock("1 + 2");
            Assert.IsNotNull(block);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(21, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(21, block.ByteCodes.Length);
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
            Assert.AreEqual(21, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(11, block.ByteCodes.Length);
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
            Assert.AreEqual(21, block.ByteCodes.Length);
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
            Block block = this.compiler.CompileBlock(" :a | a doSomething");

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
            Block block = this.compiler.CompileBlock(" :a :b | a+b");

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

            Block block = this.compiler.CompileBlock("nil ifFalse: [GlobalName := 'foo']");

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

            Block block = this.compiler.CompileBlock("^nil new instSize");

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

            Block block = this.compiler.CompileBlock("^aRectangle instSize");

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

            Block block = this.compiler.CompileBlock("^aRectangle instAt: 0");

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

            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                null);

            cls.DefineClassMethod(new BehaviorDoesNotUnderstandMethod(machine));

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

            IClass cls = CompileClass(
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
            IClass cls = CompileClass(
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
            Assert.AreEqual(4, ops.Count);
            Assert.AreEqual("GetConstant 1", ops[0]);
            Assert.AreEqual("GetConstant 2", ops[1]);
            Assert.AreEqual("GetConstant 3", ops[2]);
            Assert.AreEqual("MakeCollection 3", ops[3]);
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

