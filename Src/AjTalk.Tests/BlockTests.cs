using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;

namespace AjTalk.Tests
{
    [TestFixture]
    public class BlockTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            IBlock block = new Block();

            Assert.IsNotNull(block);
        }

        [Test]
        public void ShouldCompile()
        {
            Machine machine = new Machine();
            IClass cls = machine.CreateClass("TestClass");
            cls.DefineInstanceVariable("x");

            Block block;

            block = new Block();
            block.CompileArgument("newX");
            block.CompileGet("newX");
            block.CompileSet("x");

            Assert.AreEqual(1, block.Arity);
            Assert.AreEqual(0, block.NoLocals);
            Assert.IsNotNull(block.ByteCodes);
            Assert.IsTrue(block.ByteCodes.Length > 0);
        }

        [Test]
        public void ShouldCompileGlobal()
        {
            Block block;

            block = new Block();
            block.CompileGetConstant(10);
            block.CompileSet("Global");

            Assert.AreEqual("Global", block.GetGlobalName(0));
        }

        [Test]
        public void ShouldCompileAndRunWithGlobal()
        {
            Block block;

            block = new Block();
            block.CompileGetConstant(10);
            block.CompileSet("Global");

            Machine machine = new Machine();

            block.Execute(machine, null);

            Assert.AreEqual(10, machine.GetGlobalObject("Global"));
        }

        [Test]
        public void ShouldCompileWithLocals()
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

        [Test]
        public void ShouldCompileAndRun()
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

        [Test]
        public void ShouldCompileWithLocalsAndRun()
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

        [Test]
        public void ShouldCompileGlobalName()
        {
            Block block = new Block();
            byte p = block.CompileGlobal("Class");

            Assert.AreEqual(0, p);
        }

        [Test]
        public void ShouldCompileGlobalNames()
        {
            Block block = new Block();
            byte p1 = block.CompileGlobal("Class");
            byte p2 = block.CompileGlobal("Object");
            byte p3 = block.CompileGlobal("Class");

            Assert.AreEqual(0, p1);
            Assert.AreEqual(1, p2);
            Assert.AreEqual(0, p3);
        }

        [Test]
        public void ShouldCompileGetGlobalVariable()
        {
            Block block = new Block();
            block.CompileGet("Class");
            block.CompileGet("Object");

            byte p1 = block.CompileGlobal("Object");
            byte p2 = block.CompileGlobal("Class");

            Assert.AreEqual(1, p1);
            Assert.AreEqual(0, p2);
        }
    }
}

