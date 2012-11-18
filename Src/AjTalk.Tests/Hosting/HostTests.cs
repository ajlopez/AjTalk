namespace AjTalk.Tests.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Hosting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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
