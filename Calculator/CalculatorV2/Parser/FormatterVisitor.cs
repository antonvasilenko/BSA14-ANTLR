using System;
using CalculatorV2.Parser.Calc.Antlr;

namespace CalculatorV2.Parser
{
    class FormatterVisitor : CalcBaseVisitor<string>
    {
        public override string VisitValue(CalcParser.ValueContext context)
        {
            var text = context.INT().GetText();
            return text;
        }
    }

    class EvaluatorVisitor : CalcBaseVisitor<int>
    {

        public override int VisitValue(CalcParser.ValueContext context)
        {
            var number = int.Parse(context.INT().GetText());
            var op = context.OP_SUM();
            if (op != null && op.GetText() == "-")
            {
                number = 0 - number;
            }
            return number;
        }

        public override int VisitAddSub(CalcParser.AddSubContext context)
        {
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            var opText = context.OP_SUM().GetText();
            if (opText == "+")
                return left + right;
            if (opText == "-")
                return left - right;
            throw new FormatException("wrong operation, expected '+', '-'");
        }

        public override int VisitMulDiv(CalcParser.MulDivContext context)
        {
            var left = Visit(context.expr(0));
            var right = Visit(context.expr(1));
            var opText = context.OP_MUL().GetText();
            if (opText == "*")
                return left * right;
            if (opText == "/")
                return left / right;
            throw new FormatException("wrong operation, expected '*', '/'");
        }

        public override int VisitParens(CalcParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
