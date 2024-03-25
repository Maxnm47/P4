grammar UCM;

// Add a start rule for testing
start: statementList;

// for expressions
ASSIGN: '=';
IF: 'if';
ELSE: 'else';
WHILE: 'while';
FOR: 'for';
RETURN: 'return';

ID: [a-zA-Z_][a-zA-Z_0-9]*;

// Expressions
expr: value | ID | boolExpr | numExpr | methodCall;

numExpr:
	NUM
	| ID
	| MINUS numExpr
	| numExpr (MULT | DIV | MOD) numExpr
	| numExpr (PLUS | MINUS) numExpr
	| LPAREN numExpr RPAREN;
boolExpr:
	BOOL
	| ID
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
TYPE:
	PRIMITIVE_TYPE
	| COMPLEX_TYPE
	| ID; // ID IS FUCKING UP HERE
PRIMITIVE_TYPE: INT_T | FLOAT_T | STRING_T | BOOL_T;
COMPLEX_TYPE: OBJECT_T | ARRAY_T;

value: NUM | STRING | BOOL | object | array;

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
TEMPLATE_KEYWORD: 'template';
IN: 'in';

object: LCURLY (field)* RCURLY;

field: TYPE? ID ASSIGN value SEMI;

typedId: TYPE ID;

method: typedId LPAREN typedId* RPAREN LCURLY statement RCURLY;

methodCall: ID LPAREN (expr (COMMA expr)* |) RPAREN;

// Condtionals structure
ifStatement: IF LPAREN boolExpr RPAREN LCURLY statement RCURLY;

conditional: ifStatement (ELSE ifStatement)* (ELSE statement)?;

// while loop
whileLoop: WHILE LPAREN boolExpr RPAREN LCURLY statement RCURLY;

// For loop
forLoop:
	FOR LPAREN ID IN (array | methodCall) LCURLY statement RCURLY;

statementList: statement*;

statement:
	conditional
	| assignment
	| whileLoop
	| forLoop
	| methodCall
	| method
	| RETURN expr SEMI;

array:
	LBRACKET value (COMMA value)* RBRACKET
	| LBRACKET RBRACKET;

assignment: (TYPE | ID)? ID ASSIGN expr SEMI; // TODO: find way to remove ID from here
declaration: typedId SEMI;

// Templates
templateField: typedId (ASSIGN value)? SEMI;

template:
	TEMPLATE_KEYWORD ID LCURLY (templateField | method)* RCURLY;