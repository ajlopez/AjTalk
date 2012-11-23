namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Language;
    using AjTalk.Model;
    using AjTalk.Compilers.Vm;

    public class VmCompiler
    {
        public Block CompileBlock(string text)
        {
            ModelParser parser = new ModelParser(text);
            var expr = parser.ParseBlock();
            Block block = new Block(text);
            BytecodeCompiler compiler = new BytecodeCompiler(block);
            compiler.CompileExpression(expr);
            return block;
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
