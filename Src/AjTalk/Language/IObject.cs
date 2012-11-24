namespace AjTalk.Language
{
    using System;

    public interface IObject
    {
        IBehavior Behavior { get; }

        object this[int n] 
        {
            get; set; 
        }

        int NoVariables { get; }

        object SendMessage(string msgname, object[] args);
    }
}
