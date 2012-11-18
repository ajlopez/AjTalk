namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class ConstantExpression : IExpression
    {
        private object value;

        public ConstantExpression(object value)
        {
            this.value = value;
        }

        public object Value { get { return this.value; } }

        public string AsString()
        {
            if (this.value == null)
                return "nil";
            //// TODO Escape chars
            if (this.value is string)
                return string.Format("'{0}'", NormalizeString((string)this.value));
            if (this.value is char)
                return string.Format("${0}", this.value);
            if (this.value.Equals(false))
                return "false";
            if (this.value.Equals(true))
                return "true";

            return Convert.ToString(this.value, CultureInfo.InvariantCulture);

            ////return this.value.ToString();
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        private static string NormalizeString(string text)
        {
            text = text.Replace("\r", "\\r");
            text = text.Replace("\n", "\\n");
            text = text.Replace("'", "\\'");
            return text;
        }
    }
}
