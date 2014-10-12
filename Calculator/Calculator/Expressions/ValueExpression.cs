using System;
using System.Text;

namespace Calculator.Expressions
{
    public class ValueExpression : Expression
    {
        public override ExpressionKind Kind { get { return ExpressionKind.Value; } }

        public object Value { get; private set; }

        public ValueExpression(object value)
        {
            Value = value;
        }

        public override int Evaluate()
        {
            return Int32.Parse(Value.ToString());
        }

        public override void ToString(StringBuilder builder)
        {
            builder.Append(Value);
        }
    }
}