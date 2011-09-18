namespace AjTalk.Compilers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AjTalk.Model;

    public interface ICompiler 
    {
        void CompileMethod(MethodModel method);

        void CompileExpression(IExpression expression);
    }
}
