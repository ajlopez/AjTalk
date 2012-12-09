namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FunctionalMethod : IMethod
    {
        private string name;
        private IBehavior classDescription;
        private Func<Machine, IObject, IObject, object[], object> function;
        private Func<Machine, object, object[], object> nativeFunction;

        public FunctionalMethod(Func<Machine, IObject, IObject, object[], object> function)
            : this(null, null, function)
        {
        }

        public FunctionalMethod(Func<Machine, object, object[], object> nativeFunction)
            : this(null, null, nativeFunction)
        {
        }

        public FunctionalMethod(string name, IBehavior classDescription, Func<Machine, IObject, IObject, object[], object> function)
        {
            this.name = name;
            this.classDescription = classDescription;
            this.function = function;
        }

        public FunctionalMethod(string name, IBehavior classDescription, Func<Machine, object, object[], object> nativeFunction)
        {
            this.name = name;
            this.classDescription = classDescription;
            this.nativeFunction = nativeFunction;
        }

        public string Name { get { return this.name; } }

        public string SourceCode { get { return null; } }

        public byte[] Bytecodes { get { return null; } }

        public IBehavior Behavior { get { return this.classDescription; } }

        public object Execute(Machine machine, IObject self, object[] args)
        {
            if (this.nativeFunction != null)
                return this.nativeFunction(machine, self, args);
            return this.function(machine, self, self, args);
        }

        public object Execute(Machine machine, IObject self, IObject receiver, object[] args)
        {
            // TODO review, used in Machine to define ifNil:
            if (this.function == null)
                return this.nativeFunction(machine, self, args);

            return this.function(machine, self, receiver, args);
        }

        public object ExecuteNative(Machine machine, object self, object[] args)
        {
            return this.nativeFunction(machine, self, args);
        }

        public object Execute(Machine machine, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
