namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class DotNetObject
    {
        private static Dictionary<string, IMethod> binaryMethods = new Dictionary<string, IMethod>();

        static DotNetObject()
        {
            binaryMethods["+"] = new FunctionalMethod((obj, args) => ObjectOperators.Add(obj, args[0]));
            binaryMethods["-"] = new FunctionalMethod((obj, args) => ObjectOperators.Substract(obj, args[0]));
            binaryMethods["*"] = new FunctionalMethod((obj, args) => ObjectOperators.Multiply(obj, args[0]));
            binaryMethods["/"] = new FunctionalMethod((obj, args) => ObjectOperators.Divide(obj, args[0]));
            binaryMethods["<"] = new FunctionalMethod((obj, args) => ObjectOperators.Less(obj, args[0]));
            binaryMethods[">"] = new FunctionalMethod((obj, args) => ObjectOperators.Greater(obj, args[0]));
            binaryMethods["<="] = new FunctionalMethod((obj, args) => ObjectOperators.LessEqual(obj, args[0]));
            binaryMethods[">="] = new FunctionalMethod((obj, args) => ObjectOperators.GreaterEqual(obj, args[0]));
            binaryMethods["="] = new FunctionalMethod((obj, args) => ObjectOperators.Equals(obj, args[0]));
            binaryMethods["~="] = new FunctionalMethod((obj, args) => !ObjectOperators.Equals(obj, args[0]));
            binaryMethods["=="] = new FunctionalMethod((obj, args) => ObjectOperators.Same(obj, args[0]));
            binaryMethods["~~"] = new FunctionalMethod((obj, args) => !ObjectOperators.Same(obj, args[0]));
        }

        public static object NewObject(Type type, object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        public static object SendNativeMessage(object obj, string mthname, object[] args)
        {
            if (args != null && args.Length == 1 && binaryMethods.ContainsKey(mthname))
            {
                IMethod binmethod = binaryMethods[mthname];
                return binmethod.ExecuteNative(obj, args);
            }

            // TODO support for indexed properties
            Type type = obj.GetType();

            if (args != null && args.Length > 0)
            {
                PropertyInfo prop = type.GetProperty(mthname, System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (prop != null)
                    return type.InvokeMember(mthname, System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
            }

            try
            {
                return obj.GetType().InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, obj, args);
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public static object SendNativeStaticMessage(Type type, string mthname, object[] args)
        {
            try
            {
                return type.InvokeMember(mthname, System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, null, null, args);
            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public static object SendMessage(Machine machine, object obj, string msgname, object[] args)
        {
            NativeBehavior behavior = machine.GetNativeBehavior(obj.GetType());

            if (behavior != null)
            {
                IMethod mth = behavior.GetInstanceMethod(msgname);

                if (mth != null)
                    return mth.ExecuteNative(obj, args);
            }

            string mthname = msgname;
            int p = msgname.IndexOf(":");

            if (p > 0)
                mthname = msgname.Substring(0, p);
            else
                mthname = msgname;

            if (obj is bool)
            {
                behavior = machine.GetNativeBehavior(typeof(bool));
                IMethod mth = behavior.GetInstanceMethod(msgname);

                if (mth != null)
                    return mth.ExecuteNative(obj, args);
            }

            if (obj is Type)
            {
                if (msgname == "new" || msgname.StartsWith("new:"))
                    return NewObject((Type)obj, args);
                return SendNativeStaticMessage((Type)obj, mthname, args);
            }

            behavior = machine.GetNativeBehavior(obj.GetType());

            if (behavior != null)
            {
                IMethod mth = behavior.GetInstanceMethod(msgname);

                if (mth != null)
                    return mth.ExecuteNative(obj, args);
            }

            if (obj is IEnumerable)
            {
                behavior = machine.GetNativeBehavior(typeof(IEnumerable));
                IMethod mth = behavior.GetInstanceMethod(msgname);

                if (mth != null)
                    return mth.ExecuteNative(obj, args);
            }

            // TODO how to use doesNotUnderstand in native behavior
            // mth = behavior.GetInstanceMethod("doesNotUnderstand:");
            // if (mth != null)
            //    return mth.ExecuteNative(obj, new object[] { msgname, args });
            return SendNativeMessage(obj, mthname, args);
        }
    }
}
