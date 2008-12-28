namespace AjTalk
{
    using System;

    /// <summary>
    /// Summary description for BaseObject.
    /// </summary>
    public class BaseObject : IObject
    {
        private IBehavior behavior;
        private object[] variables;

        public BaseObject()
        {
            this.behavior = null;
            this.variables = null;
        }

        public BaseObject(IBehavior behavior, int nvars) 
        {
            this.behavior = behavior;
            this.variables = new object[nvars];
        }

        public BaseObject(IBehavior behavior, object[] vars) 
        {
            this.behavior = behavior;
            this.variables = vars;
        }

        public IBehavior Behavior
        {
            get
            {
                // TODO:  Add BaseObject.Class getter implementation
                return this.behavior;
            }
        }

        public object this[int n]
        {
            get
            {
                return this.variables[n];
            }

            set
            {
                this.variables[n] = value;
            }
        }

        public object SendMessage(string msgname, object[] args)
        {
            // TODO objclass to review
            IMethod mth = this.behavior.GetInstanceMethod(msgname);

            if (mth != null)
            {
                return mth.Execute(this, this, args);
            }

            mth = this.behavior.GetInstanceMethod("doesNotUnderstand:");

            if (mth != null)
            {
                return mth.Execute(this, this, new object[] { msgname, args });
            }

            throw new InvalidProgramException(string.Format("Does not understand {0}", msgname));
        }

        internal void SetBehavior(IBehavior behavior)
        {
            this.behavior = behavior;
        }
    }
}
