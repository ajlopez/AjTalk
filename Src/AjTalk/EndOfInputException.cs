namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EndOfInputException : Exception
    {
        public EndOfInputException()
            : base("End of Input")
        {
        }
    }
}
