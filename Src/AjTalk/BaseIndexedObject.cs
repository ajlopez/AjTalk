namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BaseIndexedObject : BaseObject, IIndexedObject
    {
        private object[] indexedValues;

        public BaseIndexedObject()
        {
        }

        public BaseIndexedObject(IBehavior behavior, int nvars)
            : base(behavior, nvars)
        {
        }

        public BaseIndexedObject(IBehavior behavior, object[] vars)
            : base(behavior, vars)
        {
        }

        public object GetIndexedValue(int nposition)
        {
            if (nposition < 0)
                throw new ArgumentOutOfRangeException("nposition");

            if (this.indexedValues == null || this.indexedValues.Length <= nposition)
                return null;

            return this.indexedValues[nposition];
        }

        public void SetIndexedValue(int nposition, object value)
        {
            if (nposition < 0)
                throw new ArgumentOutOfRangeException("nposition");

            if (this.indexedValues == null)
                this.indexedValues = new object[nposition + 1];
            else if (this.indexedValues.Length <= nposition)
            {
                object[] newValues = new object[nposition + 1];
                Array.Copy(this.indexedValues, newValues, this.indexedValues.Length);
                this.indexedValues = newValues;
            }

            this.indexedValues[nposition] = value;
        }

        public int BasicSize
        {
            get
            {
                if (this.indexedValues == null)
                    return 0;

                return this.indexedValues.Length;
            }
        }
    }
}
