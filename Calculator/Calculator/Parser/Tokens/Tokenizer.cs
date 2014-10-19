using System;

namespace Calculator.Parser.Tokens
{
    internal class Tokenizer
    {
        private string _data;

        public TokenKind TokenKind { get; private set; }

        public string TokenValue { get; private set; }

        public int Index { get; private set; }


        public Tokenizer(string data)
        {
            Index = 0;
            _data = data + (char)0;
            Next();
        }

        public void Next()
        {
            do
            {
                internalNext();
            } while (TokenKind == TokenKind.Whitespace);
        }

        private void internalNext()
        {
            var singleTokens = "()+-*/";
            int curIdx;
            int curLen = 0;
            var curChar = _data[Index];

            if (Char.IsWhiteSpace(curChar))
            {
                curIdx = Index + 1;
                while (Char.IsWhiteSpace(_data[curIdx]))
                    curIdx++;
                TokenKind = TokenKind.Whitespace;
                curLen = curIdx - Index;
            }
            else if (Char.IsNumber(curChar))
            {
                curIdx = Index + 1;
                while (Char.IsNumber(_data[curIdx]))
                    curIdx++;
                TokenKind = TokenKind.Number;
                curLen = curIdx - Index;
            }
            else if (singleTokens.IndexOf(curChar) >= 0)
            {
                switch (curChar)
                {
                    case '(':
                        TokenKind = TokenKind.OpenParenthesis;
                        break;
                    case ')':
                        TokenKind = TokenKind.CloseParenthesis;
                        break;
                    case '+':
                        TokenKind = TokenKind.OpAdd;
                        break;
                    case '-':
                        TokenKind = TokenKind.OpSubs;
                        break;
                    case '*':
                        TokenKind = TokenKind.OpMultiply;
                        break;
                    case '/':
                        TokenKind = TokenKind.OpDivide;
                        break;
                }
                curLen = 1;
            }
            else if (curChar == 0)
            {
                TokenKind = TokenKind.Eof;
                curLen = 0;
            }
            else
            {
                throw new FormatException(string.Format("Invalid char {0} at {1}", curChar, Index));
            }
            TokenValue = _data.Substring(Index, curLen);
            Index += curLen;
        }
    }
}