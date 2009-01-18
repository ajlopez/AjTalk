namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum TokenType : int
    {
        Name = 0,
        Integer = 1,
        String = 2,
        Punctuation = 3,
        Operator = 4,
        Symbol
    }
}
