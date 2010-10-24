using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Transactions
{
    public class TransactionalValue
    {
        private Transaction transaction;
        private object value;

        private TransactionalObject trobj;
        private int position;

        private Dictionary<long, object> committedValues = new Dictionary<long, object>();

        public TransactionalValue(TransactionalObject trobj, int position)
        {
            this.trobj = trobj;
            this.position = position;
        }

        public object GetValue(Transaction transaction)
        {
            if (this.transaction != null && this.transaction == transaction)
                return this.value;

            return this.GetValue(transaction.Start - 1);
        }

        public object GetValue(long attime)
        {
            if (this.committedValues.ContainsKey(attime))
                return this.committedValues[attime];

            long candidateTime = 0;
            object candidateValue = this.trobj.InnerObject[this.position];

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
            if (this.transaction != null && this.transaction != transaction)
                throw new InvalidOperationException("Another transaction modified this value");

            foreach (long time in this.committedValues.Keys)
                if (time > transaction.Start)
                    throw new InvalidOperationException("Another transaction modified this value");

            if (this.transaction == null)
                transaction.RegisterValue(this);

            this.transaction = transaction;
            this.value = value;
        }

        public void SetValue(long time, object value)
        {
            this.committedValues[time] = value;
        }

        public void CommitValue(Transaction transaction)
        {
            lock (this.trobj)
            {
                if (this.transaction == transaction)
                {
                    this.SetValue(transaction.End, this.value);
                    this.transaction = null;
                    this.value = null;
                }
                if (this.trobj.TransactionManager.HasTransactions())
                    this.ReleaseValues(this.trobj.TransactionManager.MinimalTransactionalTime);
            }
        }

        public void RollbackValue(Transaction transaction)
        {
            lock (this.trobj)
            {
                if (this.transaction != transaction)
                    return;
                this.transaction = null;
                this.value = null;
            }
        }

        // TODO this.trobj should be locked here, and it is
        internal void ReleaseValues(long activetime)
        {
            List<long> times = (from time in this.committedValues.Keys where time < activetime select time).ToList();

            if (times.Count()==0)
                return;

            long selected = times.Max();
            object value = this.committedValues[selected];

            foreach (long time in times)
                this.committedValues.Remove(time);

            this.trobj.InnerObject[this.position] = value;
        }
    }
}
