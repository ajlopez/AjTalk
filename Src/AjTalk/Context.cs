namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Context
    {
        private IDictionary<string, object> values = new Dictionary<string, object>();

        public object GetValue(string name)
        {
            if (!values.ContainsKey(name))
                return null;

            return values[name];
        }

        public void SetValue(string name, object value)
        {
            values[name] = value;
        }

        public bool HasValue(string name)
        {
            return values.ContainsKey(name);
        }
    }
}
