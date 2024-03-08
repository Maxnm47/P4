"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const antlr4ts_1 = require("antlr4ts");
const MathLexer_1 = require("./MathLexer");
const MathParser_1 = require("./MathParser");
// Example input
let input = "3 + 2 * 4";
let inputStream = new antlr4ts_1.ANTLRInputStream(input);
let lexer = new MathLexer_1.MathLexer(inputStream);
let tokenStream = new antlr4ts_1.CommonTokenStream(lexer);
let parser = new MathParser_1.MathParser(tokenStream);
// Parse the input
let tree = parser.expr();
console.log(tree.toStringTree(parser.ruleNames));
