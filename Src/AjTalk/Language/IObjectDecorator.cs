using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AjTalk.Language
{
    public interface IObjectDecorator
    {
        IObject InnerObject { get; }
    }
}
