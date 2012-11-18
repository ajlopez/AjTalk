namespace AjTalk.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Transaction
    {
        private TransactionManager manager;
        private long start;
        private long end;
        private List<TransactionalValue> values = new List<TransactionalValue>();

        public Transaction(TransactionManager manager, long start)
        {
            this.manager = manager;
            this.start = start;
        }

        public TransactionManager TransactionManager { get { return this.manager; } }

        public long Start { get { return this.start; } }

        public long End { get { return this.end; } }

        public bool IsCommitted { get { return this.end != 0; } }

        public bool WasOpenedAfter(long time)
        {
            return time < this.Start; // TODO review Start negative
        }

        // TODO Review: it's only called with thread local TransactionManager.Current, no lock is needed
        public void Commit(long attime)
        {
            this.end = attime;
            foreach (TransactionalValue value in this.values)
                value.CommitValue(this);
            this.values = null;
        }

        // TODO Review: it's only called with thread local TransactionManager.Current, no lock is needed
        public void Rollback(long attime)
        {
            this.end = attime;
            foreach (TransactionalValue value in this.values)
                value.RollbackValue(this);
            this.values = null;
        }

        // TODO Review: it's only called with thread local TransactionManager.Current, no lock is needed
        public void RegisterValue(TransactionalValue value)
        {
            if (this.values.Contains(value))
                return;
            this.values.Add(value);
        }
    }
}
