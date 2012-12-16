namespace AjTalk.Transactions
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

        public int NoVariables { get { return this.inner.NoVariables; } }

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

        public object SendMessage(Machine machine, string msgname, object[] args)
        {
            // TODO objclass to review
            IMethod mth = this.Behavior.GetInstanceMethod(msgname);

            if (mth != null)
                return this.ExecuteMethod(this, machine, mth, args);

            mth = this.Behavior.GetInstanceMethod("doesNotUnderstand:with:");

            if (mth != null)
                return this.ExecuteMethod(this, machine, mth, new object[] { msgname, args });

            return DotNetObject.SendMessage(machine, this, msgname, args);
        }

        public virtual object ExecuteMethod(Machine machine, IMethod method, object[] arguments)
        {
            return method.Execute(machine, this, arguments);
        }

        public virtual object ExecuteMethod(Interpreter interpreter, IMethod method, object[] arguments)
        {
            return method.ExecuteInInterpreter(interpreter, this, arguments);
        }

        public virtual object ExecuteMethod(IObject self, Machine machine, IMethod method, object[] arguments)
        {
            return method.Execute(machine, self, arguments);
        }

        public void DefineObjectMethod(IMethod method)
        {
            throw new NotImplementedException();
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
