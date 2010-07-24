namespace AjTalk.Language
{
    using System;

    public interface IMessage
    {
        string Name { get; }

        int Arity { get; }
    }
}
