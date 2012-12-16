namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;
    using AjTalk.Language;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void BeCreated()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            IBlock block = new Block();

            Assert.IsNotNull(block);
        }

        [TestMethod]
        public void Compile()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            cls.DefineClassVariable("count");

            Block block;

            block = new Method(cls, "x:");
            block.CompileArgument("newX");
            block.CompileGet("newX");
            block.CompileGet("count");
            block.CompileSet("x");

            Assert.AreEqual(1, block.Arity);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.IsTrue(block.ByteCodes.Length > 0);

            BlockDecompiler decompiler = new BlockDecompiler(block);
            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);

            Assert.AreEqual("GetArgument newX", result[0]);
            Assert.AreEqual("GetGlobalVariable count", result[1]);
            Assert.AreEqual("SetInstanceVariable x", result[2]);
        }

        [TestMethod]
        public void CompileGlobal()
        {
            Block block;

            block = new Block();
            block.CompileGetConstant(10);
            block.CompileSet("Global");

            Assert.AreEqual("Global", block.GetGlobalName(0));
        }

        [TestMethod]
        public void CompileAndExecuteGetDotNetType()
        {
            Block block;

            block = new Block();
            block.CompileGetDotNetType("System.IO.FileInfo");
            block.CompileByteCode(ByteCode.ReturnPop);

            object obj = block.Execute(null, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.Type));
        }

        [TestMethod]
        public void ExecuteEmptyBlock()
        {
            Block block;

            block = new Block();

            object obj = block.Execute((Machine)null, null);

            Assert.IsNull(obj);
        }

        [TestMethod]
        public void CompileAndExecuteNewDotNetObject()
        {
            Block block;

            block = new Block();
            block.CompileGetDotNetType("System.IO.FileInfo");
            block.CompileGetConstant("FooBar.txt");
            block.CompileSend("!new:");
            block.CompileByteCode(ByteCode.ReturnPop);

            object obj = block.Execute(null, null);

            Assert.IsNotNull(obj);
            Assert.IsInstanceOfType(obj, typeof(System.IO.FileInfo));
        }

        [TestMethod]
        public void CompileAndRunWithGlobal()
        {
            Block block;

            block = new Block();
            block.CompileGetConstant(10);
            block.CompileSet("Global");

            Machine machine = new Machine();

            block.Execute(machine, null);

            Assert.AreEqual(10, machine.GetGlobalObject("Global"));
        }

        [TestMethod]
        public void CompileWithLocals()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Block block;

            block = new Block();
            block.CompileArgument("newX");
            block.CompileLocal("l");
            block.CompileGet("newX");
            block.CompileSet("l");

            Assert.AreEqual(1, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.IsTrue(block.ByteCodes.Length > 0);
        }

        [TestMethod]
        public void CompileAndRun()
        {
            Machine machine = new Machine();

            Block block;

            block = new Block();
            block.CompileArgument("newX");
            block.CompileGet("newX");
            block.CompileSet("GlobalX");

            block.Execute(machine, new object[] { 10 });

            Assert.AreEqual(10, machine.GetGlobalObject("GlobalX"));
        }

        [TestMethod]
        public void CompileWithLocalsAndRun()
        {
            Machine machine = new Machine();

            Block block;

            block = new Block();
            block.CompileArgument("newX");
            block.CompileLocal("l");
            block.CompileGet("newX");
            block.CompileSet("l");
            block.CompileGet("l");
            block.CompileSet("GlobalX");

            block.Execute(machine, new object[] { 10 });

            Assert.AreEqual(10, machine.GetGlobalObject("GlobalX"));
        }

        [TestMethod]
        public void CompileGlobalName()
        {
            Block block = new Block();
            byte p = block.CompileGlobal("Class");

            Assert.AreEqual(0, p);
        }

        [TestMethod]
        public void CompileGlobalNames()
        {
            Block block = new Block();
            byte p1 = block.CompileGlobal("Class");
            byte p2 = block.CompileGlobal("Object");
            byte p3 = block.CompileGlobal("Class");

            Assert.AreEqual(0, p1);
            Assert.AreEqual(1, p2);
            Assert.AreEqual(0, p3);
        }

        [TestMethod]
        public void CompileGetGlobalVariable()
        {
            Block block = new Block();
            block.CompileGet("Class");
            block.CompileGet("Object");

            byte p1 = block.CompileGlobal("Object");
            byte p2 = block.CompileGlobal("Class");

            Assert.AreEqual(1, p1);
            Assert.AreEqual(0, p2);
        }

        [TestMethod]
        public void CalculateArity()
        {
            Assert.AreEqual(0, Block.MessageArity("class"));
            Assert.AreEqual(1, Block.MessageArity("with:"));
            Assert.AreEqual(2, Block.MessageArity("with:with:"));
        }

        [TestMethod]
        public void GetInstanceVariableOffset()
        {
            Block block = new Block();
            Assert.AreEqual(-1, block.GetInstanceVariableOffset("x"));
        }

        [TestMethod]
        public void GetInstanceVariableOffsetWithOuter()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");
            Method method = new Method(cls, "mymethod");

            Block block = new Block("x", method);
            Assert.AreEqual(0, block.GetInstanceVariableOffset("x"));
        }
    }
}

