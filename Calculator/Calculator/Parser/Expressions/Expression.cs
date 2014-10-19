using System.Text;

namespace Calculator.Parser.Expressions
{
    public enum ExpressionKind
    {
        Binary,
        Value
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