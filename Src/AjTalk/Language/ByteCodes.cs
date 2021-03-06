namespace AjTalk.Language
{
    using System;

    public enum ByteCode : byte
    {
        Nop = 0,
        GetInstanceVariable = 1,
        SetInstanceVariable = 2,
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
        GetSuper = 27,
        GetNil = 28,
/*
        Add = 40,
        Substract = 41,
        Multiply = 42,
        Divide = 43,
*/
        Send = 50,
        ChainedSend = 51,
        MakeCollection = 52,
        Primitive = 53,
        NamedPrimitive = 54,
        PrimitiveError = 55,

        BasicInstVarAt = 60,
        BasicInstVarAtPut = 61,
        BasicInstSize = 62,
        BasicSize = 63,
        BasicAt = 64,
        BasicAtPut = 65,

        Value = 70,
        MultiValue = 71,

        GetDotNetType = 80,
        NewDotNetObject = 81,
        InvokeDotNetMethod = 82, 
        RaiseException = 83,

        Jump = 100,
        JumpIfFalse = 101,
        JumpIfTrue = 102
    }
}
