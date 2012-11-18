namespace AjTalk.Tests.Hosting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Hosting;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemotingTests
    {
        [TestMethod]
        public void CreateRemotingServer()
        {
            RemotingHostServer server = new RemotingHostServer(10000, "Server0");
            Assert.IsNotNull(server.Address);
            Assert.IsTrue(server.IsLocal);
            server.Stop();
        }

        [TestMethod]
        public void CreateRemotingServerWithMachine()
        {
            Machine machine = new Machine();
            RemotingHostServer server = new RemotingHostServer(machine, 10001, "Server1");
            Assert.IsNotNull(server.Address);
            Assert.AreSame(machine, server.Machine);
            Assert.AreSame(machine.Host, server);
            Assert.AreSame(machine.GetHost(server.Id), server);
            server.Stop();
        }

        [TestMethod]
        public void CreateRemotingAndClientServerAndEvaluateConstant()
        {
            Machine machine = new Machine();
            RemotingHostServer server = new RemotingHostServer(machine, 10002, "Server2");
            RemotingHostClient client = new RemotingHostClient("localhost", 10002, "Server2");
            object result = client.Evaluate("2");
            Assert.AreEqual(2, result);
            server.Stop();
        }

        [TestMethod]
        public void CreateRemotingAndClientServerAndExecuteCommand()
        {
            Machine machine = new Machine();
            RemotingHostServer server = new RemotingHostServer(machine, 10003, "Server3");
            Machine machine2 = new Machine();
            RemotingHostClient client = new RemotingHostClient("localhost", 10003, "Server3");
            client.Execute("aNumber := 3");
            Assert.AreEqual(3, machine.GetGlobalObject("aNumber"));
            Assert.IsNull(machine2.GetGlobalObject("aNumber"));
            server.Stop();
        }

        [TestMethod]
        [DeploymentItem(@"CodeFiles\DefineRectangleWithNewAndInitialize.st")]
        public void CreateRemotingAndClientServerAndExportClass()
        {
            Loader loader = new Loader(@"DefineRectangleWithNewAndInitialize.st");
            Machine machine = new Machine();
            RemotingHostServer server = new RemotingHostServer(machine, 10004, "Server4");
            Machine machine2 = new Machine();
            loader.LoadAndExecute(machine2);
            BaseClass rect = (BaseClass)machine2.GetGlobalObject("Rectangle");
            RemotingHostClient client = new RemotingHostClient("localhost", 10004, "Server4");
            client.Execute(rect.ToOutputString());
            object result = machine.GetGlobalObject("Rectangle");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BaseClass));
            object newresult = client.Evaluate("Rectangle new");
            Assert.IsNotNull(newresult);
            Assert.IsInstanceOfType(newresult, typeof(IObject));
            IObject newrect = (IObject)newresult;
            Assert.AreSame(rect, newrect.Behavior);
            Assert.AreEqual(10, newrect[0]);
            Assert.AreEqual(20, newrect[1]);
            server.Stop();
        }
    }
}
