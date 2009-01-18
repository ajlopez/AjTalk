namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TokenizerException : Exception
    {
        public TokenizerException(string msg)
            : base(msg)
        {
        }
    }
}
