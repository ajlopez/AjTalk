namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;

    public class SimpleCompiler : AjTalk.Compiler.ICompiler
    {
        public Block CompileBlock(string text)
        {
            Parser parser = new Parser(text);
            return parser.CompileBlock();
        }

        public Method CompileInstanceMethod(string text, IBehavior cls)
        {
            Parser parser = new Parser(text);
            return parser.CompileInstanceMethod(cls);
        }

        public Method CompileClassMethod(string text, IBehavior cls)
        {
            Parser parser = new Parser(text);
            return parser.CompileClassMethod(cls);
        }
    }
}
