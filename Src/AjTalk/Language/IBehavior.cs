namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBehavior : IObject
    {
        IBehavior SuperClass { get; }

        Machine Machine { get; }

        Context Scope { get; }

        int NoInstanceVariables { get; }

        IMetaClass MetaClass { get; }

        void DefineClassMethod(IMethod method);

        void DefineInstanceMethod(IMethod method);

        object NewObject();

        IMethod GetClassMethod(string mthname);

        IMethod GetInstanceMethod(string mthname);

        ICollection<IMethod> GetInstanceMethods();

        ICollection<IMethod> GetClassMethods();

        object SendMessageToObject(IObject self, Machine machine, string msgname, object[] args);

        object SendMessageToObject(IObject self, Interpreter interpreter, string msgname, object[] args);
    }
}
