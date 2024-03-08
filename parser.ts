import { ANTLRInputStream, CommonTokenStream } from 'antlr4ts';
import { MathLexer } from './MathLexer';
import { MathParser } from './MathParser';

// Example input
let input = "3 + 2 * 4";
let inputStream = new ANTLRInputStream(input);
let lexer = new MathLexer(inputStream);
let tokenStream = new CommonTokenStream(lexer);
let parser = new MathParser(tokenStream);

// Parse the input
let tree = parser.expr();

console.log(tree.toStringTree(parser.ruleNames));
