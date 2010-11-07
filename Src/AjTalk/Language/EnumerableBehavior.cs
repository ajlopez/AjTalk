﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AjTalk.Language
{
    public class EnumerableBehavior : NativeBehavior
    {
        public EnumerableBehavior(IBehavior superclass, Machine machine)
            : base(superclass, machine, typeof(IEnumerable))
        {
            this.DefineInstanceMethod(new FunctionalMethod("do:", this, this.DoMethod));
            this.DefineInstanceMethod(new FunctionalMethod("select:", this, this.SelectMethod));
        }

        private object DoMethod(object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count()!=1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock) arguments[0];
            IEnumerable elements = (IEnumerable)obj;
            object result = null;
            foreach (object element in elements)
                result = block.Execute(this.Machine, new object[] { element });
            return result;
        }

        private object SelectMethod(object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            IEnumerable elements = (IEnumerable)obj;
            ArrayList result = new ArrayList();

            foreach (object element in elements)
                if ((bool) block.Execute(this.Machine, new object[] { element }))
                    result.Add(element);

            return result;
        }
    }
}