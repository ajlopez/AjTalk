namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BaseBehavior : BaseObject, IBehavior
    {
        private IBehavior superclass;
        private Machine machine;
        private int noinstancevariables;

        private Dictionary<string, IMethod> classmethods = new Dictionary<string, IMethod>();
        private Dictionary<string, IMethod> instancemethods = new Dictionary<string, IMethod>();

        private BaseBehavior(Machine machine)
        {
            this.machine = machine;
        }

        public BaseBehavior(IBehavior superclass, Machine machine) 
        {
            if (machine == null)
            {
                throw new ArgumentNullException("machine");
            }

            this.superclass = superclass;
            this.machine = machine;

            if (this is IMetaClass)
                ; // TODO implements metaclass for metaclass
            else
                this.SetBehavior(BaseMetaClass.CreateMetaClass(superclass, machine));
        }

        public IBehavior SuperClass
        {
            get
            {
                return this.superclass;
            }
        }

        public IMetaClass MetaClass
        {
            get
            {
                return (IMetaClass) this.Behavior;
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
            this.MetaClass.DefineInstanceMethod(method);
        }

        public void DefineInstanceMethod(IMethod method)
        {
            this.instancemethods[method.Name] = method;
        }

        public IMethod GetClassMethod(string mthname)
        {
            return this.MetaClass.GetInstanceMethod(mthname);
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

        public virtual object NewObject()
        {
            if (this.IsIndexed)
                return new BaseIndexedObject(this, this.NoInstanceVariables);

            return new BaseObject(this, this.NoInstanceVariables);
        }
    }
}
