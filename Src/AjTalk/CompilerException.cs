namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CompilerException : Exception
    {
        public CompilerException(string message)
            : base(message)
        {
        }
    }
}

