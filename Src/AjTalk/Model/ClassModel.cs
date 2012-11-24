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
        private IList<string> poolDictionaries;
        private string category;
        private IList<MethodModel> classMethods;
        private IList<MethodModel> instanceMethods;
        private bool isvariable;

        public ClassModel(string name, ClassModel superclass, IList<string> instanceVariableNames, IList<string> classVariableNames, bool isvariable, IList<string> poolDictionaries, string category)
            : this(name, instanceVariableNames, classVariableNames, isvariable, poolDictionaries, category)
        {
            this.superclass = superclass;
        }

        public ClassModel(string name, string superclassname, IList<string> instanceVariableNames, IList<string> classVariableNames, bool isvariable, IList<string> poolDictionaries, string category)
            : this(name, instanceVariableNames, classVariableNames, isvariable, poolDictionaries, category)
        {
            this.superclassname = superclassname;
        }

        public ClassModel(string name, IList<string> instanceVariableNames, IList<string> classVariableNames, bool isvariable, IList<string> poolDictionaries, string category)
        {
            this.name = name;
            this.instanceVariableNames = instanceVariableNames ?? new List<string>();
            this.classVariableNames = classVariableNames ?? new List<string>();
            this.classMethods = new List<MethodModel>();
            this.instanceMethods = new List<MethodModel>();
            if (!name.EndsWith(" class"))
                this.metaclass = new ClassModel(name + " class", this.superclassname == null ? null : this.superclassname + " class", null, null, isvariable, null, null);
            this.isvariable = isvariable;
            this.poolDictionaries = poolDictionaries ?? new List<string>();
            this.category = category ?? string.Empty;
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

        public IList<string> PoolDictionaries { get { return this.poolDictionaries; } }

        public string Category { get { return this.category; } }

        public string PoolDictionariesAsString { get { return AsString(this.poolDictionaries); } }

        public string ClassVariableNamesAsString { get { return AsString(this.classVariableNames); } }

        public string InstanceVariableNamesAsString { get { return AsString(this.instanceVariableNames); } }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private static string AsString(IList<string> names)
        {
            if (names == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            int nnames = 0;

            foreach (var name in names) 
            {
                if (nnames > 0)
                    sb.Append(" ");

                sb.Append(name);
                nnames++;
            }

            return sb.ToString();
        }
    }
}

