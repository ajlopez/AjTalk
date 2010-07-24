namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LexerException : Exception
    {
        public LexerException(string msg)
            : base(msg)
        {
        }
    }
}
