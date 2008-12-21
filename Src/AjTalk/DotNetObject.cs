using System;
using System.Collections.Generic;
using System.Text;

namespace AjTalk
{
    public class DotNetObject
    {
        public static object SendMessage(object obj, string mthname, object[] args)
        {
            Type type = obj as Type;

            if (type != null && mthname.StartsWith("new"))
            {
                return Activator.CreateInstance(type, args);
            }

            int point = mthname.IndexOf(":");

            if (point>0)
                mthname = mthname.Substring(0, point);

            if (type != null) 
            {
                return type.InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null, null, args);
            }

            return obj.GetType().InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
        }
    }
}
