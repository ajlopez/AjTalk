namespace AjTalk.Language
{
    using System;

    public interface IMethod : IBlock
    {
        string Name { get; }

        IBehavior Class { get; }

        object Execute(IObject self, object[] args);

        object Execute(IObject self, IObject receiver, object[] args);

        object ExecuteNative(object seft, object[] args);
    }
}
