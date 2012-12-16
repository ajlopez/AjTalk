namespace AjTalk.Language
{
    using System;

    public interface IMethod : IBlock
    {
        string Name { get; }

        IBehavior Behavior { get; }

        object Execute(Machine machine, IObject self, object[] args);

        object ExecuteInInterpreter(Interpreter interpreter, IObject self, object[] args);

        object ExecuteNative(Machine machine, object seft, object[] args);

        object ExecuteNativeInInterpreter(Interpreter interpreter, object seft, object[] args);
    }
}
