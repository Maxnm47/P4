grammar UCM;
// Add a start rule for testing
start: expr;

// for expressions
ASSIGN: '=';
IF: 'if';
ELSE: 'else';
WHILE: 'while';
RETURN: 'return';


// Expressions
expr: boolExpr | numExpr;

numExpr: 
    NUM
    | MINUS numExpr
    | numExpr (MULT | DIV | MOD)numExpr 
    | numExpr (PLUS | MINUS) numExpr 
    | LPAREN numExpr RPAREN
    ;
boolExpr:
    BOOL
    | NOT expr
    | numExpr compExpr numExpr
    | boolExpr EQ boolExpr
    | boolExpr AND boolExpr
    | boolExpr OR boolExpr
    ;

compExpr: 
    GT
    | LT
    | GTE
    | LTE
    | EQ
    | NEQ
    ;
    

//operators
MULT: '*';
DIV: '/';
PLUS: '+';
MINUS: '-';
MOD: '%';
AND: '&&';
OR: '||';
EQ: '==';
NEQ: '!=';
GT: '>';
LT: '<';
GTE: '>=';
LTE: '<=';
NOT: '!';



// Types
type: INT_T | FLOAT_T | STRING_T | BOOL_T;

NUM: INT | FLOAT;
INT_T: 'int';
FLOAT_T: 'float';
STRING_T: 'string';
BOOL_T: 'bool';


INT: [0-9]+;
FLOAT: [0-9]*'.'[0-9]+ | [0-9]+'.'[0-9]*;

//strings
STRING : '\'' STRING_BODY '\'' | '"' STRING_BODY '"';
fragment STRING_BODY:  ( ESCAPE_SEQUENCE | . )*? ;

ESCAPE_SEQUENCE: '\\' ( ('\\' | '\'' | '"') | UNICODE_ESCAPE ) ;

UNICODE_ESCAPE: 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT ;

fragment HEX_DIGIT: [0-9a-fA-F] ;

BOOL: 'true' | 'false';

// White space and comments
WS: [ \t\r\n]+ -> skip;

COMMENT
    :   (BLOCK_COMMENT|'#' ~[\r\n]*) -> skip
    ;

fragment BLOCK_COMMENT
    :   '##' .*? '##';

// Symbols
QUESTION: '?';
LPAREN: '(';
RPAREN: ')';
LCURLY: '{';
RCURLY: '}';
SEMI: ';';
COMMA: ',';
COLON: ':';
