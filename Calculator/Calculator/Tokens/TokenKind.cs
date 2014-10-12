﻿namespace Calculator.Tokens
{
    public enum TokenKind
    {
        Whitespace,
        Number,
        OpAdd,
        OpSubs,
        OpMultiply,
        OpDivide,
        OpenParenthesis,
        CloseParenthesis,
        Eof
    }
}