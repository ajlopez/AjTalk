using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Transactions
{
    public class Transaction
    {
        private TransactionManager manager;
        private long start;
        private long end;

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
    }
}
