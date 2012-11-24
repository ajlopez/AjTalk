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
        private Func<IObject, IObject, object[], object> function;
        private Func<object, object[], object> nativeFunction;

        public FunctionalMethod(Func<IObject, IObject, object[], object> function)
            : this(null, null, function)
        {
        }

        public FunctionalMethod(Func<object, object[], object> nativeFunction)
            : this(null, null, nativeFunction)
        {
        }

        public FunctionalMethod(string name, IBehavior classDescription, Func<IObject, IObject, object[], object> function)
        {
            this.name = name;
            this.classDescription = classDescription;
            this.function = function;
        }

        public FunctionalMethod(string name, IBehavior classDescription, Func<object, object[], object> nativeFunction)
        {
            this.name = name;
            this.classDescription = classDescription;
            this.nativeFunction = nativeFunction;
        }

        public string Name { get { return this.name; } }

        public string SourceCode { get { return null; } }

        public byte[] Bytecodes { get { return null; } }

        public IBehavior Class { get { return this.classDescription; } }

        public object Execute(IObject self, object[] args)
        {
            return this.function(self, self, args);
        }

        public object Execute(IObject self, IObject receiver, object[] args)
        {
            return this.function(self, receiver, args);
        }

        public object ExecuteNative(object self, object[] args)
        {
            return this.nativeFunction(self, args);
        }

        public object Execute(Machine machine, object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
