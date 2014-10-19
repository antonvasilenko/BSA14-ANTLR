using System;
using System.Globalization;
using System.Text;
using Calculator.Parser.Expressions;
using Calculator.Parser.Tokens;

namespace Calculator
{
    public class Calculator
    {
        private string _input;

        public bool Debug { get; private set; }

        public Calculator(bool debug = false)
        {
            Debug = debug;
        }

        public string Calculate(string inputString)
        {
            _input = inputString;

            if (Debug)
            {
                var debugTokenizer = new Tokenizer(_input);
                while (debugTokenizer.TokenKind != TokenKind.Eof)
                {
                    Console.WriteLine("{0} ({1})", debugTokenizer.TokenValue, debugTokenizer.TokenKind);
                    debugTokenizer.Next();
                }
            }

            var tokenizer = new Tokenizer(_input);
            var parser = new Parser.Parser();
            Expression expr = parser.Parse(tokenizer);

            if (Debug)
            {
                Console.WriteLine("Input: {0}", _input);
                Console.WriteLine("Parsed: {0}", expr);
            }

            if (tokenizer.TokenKind != TokenKind.Eof)
                throw new FormatException("Invalid expression string");

            var result = expr.Evaluate().ToString(CultureInfo.InvariantCulture);
            return result;
        }
    }
}