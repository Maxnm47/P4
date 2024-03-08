grammar Math;

// Parser rules
expr:   expr ('*' | '/') expr
    |   expr ('+' | '-') expr
    |   INT
    ;

// Lexer rules
INT :   [0-9]+ ;
WS  :   [ \t\r\n]+ -> skip ;
