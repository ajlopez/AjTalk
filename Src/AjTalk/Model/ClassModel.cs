namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClassModel : IVisitable
    {
        private string name;
        private ClassModel superclass;
        private string superclassname;
        private ClassModel metaclass;
        private IList<string> classVariableNames;
        private IList<string> instanceVariableNames;
        private IList<MethodModel> classMethods;
        private IList<MethodModel> instanceMethods;
        private bool isvariable;

        public ClassModel(string name, ClassModel superclass, IList<string> instanceVariableNames, IList<string> classVariableNames)
            : this(name, superclass, instanceVariableNames, classVariableNames, false)
        {
        }

        public ClassModel(string name, ClassModel superclass, IList<string> instanceVariableNames, IList<string> classVariableNames, bool isvariable)
        {
            this.name = name;
            this.superclass = superclass;
            this.instanceVariableNames = instanceVariableNames ?? new List<string>();
            this.classVariableNames = classVariableNames ?? new List<string>();
            this.classMethods = new List<MethodModel>();
            this.instanceMethods = new List<MethodModel>();
            if (!name.EndsWith(" class"))
                this.metaclass = new ClassModel(name + " class", superclass == null ? null : superclass.MetaClass, null, null);
            this.isvariable = isvariable;
        }

        public ClassModel(string name, string superclassname, IList<string> instanceVariableNames, IList<string> classVariableNames, bool isvariable)
        {
            this.name = name;
            this.superclassname = superclassname;
            this.instanceVariableNames = instanceVariableNames ?? new List<string>();
            this.classVariableNames = classVariableNames ?? new List<string>();
            this.classMethods = new List<MethodModel>();
            this.instanceMethods = new List<MethodModel>();
            if (!name.EndsWith(" class"))
                this.metaclass = new ClassModel(name + " class", superclassname == null ? null : superclassname + " class", null, null, isvariable);
            this.isvariable = isvariable;
        }

        public string Name { get { return this.name; } }

        public string SuperClassName 
        { 
            get 
            {
                if (this.superclass != null)
                    return this.superclass.Name;

                return this.superclassname; 
            } 
        }

        public ClassModel MetaClass { get { return this.metaclass; } }

        public IList<string> ClassVariableNames { get { return this.classVariableNames; } }

        public IList<string> InstanceVariableNames { get { return this.instanceVariableNames; } }

        public IList<MethodModel> ClassMethods { get { return this.classMethods; } }

        public IList<MethodModel> InstanceMethods { get { return this.instanceMethods; } }

        public bool IsVariable { get { return this.isvariable; } }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

