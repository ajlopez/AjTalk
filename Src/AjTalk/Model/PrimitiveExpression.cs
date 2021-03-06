﻿namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PrimitiveExpression : IExpression
    {
        private int number;
        private string name;
        private string module;
        private string error;

        public PrimitiveExpression(int number)
            : this(number, null)
        {
        }

        public PrimitiveExpression(int number, string error)
        {
            this.number = number;
            this.error = error;
        }

        public PrimitiveExpression(string name, string module)
        {
            this.name = name;
            this.module = module;
        }

        public int Number { get { return this.number; } }

        public string Name { get { return this.name; } }

        public string Module { get { return this.module; } }

        public string AsString()
        {
            if (this.name != null)
                return string.Format("<primitive: '{0}' module: '{1}'>", this.name, this.module);
            else
                return string.Format("<primitive: {0}>", this.number);
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
