namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Compilers.Vm;
    using AjTalk.Language;
    using AjTalk.Model;

    public class VmCompiler : ICompiler
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
            ModelParser parser = new ModelParser(text);
            var methodmodel = parser.ParseMethod();
            Method method = new Method(cls, methodmodel.Selector, text);
            BytecodeCompiler compiler = new BytecodeCompiler(method);
            compiler.CompileMethod(methodmodel);
            return method;
        }

        public Method CompileClassMethod(string text, IBehavior cls)
        {
            ModelParser parser = new ModelParser(text);
            var methodmodel = parser.ParseMethod();
            Method method = new Method(cls.MetaClass, methodmodel.Selector, text);
            BytecodeCompiler compiler = new BytecodeCompiler(method);
            compiler.CompileMethod(methodmodel);
            return method;
        }
    }
}
