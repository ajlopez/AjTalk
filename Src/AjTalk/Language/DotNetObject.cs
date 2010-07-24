namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DotNetObject
    {
        public static object NewObject(Type type, object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        public static object SendMessage(object obj, string mthname, object[] args)
        {
            return obj.GetType().InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
        }
    }
}
