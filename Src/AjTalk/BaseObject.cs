namespace AjTalk
{
    using System;

    /// <summary>
    /// Summary description for BaseObject.
    /// </summary>
    public class BaseObject : IObject
    {
        private IClass objclass;
        private object[] variables;

        public BaseObject()
        {
            this.objclass = null;
            this.variables = null;
        }

        public BaseObject(IClass cls, int nvars) 
        {
            this.objclass = cls;
            this.variables = new object[nvars];
        }

        public BaseObject(IClass cls, object[] vars) 
        {
            this.objclass = cls;
            this.variables = vars;
        }

        public IClass Class
        {
            get
            {
                // TODO:  Add BaseObject.Class getter implementation
                return this.objclass;
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
            IMethod mth = this.objclass.GetInstanceMethod(msgname);

            if (mth != null)
            {
                return mth.Execute(this, this, args);
            }

            mth = this.objclass.GetInstanceMethod("doesNotUnderstand:");

            if (mth != null)
            {
                return mth.Execute(this, this, new object[] { msgname, args });
            }

            throw new InvalidProgramException(string.Format("Does not understand {0}", msgname));
        }

        internal void SetClass(IClass cls)
        {
            this.objclass = cls;
        }
    }
}
