namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBlock
    {
        string SourceCode { get; }

        object Execute(Machine machine, object[] args);
    }
}
