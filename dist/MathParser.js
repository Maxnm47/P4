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
exports.ExprContext = exports.MathParser = void 0;
const ATN_1 = require("antlr4ts/atn/ATN");
const ATNDeserializer_1 = require("antlr4ts/atn/ATNDeserializer");
const FailedPredicateException_1 = require("antlr4ts/FailedPredicateException");
const Parser_1 = require("antlr4ts/Parser");
const ParserRuleContext_1 = require("antlr4ts/ParserRuleContext");
const ParserATNSimulator_1 = require("antlr4ts/atn/ParserATNSimulator");
const RecognitionException_1 = require("antlr4ts/RecognitionException");
const Token_1 = require("antlr4ts/Token");
const VocabularyImpl_1 = require("antlr4ts/VocabularyImpl");
const Utils = __importStar(require("antlr4ts/misc/Utils"));
class MathParser extends Parser_1.Parser {
    // @Override
    // @NotNull
    get vocabulary() {
        return MathParser.VOCABULARY;
    }
    // tslint:enable:no-trailing-whitespace
    // @Override
    get grammarFileName() { return "Math.g4"; }
    // @Override
    get ruleNames() { return MathParser.ruleNames; }
    // @Override
    get serializedATN() { return MathParser._serializedATN; }
    createFailedPredicateException(predicate, message) {
        return new FailedPredicateException_1.FailedPredicateException(this, predicate, message);
    }
    constructor(input) {
        super(input);
        this._interp = new ParserATNSimulator_1.ParserATNSimulator(MathParser._ATN, this);
    }
    // @RuleVersion(0)
    expr(_p) {
        if (_p === undefined) {
            _p = 0;
        }
        let _parentctx = this._ctx;
        let _parentState = this.state;
        let _localctx = new ExprContext(this._ctx, _parentState);
        let _prevctx = _localctx;
        let _startState = 0;
        this.enterRecursionRule(_localctx, 0, MathParser.RULE_expr, _p);
        let _la;
        try {
            let _alt;
            this.enterOuterAlt(_localctx, 1);
            {
                {
                    this.state = 3;
                    this.match(MathParser.INT);
                }
                this._ctx._stop = this._input.tryLT(-1);
                this.state = 13;
                this._errHandler.sync(this);
                _alt = this.interpreter.adaptivePredict(this._input, 1, this._ctx);
                while (_alt !== 2 && _alt !== ATN_1.ATN.INVALID_ALT_NUMBER) {
                    if (_alt === 1) {
                        if (this._parseListeners != null) {
                            this.triggerExitRuleEvent();
                        }
                        _prevctx = _localctx;
                        {
                            this.state = 11;
                            this._errHandler.sync(this);
                            switch (this.interpreter.adaptivePredict(this._input, 0, this._ctx)) {
                                case 1:
                                    {
                                        _localctx = new ExprContext(_parentctx, _parentState);
                                        this.pushNewRecursionContext(_localctx, _startState, MathParser.RULE_expr);
                                        this.state = 5;
                                        if (!(this.precpred(this._ctx, 3))) {
                                            throw this.createFailedPredicateException("this.precpred(this._ctx, 3)");
                                        }
                                        this.state = 6;
                                        _la = this._input.LA(1);
                                        if (!(_la === MathParser.T__0 || _la === MathParser.T__1)) {
                                            this._errHandler.recoverInline(this);
                                        }
                                        else {
                                            if (this._input.LA(1) === Token_1.Token.EOF) {
                                                this.matchedEOF = true;
                                            }
                                            this._errHandler.reportMatch(this);
                                            this.consume();
                                        }
                                        this.state = 7;
                                        this.expr(4);
                                    }
                                    break;
                                case 2:
                                    {
                                        _localctx = new ExprContext(_parentctx, _parentState);
                                        this.pushNewRecursionContext(_localctx, _startState, MathParser.RULE_expr);
                                        this.state = 8;
                                        if (!(this.precpred(this._ctx, 2))) {
                                            throw this.createFailedPredicateException("this.precpred(this._ctx, 2)");
                                        }
                                        this.state = 9;
                                        _la = this._input.LA(1);
                                        if (!(_la === MathParser.T__2 || _la === MathParser.T__3)) {
                                            this._errHandler.recoverInline(this);
                                        }
                                        else {
                                            if (this._input.LA(1) === Token_1.Token.EOF) {
                                                this.matchedEOF = true;
                                            }
                                            this._errHandler.reportMatch(this);
                                            this.consume();
                                        }
                                        this.state = 10;
                                        this.expr(3);
                                    }
                                    break;
                            }
                        }
                    }
                    this.state = 15;
                    this._errHandler.sync(this);
                    _alt = this.interpreter.adaptivePredict(this._input, 1, this._ctx);
                }
            }
        }
        catch (re) {
            if (re instanceof RecognitionException_1.RecognitionException) {
                _localctx.exception = re;
                this._errHandler.reportError(this, re);
                this._errHandler.recover(this, re);
            }
            else {
                throw re;
            }
        }
        finally {
            this.unrollRecursionContexts(_parentctx);
        }
        return _localctx;
    }
    sempred(_localctx, ruleIndex, predIndex) {
        switch (ruleIndex) {
            case 0:
                return this.expr_sempred(_localctx, predIndex);
        }
        return true;
    }
    expr_sempred(_localctx, predIndex) {
        switch (predIndex) {
            case 0:
                return this.precpred(this._ctx, 3);
            case 1:
                return this.precpred(this._ctx, 2);
        }
        return true;
    }
    static get _ATN() {
        if (!MathParser.__ATN) {
            MathParser.__ATN = new ATNDeserializer_1.ATNDeserializer().deserialize(Utils.toCharArray(MathParser._serializedATN));
        }
        return MathParser.__ATN;
    }
}
exports.MathParser = MathParser;
MathParser.T__0 = 1;
MathParser.T__1 = 2;
MathParser.T__2 = 3;
MathParser.T__3 = 4;
MathParser.INT = 5;
MathParser.WS = 6;
MathParser.RULE_expr = 0;
// tslint:disable:no-trailing-whitespace
MathParser.ruleNames = [
    "expr",
];
MathParser._LITERAL_NAMES = [
    undefined, "'*'", "'/'", "'+'", "'-'",
];
MathParser._SYMBOLIC_NAMES = [
    undefined, undefined, undefined, undefined, undefined, "INT", "WS",
];
MathParser.VOCABULARY = new VocabularyImpl_1.VocabularyImpl(MathParser._LITERAL_NAMES, MathParser._SYMBOLIC_NAMES, []);
MathParser._serializedATN = "\x03\uC91D\uCABA\u058D\uAFBA\u4F53\u0607\uEA8B\uC241\x03\b\x13\x04\x02" +
    "\t\x02\x03\x02\x03\x02\x03\x02\x03\x02\x03\x02\x03\x02\x03\x02\x03\x02" +
    "\x03\x02\x07\x02\x0E\n\x02\f\x02\x0E\x02\x11\v\x02\x03\x02\x02\x02\x03" +
    "\x02\x03\x02\x02\x02\x04\x03\x02\x03\x04\x03\x02\x05\x06\x02\x13\x02\x04" +
    "\x03\x02\x02\x02\x04\x05\b\x02\x01\x02\x05\x06\x07\x07\x02\x02\x06\x0F" +
    "\x03\x02\x02\x02\x07\b\f\x05\x02\x02\b\t\t\x02\x02\x02\t\x0E\x05\x02\x02" +
    "\x06\n\v\f\x04\x02\x02\v\f\t\x03\x02\x02\f\x0E\x05\x02\x02\x05\r\x07\x03" +
    "\x02\x02\x02\r\n\x03\x02\x02\x02\x0E\x11\x03\x02\x02\x02\x0F\r\x03\x02" +
    "\x02\x02\x0F\x10\x03\x02\x02\x02\x10\x03\x03\x02\x02\x02\x11\x0F\x03\x02" +
    "\x02\x02\x04\r\x0F";
class ExprContext extends ParserRuleContext_1.ParserRuleContext {
    expr(i) {
        if (i === undefined) {
            return this.getRuleContexts(ExprContext);
        }
        else {
            return this.getRuleContext(i, ExprContext);
        }
    }
    INT() { return this.tryGetToken(MathParser.INT, 0); }
    constructor(parent, invokingState) {
        super(parent, invokingState);
    }
    // @Override
    get ruleIndex() { return MathParser.RULE_expr; }
    // @Override
    enterRule(listener) {
        if (listener.enterExpr) {
            listener.enterExpr(this);
        }
    }
    // @Override
    exitRule(listener) {
        if (listener.exitExpr) {
            listener.exitExpr(this);
        }
    }
    // @Override
    accept(visitor) {
        if (visitor.visitExpr) {
            return visitor.visitExpr(this);
        }
        else {
            return visitor.visitChildren(this);
        }
    }
}
exports.ExprContext = ExprContext;
