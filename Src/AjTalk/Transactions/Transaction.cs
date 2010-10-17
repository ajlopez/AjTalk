using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Transactions
{
    public class Transaction
    {
        private Machine machine;
        private long start;
        private long end;

        public Transaction(Machine machine, long start)
        {
            this.machine = machine;
            this.start = start;
        }

        public Machine Machine { get { return this.machine; } }

        public long Start { get { return this.start; } }

        public long End { get { return this.end; } }

        public bool IsCommitted { get { return this.end != 0; } }

        public bool WasOpenedAfter(long time)
        {
            return time < this.Start; // TODO review Start negative
        }
    }
}
