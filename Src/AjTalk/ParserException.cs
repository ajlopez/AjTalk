namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ParserException : Exception
    {
        public ParserException(string message)
            : base(message)
        {
        }
    }
}

