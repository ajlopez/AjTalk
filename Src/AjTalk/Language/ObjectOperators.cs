using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace AjTalk.Language
{
    public class ObjectOperators
    {
        public static object Add(object obj1, object obj2)
        {
            if (!IsNumber(obj1) || !IsNumber(obj2))
                return Operators.ConcatenateObject(obj1, obj2);

            return Operators.AddObject(obj1, obj2);
        }

        public static object Substract(object obj1, object obj2)
        {
            return Operators.SubtractObject(obj1, obj2);
        }

        public static object Multiply(object obj1, object obj2)
        {
            return Operators.MultiplyObject(obj1, obj2);
        }

        public static object Divide(object obj1, object obj2)
        {
            return Operators.DivideObject(obj1, obj2);
        }

        public static object Less(object obj1, object obj2)
        {
            return Operators.CompareObjectLess(obj1, obj2, false);
        }

        public static object LessEqual(object obj1, object obj2)
        {
            return Operators.CompareObjectLessEqual(obj1, obj2, false);
        }

        public static object Greater(object obj1, object obj2)
        {
            return Operators.CompareObjectGreater(obj1, obj2, false);
        }

        public static object GreaterEqual(object obj1, object obj2)
        {
            return Operators.CompareObjectGreaterEqual(obj1, obj2, false);
        }

        public static object Equals(object obj1, object obj2)
        {
            return Operators.Equals(obj1, obj2);
        }

        public static object IntDivide(object obj1, object obj2)
        {
            return Operators.IntDivideObject(obj1, obj2);
        }

        public static object Mod(object obj1, object obj2)
        {
            return Operators.ModObject(obj1, obj2);
        }

        public static bool IsNumber(object obj)
        {
            if (obj == null)
                return false;
            if (obj is short || obj is int || obj is long || obj is float || obj is double || obj is decimal)
                return true;
            return false;
        }
    }
}
