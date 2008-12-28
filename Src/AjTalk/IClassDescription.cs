using System;
using System.Collections;
using System.Collections.Generic;

namespace AjTalk
{
	public interface IClassDescription : IBehavior
	{
        IClass MetaClass { get; }

        void DefineClassVariable(string varname);
        void DefineInstanceVariable(string varname);

        int GetClassVariableOffset(string varname);
        int GetInstanceVariableOffset(string varname);
	}
}

