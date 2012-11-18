﻿namespace AjTalk.Transactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;

    public class TransactionalObject : IObject, IObjectDecorator
    {
        private IObject inner;
        private TransactionManager manager;
        private Dictionary<int, TransactionalValue> values = new Dictionary<int, TransactionalValue>();

        public TransactionalObject(IObject inner, TransactionManager manager)
        {
            this.inner = inner;
            this.manager = manager;
        }

        public IBehavior Behavior
        {
            get { return this.inner.Behavior; }
        }

        public TransactionManager TransactionManager { get { return this.manager; } }

        public IObject InnerObject
        {
            get { return this.inner; }
        }

        public object this[int n]
        {
            get
            {
                lock (this)
                {
                    if (TransactionManager.CurrentTransaction == null && !this.manager.HasTransactions())
                    {
                        if (this.values.Count > 0)
                            this.ReleaseValues();

                        return this.inner[n];
                    }

                    if (this.values.ContainsKey(n))
                    {
                        if (TransactionManager.CurrentTransaction == null)
                            return this.values[n].GetValue(this.manager.Time);
                        else
                            return this.values[n].GetValue(TransactionManager.CurrentTransaction);
                    }

                    return this.inner[n];
                }
            }

            set
            {
                lock (this)
                {
                    if (TransactionManager.CurrentTransaction == null && !this.manager.HasTransactions())
                    {
                        if (this.values.Count > 0)
                            this.ReleaseValues();

                        this.inner[n] = value;
                        return;
                    }
                       
                    if (!this.values.ContainsKey(n))
                    {
                        TransactionalValue tv = new TransactionalValue(this, n);
                        this.values[n] = tv;
                    }

                    if (TransactionManager.CurrentTransaction == null)
                        this.values[n].SetValue(this.manager.Time, value);
                    else
                        this.values[n].SetValue(TransactionManager.CurrentTransaction, value);
                }
            }
        }

        public object SendMessage(string msgname, object[] args)
        {
            // TODO objclass to review
            IMethod mth = this.Behavior.GetInstanceMethod(msgname);

            if (mth != null)
                return this.ExecuteMethod(mth, args);

            mth = this.Behavior.GetInstanceMethod("doesNotUnderstand:");

            if (mth != null)
                return this.ExecuteMethod(mth, new object[] { msgname, args });

            throw new InvalidProgramException(string.Format("Does not understand {0}", msgname));
        }

        public virtual object ExecuteMethod(IMethod method, object[] arguments)
        {
            // TODO native methods are directed to this Transactional object
            // instead to inner object
            return method.Execute(this, this, arguments);
        }

        internal void ReleaseValues()
        {
            long time = this.manager.MinimalTransactionalTime;

            foreach (TransactionalValue val in this.values.Values)
                val.ReleaseValues(time);

            this.values = new Dictionary<int, TransactionalValue>();
        }
    }
}
