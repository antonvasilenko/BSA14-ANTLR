using System;
using System.Globalization;
using Antlr4.Runtime;
using CalculatorV2.Parser;
using CalculatorV2.Parser.Calc.Antlr;

namespace CalculatorV2
{
    public class Calculator
    {
        private readonly IAntlrErrorListener<IToken> _errorListener;
        public bool Debug { get; private set; }

        public Calculator(bool debug = false, IAntlrErrorListener<IToken> errorListener = null)
        {
            _errorListener = errorListener ?? new CustomErrorListener();
            Debug = debug;
        }

        public string Calculate(string inputString)
        {
            if (Debug)
            {
                var streamDebug = new AntlrInputStream(inputString);
                var lexerDebug = new CalcLexer(streamDebug);
                foreach (var token in lexerDebug.GetAllTokens())
                {
                    Console.WriteLine("{0} ({1})", token.Text, token.Type);
                }
            }

            var stream = new AntlrInputStream(inputString);
            var lexer = new CalcLexer(stream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new CalcParser(tokenStream);

            parser.RemoveErrorListeners();
            parser.AddErrorListener(_errorListener);
            var tree = parser.entry();
            var result = tree.Accept(new EvaluatorVisitor());
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}