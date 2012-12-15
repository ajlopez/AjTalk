namespace AjTalk.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AjTalk.Compiler;
    using AjTalk.Exceptions;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EvaluateProcessTests : EvaluateTests
    {
        protected override object Evaluate(string text, Machine machine)
        {
            Parser parser = new Parser(text);
            Block block = parser.CompileBlock();
            Process process = new Process(block, null, machine);
            return process.Execute();
        }
    }
}
