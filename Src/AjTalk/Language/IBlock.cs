namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBlock
    {
        object Execute(Machine machine, object[] args);
    }
}
