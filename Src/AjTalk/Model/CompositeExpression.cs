﻿namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CompositeExpression : IExpression
    {
        private IEnumerable<IExpression> expressions;

        public CompositeExpression(IEnumerable<IExpression> expressions)
        {
            this.expressions = expressions;
        }

        public string AsString()
        {
            string result = "";

            foreach (IExpression expression in this.expressions)
            {
                if (result != "")
                    result += ". ";

                result += expression.AsString();
            }

            return result;
        }
    }
}
