namespace AjTalk.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AssertError : ErrorException
    {
        public AssertError()
            : this("assert failed")
        {
        }

        public AssertError(string msg)
            : base(msg)
        {
        }
    }
}
