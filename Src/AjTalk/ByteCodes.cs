using System;

namespace AjTalk
{
	public enum ByteCode : byte
	{
		Nop = 0,
		GetVariable = 1,
		SetVariable = 2,
		GetArgument = 3,
		SetArgument = 4,
		GetConstant = 5,
		GetLocal = 6,
		SetLocal = 7,
		GetClassVariable = 8,
		SetClassVariable = 9,
        GetGlobalVariable = 10,
        SetGlobalVariable = 11,

		GetSelf = 20,
		GetClass = 21,
		GetSuperClass = 22,
		NewObject = 23,
		Pop = 24,
		ReturnSub = 25,
		ReturnPop = 26,

		Add = 40,
		Substract = 41,
		Multiply = 42,
		Divide = 43,

		Send = 50
	}
}
