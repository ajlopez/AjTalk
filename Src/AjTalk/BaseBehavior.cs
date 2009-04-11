namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BaseBehavior : BaseObject, IBehavior
    {
        private IClass superclass;
        private Machine machine;
        private int noinstancevariables;

        private Dictionary<string, IMethod> classmethods = new Dictionary<string, IMethod>();
        private Dictionary<string, IMethod> instancemethods = new Dictionary<string, IMethod>();

        public BaseBehavior(IClass superclass, Machine machine) 
        {
            if (machine == null)
            {
                throw new ArgumentNullException("machine");
            }

            this.superclass = superclass;
            this.machine = machine;
        }

        public IClass SuperClass
        {
            get
            {
                return this.superclass;
            }
        }

        public IClass MetaClass
        {
            get
            {
                return (IClass)this.Behavior;
            }
        }

        public Machine Machine
        {
            get
            {
                return this.machine;
            }
        }

        public bool IsIndexed { get; set; }

        public virtual int NoInstanceVariables
        {
            get
            {
                if (this.superclass != null)
                {
                    return this.noinstancevariables + this.superclass.NoInstanceVariables;
                }

                return this.noinstancevariables;
            }
        }

        public void DefineClassMethod(IMethod method)
        {
            if (method == null)
            {
                throw new ArgumentNullException("method");
            }

            this.classmethods[method.Name] = method;
        }

        public void DefineInstanceMethod(IMethod method)
        {
            this.instancemethods[method.Name] = method;
        }

        public IMethod GetClassMethod(string mthname)
        {
            if (mthname == null)
            {
                throw new ArgumentNullException("mthname");
            }

            if (!this.classmethods.ContainsKey(mthname))
            {
                if (this.superclass != null)
                {
                    return this.superclass.GetClassMethod(mthname);
                }

                return null;
            }

            return this.classmethods[mthname];
        }

        public IMethod GetInstanceMethod(string mthname)
        {
            if (mthname == null)
            {
                throw new ArgumentNullException("mthname");
            }

            if (!this.instancemethods.ContainsKey(mthname))
            {
                if (this.superclass != null)
                {
                    return this.superclass.GetInstanceMethod(mthname);
                }

                return null;
            }

            return this.instancemethods[mthname];
        }

        public virtual IObject NewObject()
        {
            if (this.IsIndexed)
                return new BaseIndexedObject(this, this.NoInstanceVariables);

            return new BaseObject(this, this.NoInstanceVariables);
        }
    }
}
