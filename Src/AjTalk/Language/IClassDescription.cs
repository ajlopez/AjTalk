namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IClassDescription : IBehavior
    {
        int NoClassVariables { get; }

        void DefineClassVariable(string varname);

        void DefineInstanceVariable(string varname);

        void RedefineClassVariables(string varnames);

        void RedefineInstanceVariables(string varnames);

        int GetClassVariableOffset(string varname);

        int GetInstanceVariableOffset(string varname);

        string GetInstanceVariableNamesAsString();

        string GetClassVariableNamesAsString();

        ICollection<string> GetInstanceVariableNames();

        ICollection<string> GetClassVariableNames();
    }
}

