// Generated from UCM.g4 by ANTLR 4.9.0-SNAPSHOT


import { ATN } from "antlr4ts/atn/ATN";
import { ATNDeserializer } from "antlr4ts/atn/ATNDeserializer";
import { FailedPredicateException } from "antlr4ts/FailedPredicateException";
import { NotNull } from "antlr4ts/Decorators";
import { NoViableAltException } from "antlr4ts/NoViableAltException";
import { Override } from "antlr4ts/Decorators";
import { Parser } from "antlr4ts/Parser";
import { ParserRuleContext } from "antlr4ts/ParserRuleContext";
import { ParserATNSimulator } from "antlr4ts/atn/ParserATNSimulator";
import { ParseTreeListener } from "antlr4ts/tree/ParseTreeListener";
import { ParseTreeVisitor } from "antlr4ts/tree/ParseTreeVisitor";
import { RecognitionException } from "antlr4ts/RecognitionException";
import { RuleContext } from "antlr4ts/RuleContext";
//import { RuleVersion } from "antlr4ts/RuleVersion";
import { TerminalNode } from "antlr4ts/tree/TerminalNode";
import { Token } from "antlr4ts/Token";
import { TokenStream } from "antlr4ts/TokenStream";
import { Vocabulary } from "antlr4ts/Vocabulary";
import { VocabularyImpl } from "antlr4ts/VocabularyImpl";

import * as Utils from "antlr4ts/misc/Utils";

import { UCMListener } from "./UCMListener";
import { UCMVisitor } from "./UCMVisitor";


export class UCMParser extends Parser {
	public static readonly INT_T = 1;
	public static readonly FLOAT_T = 2;
	public static readonly STRING_T = 3;
	public static readonly INT = 4;
	public static readonly FLOAT = 5;
	public static readonly STRING = 6;
	public static readonly WS = 7;
	public static readonly COMMENT = 8;
	public static readonly RULE_type = 0;
	// tslint:disable:no-trailing-whitespace
	public static readonly ruleNames: string[] = [
		"type",
	];

	private static readonly _LITERAL_NAMES: Array<string | undefined> = [
		undefined, "'int'", "'float'", "'string'",
	];
	private static readonly _SYMBOLIC_NAMES: Array<string | undefined> = [
		undefined, "INT_T", "FLOAT_T", "STRING_T", "INT", "FLOAT", "STRING", "WS", 
		"COMMENT",
	];
	public static readonly VOCABULARY: Vocabulary = new VocabularyImpl(UCMParser._LITERAL_NAMES, UCMParser._SYMBOLIC_NAMES, []);

	// @Override
	// @NotNull
	public get vocabulary(): Vocabulary {
		return UCMParser.VOCABULARY;
	}
	// tslint:enable:no-trailing-whitespace

	// @Override
	public get grammarFileName(): string { return "UCM.g4"; }

	// @Override
	public get ruleNames(): string[] { return UCMParser.ruleNames; }

	// @Override
	public get serializedATN(): string { return UCMParser._serializedATN; }

	protected createFailedPredicateException(predicate?: string, message?: string): FailedPredicateException {
		return new FailedPredicateException(this, predicate, message);
	}

	constructor(input: TokenStream) {
		super(input);
		this._interp = new ParserATNSimulator(UCMParser._ATN, this);
	}
	// @RuleVersion(0)
	public type(): TypeContext {
		let _localctx: TypeContext = new TypeContext(this._ctx, this.state);
		this.enterRule(_localctx, 0, UCMParser.RULE_type);
		let _la: number;
		try {
			this.enterOuterAlt(_localctx, 1);
			{
			this.state = 2;
			_la = this._input.LA(1);
			if (!((((_la) & ~0x1F) === 0 && ((1 << _la) & ((1 << UCMParser.INT_T) | (1 << UCMParser.FLOAT_T) | (1 << UCMParser.STRING_T))) !== 0))) {
			this._errHandler.recoverInline(this);
			} else {
				if (this._input.LA(1) === Token.EOF) {
					this.matchedEOF = true;
				}

				this._errHandler.reportMatch(this);
				this.consume();
			}
			}
		}
		catch (re) {
			if (re instanceof RecognitionException) {
				_localctx.exception = re;
				this._errHandler.reportError(this, re);
				this._errHandler.recover(this, re);
			} else {
				throw re;
			}
		}
		finally {
			this.exitRule();
		}
		return _localctx;
	}

	public static readonly _serializedATN: string =
		"\x03\uC91D\uCABA\u058D\uAFBA\u4F53\u0607\uEA8B\uC241\x03\n\x07\x04\x02" +
		"\t\x02\x03\x02\x03\x02\x03\x02\x02\x02\x02\x03\x02\x02\x02\x03\x03\x02" +
		"\x03\x05\x02\x05\x02\x04\x03\x02\x02\x02\x04\x05\t\x02\x02\x02\x05\x03" +
		"\x03\x02\x02\x02\x02";
	public static __ATN: ATN;
	public static get _ATN(): ATN {
		if (!UCMParser.__ATN) {
			UCMParser.__ATN = new ATNDeserializer().deserialize(Utils.toCharArray(UCMParser._serializedATN));
		}

		return UCMParser.__ATN;
	}

}

export class TypeContext extends ParserRuleContext {
	public INT_T(): TerminalNode | undefined { return this.tryGetToken(UCMParser.INT_T, 0); }
	public FLOAT_T(): TerminalNode | undefined { return this.tryGetToken(UCMParser.FLOAT_T, 0); }
	public STRING_T(): TerminalNode | undefined { return this.tryGetToken(UCMParser.STRING_T, 0); }
	constructor(parent: ParserRuleContext | undefined, invokingState: number) {
		super(parent, invokingState);
	}
	// @Override
	public get ruleIndex(): number { return UCMParser.RULE_type; }
	// @Override
	public enterRule(listener: UCMListener): void {
		if (listener.enterType) {
			listener.enterType(this);
		}
	}
	// @Override
	public exitRule(listener: UCMListener): void {
		if (listener.exitType) {
			listener.exitType(this);
		}
	}
	// @Override
	public accept<Result>(visitor: UCMVisitor<Result>): Result {
		if (visitor.visitType) {
			return visitor.visitType(this);
		} else {
			return visitor.visitChildren(this);
		}
	}
}


