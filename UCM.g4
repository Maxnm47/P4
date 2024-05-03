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
//THIS_KEYWORD: 'this';
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
array_t: (primitiveType | object_t | STRING_T |) (
		LBRACKET RBRACKET
	)+;

primitiveType: INT_T | FLOAT_T | BOOL_T | VOID_T;
complexType: object_t | array_t | STRING_T;
type: primitiveType | complexType;

// Values
BOOL: 'true' | 'false';
INT: [0-9]+;
FLOAT: ([0-9]* '.' [0-9]+ | [0-9]+ '.' [0-9]*);

augmentedString:
	STRING_START expr? (STRING_MIDDLE expr?)* STRING_END;
string: SIMPLE_STRING;

SIMPLE_STRING: '"' ~["\r\n]* '"' | '$"' ~["\r\n`]* '"';
STRING_START: '$"' ~["`]* '`';
STRING_MIDDLE: '´' ~["`]* '`';
STRING_END: '´' ~["`]* '"';
SPACES: [ \t\r\n]+ -> skip;

compoundasign:
	PLUSASSIGN
	| MULTASSIGN
	| DIVASSIGN
	| MODASSIGN
	| MINUSASSIGN;

int: MINUS? INT;
float: MINUS? FLOAT;
bool: BOOL;
num: int | float;

value:
	num
	| augmentedString
	| string
	| bool
	| object
	| array
	| NULL;

// Identifiers
ID: [a-zA-Z_][a-zA-Z_0-9]*;
id: ID;
argument: type id; //maybe replace all with the right hand side.
stringId: LPAREN expr RPAREN;
fieldId: id | stringId;
// Objects
adapting: id;
object: adapting? LCURLY (field | loopConstruction)* RCURLY;

field:
	HIDDEN_? type? fieldId (ASSIGN | compoundasign) expr SEMI;

// Arrays
arrayElement: expr | loopConstruction;
array: LBRACKET (arrayElement (COMMA arrayElement)* |) RBRACKET;

arrayAccess: id (LBRACKET expr RBRACKET)+;
// Templates
evaluaterArray: LBRACKET (expr (COMMA expr)* |) RBRACKET;

templateField:
	type id (ASSIGN expr)? (COLON evaluaterArray)? SEMI;
templateExtention: EXTENDS_KEYWORD id;
templateDefenition:
	TEMPLATE_KEYWORD id templateExtention? LCURLY (
		templateField
		| method
	)* RCURLY;

// Functions
functionCollection: FUNCTIONS_KEYWORD id LCURLY method* RCURLY;

// Methods

arguments: argument (COMMA argument)* |;
method:
	type id LPAREN arguments RPAREN LCURLY statementList RCURLY;

functionCollectionCall: id DOT;
methodCall:
	functionCollectionCall? id LPAREN (expr (COMMA expr)* |) RPAREN;
objectFieldAcess: id (DOT id)+;
// Expressions
expr:
	value
	| id
	| objectFieldAcess
	| arrayAccess
	| methodCall
	| boolExpr
	| numExpr
	| stringExpr;

stringExpr:
	stringExpr PLUS stringExpr
	| id
	| arrayAccess
	| methodCall
	| augmentedString
	| string;

numExpr:
	value
	//| THIS_KEYWORD // this  may ruin everything in the semantics :)))
	| id
	| methodCall
	| arrayAccess
	| MINUS numExpr
	| numExpr (MULT | DIV | MOD) numExpr
	| numExpr (PLUS | MINUS) numExpr
	| LPAREN numExpr RPAREN;

boolExpr:
	value
	//| THIS_KEYWORD // this  may ruin everything in the semantics :)))
	| id
	| methodCall
	| NOT boolExpr
	| boolExpr compExpr boolExpr
	| boolExpr AND boolExpr
	| boolExpr OR boolExpr
	| LPAREN boolExpr RPAREN;

compExpr: GT | LT | GTE | LTE | EQ | NEQ;

// Condtionals structure
ifStatement: IF LPAREN expr RPAREN LCURLY statementList RCURLY;
conditional:
	ifStatement (ELSE ifStatement)* (
		ELSE LCURLY statementList RCURLY
	)?;

// While loop
whileLoop: WHILE LPAREN expr RPAREN LCURLY statementList RCURLY;

// For loop
forLoop:
	FOR LPAREN id IN expr RPAREN LCURLY statementList RCURLY;

// List construction
loopConstructContent: (field | expr)*;
loopConstruction:
	FOR LPAREN id IN expr RPAREN LCURLY loopConstructContent RCURLY;

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

assignment:
	type? (id | arrayAccess) (ASSIGN | compoundasign) expr SEMI;

// Add a start rule for testing
root: (
		templateDefenition
		| functionCollection
		| field
		| loopConstruction
	)*;