using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Hosting;

namespace AjTalk.Tests.Hosting
{
    [TestClass]
    public class HostTests
    {
        private Machine machine;
        private Host host;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.host = new Host(this.machine);
        }

        [TestMethod]
        public void EvaluateAnUndefinedGlobalValue()
        {
            object result = this.host.Evaluate("AClass");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void EvaluateADefinedGlobalValue()
        {
            this.machine.SetGlobalObject("anObject", 1);
            object result = this.host.Evaluate("anObject");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ExecuteASetCommand()
        {
            this.machine.SetGlobalObject("anObject", 1);
            this.host.Execute("anObject := 2");
            Assert.AreEqual(2, this.machine.GetGlobalObject("anObject"));
        }
    }
}
