using System;
using Calculator.Parser.Expressions;
using Calculator.Parser.Tokens;

namespace Calculator.Parser
{
    internal class Parser
    {
        public Expression Parse(Tokenizer t)
        {
            // my priorities (low to high)
            // addition -> multiply -> value()
            return parseExpression(t);
        }

        private static Expression parseExpression(Tokenizer t)
        {
            return parseAdditionExpression(t);
        }

        private static Expression parseAdditionExpression(Tokenizer t)
        {
            var left = parseMultiplyExpression(t);

            while (true)
            {
                BinaryOperator op;
                switch (t.TokenKind)
                {
                    case TokenKind.OpAdd:
                        op = BinaryOperator.Add;
                        break;
                    case TokenKind.OpSubs:
                        op = BinaryOperator.Substract;
                        break;
                    default:
                        return left;
                }
                t.Next();
                var right = parseMultiplyExpression(t);
                left = new BinaryExpression(left, right, op);
            }
        }

        private static Expression parseMultiplyExpression(Tokenizer t)
        {
            // 2*3*6
            var left = parseValueExpression(t);
            while (true)
            {
                BinaryOperator op;
                switch (t.TokenKind)
                {
                    case TokenKind.OpMultiply:
                        op = BinaryOperator.Multiply;
                        break;
                    case TokenKind.OpDivide:
                        op = BinaryOperator.Divide;
                        break;
                    default:
                        return left;
                }
                t.Next();

                var right = parseValueExpression(t);
                left = new BinaryExpression(left, right, op);
            }

        }

        private static Expression parseValueExpression(Tokenizer t)
        {
            Expression result = null;
            switch (t.TokenKind)
            {
                case TokenKind.Number:
                    result = new ValueExpression(t.TokenValue);
                    t.Next();
                    break;
                case TokenKind.OpenParenthesis:
                    t.Next();
                    result = parseExpression(t);
                    if (t.TokenKind != TokenKind.CloseParenthesis)
                        throw new FormatException("parser: syntax error at " + t.Index);
                    t.Next();
                    break;
                default:
                    throw new FormatException("parser: syntax error at " + t.Index);
            }
            return result;
        }
    }
}