namespace AjTalk.Language
{
    using System;

    public interface IMethod : IBlock
    {
        string Name { get; }

        // TODO public set used in Machine CopyMethods, to review
        IBehavior Behavior { get; set; }

        object Execute(IObject self, object[] args);

        object Execute(IObject self, IObject receiver, object[] args);

        object ExecuteNative(object seft, object[] args);
    }
}
