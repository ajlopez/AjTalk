namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EnumerableBehavior : NativeBehavior
    {
        public EnumerableBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(IEnumerable))
        {
            this.DefineInstanceMethod(new FunctionalMethod("do:", this, this.DoMethod));
            this.DefineInstanceMethod(new FunctionalMethod("select:", this, this.SelectMethod));
            this.DefineInstanceMethod(new FunctionalMethod("includes:", this, this.IncludesMethod));
        }

        private object DoMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            IEnumerable elements = (IEnumerable)obj;
            object result = null;
            foreach (object element in elements)
                result = block.Execute(this.Machine, new object[] { element });
            return result;
        }

        private object SelectMethod(Machine machine, object obj, object[] arguments)
        {
            if (arguments == null)
                throw new ArgumentException("arguments");
            if (arguments.Count() != 1 || !(arguments[0] is IBlock))
                throw new InvalidOperationException("A Block was expected");
            IBlock block = (IBlock)arguments[0];
            IEnumerable elements = (IEnumerable)obj;
            ArrayList result = new ArrayList();

            foreach (object element in elements)
                if ((bool)block.Execute(this.Machine, new object[] { element }))
                    result.Add(element);

            return result;
        }

        private object IncludesMethod(Machine machine, object obj, object[] arguments)
        {
            var list = obj as IList;
            var argument = arguments[0];

            if (list != null)
                return list.Contains(argument);

            foreach (var element in (IEnumerable)obj)
            {
                if (element == null && argument == null)
                    return true;
                if (element != null && element.Equals(argument))
                    return true;
            }

            return false;
        }
    }
}
