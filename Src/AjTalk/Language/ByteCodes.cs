namespace AjTalk.Language
{
    using System;

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
        GetBlock = 12,

        GetSelf = 20,
        GetClass = 21,
        GetSuperClass = 22,
        NewObject = 23,
        Pop = 24,
        ReturnSub = 25,
        ReturnPop = 26,
/*
        Add = 40,
        Substract = 41,
        Multiply = 42,
        Divide = 43,
*/
        Send = 50,
        ChainedSend = 51,
        MakeCollection = 52,

        InstAt = 60,
        InstAtPut = 61,
        InstSize = 62,
        BasicSize = 63,
        BasicAt = 64,
        BasicAtPut = 65,

        Value = 70,
        MultiValue = 71,

        GetDotNetType = 80,
        NewDotNetObject = 81,
        InvokeDotNetMethod = 82, 
    }
}
