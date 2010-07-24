namespace AjTalk.Language
{
    using System;

    public interface IIndexedObject : IObject
    {
        int BasicSize { get; }

        void SetIndexedValue(int nposition, object value);

        object GetIndexedValue(int nposition);
    }
}
