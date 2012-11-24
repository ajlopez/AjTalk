namespace AjTalk.Compiler
{
    using System;
    using AjTalk.Language;

    public interface ICompiler
    {
        Block CompileBlock(string text);

        Method CompileClassMethod(string text, IBehavior cls);

        Method CompileInstanceMethod(string text, IBehavior cls);
    }
}
