namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SelfExpression : IExpression
    {
        public string AsString()
        {
            return "self";
        }
    }
}
