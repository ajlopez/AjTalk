namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BaseBehavior : BaseObject, IBehavior
    {
        private IBehavior superclass;
        private IList<IBehavior> traits;
        private Machine machine;
        private Context scope;

        private Dictionary<string, IMethod> methods = new Dictionary<string, IMethod>();

        public BaseBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, behavior == null ? 0 : behavior.NoInstanceVariables)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("machine");
            }

            this.superclass = superclass;
            this.machine = machine;
            this.scope = machine.CurrentEnvironment;
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
                return (IMetaClass)this.Behavior;
            }
        }

        public Machine Machine
        {
            get
            {
                return this.machine;
            }
        }

        public Context Scope { get { return this.scope; } }

        public bool IsIndexed { get; set; }

        public virtual int NoInstanceVariables
        {
            get
            {
                if (this.superclass != null)
                {
                    return this.superclass.NoInstanceVariables;
                }

                return 0;
            }
        }

        public void DefineClassMethod(IMethod method)
        {
            this.MetaClass.DefineInstanceMethod(method);
        }

        public void DefineInstanceMethod(IMethod method)
        {
            this.methods[method.Name] = method;
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

            if (!this.methods.ContainsKey(mthname))
            {
                if (this.traits != null)
                {
                    foreach (var trait in this.traits)
                    {
                        var mth = trait.GetInstanceMethod(mthname);

                        if (mth != null)
                            return mth;
                    }
                }

                if (this.superclass != null)
                {
                    return this.superclass.GetInstanceMethod(mthname);
                }

                return null;
            }

            return this.methods[mthname];
        }

        public virtual object NewObject()
        {
            if (this.IsIndexed)
                return new BaseIndexedObject(this, this.NoInstanceVariables);

            return new BaseObject(this, this.NoInstanceVariables);
        }

        public ICollection<IMethod> GetInstanceMethods()
        {
            List<IMethod> methods = new List<IMethod>(this.methods.Values);
            return methods;
        }

        public ICollection<IMethod> GetClassMethods()
        {
            return this.MetaClass.GetInstanceMethods();
        }

        public void SetSuperClass(IBehavior superclass)
        {
            this.superclass = superclass;
        }

        public void AddTrait(IBehavior trait)
        {
            if (this.traits == null)
                this.traits = new List<IBehavior>();

            this.traits.Add(trait);
        }
    }
}
