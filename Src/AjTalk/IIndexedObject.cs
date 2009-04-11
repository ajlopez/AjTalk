namespace AjTalk
{
    using System;

    public interface IIndexedObject : IObject
    {
        void SetIndexedValue(int nposition, object value);

        object GetIndexedValue(int nposition);

        int BasicSize { get; }
    }
}
