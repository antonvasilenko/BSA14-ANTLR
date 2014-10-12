using System.Text;

namespace Calculator.Expressions
{
    public enum ExpressionKind
    {
        Binary,
        Value
    }

    public enum BinaryOperator
    {
        Add,
        Substract,
        Multiply,
        Divide
    }

    public abstract class Expression
    {
        public abstract ExpressionKind Kind { get; }
        public abstract int Evaluate();
        public abstract void ToString(StringBuilder builder);

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToString(sb);
            return sb.ToString();
        }
    }
}