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

        public bool IsPrototype
        {
            get
            {
                if (this.behavior == null)
                    return false;

                var cd = this.behavior as IClass;

                if (cd == null)
                    return false;

                // TODO review predicate, GUID check?
                return cd.Name.StartsWith("__");
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

        public object SendMessage(Machine machine, string msgname, object[] args)
        {
            return this.behavior.SendMessageToObject(this, machine, msgname, args);
        }

        public virtual object ExecuteMethod(Machine machine, IMethod method, object[] arguments)
        {
            return method.Execute(machine, this, arguments);
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Variables", this.variables);
            
            // TODO review IClass cast
            info.AddValue("ClassName", ((IClass)this.Behavior).Name);
        }

        public void DefineObjectMethod(IMethod method)
        {
            if (this.IsPrototype)
            {
                this.Behavior.DefineInstanceMethod(method);
                return;
            }

            string clsname = "__" + Guid.NewGuid().ToString();
            var newbehavior = this.Behavior.Machine.CreateClass(clsname, (IClass)this.behavior);
            this.behavior = newbehavior;
            newbehavior.DefineInstanceMethod(method);
            ((Method)method).SetBehavior(newbehavior);
        }

        internal void SetBehavior(IBehavior behavior)
        {
            this.behavior = behavior;
        }

        internal void SetVariables(object[] variables) 
        {
            this.variables = variables;
        }

        internal void ResizeVariables(int nvars)
        {
            if (this.variables == null)
            {
                this.variables = new object[nvars];
                return;
            }

            if (this.variables.Length >= nvars)
                return;

            object[] newvars = new object[nvars];

            Array.Copy(this.variables, newvars, this.variables.Length);

            this.variables = newvars;
        }
    }
}
