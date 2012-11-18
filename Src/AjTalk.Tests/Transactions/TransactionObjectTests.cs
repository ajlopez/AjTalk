namespace AjTalk.Tests.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using AjTalk.Transactions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TransactionObjectTests
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
            this.trobj = new TransactionalObject(this.obj, this.manager);
        }

        [TestMethod]
        public void GetOriginalValues()
        {
            Assert.AreEqual(1, this.trobj[0]);
            Assert.AreEqual(2, this.trobj[1]);
            Assert.AreEqual(3, this.trobj[2]);
        }

        [TestMethod]
        public void SetAndGetOriginalValues()
        {
            this.trobj[0] = 10;
            this.trobj[1] = 20;
            this.trobj[2] = 30;
            Assert.AreEqual(10, this.trobj[0]);
            Assert.AreEqual(20, this.trobj[1]);
            Assert.AreEqual(30, this.trobj[2]);
        }

        [TestMethod]
        public void GetValuesInTransaction()
        {
            this.manager.BeginTransaction();
            Assert.AreEqual(1, this.trobj[0]);
            Assert.AreEqual(2, this.trobj[1]);
            Assert.AreEqual(3, this.trobj[2]);
            this.manager.RollbackTransaction();
        }

        [TestMethod]
        public void GetValuesInTransactionAndRollback()
        {
            this.manager.BeginTransaction();
            this.trobj[0] = 10;
            this.trobj[1] = 20;
            this.trobj[2] = 30;
            Assert.AreEqual(10, this.trobj[0]);
            Assert.AreEqual(20, this.trobj[1]);
            Assert.AreEqual(30, this.trobj[2]);
            this.manager.RollbackTransaction();
            Assert.AreEqual(1, this.trobj[0]);
            Assert.AreEqual(2, this.trobj[1]);
            Assert.AreEqual(3, this.trobj[2]);
        }

        [TestMethod]
        public void GetValuesInTransactionAndCommit()
        {
            this.manager.BeginTransaction();
            this.trobj[0] = 10;
            this.trobj[1] = 20;
            this.trobj[2] = 30;
            Assert.AreEqual(10, this.trobj[0]);
            Assert.AreEqual(20, this.trobj[1]);
            Assert.AreEqual(30, this.trobj[2]);
            this.manager.CommitTransaction();
            Assert.AreEqual(10, this.trobj[0]);
            Assert.AreEqual(20, this.trobj[1]);
            Assert.AreEqual(30, this.trobj[2]);
        }
    }
}
