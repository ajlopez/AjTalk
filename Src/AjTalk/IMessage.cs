namespace AjTalk
{
    using System;

    public interface IMessage
    {
        string Name { get; }

        int Arity { get; }
    }
}
