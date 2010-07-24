namespace AjTalk.Language
{
    using System;

    public interface IMethod : IBlock
    {
        string Name { get; }

        IClass Class { get; }

        object Execute(IObject self, object[] args);

        object Execute(IObject self, IObject receiver, object[] args);
    }
}
