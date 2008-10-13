namespace AjTalk.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AjTalk;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class LoaderTests
    {
        [TestMethod]
        public void ShouldBeCreated()
        {
            Loader loader = new Loader(new StringReader(""));

            Assert.IsNotNull(loader);
        }

        [TestMethod]
        public void ShouldGetEmptyLine()
        {
            Loader loader = new Loader(new StringReader("\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldGetTwoLinesBlock()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldGetTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!\nline 3\nline 4\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("line 3\nline 4\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [TestMethod]
        public void ShouldExecuteBlock()
        {
            Loader loader = new Loader(new StringReader("One := 1\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [TestMethod]
        public void ShouldExecuteBlockWithTwoCommands()
        {
            Loader loader = new Loader(new StringReader("One := 1.\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [TestMethod]
        public void ShouldExecuteTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("One := 1.\n!\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }
    }
}

