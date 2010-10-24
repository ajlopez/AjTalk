using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AjTalk.Transactions
{
    public class TransactionManager
    {
        private long time;
        private Machine machine;
        private List<Transaction> transactions = new List<Transaction>();

        [ThreadStatic]
        private static Transaction current;

        public TransactionManager(Machine machine)
        {
            this.machine = machine;
        }

        public static Transaction CurrentTransaction { get { return current; } }

        public long Time { get { return this.time; } }

        public Transaction CreateTransaction()
        {
            long trtime = Interlocked.Increment(ref time);
            Interlocked.Increment(ref time);

            return new Transaction(this, trtime);
        }

        public void BeginTransaction()
        {
            if (current != null)
                throw new InvalidOperationException("A Transaction is active");

            Transaction transaction = this.CreateTransaction();
            current = transaction;

            lock (this)
                this.transactions.Add(current);
        }

        public void CommitTransaction()
        {
            lock (this)
                this.transactions.Remove(current);

            long trtime = Interlocked.Increment(ref time);
            Interlocked.Increment(ref time);
            current.Commit(trtime);
            
            current = null;
        }

        public void RollbackTransaction()
        {
            lock (this)
                this.transactions.Remove(current);

            long trtime = Interlocked.Increment(ref time);
            Interlocked.Increment(ref time);
            current.Rollback(trtime);

            current = null;
        }

        public bool HasTransactions()
        {
            return this.transactions.Count != 0;
        }

        public long MinimalTransactionalTime
        {
            get
            {
                // TODO review is this method needs locks
                if (this.transactions.Count == 0)
                    return this.time+1;

                IEnumerable<long> times = from tr in this.transactions select tr.Start;
                return times.Min();
            }
        }
    }
}
