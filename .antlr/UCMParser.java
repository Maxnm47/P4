// Generated from /home/max/Desktop/uni/4. semester/p4/UCM.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class UCMParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		ASSIGN=1, IF=2, ELSE=3, WHILE=4, RETURN=5, MULT=6, DIV=7, PLUS=8, MINUS=9, 
		MOD=10, AND=11, OR=12, EQ=13, NEQ=14, GT=15, LT=16, GTE=17, LTE=18, NOT=19, 
		NUM=20, INT_T=21, FLOAT_T=22, STRING_T=23, BOOL_T=24, INT=25, FLOAT=26, 
		STRING=27, ESCAPE_SEQUENCE=28, UNICODE_ESCAPE=29, BOOL=30, WS=31, COMMENT=32, 
		QUESTION=33, LPAREN=34, RPAREN=35, LCURLY=36, RCURLY=37, SEMI=38, COMMA=39, 
		COLON=40;
	public static final int
		RULE_start = 0, RULE_expr = 1, RULE_numExpr = 2, RULE_boolExpr = 3, RULE_compExpr = 4, 
		RULE_type = 5;
	private static String[] makeRuleNames() {
		return new String[] {
			"start", "expr", "numExpr", "boolExpr", "compExpr", "type"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'='", "'if'", "'else'", "'while'", "'return'", "'*'", "'/'", "'+'", 
			"'-'", "'%'", "'&&'", "'||'", "'=='", "'!='", "'>'", "'<'", "'>='", "'<='", 
			"'!'", null, "'int'", "'float'", "'string'", "'bool'", null, null, null, 
			null, null, null, null, null, "'?'", "'('", "')'", "'{'", "'}'", "';'", 
			"','", "':'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "ASSIGN", "IF", "ELSE", "WHILE", "RETURN", "MULT", "DIV", "PLUS", 
			"MINUS", "MOD", "AND", "OR", "EQ", "NEQ", "GT", "LT", "GTE", "LTE", "NOT", 
			"NUM", "INT_T", "FLOAT_T", "STRING_T", "BOOL_T", "INT", "FLOAT", "STRING", 
			"ESCAPE_SEQUENCE", "UNICODE_ESCAPE", "BOOL", "WS", "COMMENT", "QUESTION", 
			"LPAREN", "RPAREN", "LCURLY", "RCURLY", "SEMI", "COMMA", "COLON"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "UCM.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public UCMParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StartContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public StartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_start; }
	}

	public final StartContext start() throws RecognitionException {
		StartContext _localctx = new StartContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_start);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(12);
			expr();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ExprContext extends ParserRuleContext {
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public NumExprContext numExpr() {
			return getRuleContext(NumExprContext.class,0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		ExprContext _localctx = new ExprContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_expr);
		try {
			setState(16);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,0,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(14);
				boolExpr(0);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(15);
				numExpr(0);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class NumExprContext extends ParserRuleContext {
		public TerminalNode NUM() { return getToken(UCMParser.NUM, 0); }
		public TerminalNode MINUS() { return getToken(UCMParser.MINUS, 0); }
		public List<NumExprContext> numExpr() {
			return getRuleContexts(NumExprContext.class);
		}
		public NumExprContext numExpr(int i) {
			return getRuleContext(NumExprContext.class,i);
		}
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode MULT() { return getToken(UCMParser.MULT, 0); }
		public TerminalNode DIV() { return getToken(UCMParser.DIV, 0); }
		public TerminalNode MOD() { return getToken(UCMParser.MOD, 0); }
		public TerminalNode PLUS() { return getToken(UCMParser.PLUS, 0); }
		public NumExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numExpr; }
	}

	public final NumExprContext numExpr() throws RecognitionException {
		return numExpr(0);
	}

	private NumExprContext numExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		NumExprContext _localctx = new NumExprContext(_ctx, _parentState);
		NumExprContext _prevctx = _localctx;
		int _startState = 4;
		enterRecursionRule(_localctx, 4, RULE_numExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(26);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NUM:
				{
				setState(19);
				match(NUM);
				}
				break;
			case MINUS:
				{
				setState(20);
				match(MINUS);
				setState(21);
				numExpr(4);
				}
				break;
			case LPAREN:
				{
				setState(22);
				match(LPAREN);
				setState(23);
				numExpr(0);
				setState(24);
				match(RPAREN);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(36);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(34);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
					case 1:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(28);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(29);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1216L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(30);
						numExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(31);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(32);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(33);
						numExpr(3);
						}
						break;
					}
					} 
				}
				setState(38);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,3,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BoolExprContext extends ParserRuleContext {
		public TerminalNode BOOL() { return getToken(UCMParser.BOOL, 0); }
		public TerminalNode NOT() { return getToken(UCMParser.NOT, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public List<NumExprContext> numExpr() {
			return getRuleContexts(NumExprContext.class);
		}
		public NumExprContext numExpr(int i) {
			return getRuleContext(NumExprContext.class,i);
		}
		public CompExprContext compExpr() {
			return getRuleContext(CompExprContext.class,0);
		}
		public List<BoolExprContext> boolExpr() {
			return getRuleContexts(BoolExprContext.class);
		}
		public BoolExprContext boolExpr(int i) {
			return getRuleContext(BoolExprContext.class,i);
		}
		public TerminalNode EQ() { return getToken(UCMParser.EQ, 0); }
		public TerminalNode AND() { return getToken(UCMParser.AND, 0); }
		public TerminalNode OR() { return getToken(UCMParser.OR, 0); }
		public BoolExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolExpr; }
	}

	public final BoolExprContext boolExpr() throws RecognitionException {
		return boolExpr(0);
	}

	private BoolExprContext boolExpr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		BoolExprContext _localctx = new BoolExprContext(_ctx, _parentState);
		BoolExprContext _prevctx = _localctx;
		int _startState = 6;
		enterRecursionRule(_localctx, 6, RULE_boolExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(47);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case BOOL:
				{
				setState(40);
				match(BOOL);
				}
				break;
			case NOT:
				{
				setState(41);
				match(NOT);
				setState(42);
				expr();
				}
				break;
			case MINUS:
			case NUM:
			case LPAREN:
				{
				setState(43);
				numExpr(0);
				setState(44);
				compExpr();
				setState(45);
				numExpr(0);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(60);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(58);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
					case 1:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(49);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(50);
						match(EQ);
						setState(51);
						boolExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(52);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(53);
						match(AND);
						setState(54);
						boolExpr(3);
						}
						break;
					case 3:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(55);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(56);
						match(OR);
						setState(57);
						boolExpr(2);
						}
						break;
					}
					} 
				}
				setState(62);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,6,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class CompExprContext extends ParserRuleContext {
		public TerminalNode GT() { return getToken(UCMParser.GT, 0); }
		public TerminalNode LT() { return getToken(UCMParser.LT, 0); }
		public TerminalNode GTE() { return getToken(UCMParser.GTE, 0); }
		public TerminalNode LTE() { return getToken(UCMParser.LTE, 0); }
		public TerminalNode EQ() { return getToken(UCMParser.EQ, 0); }
		public TerminalNode NEQ() { return getToken(UCMParser.NEQ, 0); }
		public CompExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_compExpr; }
	}

	public final CompExprContext compExpr() throws RecognitionException {
		CompExprContext _localctx = new CompExprContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_compExpr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 516096L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TypeContext extends ParserRuleContext {
		public TerminalNode INT_T() { return getToken(UCMParser.INT_T, 0); }
		public TerminalNode FLOAT_T() { return getToken(UCMParser.FLOAT_T, 0); }
		public TerminalNode STRING_T() { return getToken(UCMParser.STRING_T, 0); }
		public TerminalNode BOOL_T() { return getToken(UCMParser.BOOL_T, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_type);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 31457280L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 2:
			return numExpr_sempred((NumExprContext)_localctx, predIndex);
		case 3:
			return boolExpr_sempred((BoolExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean numExpr_sempred(NumExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 3);
		case 1:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean boolExpr_sempred(BoolExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 2:
			return precpred(_ctx, 3);
		case 3:
			return precpred(_ctx, 2);
		case 4:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001(D\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002\u0002"+
		"\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002\u0005"+
		"\u0007\u0005\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001\u0003\u0001"+
		"\u0011\b\u0001\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0001\u0002\u0003\u0002\u001b\b\u0002\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0001\u0002\u0005\u0002"+
		"#\b\u0002\n\u0002\f\u0002&\t\u0002\u0001\u0003\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003"+
		"0\b\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0005\u0003;\b\u0003"+
		"\n\u0003\f\u0003>\t\u0003\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005"+
		"\u0001\u0005\u0000\u0002\u0004\u0006\u0006\u0000\u0002\u0004\u0006\b\n"+
		"\u0000\u0004\u0002\u0000\u0006\u0007\n\n\u0001\u0000\b\t\u0001\u0000\r"+
		"\u0012\u0001\u0000\u0015\u0018G\u0000\f\u0001\u0000\u0000\u0000\u0002"+
		"\u0010\u0001\u0000\u0000\u0000\u0004\u001a\u0001\u0000\u0000\u0000\u0006"+
		"/\u0001\u0000\u0000\u0000\b?\u0001\u0000\u0000\u0000\nA\u0001\u0000\u0000"+
		"\u0000\f\r\u0003\u0002\u0001\u0000\r\u0001\u0001\u0000\u0000\u0000\u000e"+
		"\u0011\u0003\u0006\u0003\u0000\u000f\u0011\u0003\u0004\u0002\u0000\u0010"+
		"\u000e\u0001\u0000\u0000\u0000\u0010\u000f\u0001\u0000\u0000\u0000\u0011"+
		"\u0003\u0001\u0000\u0000\u0000\u0012\u0013\u0006\u0002\uffff\uffff\u0000"+
		"\u0013\u001b\u0005\u0014\u0000\u0000\u0014\u0015\u0005\t\u0000\u0000\u0015"+
		"\u001b\u0003\u0004\u0002\u0004\u0016\u0017\u0005\"\u0000\u0000\u0017\u0018"+
		"\u0003\u0004\u0002\u0000\u0018\u0019\u0005#\u0000\u0000\u0019\u001b\u0001"+
		"\u0000\u0000\u0000\u001a\u0012\u0001\u0000\u0000\u0000\u001a\u0014\u0001"+
		"\u0000\u0000\u0000\u001a\u0016\u0001\u0000\u0000\u0000\u001b$\u0001\u0000"+
		"\u0000\u0000\u001c\u001d\n\u0003\u0000\u0000\u001d\u001e\u0007\u0000\u0000"+
		"\u0000\u001e#\u0003\u0004\u0002\u0004\u001f \n\u0002\u0000\u0000 !\u0007"+
		"\u0001\u0000\u0000!#\u0003\u0004\u0002\u0003\"\u001c\u0001\u0000\u0000"+
		"\u0000\"\u001f\u0001\u0000\u0000\u0000#&\u0001\u0000\u0000\u0000$\"\u0001"+
		"\u0000\u0000\u0000$%\u0001\u0000\u0000\u0000%\u0005\u0001\u0000\u0000"+
		"\u0000&$\u0001\u0000\u0000\u0000\'(\u0006\u0003\uffff\uffff\u0000(0\u0005"+
		"\u001e\u0000\u0000)*\u0005\u0013\u0000\u0000*0\u0003\u0002\u0001\u0000"+
		"+,\u0003\u0004\u0002\u0000,-\u0003\b\u0004\u0000-.\u0003\u0004\u0002\u0000"+
		".0\u0001\u0000\u0000\u0000/\'\u0001\u0000\u0000\u0000/)\u0001\u0000\u0000"+
		"\u0000/+\u0001\u0000\u0000\u00000<\u0001\u0000\u0000\u000012\n\u0003\u0000"+
		"\u000023\u0005\r\u0000\u00003;\u0003\u0006\u0003\u000445\n\u0002\u0000"+
		"\u000056\u0005\u000b\u0000\u00006;\u0003\u0006\u0003\u000378\n\u0001\u0000"+
		"\u000089\u0005\f\u0000\u00009;\u0003\u0006\u0003\u0002:1\u0001\u0000\u0000"+
		"\u0000:4\u0001\u0000\u0000\u0000:7\u0001\u0000\u0000\u0000;>\u0001\u0000"+
		"\u0000\u0000<:\u0001\u0000\u0000\u0000<=\u0001\u0000\u0000\u0000=\u0007"+
		"\u0001\u0000\u0000\u0000><\u0001\u0000\u0000\u0000?@\u0007\u0002\u0000"+
		"\u0000@\t\u0001\u0000\u0000\u0000AB\u0007\u0003\u0000\u0000B\u000b\u0001"+
		"\u0000\u0000\u0000\u0007\u0010\u001a\"$/:<";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}