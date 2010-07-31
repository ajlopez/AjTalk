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

        public static object SendNativeMessage(object obj, string mthname, object[] args)
        {
            return obj.GetType().InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
        }

        public static object SendNativeStaticMessage(Type type, string mthname, object[] args)
        {
            return type.InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, null, args);
        }

        public static object SendMessage(Machine machine, object obj, string msgname, object[] args)
        {
            NativeBehavior behavior = machine.GetNativeBehavior(obj.GetType());

            if (behavior == null)
                return SendNativeMessage(obj, msgname, args); // TODO get real method name from message

            IMethod mth = behavior.GetInstanceMethod(msgname);

            //if (mth != null)
            //{
            //    return mth.Execute(this, this, args);
            //}

            //mth = this.behavior.GetInstanceMethod("doesNotUnderstand:");

            //if (mth != null)
            //{
            //    return mth.Execute(this, this, new object[] { msgname, args });
            //}

            throw new InvalidProgramException(string.Format("Does not understand {0}", msgname));
        }
    }
}
