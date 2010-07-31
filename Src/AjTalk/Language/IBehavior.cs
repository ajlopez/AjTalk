namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBehavior : IObject
    {
        IClass SuperClass { get; }

        Machine Machine { get; }

        int NoInstanceVariables { get; }

        IClass MetaClass { get; }

        void DefineClassMethod(IMethod method);

        void DefineInstanceMethod(IMethod method);

        object NewObject();

        IMethod GetClassMethod(string mthname);

        IMethod GetInstanceMethod(string mthname);
    }
}
