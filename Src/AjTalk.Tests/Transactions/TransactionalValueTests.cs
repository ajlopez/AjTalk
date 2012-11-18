namespace AjTalk.Tests.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using AjTalk.Language;
    using AjTalk.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionalValueTests
    {
        private Machine machine;
        private TransactionManager manager;
        private IObject obj;
        private TransactionalObject trobj;

        [TestInitialize]
        public void Setup()
        {
            this.machine = new Machine();
            this.manager = new TransactionManager(this.machine);
            this.obj = new BaseObject(null, new object[] { 1, 2, 3 });
            this.trobj = new TransactionalObject(this.obj, new TransactionManager(this.machine));
        }

        [TestMethod]
        public void SetAndGetOriginalValue()
        {
            IObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            TransactionalValue tvalue = new TransactionalValue(this.trobj, 2);
            Assert.AreEqual(3, tvalue.GetValue(this.CreateTransaction()));
            Assert.AreEqual(3, tvalue.GetValue(0));
        }

        [TestMethod]
        public void SetAndGetValueInTransaction()
        {
            IObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            TransactionalValue tvalue = new TransactionalValue(this.trobj, 2);
            Transaction transaction = this.CreateTransaction();
            tvalue.SetValue(transaction, 2);
            Assert.AreEqual(2, tvalue.GetValue(transaction));
            Assert.AreEqual(3, tvalue.GetValue(0));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RaiseIfTwoTransactionChangeTheSameSlot()
        {
            IObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            TransactionalValue tvalue = new TransactionalValue(this.trobj, 0);
            Transaction transaction1 = this.CreateTransaction();
            tvalue.SetValue(transaction1, 2);
            Transaction transaction2 = this.CreateTransaction();
            tvalue.SetValue(transaction2, 3);
        }

        [TestMethod]
        public void TwoSerializedTransactions()
        {
            IObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            TransactionalValue tvalue = new TransactionalValue(this.trobj, 0);
            Transaction transaction1 = this.CreateTransaction();
            tvalue.SetValue(transaction1, 2);
            tvalue.CommitValue(transaction1);

            Assert.AreEqual(2, tvalue.GetValue(0));

            Transaction transaction2 = this.CreateTransaction();
            tvalue.SetValue(transaction2, 3);
            tvalue.CommitValue(transaction2);

            Assert.AreEqual(3, tvalue.GetValue(0));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RaiseIfTransactionChangeACommittedSlot()
        {
            IObject obj = new BaseObject(null, new object[] { 1, 2, 3 });
            TransactionalValue tvalue = new TransactionalValue(this.trobj, 0);
            Transaction transaction1 = this.CreateTransaction();

            Transaction transaction2 = this.CreateTransaction();
            tvalue.SetValue(transaction2, 3);
            transaction2.Commit(this.manager.Time + 1);
            ////tvalue.CommitValue(transaction2);
            tvalue.SetValue(transaction1, 2);
        }

        private Transaction CreateTransaction()
        {
            return this.manager.CreateTransaction();
        }
    }
}
