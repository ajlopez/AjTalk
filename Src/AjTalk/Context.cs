namespace AjTalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Context
    {
        private IDictionary<string, object> values = new Dictionary<string, object>();
        private Context parent;

        public Context()
            : this(null)
        {
        }

        public Context(Context parent)
        {
            this.parent = parent;
        }

        public object GetValue(string name)
        {
            if (!values.ContainsKey(name))
            {
                if (this.parent != null)
                    return this.parent.GetValue(name);

                return null;
            }

            return values[name];
        }

        public void SetValue(string name, object value)
        {
            values[name] = value;
        }

        public bool HasValue(string name)
        {
            if (values.ContainsKey(name))
                return true;

            if (this.parent != null)
                return this.parent.HasValue(name);

            return false;
        }

        public ICollection<string> GetNames()
        {
            return values.Keys;
        }
    }
}
