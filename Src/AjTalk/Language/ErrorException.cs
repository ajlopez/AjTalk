namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ErrorException : Exception
    {
        public ErrorException(string message)
            : base(message)
        {
        }
    }
}
