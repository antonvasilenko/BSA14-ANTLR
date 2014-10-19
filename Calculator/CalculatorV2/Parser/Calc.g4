grammar Calc;

/*
 * Parser Rules
 */
expr:    expr OP_SUM expr
    |    expr OP_MUL expr
    |    LP expr RP
    |    value;

value: OP_SUM? INT;

entry: expr | EOF;

/*
 * Lexer Rules
 */

WS: [\t\n\r]+ -> skip;
LP: '(';
RP: ')';

INT: DIGIT+; // match 1 2 23 etc
fragment DIGIT: [0-9];

OP_MUL: [/*];
OP_SUM: [+-];