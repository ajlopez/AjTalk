namespace AjTalk.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum TokenType : int
    {
        Name,
        Integer,
        Real,
        String,
        Character,
        Punctuation,
        Operator,
        Symbol,
        Parameter
    }
}
