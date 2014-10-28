using System;
using CalculatorV2.Parser.Calc.Antlr;
using System.Globalization;

namespace CalculatorV2.Parser
{
    class EvaluatorVisitor : CalcBaseVisitor<double>
    {
        public override double VisitValue(CalcParser.ValueContext context)
        {
            var text = context.FLOAT().GetText();
            var number = Double.Parse(text, CultureInfo.InvariantCulture);
            var op = context.OP_SUM();
            if (op != null && op.GetText() == "-")
            {
                number = 0 - number;
            }
            return number;
        }

        public override double VisitBinaryOperation(CalcParser.BinaryOperationContext context)
        {
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            var op = context.OP_PR1() ?? context.OP_SUM();
            var opText = op.GetText();
            if (opText == "+")
                return left + right;
            if (opText == "-")
                return left - right;
            if (opText == "*")
                return left * right;
            if (opText == "/")
                if (Math.Abs(right) > 0.0000001)
                    return left / right;
                else
                {
                    throw new DivideByZeroException();
                }
            throw new FormatException("wrong operation, expected '+', '-', '*', '/'");
        }

        public override double VisitParens(CalcParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
