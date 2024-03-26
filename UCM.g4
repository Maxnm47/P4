grammar UCM;

// Comments and white space
WS: [ \t\r\n]+ -> skip;
COMMENT: (BLOCK_COMMENT | LINE_COMMENT) -> skip;
fragment LINE_COMMENT: '#' ~[\r\n]*;
fragment BLOCK_COMMENT: '##' .*? '##';

// key words
IF: 'if';
ELSE: 'else';
WHILE: 'while';
FOR: 'for';
RETURN: 'return';
TEMPLATE_KEYWORD: 'template';
IN: 'in';
HIDDEN_: 'hidden';
OBJECT_KEYWORD: 'object';
FUNCTIONS_KEYWORD: 'functions';

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
ASSIGN: '=';
QUOTE: '"';

// Types
INT_T: 'int';
FLOAT_T: 'float';
STRING_T: 'string';
BOOL_T: 'bool';
object_t: OBJECT_KEYWORD | ID;
array_t: (primitiveType | object_t) (LBRACKET RBRACKET)+;

primitiveType: INT_T | FLOAT_T | BOOL_T;
complexType: object_t | array_t | STRING_T;
type: primitiveType | complexType;

// Values
BOOL: 'true' | 'false';
INT: [0-9]+;
FLOAT: [0-9]* '.' [0-9]+ | [0-9]+ '.' [0-9]*;
num: INT | FLOAT;
value: num | STRING | BOOL | object | array;

STRING: QUOTE STRING_BODY QUOTE;
fragment STRING_BODY: ( ESCAPE_SEQUENCE | .)*?;
fragment ESCAPE_SEQUENCE:
	'\\' (('\\' | '\'' | '"') | UNICODE_ESCAPE);
fragment UNICODE_ESCAPE:
	'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT;
fragment HEX_DIGIT: [0-9a-fA-F];

// Identifiers
ID: [a-zA-Z_][a-zA-Z_0-9]*;
typedId: type ID;

// Objects
object: ID? LCURLY field* RCURLY;
field: HIDDEN_? type? ID ASSIGN expr SEMI;

// Arrays
array:
	LBRACKET (value (COMMA value)* | listConstruction |) RBRACKET;

// Templates
templateField: typedId (ASSIGN value)? SEMI;
templateDefenition:
	TEMPLATE_KEYWORD ID LCURLY (templateField | method)* RCURLY SEMI;

// Functions
functionCollection: FUNCTIONS_KEYWORD ID LCURLY method* RCURLY;

// Methods
method:
	typedId LPAREN (typedId (COMMA typedId)* |) RPAREN LCURLY statementList RCURLY;
methodCall: ID LPAREN (expr (COMMA expr)* |) RPAREN;

// Expressions
expr: value | ID | boolExpr | numExpr | methodCall;

numExpr:
	num
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

// Condtionals structure
ifStatement: IF LPAREN boolExpr RPAREN LCURLY statement RCURLY;
conditional: ifStatement (ELSE ifStatement)* (ELSE statement)?;

// While loop
whileLoop: WHILE LPAREN boolExpr RPAREN LCURLY statement RCURLY;

// For loop
forLoop:
	FOR LPAREN ID IN (array | methodCall) LCURLY statement RCURLY;

// List construction
listConstruction:
	FOR LPAREN ID IN (array | methodCall) RPAREN LCURLY object RCURLY;

// Statements
statementList: statement*;

statement:
	conditional
	| assignment
	| whileLoop
	| forLoop
	| methodCall
	| method
	| RETURN expr SEMI;

assignment: HIDDEN_? type? ID ASSIGN expr SEMI;
objectDefenition: HIDDEN_? object_t ID ASSIGN object SEMI;
arrayDefenition: HIDDEN_? array_t ID ASSIGN array SEMI;
declaration: typedId SEMI;

// Add a start rule for testing
root: (
		templateDefenition
		| objectDefenition
		| arrayDefenition
		| functionCollection
		| field
	)*;

start: root;