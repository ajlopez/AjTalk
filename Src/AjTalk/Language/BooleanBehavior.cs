namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compiler;

    public class BooleanBehavior : NativeBehavior
    {
        public BooleanBehavior(IBehavior behavior, IBehavior superclass, Machine machine)
            : base(behavior, superclass, machine, typeof(bool))
        {
            string iffalseiftruesource = @"
ifFalse: falseBlock ifTrue: trueBlock
    self ifFalse: [^falseBlock value].
    ^trueBlock value.
            ";
            string iftrueiffalsesource = @"
ifTrue: trueBlock ifFalse: falseBlock
    self ifFalse: [^falseBlock value].
    ^trueBlock value.
            ";

            Parser parser = new Parser(iffalseiftruesource);
            this.DefineInstanceMethod(parser.CompileInstanceMethod(this));
            parser = new Parser(iftrueiffalsesource);
            this.DefineInstanceMethod(parser.CompileInstanceMethod(this));
        }
    }
}
