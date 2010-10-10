using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AjTalk.Language;

namespace AjTalk.Hosting
{
    public interface IHost
    {
        // Host Id
        Guid Id { get; }

        bool IsLocal { get; }

        string Address { get; }

        // Host Invocation
        void Execute(string command);
        object Evaluate(string expression);
        object Invoke(IObject receiver, string msgname, object[] args);
    }
}
