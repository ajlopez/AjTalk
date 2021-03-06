﻿namespace AjTalk.Tests.Compilers.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compilers.Vm;
    using AjTalk.Language;
    using AjTalk.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BytecodeCompilerTests
    {
        private Block block;
        private BytecodeCompiler compiler;

        [TestInitialize]
        public void Setup()
        {
            this.block = new Block();
            this.compiler = new BytecodeCompiler(this.block);
        }

        [TestMethod]
        public void CompileSimpleCommand()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(6, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleSum()
        {
            ModelParser parser = new ModelParser("1 + 2");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(7, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
            BlockDecompiler decompiler = new BlockDecompiler(this.block);
            var program = decompiler.Decompile();
            Assert.IsNotNull(program);
            Assert.AreEqual(3, program.Count);
            Assert.AreEqual("GetConstant 1", program[0]);
            Assert.AreEqual("GetConstant 2", program[1]);
            Assert.AreEqual("Send + 1", program[2]);
        }

        [TestMethod]
        public void CompileSimpleRealSum()
        {
            ModelParser parser = new ModelParser("1.2 + 3.4");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(7, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
            BlockDecompiler decompiler = new BlockDecompiler(this.block);
            var program = decompiler.Decompile();
            Assert.IsNotNull(program);
            Assert.AreEqual(3, program.Count);
            Assert.AreEqual("GetConstant 1.2", program[0]);
            Assert.AreEqual("GetConstant 3.4", program[1]);
            Assert.AreEqual("Send + 1", program[2]);
        }

        [TestMethod]
        public void CompileSimpleArithmeticWithParenthesis()
        {
            ModelParser parser = new ModelParser("1 * (2 + 3)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(5, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(12, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
            BlockDecompiler decompiler = new BlockDecompiler(this.block);
            var program = decompiler.Decompile();
            Assert.IsNotNull(program);
            Assert.AreEqual(5, program.Count);
            Assert.AreEqual("GetConstant 1", program[0]);
            Assert.AreEqual("GetConstant 2", program[1]);
            Assert.AreEqual("GetConstant 3", program[2]);
            Assert.AreEqual("Send + 1", program[3]);
            Assert.AreEqual("Send * 1", program[4]);
        }

        [TestMethod]
        public void CompileTwoSimpleCommand()
        {
            ModelParser parser = new ModelParser("a := 1. b := 2");
            this.compiler.CompileExpressions(parser.ParseExpressions());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(2, this.block.NoGlobalNames);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(8, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
            BlockDecompiler decompiler = new BlockDecompiler(this.block);
            var program = decompiler.Decompile();
            Assert.IsNotNull(program);
            Assert.AreEqual(4, program.Count);
            Assert.AreEqual("GetConstant 1", program[0]);
            Assert.AreEqual("SetGlobalVariable a", program[1]);
            Assert.AreEqual("GetConstant 2", program[2]);
            Assert.AreEqual("SetGlobalVariable b", program[3]);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesis()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject class)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(1, this.block.NoConstants);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(10, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBang()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject !nativeMethod)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(12, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSimpleCommandWithParenthesisAndBangKeyword()
        {
            ModelParser parser = new ModelParser("a := b with: (anObject !nativeMethod: 1)");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoGlobalNames);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(14, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileAndExecuteTwoSimpleCommand()
        {
            ModelParser parser = new ModelParser("a := 1. b := 2");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Machine machine = new Machine();
            this.block.Execute(machine, null);
            Assert.AreEqual(1, machine.GetGlobalObject("a"));
            Assert.AreEqual(2, machine.GetGlobalObject("b"));
        }

        [TestMethod]
        public void CompileGlobalVariable()
        {
            ModelParser parser = new ModelParser("AClass");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(1, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(2, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinition()
        {
            ModelParser parser = new ModelParser("nil subclass: #Object");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(2, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(6, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileSubClassDefinitionWithInstances()
        {
            ModelParser parser = new ModelParser("nil subclass: #Object instanceVariables: 'a b c'");
            IExpression expr = parser.ParseExpression();
            this.compiler.CompileExpression(expr);
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(8, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommands()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10. Global := 20");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(1, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(10, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileTwoCommandsUsingSemicolon()
        {
            ModelParser parser = new ModelParser("nil invokeWith: 10; invokeWith: 20");
            this.compiler.CompileExpressions(parser.ParseExpressions());
            Assert.IsNotNull(this.block);
            Assert.AreEqual(3, this.block.NoConstants);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(12, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);
        }

        [TestMethod]
        public void CompileBlock()
        {
            ModelParser parser = new ModelParser("nil ifFalse: [self halt]");
            this.compiler.CompileExpression(parser.ParseExpression());

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
            Assert.AreEqual(4, newblock.ByteCodes.Length);

            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual("GetNil", result[0]);
            Assert.AreEqual("JumpIfFalse 8", result[1]);
            Assert.AreEqual("GetNil", result[2]);
            Assert.AreEqual("Jump 11", result[3]);
            Assert.AreEqual("GetBlock { GetSelf; Send halt 0 }", result[4]);
        }

        [TestMethod]
        public void CompileBlockWithParameter()
        {
            ModelParser parser = new ModelParser("[ :a | a doSomething ]");
            this.compiler.CompileExpression(parser.ParseExpression());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(0, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(1, this.block.NoConstants);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(2, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);

            object constant = this.block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.NoGlobalNames);
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.AreEqual(1, newblock.NoConstants);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(5, newblock.ByteCodes.Length);
            Assert.AreEqual(1, newblock.Arity);
        }

        [TestMethod]
        public void CompileBlockWithTwoParameters()
        {
            ModelParser parser = new ModelParser("[:a :b | a+b]");
            this.compiler.CompileExpression(parser.ParseExpression());

            Assert.IsNotNull(this.block);
            Assert.AreEqual(0, this.block.NoGlobalNames);
            Assert.AreEqual(0, this.block.NoLocals);
            Assert.AreEqual(1, this.block.NoConstants);
            Assert.IsNotNull(this.block.ByteCodes);
            Assert.AreEqual(2, this.block.ByteCodes.Length);
            Assert.AreEqual(0, this.block.Arity);

            object constant = this.block.GetConstant(0);

            Assert.IsNotNull(constant);
            Assert.IsInstanceOfType(constant, typeof(Block));

            var newblock = (Block)constant;
            Assert.AreEqual(0, newblock.NoLocals);
            Assert.AreEqual(0, newblock.NoGlobalNames);
            Assert.AreEqual(1, newblock.NoConstants);
            Assert.IsNotNull(newblock.ByteCodes);
            Assert.AreEqual(7, newblock.ByteCodes.Length);
            Assert.AreEqual(2, newblock.Arity);
        }

        [TestMethod]
        public void CompileIntegerArray()
        {
            ModelParser parser = new ModelParser("#(1 2 3)");
            this.compiler.CompileExpression(parser.ParseExpression());
            Assert.IsNotNull(this.block.ByteCodes);
            BlockDecompiler decompiler = new BlockDecompiler(this.block);
            var ops = decompiler.Decompile();
            Assert.IsNotNull(ops);
            Assert.AreEqual(1, ops.Count);
            Assert.AreEqual("GetConstant System.Object[]", ops[0]);
        }

        [TestMethod]
        public void ExecuteBlock()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ModelParser parser = new ModelParser("nil ifNil: [GlobalName := 'foo']");
            this.compiler.CompileExpression(parser.ParseExpression());

            this.block.Execute(machine, null);

            Assert.IsNotNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfFalse()
        {
            Machine machine = new Machine();

            ModelParser parser = new ModelParser("true ifFalse: [GlobalName := 'foo']");
            this.compiler.CompileExpression(parser.ParseExpression());

            this.block.Execute(machine, null);

            Assert.IsNull(machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteTrueIfTrueIfFalse()
        {
            Machine machine = new Machine();

            ModelParser parser = new ModelParser("true ifTrue: [GlobalName := 'bar'] ifFalse: [GlobalName := 'foo']");
            this.compiler.CompileExpression(parser.ParseExpression());

            this.block.Execute(machine, null);

            Assert.AreEqual("bar", machine.GetGlobalObject("GlobalName"));
        }

        [TestMethod]
        public void ExecuteBasicInstSize()
        {
            Machine machine = new Machine();

            object nil = machine.UndefinedObjectClass;

            Assert.IsNotNull(nil);
            Assert.IsInstanceOfType(nil, typeof(IClass));

            ModelParser parser = new ModelParser("^UndefinedObject new basicInstSize");
            this.compiler.CompileExpression(parser.ParseExpression());

            object result = this.block.Execute(machine, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExecuteBasicInstSizeInRectangle()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            machine.SetGlobalObject("aRectangle", cls.NewObject());

            ModelParser parser = new ModelParser("^aRectangle basicInstSize");
            this.compiler.CompileExpression(parser.ParseExpression());

            object result = this.block.Execute(machine, null);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ExecuteBasicInstVarAt()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            iobj[0] = 100;

            ModelParser parser = new ModelParser("^aRectangle basicInstVarAt: 1");
            this.compiler.CompileExpression(parser.ParseExpression());

            object result = this.block.Execute(machine, null);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void ExecuteBasicInstVarAtPut()
        {
            Machine machine = new Machine();
            IClass cls = CompileClass(
                "Rectangle",
                new string[] { "x", "y" },
                new string[] { "x ^x", "x: newX x := newX", "y ^y", "y: newY y := newY" });

            IObject iobj = (IObject)cls.NewObject();

            machine.SetGlobalObject("aRectangle", iobj);

            ModelParser parser = new ModelParser("aRectangle basicInstVarAt: 1 put: 200");
            this.compiler.CompileExpression(parser.ParseExpression());

            this.block.Execute(machine, null);

            Assert.AreEqual(200, iobj[0]);
            Assert.IsNull(iobj[1]);
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut01.st")]
        public void CompileFileOut01()
        {
            CompileFile("FileOut01.st");
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\FileOut02.st")]
        public void CompileFileOut02()
        {
            CompileFile("FileOut02.st");
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakObject.st")]
        public void CompileSqueakObject()
        {
            CompileFile("SqueakObject.st");
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\SqueakKernelObjects.st")]
        public void CompileSqueakKernelObjects()
        {
            CompileFile("SqueakKernelObjects.st");
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        public void CompilePharoCoreKernelObjects()
        {
            CompileFile("PharoCoreKernelObjects.st");
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        [DeploymentItem(@"CodeFiles\PharoCorePoint.st")]
        public void CompilePharoCorePoint()
        {
            ChunkReader chunkCoreReader = new ChunkReader(@"PharoCoreKernelObjects.st");
            CodeReader coreReader = new CodeReader(chunkCoreReader);
            ChunkReader chunkReader = new ChunkReader(@"PharoCorePoint.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            coreReader.Process(model);
            reader.Process(model);

            foreach (var element in model.Elements)
            {
                Block block = new Block();
                BytecodeCompiler compiler = new BytecodeCompiler(block);
                element.Visit(compiler);
                if (element is MethodModel && ((MethodModel)element).Body == null)
                    continue;
                Assert.IsNotNull(block.ByteCodes);
            }
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\PharoCoreKernelObjects.st")]
        [DeploymentItem(@"CodeFiles\PharoCoreRectangle.st")]
        public void CompilePharoCoreRectangle()
        {
            ChunkReader chunkCoreReader = new ChunkReader(@"PharoCoreKernelObjects.st");
            CodeReader coreReader = new CodeReader(chunkCoreReader);
            ChunkReader chunkReader = new ChunkReader(@"PharoCoreRectangle.st");
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            coreReader.Process(model);
            reader.Process(model);

            foreach (var element in model.Elements)
            {
                Block block = new Block();
                BytecodeCompiler compiler = new BytecodeCompiler(block);
                element.Visit(compiler);

                if (element is MethodModel && ((MethodModel)element).Body == null)
                    continue;

                Assert.IsNotNull(block.ByteCodes);
            }
        }

        internal static void CompileFile(string filename)
        {
            ChunkReader chunkReader = new ChunkReader(filename);
            CodeReader reader = new CodeReader(chunkReader);
            CodeModel model = new CodeModel();

            reader.Process(model);

            foreach (var element in model.Elements)
            {
                Block block = new Block();
                BytecodeCompiler compiler = new BytecodeCompiler(block);
                element.Visit(compiler);
                if (element is MethodModel && ((MethodModel)element).Body == null)
                    continue;
                Assert.IsNotNull(block.ByteCodes);
            }
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
                    ModelParser parser = new ModelParser(method);
                    MethodModel model = parser.ParseMethod();
                    Method newmethod = new Method(cls, model.Selector, method);
                    BytecodeCompiler compiler = new BytecodeCompiler(newmethod);
                    compiler.CompileMethod(model);
                    cls.DefineInstanceMethod(newmethod);
                }
            }

            if (clsmethods != null)
            {
                foreach (string method in clsmethods)
                {
                    ModelParser parser = new ModelParser(method);
                    MethodModel model = parser.ParseMethod();
                    Method newmethod = new Method(cls, model.Selector, method);
                    BytecodeCompiler compiler = new BytecodeCompiler(newmethod);
                    compiler.CompileMethod(model);
                    cls.DefineClassMethod(newmethod);
                }
            }

            return cls;
        }
    }
}
