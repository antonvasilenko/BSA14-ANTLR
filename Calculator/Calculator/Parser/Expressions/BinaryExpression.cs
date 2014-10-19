using System;
using System.Text;

namespace Calculator.Parser.Expressions
{
    public enum BinaryOperator
    {
        Add,
        Substract,
        Multiply,
        Divide
    }

    public class BinaryExpression : Expression
    {
        public override ExpressionKind Kind { get { return ExpressionKind.Binary; } }

        public Expression Left { get; private set; }
        public Expression Right { get; private set; }
        public BinaryOperator Operator { get; private set; }

        public BinaryExpression(Expression left, Expression right, BinaryOperator op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }

        public override int Evaluate()
        {
            var left = Left.Evaluate();
            var right = Right.Evaluate();
            switch (Operator)
            {
                case BinaryOperator.Add:
                    return left + right;
                case BinaryOperator.Substract:
                    return left - right;
                case BinaryOperator.Multiply:
                    return left * right;
                case BinaryOperator.Divide:
                    return (left / right);
            }
            throw new InvalidOperationException("binary evaluation failed");
        }

        public override void ToString(StringBuilder builder)
        {
            builder.Append("(");
            Left.ToString(builder);
            builder.Append(' ');
            switch (Operator)
            {
                case BinaryOperator.Add:
                    builder.Append('+');
                    break;
                case BinaryOperator.Substract:
                    builder.Append('-');
                    break;
                case BinaryOperator.Multiply:
                    builder.Append('*');
                    break;
                case BinaryOperator.Divide:
                    builder.Append('/');
                    break;
            }
            builder.Append(' ');
            Right.ToString(builder);
            builder.Append(")");
        }
    }
}