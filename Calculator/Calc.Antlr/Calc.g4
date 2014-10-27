grammar Calc;

/*
 * Parser Rules
 */
expr
    :    expr OP_MUL expr   # BinaryOperation
    |    expr OP_SUM expr   # BinaryOperation
    |    value              # Int
    |    LP expr RP         # Parens
    ;

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

//INT: DIGIT+; // match 1 2 23 etc
FLOAT
    : DIGIT+ '.' DIGIT* // match 0.2 1.5
    | '.'? DIGIT+;       // match .2 23
fragment DIGIT: [0-9];

OP_MUL: [/*];
OP_SUM: [+-];