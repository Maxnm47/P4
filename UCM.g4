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
PLUSASSIGN: '+=';
MULTASSIGN: '*=';
DIVASSIGN: '/=';
MODASSIGN: '%=';
MINUSASSIGN: '-=';
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


augmentedString:
	STRING_START expr? (STRING_MIDDLE expr?)* STRING_END;
string: SIMPLE_STRING;



SIMPLE_STRING: '"' ~["\r\n]* '"' | '$"' ~["\r\n`]* '"';
STRING_START: '$"' ~["`]* '`';
STRING_MIDDLE: '´' ~["`]* '`';
STRING_END: '´' ~["`]* '"';
SPACES: [ \t\r\n]+ -> skip;

compoundasign:  PLUSASSIGN |MULTASSIGN | DIVASSIGN | MODASSIGN | MINUSASSIGN;

int: INT;
float: FLOAT;
num: int | float;

value:
	num
	| augmentedString
	| string
	| BOOL
	| object
	| array
	| NULL;

// Identifiers
ID: [a-zA-Z_][a-zA-Z_0-9]*;
id: ID;
argument: type id; //maybe replace all with the right hand side.

// Objects
adapting: id;
object: adapting? LCURLY field* RCURLY;
field: HIDDEN_? type? id (ASSIGN|compoundasign) expr SEMI;

// Arrays
array:
	LBRACKET (expr (COMMA expr)* | listConstruction |) RBRACKET;

arrayAccess:
	id LBRACKET expr RBRACKET;
// Templates
evaluaterArray:
	LBRACKET ((boolExpr | id) (COMMA (boolExpr | id))* |) RBRACKET;

templateField:
	type id (ASSIGN value)? (COLON evaluaterArray)? SEMI;
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

arguments: argument (COMMA argument)* |;
method:
	type id LPAREN arguments RPAREN LCURLY statementList RCURLY SEMI;

functionCollectionCall: id DOT;
methodCall:
	functionCollectionCall? id LPAREN (expr (COMMA expr)* |) RPAREN;

// Expressions
expr:
	value
	| id
	| arrayAccess
	| methodCall
	| boolExpr
	| expr EQ expr // This to avoid left recursion
	| numExpr
	| stringExpr;

stringExpr:
	stringExpr PLUS stringExpr
	| id
	| augmentedString
	| string;

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
ifStatement:
	IF LPAREN boolExpr RPAREN LCURLY statementList RCURLY;
conditional:
	ifStatement (ELSE ifStatement)* (
		ELSE LCURLY statementList RCURLY
	)?;

// While loop
whileLoop:
	WHILE LPAREN boolExpr RPAREN LCURLY statementList RCURLY SEMI;

// For loop
forLoop:
	FOR LPAREN id IN (array | methodCall) RPAREN LCURLY statementList RCURLY SEMI;

// List construction
listConstruction:
	FOR LPAREN id IN (array | methodCall) RPAREN LCURLY (expr|assignment) RCURLY SEMI;

//return
return_: RETURN expr? SEMI;
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
	| return_;

assignment: type? (id|arrayAccess) (ASSIGN|compoundasign) expr SEMI;

// Add a start rule for testing
root: ( templateDefenition | functionCollection | field)*;