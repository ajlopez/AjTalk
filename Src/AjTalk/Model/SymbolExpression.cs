namespace AjTalk.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SymbolExpression : IExpression
    {
        private string symbol;

        public SymbolExpression(string symbol)
        {
            this.symbol = symbol;
        }

        public string Symbol { get { return this.symbol; } }

        public string AsString()
        {
            return "#" +this.symbol;
        }

        public void Visit(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
