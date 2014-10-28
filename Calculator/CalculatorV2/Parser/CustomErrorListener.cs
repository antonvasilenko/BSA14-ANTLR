using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV2.Parser
{
    class CustomErrorListener: BaseErrorListener
    {
        private List<string> _errors = new List<string>();

        public List<String> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var errorText = string.Format("Error at position [{0}:{1}] : {2}", line, charPositionInLine, msg);
            Errors.Add(errorText);
            Console.WriteLine(errorText);
            UnderlineError(recognizer, (IToken)offendingSymbol, line, charPositionInLine);
        }

        private void UnderlineError(IRecognizer recognizer, IToken offendingToken, int line, int charPositionInLine)
        {
            var tokens = (CommonTokenStream)recognizer.InputStream;
            var input = tokens.TokenSource.InputStream.ToString();
            var lines = input.Split('\n');
            var errorLine = lines[line - 1];

            Console.Write(errorLine.Substring(0, charPositionInLine));
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(errorLine.Substring(charPositionInLine, offendingToken.StopIndex - offendingToken.StartIndex + 1));
            Console.ForegroundColor = prevColor;
            Console.WriteLine(errorLine.Substring(charPositionInLine + offendingToken.StopIndex - offendingToken.StartIndex + 1));
            Console.WriteLine();
        }
    }
}
