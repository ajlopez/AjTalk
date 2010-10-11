namespace AjTalk.Language
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;

    public class DotNetObject
    {
        public static object NewObject(Type type, object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        public static object SendNativeMessage(object obj, string mthname, object[] args)
        {
            // TODO support for indexed properties
            Type type = obj.GetType();

            if (args != null && args.Length > 0)
            {
                PropertyInfo prop = type.GetProperty(mthname, System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (prop != null)
                    return type.InvokeMember(mthname, System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
            }

            return obj.GetType().InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
        }

        public static object SendNativeStaticMessage(Type type, string mthname, object[] args)
        {
            return type.InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, null, args);
        }

        public static object SendMessage(Machine machine, object obj, string msgname, object[] args)
        {
            NativeBehavior behavior = machine.GetNativeBehavior(obj.GetType());

            string mthname = msgname;
            int p = msgname.IndexOf(":");

            if (p > 0)
                mthname = msgname.Substring(0, p);
            else
                mthname = msgname;

            if (behavior == null)
                return SendNativeMessage(obj, mthname, args); 

            IMethod mth = behavior.GetInstanceMethod(msgname);

            if (mth != null)
                return mth.ExecuteNative(obj, args);

            if (obj is Type && (msgname == "new" || msgname.StartsWith("new:")))
                return NewObject((Type)obj, args);

            // TODO how to use doesNotUnderstand in native behavior
            //mth = behavior.GetInstanceMethod("doesNotUnderstand:");

            //if (mth != null)
            //    return mth.ExecuteNative(obj, new object[] { msgname, args });

            return SendNativeMessage(obj, mthname, args);
        }
    }
}
