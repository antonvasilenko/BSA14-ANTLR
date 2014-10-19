grammar Calc;

/*
 * Parser Rules
 */
expr
    :    expr OP_MUL expr   # MulDiv
    |    expr OP_SUM expr   # AddSub
    |    value              # Int
    |    LP expr RP         # Parens
    ;

value: OP_SUM? INT;

entry: expr | EOF;

/*
 * Lexer Rules
 */

WS  
    : [ \t\n\r]+ -> skip
    ;
LP: '(';
RP: ')';

INT: DIGIT+; // match 1 2 23 etc
fragment DIGIT: [0-9];

OP_MUL: [/*];
OP_SUM: [+-];