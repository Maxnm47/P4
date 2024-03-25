grammar UCM;

// Add a start rule for testing
start: object;

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
	| numExpr (MULT | DIV | MOD) numExpr
	| numExpr (PLUS | MINUS) numExpr
	| LPAREN numExpr RPAREN;
boolExpr:
	BOOL
	| NOT expr
	| numExpr compExpr numExpr
	| boolExpr EQ boolExpr
	| boolExpr AND boolExpr
	| boolExpr OR boolExpr;

compExpr: GT | LT | GTE | LTE | EQ | NEQ;

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
TYPE: PRIMITIVE_TYPE | COMPLEX_TYPE;
PRIMITIVE_TYPE: INT_T | FLOAT_T | STRING_T | BOOL_T;
COMPLEX_TYPE: OBJECT_T | ARRAY_T;

VALUE: NUM | STRING | BOOL | OBJECT | ARRAY;

NUM: INT | FLOAT;
INT_T: 'int';
FLOAT_T: 'float';
STRING_T: 'string';
BOOL_T: 'bool';
OBJECT_T: 'object'; // FIX LATER
ARRAY_T: (PRIMITIVE_TYPE | OBJECT_T) (LBRACKET RBRACKET)+;

BOOL: 'true' | 'false';

INT: [0-9]+;
FLOAT: [0-9]* '.' [0-9]+ | [0-9]+ '.' [0-9]*;

//strings
STRING: '"' STRING_BODY '"';
fragment STRING_BODY: ( ESCAPE_SEQUENCE | .)*?;

ESCAPE_SEQUENCE: '\\' ( ('\\' | '\'' | '"') | UNICODE_ESCAPE);

UNICODE_ESCAPE: 'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT;

fragment HEX_DIGIT: [0-9a-fA-F];

// White space and comments
WS: [ \t\r\n]+ -> skip;

COMMENT: (BLOCK_COMMENT | LINE_COMMENT) -> skip;

fragment LINE_COMMENT: '#' ~[\r\n]*;

fragment BLOCK_COMMENT: '##' .*? '##';

// Symbols
QUESTION: '?';
LPAREN: '(';
RPAREN: ')';
LCURLY: '{';
RCURLY: '}';
LBRACKET: '[';
RBRACKET: ']';
SEMI: ';';
COMMA: ',';
COLON: ':';
NEWLINE: '\n';

ID: [a-zA-Z_][a-zA-Z_0-9]*;

OBJECT: LCURLY (FIELD)* RCURLY;

object: LCURLY (FIELD)* RCURLY;

FIELD: TYPE? ID ASSIGN VALUE;

ARRAY:
	LBRACKET VALUE (COMMA VALUE)* RBRACKET
	| LBRACKET RBRACKET;

typedDeclaration: TYPE ID ASSIGN (expr | VALUE);

declaration: ID ASSIGN VALUE;

//hiddenDeclaration: 'hidden' (typedDeclaration | declaration);