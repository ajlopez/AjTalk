using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AjTalk.Transactions;
using System.Threading;

namespace AjTalk.Tests.Transactions
{
    [TestClass]
    public class TransactionalValueTests
    {
        private Machine machine;
        private TransactionManager manager;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.manager = new TransactionManager(this.machine);
        }

        [TestMethod]
        public void SetAndGetOriginalValue()
        {
            TransactionalValue tvalue = new TransactionalValue();
            tvalue.SetValue(0, 1);
            Assert.AreEqual(1, tvalue.GetValue(CreateTransaction()));
            Assert.AreEqual(1, tvalue.GetValue(0));
        }

        [TestMethod]
        public void SetAndGetValueInTransaction()
        {
            TransactionalValue tvalue = new TransactionalValue();
            tvalue.SetValue(0, 1);
            Transaction transaction = CreateTransaction();
            tvalue.SetValue(transaction, 2);
            Assert.AreEqual(2, tvalue.GetValue(transaction));
            Assert.AreEqual(1, tvalue.GetValue(0));
        }

        [TestMethod]
        public void SetAndGetValuesInTwoTransactions()
        {
            TransactionalValue tvalue = new TransactionalValue();
            tvalue.SetValue(0, 1);
            Transaction transaction1 = CreateTransaction();
            tvalue.SetValue(transaction1, 2);
            Transaction transaction2 = CreateTransaction();
            tvalue.SetValue(transaction2, 3);
            Assert.AreEqual(2, tvalue.GetValue(transaction1));
            Assert.AreEqual(3, tvalue.GetValue(transaction2));
            Assert.AreEqual(1, tvalue.GetValue(0));
        }

        private Transaction CreateTransaction()
        {
            return this.manager.CreateTransaction();
        }
    }
}
