namespace AjTalk.Language
{
    using System;

    public interface IMethod : IBlock
    {
        string Name { get; }

        IBehavior Behavior { get; }

        object Execute(Machine machine, IObject self, object[] args);

        object Execute(Machine machine, IObject self, IObject receiver, object[] args);

        object ExecuteNative(Machine machine, object seft, object[] args);
    }
}
