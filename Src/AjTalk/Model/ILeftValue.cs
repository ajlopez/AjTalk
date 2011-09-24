namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ILeftValue : IExpression
    {
        string Name { get; }
    }
}
