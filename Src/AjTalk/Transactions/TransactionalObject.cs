using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Transactions
{
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

        public object this[int n]
        {
            get
            {
                lock (this)
                {
                    if (this.values.ContainsKey(n)) {
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
                    if (!this.values.ContainsKey(n))
                    {
                        TransactionalValue tv = new TransactionalValue();
                        // TODO review, time 0 value should be retrieved from inner object
                        tv.SetValue(0, this.inner[n]);
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

        public IObject InnerObject
        {
            get { return this.inner; }
        }
    }
}
