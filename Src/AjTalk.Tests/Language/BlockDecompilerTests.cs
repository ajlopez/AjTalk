﻿namespace AjTalk.Tests.Language
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AjTalk.Language;

    [TestClass]
    public class BlockDecompilerTests
    {
        [TestMethod]
        public void DecompileGetIntegerConstant()
        {
            Block block = new Block();
            block.CompileGetConstant(1);
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
        }

        [TestMethod]
        public void DecompileGetStringConstant()
        {
            Block block = new Block();
            block.CompileGetConstant("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetConstant \"foo\"", result[0]);
        }

        [TestMethod]
        public void DecompileGetConstants()
        {
            Block block = new Block();
            block.CompileGetConstant(1);
            block.CompileGetConstant("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("GetConstant 1", result[0]);
            Assert.AreEqual("GetConstant \"foo\"", result[1]);
        }

        [TestMethod]
        public void DecompileGetLocalVariable()
        {
            Block block = new Block();
            block.CompileLocal("foo");
            block.CompileGet("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetLocal foo", result[0]);
        }

        [TestMethod]
        public void DecompileSetLocalVariable()
        {
            Block block = new Block();
            block.CompileLocal("foo");
            block.CompileSet("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("SetLocal foo", result[0]);
        }

        [TestMethod]
        public void DecompileGetArgument()
        {
            Block block = new Block();
            block.CompileArgument("foo");
            block.CompileGet("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetArgument foo", result[0]);
        }

        [TestMethod]
        public void DecompileGetGlobalVariable()
        {
            Block block = new Block();
            block.CompileGet("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("GetGlobalVariable foo", result[0]);
        }

        [TestMethod]
        public void DecompileSetGlobalVariable()
        {
            Block block = new Block();
            block.CompileSet("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("SetGlobalVariable foo", result[0]);
        }

        [TestMethod]
        public void DecompileSendUnary()
        {
            Block block = new Block();
            block.CompileSend("foo");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Send foo 0", result[0]);
        }

        [TestMethod]
        public void DecompileSendBinaryOperator()
        {
            Block block = new Block();
            block.CompileSend("+");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Send + 1", result[0]);
        }

        [TestMethod]
        public void DecompileSendKeywordWithOneArgument()
        {
            Block block = new Block();
            block.CompileSend("foo:");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Send foo: 1", result[0]);
        }

        [TestMethod]
        public void DecompileSendKeywordWithTwoArgument()
        {
            Block block = new Block();
            block.CompileSend("foo:with:");
            BlockDecompiler decompiler = new BlockDecompiler(block);

            var result = decompiler.Decompile();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Send foo:with: 2", result[0]);
        }
    }
}