using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Transactions
{
    public class TransactionalValue
    {
        private Dictionary<Transaction, object> transactionValues = new Dictionary<Transaction, object>();
        private Dictionary<long, object> committedValues = new Dictionary<long, object>();

        public object GetValue(Transaction transaction)
        {
            if (this.transactionValues.ContainsKey(transaction))
                return this.transactionValues[transaction];

            return this.GetValue(transaction.Start - 1);
        }

        public object GetValue(long attime)
        {
            if (this.committedValues.ContainsKey(attime))
                return this.committedValues[attime];

            long candidateTime = -1;
            object candidateValue = null;

            foreach (long time in this.committedValues.Keys)
                if (attime > time && candidateTime < time)  // TODO review if time is negative 
                {
                    candidateTime = time;
                    candidateValue = this.committedValues[time];
                }

            return candidateValue;
        }
       
        public void SetValue(Transaction transaction, object value)
        {
            this.transactionValues[transaction] = value;
        }

        public void SetValue(long time, object value)
        {
            this.committedValues[time] = value;
        }

        public void CommitValue(Transaction transaction)
        {
        }

        public void RollbackValue(Transaction transaction)
        {
        }
    }
}
