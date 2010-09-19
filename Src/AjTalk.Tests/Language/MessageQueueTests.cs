using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using AjTalk.Language;

namespace AAjTalk.Tests.Language
{
    [TestClass]
    public class MessageQueueTests
    {
        [TestMethod]
        public void CreateAndUseMessageQueue()
        {
            MessageQueue queue = new MessageQueue(1);
            Message message = new Message(new Method("name"), new object[] { 1, 2});

            Thread thread = new Thread(new ThreadStart(delegate() { queue.PostMessage(message); }));
            thread.Start();

            Message result = queue.GetMessage();
        }

        [TestMethod]
        public void CreateAndUseMessageQueueTenTimes()
        {
            MessageQueue queue = new MessageQueue(10);

            Thread thread = new Thread(new ThreadStart(delegate() { for (int k = 1; k <= 10; k++) queue.PostMessage(new Message(new Method("name"), new object[] { k })); }));
            thread.Start();

            for (int j = 1; j <= 10; j++)
            {
                Message message = queue.GetMessage();
                Assert.IsNotNull(message);
                Assert.IsNotNull(message.Method);
                Assert.AreEqual("name", message.Method.Name);
                Assert.IsNotNull(message.Arguments);
                Assert.AreEqual(1, message.Arguments.Length);
            }
        }

        [TestMethod]
        public void CreateAndUseMessageQueueWithTenMessages()
        {
            MessageQueue queue = new MessageQueue(10);
            Message message = new Message(new Method("name"), new object[] { 1, 2 });

            for (int k = 1; k <= 10; k++)
                queue.PostMessage(message);

            for (int k = 1; k <= 10; k++)
                Assert.AreEqual(message, queue.GetMessage());
        }

        [TestMethod]
        public void CreateAndUseMessageQueueWithMoreEntriesThanSize()
        {
            MessageQueue queue = new MessageQueue(10);
            Message message = new Message(new Method("name"), new object[] { 1, 2 });

            Thread thread = new Thread(new ThreadStart(delegate()
            {
                for (int k = 1; k <= 20; k++)
                    queue.PostMessage(message);
            }));

            thread.Start();

            for (int k = 1; k <= 20; k++)
                Assert.AreEqual(message, queue.GetMessage());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RaiseIfZeroInConstructor()
        {
            new MessageQueue(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RaiseIfNegativeNumberInConstructor()
        {
            new MessageQueue(-1);
        }
    }
}
