grammar Calc;

@members {
  private bool isZero(string text)
  {
     var number = System.Double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
     return number == 0;
  }
}
/*
 * Parser Rules
 */
expr
    :    expr OP_DIV zero_value { System.Console.WriteLine("division by zero") } #BinaryOperation
    |    expr OP_PR1 expr   # BinaryOperation
    |    expr OP_SUM expr   # BinaryOperation
    |    value              # Int
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

//INT: DIGIT+; // match 1 2 23 etc
FLOAT
    : DIGIT+ '.' DIGIT* // match 0.2 1.5
    | '.'? DIGIT+;       // match .2 23
fragment DIGIT: [0-9];
ZERO
    : '0'+ '.' '0'*
    | '.'? '0'+;

OP_PR1: OP_DIV | OP_MUL;
OP_SUM: [+-];


OP_DIV: '/';
OP_MUL: '*';