using System;
using System.Collections.Generic;
using System.Text;

namespace AjTalk
{
    public interface IBlock
    {
        object Execute(Machine machine, object[] args);
    }
}
