namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IClassDescription : IBehavior
    {
        void DefineClassVariable(string varname);

        void DefineInstanceVariable(string varname);

        int GetClassVariableOffset(string varname);

        int GetInstanceVariableOffset(string varname);
    }
}

