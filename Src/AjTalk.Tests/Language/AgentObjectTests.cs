using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Language;
using System.Threading;

namespace AjTalk.Tests.Language
{
    [TestClass]
    public class AgentObjectTests
    {
        [TestMethod]
        public void CreateAndInvokeAgent()
        {
            ManualResetEvent handle = new ManualResetEvent(false);
            bool executed = false;
            AgentObject agent = new AgentObject();
            agent.ExecuteMethod(new FunctionalMethod((x,y, args) => { 
                executed = true; 
                return handle.Set();
            }), null);
            handle.WaitOne();
            Assert.IsTrue(executed);
        }

        [TestMethod]
        public void CreateAndInvokeAgentTwice()
        {
            ManualResetEvent handle1 = new ManualResetEvent(false);
            ManualResetEvent handle2 = new ManualResetEvent(false);
            int count = 0;
            AgentObject agent = new AgentObject();

            IMethod method = new FunctionalMethod((x, y, args) =>
            {
                count++;
                return ((ManualResetEvent)args[0]).Set();
            });

            agent.ExecuteMethod(method, new object[] { handle1 });
            agent.ExecuteMethod(method, new object[] { handle2 });
            handle1.WaitOne();
            handle2.WaitOne();
            Assert.AreEqual(2, count);
        }
    }
}
