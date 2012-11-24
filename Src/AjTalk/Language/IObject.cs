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

        object SendMessage(string msgname, object[] args);
    }
}
