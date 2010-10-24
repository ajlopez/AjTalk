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
            current = this.CreateTransaction();
        }

        public void CommitTransaction()
        {
            current = null;
        }

        public void RollbackTransaction()
        {
            current = null;
        }
    }
}
