using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Hosting;
using AjTalk.Language;

namespace AjTalk.Tests.Hosting
{
    [TestClass]
    public class ObjectProxyTests
    {
        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void CreateAndInvokeProxyObjectAroundAnIObject()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st");
            Machine machine = new Machine();
            Host host = new Host(machine);
            loader.LoadAndExecute(machine);

            IObject result = (IObject) machine.GetGlobalObject("result");

            ObjectProxy proxy = (ObjectProxy) host.ResultToObject(result);

            Assert.AreEqual(proxy.HostId, host.Id);

            Assert.AreSame(result, host.GetObject(proxy.ObjectId));

            object xresult = proxy.SendMessage("x", null);
            Assert.AreEqual(10, xresult);

            proxy.SendMessage("y:", new object[] { 30 });
            object yresult = proxy.SendMessage("y", null);
            Assert.AreEqual(30, yresult);
        }
    }
}
