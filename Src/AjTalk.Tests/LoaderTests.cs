using System;
using System.Collections.Generic;
using System.Text;

using AjTalk;

using NUnit.Framework;
using System.IO;

namespace AjTalk.Tests
{
    [TestFixture]
    public class LoaderTests
    {
        [Test]
        public void ShouldBeCreated()
        {
            Loader loader = new Loader(new StringReader(""));

            Assert.IsNotNull(loader);
        }

        [Test]
        public void ShouldGetEmptyLine()
        {
            Loader loader = new Loader(new StringReader("\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [Test]
        public void ShouldGetTwoLinesBlock()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [Test]
        public void ShouldGetTwoBlocks()
        {
            Loader loader = new Loader(new StringReader("line 1\nline 2\n!\nline 3\nline 4\n"));

            Assert.IsNotNull(loader);
            Assert.AreEqual("line 1\nline 2\n", loader.GetBlockText());
            Assert.AreEqual("line 3\nline 4\n", loader.GetBlockText());
            Assert.IsNull(loader.GetBlockText());
        }

        [Test]
        public void ShouldExecuteBlock()
        {
            Loader loader = new Loader(new StringReader("One := 1\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
        }

        [Test]
        public void ShouldExecuteBlockWithTwoCommands()
        {
            Loader loader = new Loader(new StringReader("One := 1.\nTwo := 2\n!\n"));
            Machine machine = new Machine();

            loader.LoadAndExecute(machine);

            Assert.AreEqual(1, machine.GetGlobalObject("One"));
            Assert.AreEqual(2, machine.GetGlobalObject("Two"));
        }

        [Test]
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

