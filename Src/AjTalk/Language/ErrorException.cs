using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Language
{
    public class ErrorException : Exception
    {
        public ErrorException(string message)
            : base(message)
        {
        }
    }
}
