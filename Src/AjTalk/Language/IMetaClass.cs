namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMetaClass : IClassDescription
    {
        IClass ClassInstance { get; }

        IClass CreateClass(string name, string varnames);
    }
}
