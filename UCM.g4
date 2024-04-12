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
FUNCTIONS_KEYWORD: 'methods';
EXTENDS_KEYWORD: 'extends';
THIS_KEYWORD: 'this';
NULL: 'null';

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
DOT: '.';
COMMA: ',';
COLON: ':';
NEWLINE: '\n';
ASSIGN: '=';
QUOTE: '"';
DOLLAR: '$';

// Types
INT_T: 'int';
FLOAT_T: 'float';
STRING_T: 'string';
BOOL_T: 'bool';
VOID_T: 'void';
object_t: OBJECT_KEYWORD | ID;
array_t: (primitiveType | object_t) (LBRACKET RBRACKET)+;

primitiveType: INT_T | FLOAT_T | BOOL_T | VOID_T;
complexType: object_t | array_t | STRING_T;
type: primitiveType | complexType;

// Values
BOOL: 'true' | 'false';
INT: MINUS? [0-9]+;
FLOAT: MINUS? ([0-9]* '.' [0-9]+ | [0-9]+ '.' [0-9]*);
int: INT;
float: FLOAT;
num: int | float;
value:
	num
	| augmentedString
	| concatanatedString
	| string
	| BOOL
	| object
	| array
	| NULL;

augmentedString:
	DOLLAR QUOTE (
		( ESCAPE_SEQUENCE | .)? ( LCURLY expr RCURLY)
		| ( ESCAPE_SEQUENCE | .) ( LCURLY expr RCURLY)?
	)* QUOTE;
concatanatedString: string (PLUS string)*;

string: QUOTE ( ESCAPE_SEQUENCE | .)*? QUOTE;

fragment STRING_BODY: ( ESCAPE_SEQUENCE | .)*?;
ESCAPE_SEQUENCE: '\\' (('\\' | '\'' | '"') | UNICODE_ESCAPE);
fragment UNICODE_ESCAPE:
	'u' HEX_DIGIT HEX_DIGIT HEX_DIGIT HEX_DIGIT;
fragment HEX_DIGIT: [0-9a-fA-F];

// Identifiers
ID: [a-zA-Z_][a-zA-Z_0-9]*;
id: ID;
typedId: type id; //maybe replace all with the right hand side.

// Objects
adapting: id;
object: adapting? LCURLY field* RCURLY;
field: HIDDEN_? type? id ASSIGN expr SEMI;

// Arrays
array:
	LBRACKET (expr (COMMA expr)* | listConstruction |) RBRACKET;

// Templates
evaluaterArray:
	LBRACKET ((boolExpr | id) (COMMA (boolExpr | id))* |) RBRACKET;

templateField:
	typedId (ASSIGN value)? (COLON evaluaterArray)? SEMI;
templateExtention: EXTENDS_KEYWORD id;
templateDefenition:
	TEMPLATE_KEYWORD id templateExtention? LCURLY (
		templateField
		| method
	)* RCURLY SEMI;

// Functions
functionCollection:
	FUNCTIONS_KEYWORD id LCURLY method* RCURLY SEMI;

// Methods
method:
	typedId LPAREN (typedId (COMMA typedId)* |) RPAREN LCURLY statementList RCURLY SEMI;
functionCollectionCall: id DOT;
methodCall:
	functionCollectionCall? id LPAREN (expr (COMMA expr)* |) RPAREN;

// Expressions
expr:
	value
	| id
	| methodCall
	| boolExpr
	| expr EQ expr // This to avoid left recursion
	| numExpr;

numExpr:
	num
	| THIS_KEYWORD // this  may ruin everything in the semantics :)))
	| id
	| methodCall
	| MINUS numExpr
	| numExpr (MULT | DIV | MOD) numExpr
	| numExpr (PLUS | MINUS) numExpr
	| LPAREN numExpr RPAREN;

boolExpr:
	BOOL
	| THIS_KEYWORD // this  may ruin everything in the semantics :)))
	| id
	| methodCall
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
whileLoop:
	WHILE LPAREN boolExpr RPAREN LCURLY statement RCURLY SEMI;

// For loop
forLoop:
	FOR LPAREN id IN (array | methodCall) RPAREN LCURLY statement RCURLY SEMI;

// List construction
listConstruction:
	FOR LPAREN id IN (array | methodCall) RPAREN LCURLY value RCURLY;

//return
return: RETURN expr SEMI;
// Statements
statementList: statement*;

statement:
	conditional
	| assignment
	| whileLoop
	| forLoop
	| methodCall SEMI
	| method
	| field
    | return;

assignment: type? id ASSIGN expr SEMI;

// Add a start rule for testing
root: (
		templateDefenition
		| functionCollection
		| field
	)*;
