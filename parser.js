"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var antlr4ts_1 = require("antlr4ts");
var UCMLexer_1 = require("./compiler/UCMLexer");
var UCMParser_1 = require("./compiler/UCMParser");
// Example input
var input = "int = 0003";
var inputStream = antlr4ts_1.CharStreams.fromString(input);
var lexer = new UCMLexer_1.UCMLexer(inputStream);
var tokenStream = new antlr4ts_1.CommonTokenStream(lexer);
var parser = new UCMParser_1.UCMParser(tokenStream);
// Parse the input
var tree = parser.expr();
console.log(tree.toStringTree(parser.ruleNames));
