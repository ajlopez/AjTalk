﻿namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ClassModel : IVisitable
    {
        private string name;
        private ClassModel superclass;
        private ClassModel metaclass;
        private IList<string> classVariableNames;
        private IList<string> instanceVariableNames;
        private IList<MethodModel> classMethods;
        private IList<MethodModel> instanceMethods;

        public ClassModel(string name, ClassModel superclass, IList<string> instanceVariableNames, IList<string> classVariableNames)
        {
            this.name = name;
            this.superclass = superclass;
            this.instanceVariableNames = instanceVariableNames ?? new List<string>();
            this.classVariableNames = classVariableNames ?? new List<string>();
            this.classMethods = new List<MethodModel>();
            this.instanceMethods = new List<MethodModel>();
            if (!name.EndsWith(" class"))
                this.metaclass = new ClassModel(name + " class", superclass == null ? null : superclass.MetaClass, null, null);
        }

        public string Name { get { return this.name; } }

        public ClassModel SuperClass { get { return this.superclass; } }

        public ClassModel MetaClass { get { return this.metaclass; } }

        public IList<string> ClassVariableNames { get { return this.classVariableNames; } }

        public IList<string> InstanceVariableNames { get { return this.instanceVariableNames; } }

        public IList<MethodModel> ClassMethods { get { return this.classMethods; } }

        public IList<MethodModel> InstanceMethods { get { return this.instanceMethods; } }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

