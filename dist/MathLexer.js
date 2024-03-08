"use strict";
// Generated from Math.g4 by ANTLR 4.9.0-SNAPSHOT
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.MathLexer = void 0;
const ATNDeserializer_1 = require("antlr4ts/atn/ATNDeserializer");
const Lexer_1 = require("antlr4ts/Lexer");
const LexerATNSimulator_1 = require("antlr4ts/atn/LexerATNSimulator");
const VocabularyImpl_1 = require("antlr4ts/VocabularyImpl");
const Utils = __importStar(require("antlr4ts/misc/Utils"));
class MathLexer extends Lexer_1.Lexer {
    // @Override
    // @NotNull
    get vocabulary() {
        return MathLexer.VOCABULARY;
    }
    // tslint:enable:no-trailing-whitespace
    constructor(input) {
        super(input);
        this._interp = new LexerATNSimulator_1.LexerATNSimulator(MathLexer._ATN, this);
    }
    // @Override
    get grammarFileName() { return "Math.g4"; }
    // @Override
    get ruleNames() { return MathLexer.ruleNames; }
    // @Override
    get serializedATN() { return MathLexer._serializedATN; }
    // @Override
    get channelNames() { return MathLexer.channelNames; }
    // @Override
    get modeNames() { return MathLexer.modeNames; }
    static get _ATN() {
        if (!MathLexer.__ATN) {
            MathLexer.__ATN = new ATNDeserializer_1.ATNDeserializer().deserialize(Utils.toCharArray(MathLexer._serializedATN));
        }
        return MathLexer.__ATN;
    }
}
exports.MathLexer = MathLexer;
MathLexer.T__0 = 1;
MathLexer.T__1 = 2;
MathLexer.T__2 = 3;
MathLexer.T__3 = 4;
MathLexer.INT = 5;
MathLexer.WS = 6;
// tslint:disable:no-trailing-whitespace
MathLexer.channelNames = [
    "DEFAULT_TOKEN_CHANNEL", "HIDDEN",
];
// tslint:disable:no-trailing-whitespace
MathLexer.modeNames = [
    "DEFAULT_MODE",
];
MathLexer.ruleNames = [
    "T__0", "T__1", "T__2", "T__3", "INT", "WS",
];
MathLexer._LITERAL_NAMES = [
    undefined, "'*'", "'/'", "'+'", "'-'",
];
MathLexer._SYMBOLIC_NAMES = [
    undefined, undefined, undefined, undefined, undefined, "INT", "WS",
];
MathLexer.VOCABULARY = new VocabularyImpl_1.VocabularyImpl(MathLexer._LITERAL_NAMES, MathLexer._SYMBOLIC_NAMES, []);
MathLexer._serializedATN = "\x03\uC91D\uCABA\u058D\uAFBA\u4F53\u0607\uEA8B\uC241\x02\b#\b\x01\x04" +
    "\x02\t\x02\x04\x03\t\x03\x04\x04\t\x04\x04\x05\t\x05\x04\x06\t\x06\x04" +
    "\x07\t\x07\x03\x02\x03\x02\x03\x03\x03\x03\x03\x04\x03\x04\x03\x05\x03" +
    "\x05\x03\x06\x06\x06\x19\n\x06\r\x06\x0E\x06\x1A\x03\x07\x06\x07\x1E\n" +
    "\x07\r\x07\x0E\x07\x1F\x03\x07\x03\x07\x02\x02\x02\b\x03\x02\x03\x05\x02" +
    "\x04\x07\x02\x05\t\x02\x06\v\x02\x07\r\x02\b\x03\x02\x04\x03\x022;\x05" +
    "\x02\v\f\x0F\x0F\"\"\x02$\x02\x03\x03\x02\x02\x02\x02\x05\x03\x02\x02" +
    "\x02\x02\x07\x03\x02\x02\x02\x02\t\x03\x02\x02\x02\x02\v\x03\x02\x02\x02" +
    "\x02\r\x03\x02\x02\x02\x03\x0F\x03\x02\x02\x02\x05\x11\x03\x02\x02\x02" +
    "\x07\x13\x03\x02\x02\x02\t\x15\x03\x02\x02\x02\v\x18\x03\x02\x02\x02\r" +
    "\x1D\x03\x02\x02\x02\x0F\x10\x07,\x02\x02\x10\x04\x03\x02\x02\x02\x11" +
    "\x12\x071\x02\x02\x12\x06\x03\x02\x02\x02\x13\x14\x07-\x02\x02\x14\b\x03" +
    "\x02\x02\x02\x15\x16\x07/\x02\x02\x16\n\x03\x02\x02\x02\x17\x19\t\x02" +
    "\x02\x02\x18\x17\x03\x02\x02\x02\x19\x1A\x03\x02\x02\x02\x1A\x18\x03\x02" +
    "\x02\x02\x1A\x1B\x03\x02\x02\x02\x1B\f\x03\x02\x02\x02\x1C\x1E\t\x03\x02" +
    "\x02\x1D\x1C\x03\x02\x02\x02\x1E\x1F\x03\x02\x02\x02\x1F\x1D\x03\x02\x02" +
    "\x02\x1F \x03\x02\x02\x02 !\x03\x02\x02\x02!\"\b\x07\x02\x02\"\x0E\x03" +
    "\x02\x02\x02\x05\x02\x1A\x1F\x03\b\x02\x02";
