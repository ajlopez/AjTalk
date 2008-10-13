using System;
using System.Collections;
using System.Collections.Generic;

namespace AjTalk
{
	public interface IClass : IObject
	{
		IClass SuperClass { get; }
		string Name { get; }
        Machine Machine { get; }
        int NoInstanceVariables { get; }

        void DefineClassMethod(IMethod method);
        void DefineInstanceMethod(IMethod method);

        void DefineClassVariable(string varname);
        void DefineInstanceVariable(string varname);

		IObject NewObject();

        IMethod GetClassMethod(string mthname);
        IMethod GetInstanceMethod(string mthname);
        int GetClassVariableOffset(string varname);
        int GetInstanceVariableOffset(string varname);
	}
}

