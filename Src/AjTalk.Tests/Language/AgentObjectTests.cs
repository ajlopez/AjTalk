namespace AjTalk.Tests.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AjTalk.Language;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AgentObjectTests
    {
        [TestMethod]
        public void CreateAndInvokeAgent()
        {
            ManualResetEvent handle = new ManualResetEvent(false);
            bool executed = false;
            AgentObject agent = new AgentObject();
            agent.ExecuteMethod(
                (Machine)null,
                new FunctionalMethod((x, y, args) => 
            { 
                executed = true; 
                return handle.Set();
            }), 
            null);
            handle.WaitOne();
            Assert.IsTrue(executed);
        }

        [TestMethod]
        public void CreateAndInvokeAgentUsingInterpreter()
        {
            Machine machine = new Machine();
            Block block = new Block();
            AjTalk.Language.ExecutionContext context = new AjTalk.Language.ExecutionContext(machine, null, block, null);
            Interpreter interpreter = new Interpreter(context);
            ManualResetEvent handle = new ManualResetEvent(false);
            bool executed = false;
            AgentObject agent = new AgentObject();
            agent.ExecuteMethod(
                interpreter,
                new FunctionalMethod((x, y, args) =>
                {
                    executed = true;
                    return handle.Set();
                }),
            null);
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

            agent.ExecuteMethod((Machine)null, method, new object[] { handle1 });
            agent.ExecuteMethod((Machine)null, method, new object[] { handle2 });
            handle1.WaitOne();
            handle2.WaitOne();
            Assert.AreEqual(2, count);
        }
    }
}
