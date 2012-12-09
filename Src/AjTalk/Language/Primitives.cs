namespace AjTalk.Language
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Primitives
    {
        public static void RaiseException(Exception ex)
        {
            throw ex;
        }

        public static object GetDictionaryValue(IDictionary dictionary, object key)
        {
            return dictionary[key];
        }

        public static void SetDictionaryValue(IDictionary dictionary, object key, object value)
        {
            dictionary[key] = value;
        }
    }
}
