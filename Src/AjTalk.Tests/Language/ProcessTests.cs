namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using AjTalk.Compiler;

    [TestClass]
    public class ProcessTests
    {
        [TestMethod]
        public void NewProcess()
        {
            Machine machine = new Machine();
            Block block = new Block();

            Process process = new Process(block, null, machine);

            Assert.AreSame(machine, process.Machine);
            Assert.AreSame(block, process.Block);
            Assert.IsNull(process.Arguments);
        }

        [TestMethod]
        public void RunProcess()
        {
            AutoResetEvent handle = new AutoResetEvent(false);
            Machine machine = new Machine();
            machine.SetGlobalObject("handle", handle);
            Block block = (new VmCompiler()).CompileBlock("handle !Set");

            Process process = new Process(block, null, machine);

            process.Start();

            if (!handle.WaitOne(500))
                Assert.Fail("Process didn't run");
        }
    }
}
