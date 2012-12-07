namespace AjTalk.Language
{
    using System;

    public interface IObject
    {
        IBehavior Behavior { get; }

        int NoVariables { get; }

        object this[int n] 
        {
            get; set; 
        }

        object SendMessage(Machine machine, string msgname, object[] args);

        object ExecuteMethod(Machine machine, IMethod method, object[] arguments);
    }
}
