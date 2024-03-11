import { CharStreams, CommonTokenStream } from 'antlr4ts';
import { UCMLexer } from './compiler/UCMLexer';
import { UCMParser } from './compiler/UCMParser';

// Example input
let input = "int = 0003";
let inputStream = CharStreams.fromString(input);
let lexer = new UCMLexer(inputStream);
let tokenStream = new CommonTokenStream(lexer);
let parser = new UCMParser(tokenStream);

// Parse the input
let tree = parser.expr();

console.log(tree.toStringTree(parser.ruleNames));
