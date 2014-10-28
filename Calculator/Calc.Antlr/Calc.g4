grammar Calc;

@parser::members{
private void zeroDetected()
{
    throw new System.InvalidOperationException("division by zero");
}
}

/*
 * Parser Rules
 */
expr
    :    expr OP_DIV zero_value { zeroDetected(); } #BinaryOperation
    |    expr OP_PR1 expr   # BinaryOperation
    |    expr OP_SUM expr   # BinaryOperation
    |    zero_value         # Number
    |    value              # Number
    |    LP expr RP         # Parens
    ;

zero_value: OP_SUM? ZERO;
value: OP_SUM? FLOAT;

entry: expr | EOF;

/*
 * Lexer Rules
 */

WS  
    : [ \t\n\r]+ -> skip
    ;
LP: '(';
RP: ')';

ZERO
    : '0'+ '.' '0'*
    | '.'? '0'+;

FLOAT
    : DIGIT+ '.' DIGIT* // match 0.2 1.5
    | '.'? DIGIT+;       // match .2 23
fragment DIGIT: [0-9];


OP_PR1: OP_DIV | OP_MUL;
OP_SUM: [+-];


OP_DIV: '/';
OP_MUL: '*';