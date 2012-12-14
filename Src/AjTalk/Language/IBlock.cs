namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBlock
    {
        string SourceCode { get; }

        byte[] Bytecodes { get; }

        object Execute(Machine machine, object[] args);

        // TODO remove to have Process.resume/suspend, call with continuation, etc..
        object FullExecute(Machine machine, object[] args);
    }
}
