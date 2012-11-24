namespace AjTalk.Language
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BaseObject : IObject, ISerializable
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

        protected BaseObject(SerializationInfo info, StreamingContext context)
        {
            this.variables = (object[])info.GetValue("Variables", typeof(object[]));
            string classname = info.GetString("ClassName");
            this.behavior = (IBehavior)Machine.Current.GetGlobalObject(classname);
        }

        public IBehavior Behavior
        {
            get
            {
                // TODO:  Add BaseObject.Class getter implementation
                return this.behavior;
            }
        }

        public int NoVariables { get { return this.variables == null ? 0 : this.variables.Length; } }

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
                return this.ExecuteMethod(mth, args);

            mth = this.behavior.GetInstanceMethod("doesNotUnderstand:");

            if (mth != null)
                return this.ExecuteMethod(mth, new object[] { msgname, args });

            throw new InvalidProgramException(string.Format("Does not understand {0}", msgname));
        }

        public virtual object ExecuteMethod(IMethod method, object[] arguments)
        {
            return method.Execute(this, this, arguments);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Variables", this.variables);
            
            // TODO review IClass cast
            info.AddValue("ClassName", ((IClass)this.Behavior).Name);
        }

        internal void SetBehavior(IBehavior behavior)
        {
            this.behavior = behavior;
        }
    }
}
