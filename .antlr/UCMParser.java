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
		WS=1, COMMENT=2, IF=3, ELSE=4, WHILE=5, FOR=6, RETURN=7, TEMPLATE_KEYWORD=8, 
		IN=9, HIDDEN_=10, OBJECT_KEYWORD=11, FUNCTIONS_KEYWORD=12, EXTENDS_KEYWORD=13, 
		THIS_KEYWORD=14, MULT=15, DIV=16, PLUS=17, MINUS=18, MOD=19, AND=20, OR=21, 
		EQ=22, NEQ=23, GT=24, LT=25, GTE=26, LTE=27, NOT=28, QUESTION=29, LPAREN=30, 
		RPAREN=31, LCURLY=32, RCURLY=33, LBRACKET=34, RBRACKET=35, SEMI=36, DOT=37, 
		COMMA=38, COLON=39, NEWLINE=40, ASSIGN=41, QUOTE=42, DOLLAR=43, INT_T=44, 
		FLOAT_T=45, STRING_T=46, BOOL_T=47, BOOL=48, INT=49, FLOAT=50, ESCAPE_SEQUENCE=51, 
		ID=52;
	public static final int
		RULE_object_t = 0, RULE_array_t = 1, RULE_primitiveType = 2, RULE_complexType = 3, 
		RULE_type = 4, RULE_num = 5, RULE_value = 6, RULE_augmentedString = 7, 
		RULE_concatanatedString = 8, RULE_string = 9, RULE_typedId = 10, RULE_adapting = 11, 
		RULE_object = 12, RULE_field = 13, RULE_array = 14, RULE_evaluaterArray = 15, 
		RULE_templateField = 16, RULE_templateExtention = 17, RULE_templateDefenition = 18, 
		RULE_functionCollection = 19, RULE_method = 20, RULE_functionCollectionCall = 21, 
		RULE_methodCall = 22, RULE_expr = 23, RULE_numExpr = 24, RULE_boolExpr = 25, 
		RULE_compExpr = 26, RULE_ifStatement = 27, RULE_conditional = 28, RULE_whileLoop = 29, 
		RULE_forLoop = 30, RULE_listConstruction = 31, RULE_statementList = 32, 
		RULE_statement = 33, RULE_assignment = 34, RULE_objectDefenition = 35, 
		RULE_arrayDefenition = 36, RULE_declaration = 37, RULE_root = 38, RULE_start = 39;
	private static String[] makeRuleNames() {
		return new String[] {
			"object_t", "array_t", "primitiveType", "complexType", "type", "num", 
			"value", "augmentedString", "concatanatedString", "string", "typedId", 
			"adapting", "object", "field", "array", "evaluaterArray", "templateField", 
			"templateExtention", "templateDefenition", "functionCollection", "method", 
			"functionCollectionCall", "methodCall", "expr", "numExpr", "boolExpr", 
			"compExpr", "ifStatement", "conditional", "whileLoop", "forLoop", "listConstruction", 
			"statementList", "statement", "assignment", "objectDefenition", "arrayDefenition", 
			"declaration", "root", "start"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, "'if'", "'else'", "'while'", "'for'", "'return'", "'template'", 
			"'in'", "'hidden'", "'object'", "'functions'", "'extends'", "'this'", 
			"'*'", "'/'", "'+'", "'-'", "'%'", "'&&'", "'||'", "'=='", "'!='", "'>'", 
			"'<'", "'>='", "'<='", "'!'", "'?'", "'('", "')'", "'{'", "'}'", "'['", 
			"']'", "';'", "'.'", "','", "':'", "'\\n'", "'='", "'\"'", "'$'", "'int'", 
			"'float'", "'string'", "'bool'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "WS", "COMMENT", "IF", "ELSE", "WHILE", "FOR", "RETURN", "TEMPLATE_KEYWORD", 
			"IN", "HIDDEN_", "OBJECT_KEYWORD", "FUNCTIONS_KEYWORD", "EXTENDS_KEYWORD", 
			"THIS_KEYWORD", "MULT", "DIV", "PLUS", "MINUS", "MOD", "AND", "OR", "EQ", 
			"NEQ", "GT", "LT", "GTE", "LTE", "NOT", "QUESTION", "LPAREN", "RPAREN", 
			"LCURLY", "RCURLY", "LBRACKET", "RBRACKET", "SEMI", "DOT", "COMMA", "COLON", 
			"NEWLINE", "ASSIGN", "QUOTE", "DOLLAR", "INT_T", "FLOAT_T", "STRING_T", 
			"BOOL_T", "BOOL", "INT", "FLOAT", "ESCAPE_SEQUENCE", "ID"
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
	public static class Object_tContext extends ParserRuleContext {
		public TerminalNode OBJECT_KEYWORD() { return getToken(UCMParser.OBJECT_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public Object_tContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_object_t; }
	}

	public final Object_tContext object_t() throws RecognitionException {
		Object_tContext _localctx = new Object_tContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_object_t);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(80);
			_la = _input.LA(1);
			if ( !(_la==OBJECT_KEYWORD || _la==ID) ) {
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
	public static class Array_tContext extends ParserRuleContext {
		public PrimitiveTypeContext primitiveType() {
			return getRuleContext(PrimitiveTypeContext.class,0);
		}
		public Object_tContext object_t() {
			return getRuleContext(Object_tContext.class,0);
		}
		public List<TerminalNode> LBRACKET() { return getTokens(UCMParser.LBRACKET); }
		public TerminalNode LBRACKET(int i) {
			return getToken(UCMParser.LBRACKET, i);
		}
		public List<TerminalNode> RBRACKET() { return getTokens(UCMParser.RBRACKET); }
		public TerminalNode RBRACKET(int i) {
			return getToken(UCMParser.RBRACKET, i);
		}
		public Array_tContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array_t; }
	}

	public final Array_tContext array_t() throws RecognitionException {
		Array_tContext _localctx = new Array_tContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_array_t);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT_T:
			case FLOAT_T:
			case BOOL_T:
				{
				setState(82);
				primitiveType();
				}
				break;
			case OBJECT_KEYWORD:
			case ID:
				{
				setState(83);
				object_t();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(88); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(86);
				match(LBRACKET);
				setState(87);
				match(RBRACKET);
				}
				}
				setState(90); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==LBRACKET );
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
	public static class PrimitiveTypeContext extends ParserRuleContext {
		public TerminalNode INT_T() { return getToken(UCMParser.INT_T, 0); }
		public TerminalNode FLOAT_T() { return getToken(UCMParser.FLOAT_T, 0); }
		public TerminalNode BOOL_T() { return getToken(UCMParser.BOOL_T, 0); }
		public PrimitiveTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_primitiveType; }
	}

	public final PrimitiveTypeContext primitiveType() throws RecognitionException {
		PrimitiveTypeContext _localctx = new PrimitiveTypeContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_primitiveType);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(92);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 193514046488576L) != 0)) ) {
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
	public static class ComplexTypeContext extends ParserRuleContext {
		public Object_tContext object_t() {
			return getRuleContext(Object_tContext.class,0);
		}
		public Array_tContext array_t() {
			return getRuleContext(Array_tContext.class,0);
		}
		public TerminalNode STRING_T() { return getToken(UCMParser.STRING_T, 0); }
		public ComplexTypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_complexType; }
	}

	public final ComplexTypeContext complexType() throws RecognitionException {
		ComplexTypeContext _localctx = new ComplexTypeContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_complexType);
		try {
			setState(97);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(94);
				object_t();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(95);
				array_t();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(96);
				match(STRING_T);
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
	public static class TypeContext extends ParserRuleContext {
		public PrimitiveTypeContext primitiveType() {
			return getRuleContext(PrimitiveTypeContext.class,0);
		}
		public ComplexTypeContext complexType() {
			return getRuleContext(ComplexTypeContext.class,0);
		}
		public TypeContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_type; }
	}

	public final TypeContext type() throws RecognitionException {
		TypeContext _localctx = new TypeContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_type);
		try {
			setState(101);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(99);
				primitiveType();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(100);
				complexType();
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
	public static class NumContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(UCMParser.INT, 0); }
		public TerminalNode FLOAT() { return getToken(UCMParser.FLOAT, 0); }
		public NumContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_num; }
	}

	public final NumContext num() throws RecognitionException {
		NumContext _localctx = new NumContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_num);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(103);
			_la = _input.LA(1);
			if ( !(_la==INT || _la==FLOAT) ) {
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
	public static class ValueContext extends ParserRuleContext {
		public NumContext num() {
			return getRuleContext(NumContext.class,0);
		}
		public AugmentedStringContext augmentedString() {
			return getRuleContext(AugmentedStringContext.class,0);
		}
		public ConcatanatedStringContext concatanatedString() {
			return getRuleContext(ConcatanatedStringContext.class,0);
		}
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public TerminalNode BOOL() { return getToken(UCMParser.BOOL, 0); }
		public ObjectContext object() {
			return getRuleContext(ObjectContext.class,0);
		}
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_value);
		try {
			setState(112);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(105);
				num();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(106);
				augmentedString();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(107);
				concatanatedString();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(108);
				string();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(109);
				match(BOOL);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(110);
				object();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(111);
				array();
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
	public static class AugmentedStringContext extends ParserRuleContext {
		public TerminalNode DOLLAR() { return getToken(UCMParser.DOLLAR, 0); }
		public List<TerminalNode> QUOTE() { return getTokens(UCMParser.QUOTE); }
		public TerminalNode QUOTE(int i) {
			return getToken(UCMParser.QUOTE, i);
		}
		public List<TerminalNode> LCURLY() { return getTokens(UCMParser.LCURLY); }
		public TerminalNode LCURLY(int i) {
			return getToken(UCMParser.LCURLY, i);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public List<TerminalNode> RCURLY() { return getTokens(UCMParser.RCURLY); }
		public TerminalNode RCURLY(int i) {
			return getToken(UCMParser.RCURLY, i);
		}
		public List<TerminalNode> ESCAPE_SEQUENCE() { return getTokens(UCMParser.ESCAPE_SEQUENCE); }
		public TerminalNode ESCAPE_SEQUENCE(int i) {
			return getToken(UCMParser.ESCAPE_SEQUENCE, i);
		}
		public AugmentedStringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_augmentedString; }
	}

	public final AugmentedStringContext augmentedString() throws RecognitionException {
		AugmentedStringContext _localctx = new AugmentedStringContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_augmentedString);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(114);
			match(DOLLAR);
			setState(115);
			match(QUOTE);
			setState(136);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					setState(134);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
					case 1:
						{
						setState(118);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
						case 1:
							{
							setState(116);
							match(ESCAPE_SEQUENCE);
							}
							break;
						case 2:
							{
							setState(117);
							matchWildcard();
							}
							break;
						}
						{
						setState(120);
						match(LCURLY);
						setState(121);
						expr(0);
						setState(122);
						match(RCURLY);
						}
						}
						break;
					case 2:
						{
						setState(126);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
						case 1:
							{
							setState(124);
							match(ESCAPE_SEQUENCE);
							}
							break;
						case 2:
							{
							setState(125);
							matchWildcard();
							}
							break;
						}
						setState(132);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
						case 1:
							{
							setState(128);
							match(LCURLY);
							setState(129);
							expr(0);
							setState(130);
							match(RCURLY);
							}
							break;
						}
						}
						break;
					}
					} 
				}
				setState(138);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
			}
			setState(139);
			match(QUOTE);
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
	public static class ConcatanatedStringContext extends ParserRuleContext {
		public List<StringContext> string() {
			return getRuleContexts(StringContext.class);
		}
		public StringContext string(int i) {
			return getRuleContext(StringContext.class,i);
		}
		public List<TerminalNode> PLUS() { return getTokens(UCMParser.PLUS); }
		public TerminalNode PLUS(int i) {
			return getToken(UCMParser.PLUS, i);
		}
		public ConcatanatedStringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_concatanatedString; }
	}

	public final ConcatanatedStringContext concatanatedString() throws RecognitionException {
		ConcatanatedStringContext _localctx = new ConcatanatedStringContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_concatanatedString);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(141);
					string();
					setState(142);
					match(PLUS);
					setState(143);
					string();
					}
					} 
				}
				setState(149);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
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
	public static class StringContext extends ParserRuleContext {
		public List<TerminalNode> QUOTE() { return getTokens(UCMParser.QUOTE); }
		public TerminalNode QUOTE(int i) {
			return getToken(UCMParser.QUOTE, i);
		}
		public List<TerminalNode> ESCAPE_SEQUENCE() { return getTokens(UCMParser.ESCAPE_SEQUENCE); }
		public TerminalNode ESCAPE_SEQUENCE(int i) {
			return getToken(UCMParser.ESCAPE_SEQUENCE, i);
		}
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_string);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(150);
			match(QUOTE);
			setState(155);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					setState(153);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
					case 1:
						{
						setState(151);
						match(ESCAPE_SEQUENCE);
						}
						break;
					case 2:
						{
						setState(152);
						matchWildcard();
						}
						break;
					}
					} 
				}
				setState(157);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,12,_ctx);
			}
			setState(158);
			match(QUOTE);
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
	public static class TypedIdContext extends ParserRuleContext {
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TypedIdContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_typedId; }
	}

	public final TypedIdContext typedId() throws RecognitionException {
		TypedIdContext _localctx = new TypedIdContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_typedId);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			type();
			setState(161);
			match(ID);
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
	public static class AdaptingContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public AdaptingContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_adapting; }
	}

	public final AdaptingContext adapting() throws RecognitionException {
		AdaptingContext _localctx = new AdaptingContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_adapting);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(163);
			match(ID);
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
	public static class ObjectContext extends ParserRuleContext {
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public AdaptingContext adapting() {
			return getRuleContext(AdaptingContext.class,0);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public ObjectContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_object; }
	}

	public final ObjectContext object() throws RecognitionException {
		ObjectContext _localctx = new ObjectContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_object);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(166);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID) {
				{
				setState(165);
				adapting();
				}
			}

			setState(168);
			match(LCURLY);
			setState(172);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4767482418039808L) != 0)) {
				{
				{
				setState(169);
				field();
				}
				}
				setState(174);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(175);
			match(RCURLY);
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
	public static class FieldContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode ASSIGN() { return getToken(UCMParser.ASSIGN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TerminalNode HIDDEN_() { return getToken(UCMParser.HIDDEN_, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public FieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_field; }
	}

	public final FieldContext field() throws RecognitionException {
		FieldContext _localctx = new FieldContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_field);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(178);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(177);
				match(HIDDEN_);
				}
			}

			setState(181);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				{
				setState(180);
				type();
				}
				break;
			}
			setState(183);
			match(ID);
			setState(184);
			match(ASSIGN);
			setState(185);
			expr(0);
			setState(186);
			match(SEMI);
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
	public static class ArrayContext extends ParserRuleContext {
		public TerminalNode LBRACKET() { return getToken(UCMParser.LBRACKET, 0); }
		public TerminalNode RBRACKET() { return getToken(UCMParser.RBRACKET, 0); }
		public List<ValueContext> value() {
			return getRuleContexts(ValueContext.class);
		}
		public ValueContext value(int i) {
			return getRuleContext(ValueContext.class,i);
		}
		public ListConstructionContext listConstruction() {
			return getRuleContext(ListConstructionContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(UCMParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(UCMParser.COMMA, i);
		}
		public ArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array; }
	}

	public final ArrayContext array() throws RecognitionException {
		ArrayContext _localctx = new ArrayContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(188);
			match(LBRACKET);
			setState(199);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				setState(189);
				value();
				setState(194);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(190);
					match(COMMA);
					setState(191);
					value();
					}
					}
					setState(196);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case 2:
				{
				setState(197);
				listConstruction();
				}
				break;
			case 3:
				{
				}
				break;
			}
			setState(201);
			match(RBRACKET);
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
	public static class EvaluaterArrayContext extends ParserRuleContext {
		public TerminalNode LBRACKET() { return getToken(UCMParser.LBRACKET, 0); }
		public TerminalNode RBRACKET() { return getToken(UCMParser.RBRACKET, 0); }
		public List<BoolExprContext> boolExpr() {
			return getRuleContexts(BoolExprContext.class);
		}
		public BoolExprContext boolExpr(int i) {
			return getRuleContext(BoolExprContext.class,i);
		}
		public List<TerminalNode> ID() { return getTokens(UCMParser.ID); }
		public TerminalNode ID(int i) {
			return getToken(UCMParser.ID, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(UCMParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(UCMParser.COMMA, i);
		}
		public EvaluaterArrayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_evaluaterArray; }
	}

	public final EvaluaterArrayContext evaluaterArray() throws RecognitionException {
		EvaluaterArrayContext _localctx = new EvaluaterArrayContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_evaluaterArray);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(203);
			match(LBRACKET);
			setState(219);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case THIS_KEYWORD:
			case MINUS:
			case NOT:
			case LPAREN:
			case BOOL:
			case INT:
			case FLOAT:
			case ID:
				{
				setState(206);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
				case 1:
					{
					setState(204);
					boolExpr(0);
					}
					break;
				case 2:
					{
					setState(205);
					match(ID);
					}
					break;
				}
				setState(215);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(208);
					match(COMMA);
					setState(211);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
					case 1:
						{
						setState(209);
						boolExpr(0);
						}
						break;
					case 2:
						{
						setState(210);
						match(ID);
						}
						break;
					}
					}
					}
					setState(217);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case RBRACKET:
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(221);
			match(RBRACKET);
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
	public static class TemplateFieldContext extends ParserRuleContext {
		public TypedIdContext typedId() {
			return getRuleContext(TypedIdContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TerminalNode ASSIGN() { return getToken(UCMParser.ASSIGN, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public TerminalNode COLON() { return getToken(UCMParser.COLON, 0); }
		public EvaluaterArrayContext evaluaterArray() {
			return getRuleContext(EvaluaterArrayContext.class,0);
		}
		public TemplateFieldContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_templateField; }
	}

	public final TemplateFieldContext templateField() throws RecognitionException {
		TemplateFieldContext _localctx = new TemplateFieldContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_templateField);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(223);
			typedId();
			setState(226);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASSIGN) {
				{
				setState(224);
				match(ASSIGN);
				setState(225);
				value();
				}
			}

			setState(230);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(228);
				match(COLON);
				setState(229);
				evaluaterArray();
				}
			}

			setState(232);
			match(SEMI);
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
	public static class TemplateExtentionContext extends ParserRuleContext {
		public TerminalNode EXTENDS_KEYWORD() { return getToken(UCMParser.EXTENDS_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TemplateExtentionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_templateExtention; }
	}

	public final TemplateExtentionContext templateExtention() throws RecognitionException {
		TemplateExtentionContext _localctx = new TemplateExtentionContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_templateExtention);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(234);
			match(EXTENDS_KEYWORD);
			setState(235);
			match(ID);
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
	public static class TemplateDefenitionContext extends ParserRuleContext {
		public TerminalNode TEMPLATE_KEYWORD() { return getToken(UCMParser.TEMPLATE_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TemplateExtentionContext templateExtention() {
			return getRuleContext(TemplateExtentionContext.class,0);
		}
		public List<TemplateFieldContext> templateField() {
			return getRuleContexts(TemplateFieldContext.class);
		}
		public TemplateFieldContext templateField(int i) {
			return getRuleContext(TemplateFieldContext.class,i);
		}
		public List<MethodContext> method() {
			return getRuleContexts(MethodContext.class);
		}
		public MethodContext method(int i) {
			return getRuleContext(MethodContext.class,i);
		}
		public TemplateDefenitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_templateDefenition; }
	}

	public final TemplateDefenitionContext templateDefenition() throws RecognitionException {
		TemplateDefenitionContext _localctx = new TemplateDefenitionContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_templateDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(237);
			match(TEMPLATE_KEYWORD);
			setState(238);
			match(ID);
			setState(240);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXTENDS_KEYWORD) {
				{
				setState(239);
				templateExtention();
				}
			}

			setState(242);
			match(LCURLY);
			setState(247);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4767482418038784L) != 0)) {
				{
				setState(245);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
				case 1:
					{
					setState(243);
					templateField();
					}
					break;
				case 2:
					{
					setState(244);
					method();
					}
					break;
				}
				}
				setState(249);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(250);
			match(RCURLY);
			setState(251);
			match(SEMI);
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
	public static class FunctionCollectionContext extends ParserRuleContext {
		public TerminalNode FUNCTIONS_KEYWORD() { return getToken(UCMParser.FUNCTIONS_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public List<MethodContext> method() {
			return getRuleContexts(MethodContext.class);
		}
		public MethodContext method(int i) {
			return getRuleContext(MethodContext.class,i);
		}
		public FunctionCollectionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCollection; }
	}

	public final FunctionCollectionContext functionCollection() throws RecognitionException {
		FunctionCollectionContext _localctx = new FunctionCollectionContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_functionCollection);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(253);
			match(FUNCTIONS_KEYWORD);
			setState(254);
			match(ID);
			setState(255);
			match(LCURLY);
			setState(259);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4767482418038784L) != 0)) {
				{
				{
				setState(256);
				method();
				}
				}
				setState(261);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(262);
			match(RCURLY);
			setState(263);
			match(SEMI);
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
	public static class MethodContext extends ParserRuleContext {
		public List<TypedIdContext> typedId() {
			return getRuleContexts(TypedIdContext.class);
		}
		public TypedIdContext typedId(int i) {
			return getRuleContext(TypedIdContext.class,i);
		}
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public StatementListContext statementList() {
			return getRuleContext(StatementListContext.class,0);
		}
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public List<TerminalNode> COMMA() { return getTokens(UCMParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(UCMParser.COMMA, i);
		}
		public MethodContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_method; }
	}

	public final MethodContext method() throws RecognitionException {
		MethodContext _localctx = new MethodContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_method);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(265);
			typedId();
			setState(266);
			match(LPAREN);
			setState(276);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OBJECT_KEYWORD:
			case INT_T:
			case FLOAT_T:
			case STRING_T:
			case BOOL_T:
			case ID:
				{
				setState(267);
				typedId();
				setState(272);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(268);
					match(COMMA);
					setState(269);
					typedId();
					}
					}
					setState(274);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case RPAREN:
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(278);
			match(RPAREN);
			setState(279);
			match(LCURLY);
			setState(280);
			statementList();
			setState(281);
			match(RCURLY);
			setState(282);
			match(SEMI);
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
	public static class FunctionCollectionCallContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode DOT() { return getToken(UCMParser.DOT, 0); }
		public FunctionCollectionCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionCollectionCall; }
	}

	public final FunctionCollectionCallContext functionCollectionCall() throws RecognitionException {
		FunctionCollectionCallContext _localctx = new FunctionCollectionCallContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_functionCollectionCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(284);
			match(ID);
			setState(285);
			match(DOT);
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
	public static class MethodCallContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public FunctionCollectionCallContext functionCollectionCall() {
			return getRuleContext(FunctionCollectionCallContext.class,0);
		}
		public List<TerminalNode> COMMA() { return getTokens(UCMParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(UCMParser.COMMA, i);
		}
		public MethodCallContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_methodCall; }
	}

	public final MethodCallContext methodCall() throws RecognitionException {
		MethodCallContext _localctx = new MethodCallContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_methodCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(288);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,31,_ctx) ) {
			case 1:
				{
				setState(287);
				functionCollectionCall();
				}
				break;
			}
			setState(290);
			match(ID);
			setState(291);
			match(LPAREN);
			setState(301);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,33,_ctx) ) {
			case 1:
				{
				setState(292);
				expr(0);
				setState(297);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(293);
					match(COMMA);
					setState(294);
					expr(0);
					}
					}
					setState(299);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case 2:
				{
				}
				break;
			}
			setState(303);
			match(RPAREN);
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
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public NumExprContext numExpr() {
			return getRuleContext(NumExprContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public TerminalNode EQ() { return getToken(UCMParser.EQ, 0); }
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 46;
		enterRecursionRule(_localctx, 46, RULE_expr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(311);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,34,_ctx) ) {
			case 1:
				{
				setState(306);
				value();
				}
				break;
			case 2:
				{
				setState(307);
				match(ID);
				}
				break;
			case 3:
				{
				setState(308);
				methodCall();
				}
				break;
			case 4:
				{
				setState(309);
				boolExpr(0);
				}
				break;
			case 5:
				{
				setState(310);
				numExpr(0);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(318);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,35,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expr);
					setState(313);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(314);
					match(EQ);
					setState(315);
					expr(3);
					}
					} 
				}
				setState(320);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,35,_ctx);
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
	public static class NumExprContext extends ParserRuleContext {
		public NumContext num() {
			return getRuleContext(NumContext.class,0);
		}
		public TerminalNode THIS_KEYWORD() { return getToken(UCMParser.THIS_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
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
		int _startState = 48;
		enterRecursionRule(_localctx, 48, RULE_numExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(332);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,36,_ctx) ) {
			case 1:
				{
				setState(322);
				num();
				}
				break;
			case 2:
				{
				setState(323);
				match(THIS_KEYWORD);
				}
				break;
			case 3:
				{
				setState(324);
				match(ID);
				}
				break;
			case 4:
				{
				setState(325);
				methodCall();
				}
				break;
			case 5:
				{
				setState(326);
				match(MINUS);
				setState(327);
				numExpr(4);
				}
				break;
			case 6:
				{
				setState(328);
				match(LPAREN);
				setState(329);
				numExpr(0);
				setState(330);
				match(RPAREN);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(342);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(340);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
					case 1:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(334);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(335);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 622592L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(336);
						numExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(337);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(338);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(339);
						numExpr(3);
						}
						break;
					}
					} 
				}
				setState(344);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,38,_ctx);
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
		public TerminalNode THIS_KEYWORD() { return getToken(UCMParser.THIS_KEYWORD, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
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
		int _startState = 50;
		enterRecursionRule(_localctx, 50, RULE_boolExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(356);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,39,_ctx) ) {
			case 1:
				{
				setState(346);
				match(BOOL);
				}
				break;
			case 2:
				{
				setState(347);
				match(THIS_KEYWORD);
				}
				break;
			case 3:
				{
				setState(348);
				match(ID);
				}
				break;
			case 4:
				{
				setState(349);
				methodCall();
				}
				break;
			case 5:
				{
				setState(350);
				match(NOT);
				setState(351);
				expr(0);
				}
				break;
			case 6:
				{
				setState(352);
				numExpr(0);
				setState(353);
				compExpr();
				setState(354);
				numExpr(0);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(369);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(367);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
					case 1:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(358);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(359);
						match(EQ);
						setState(360);
						boolExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(361);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(362);
						match(AND);
						setState(363);
						boolExpr(3);
						}
						break;
					case 3:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(364);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(365);
						match(OR);
						setState(366);
						boolExpr(2);
						}
						break;
					}
					} 
				}
				setState(371);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,41,_ctx);
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
		enterRule(_localctx, 52, RULE_compExpr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(372);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 264241152L) != 0)) ) {
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
	public static class IfStatementContext extends ParserRuleContext {
		public TerminalNode IF() { return getToken(UCMParser.IF, 0); }
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public IfStatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifStatement; }
	}

	public final IfStatementContext ifStatement() throws RecognitionException {
		IfStatementContext _localctx = new IfStatementContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_ifStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(374);
			match(IF);
			setState(375);
			match(LPAREN);
			setState(376);
			boolExpr(0);
			setState(377);
			match(RPAREN);
			setState(378);
			match(LCURLY);
			setState(379);
			statement();
			setState(380);
			match(RCURLY);
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
	public static class ConditionalContext extends ParserRuleContext {
		public List<IfStatementContext> ifStatement() {
			return getRuleContexts(IfStatementContext.class);
		}
		public IfStatementContext ifStatement(int i) {
			return getRuleContext(IfStatementContext.class,i);
		}
		public List<TerminalNode> ELSE() { return getTokens(UCMParser.ELSE); }
		public TerminalNode ELSE(int i) {
			return getToken(UCMParser.ELSE, i);
		}
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public ConditionalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_conditional; }
	}

	public final ConditionalContext conditional() throws RecognitionException {
		ConditionalContext _localctx = new ConditionalContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_conditional);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(382);
			ifStatement();
			setState(387);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(383);
					match(ELSE);
					setState(384);
					ifStatement();
					}
					} 
				}
				setState(389);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			}
			setState(392);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(390);
				match(ELSE);
				setState(391);
				statement();
				}
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
	public static class WhileLoopContext extends ParserRuleContext {
		public TerminalNode WHILE() { return getToken(UCMParser.WHILE, 0); }
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public BoolExprContext boolExpr() {
			return getRuleContext(BoolExprContext.class,0);
		}
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public WhileLoopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whileLoop; }
	}

	public final WhileLoopContext whileLoop() throws RecognitionException {
		WhileLoopContext _localctx = new WhileLoopContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_whileLoop);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(394);
			match(WHILE);
			setState(395);
			match(LPAREN);
			setState(396);
			boolExpr(0);
			setState(397);
			match(RPAREN);
			setState(398);
			match(LCURLY);
			setState(399);
			statement();
			setState(400);
			match(RCURLY);
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
	public static class ForLoopContext extends ParserRuleContext {
		public TerminalNode FOR() { return getToken(UCMParser.FOR, 0); }
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode IN() { return getToken(UCMParser.IN, 0); }
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public StatementContext statement() {
			return getRuleContext(StatementContext.class,0);
		}
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
		public ForLoopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_forLoop; }
	}

	public final ForLoopContext forLoop() throws RecognitionException {
		ForLoopContext _localctx = new ForLoopContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_forLoop);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(402);
			match(FOR);
			setState(403);
			match(LPAREN);
			setState(404);
			match(ID);
			setState(405);
			match(IN);
			setState(408);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LBRACKET:
				{
				setState(406);
				array();
				}
				break;
			case ID:
				{
				setState(407);
				methodCall();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(410);
			match(RPAREN);
			setState(411);
			match(LCURLY);
			setState(412);
			statement();
			setState(413);
			match(RCURLY);
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
	public static class ListConstructionContext extends ParserRuleContext {
		public TerminalNode FOR() { return getToken(UCMParser.FOR, 0); }
		public TerminalNode LPAREN() { return getToken(UCMParser.LPAREN, 0); }
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode IN() { return getToken(UCMParser.IN, 0); }
		public TerminalNode RPAREN() { return getToken(UCMParser.RPAREN, 0); }
		public TerminalNode LCURLY() { return getToken(UCMParser.LCURLY, 0); }
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public TerminalNode RCURLY() { return getToken(UCMParser.RCURLY, 0); }
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
		public ListConstructionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_listConstruction; }
	}

	public final ListConstructionContext listConstruction() throws RecognitionException {
		ListConstructionContext _localctx = new ListConstructionContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_listConstruction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(415);
			match(FOR);
			setState(416);
			match(LPAREN);
			setState(417);
			match(ID);
			setState(418);
			match(IN);
			setState(421);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LBRACKET:
				{
				setState(419);
				array();
				}
				break;
			case ID:
				{
				setState(420);
				methodCall();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(423);
			match(RPAREN);
			setState(424);
			match(LCURLY);
			setState(425);
			value();
			setState(426);
			match(RCURLY);
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
	public static class StatementListContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public StatementListContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statementList; }
	}

	public final StatementListContext statementList() throws RecognitionException {
		StatementListContext _localctx = new StatementListContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_statementList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(431);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4767482418040040L) != 0)) {
				{
				{
				setState(428);
				statement();
				}
				}
				setState(433);
				_errHandler.sync(this);
				_la = _input.LA(1);
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
	public static class StatementContext extends ParserRuleContext {
		public ConditionalContext conditional() {
			return getRuleContext(ConditionalContext.class,0);
		}
		public AssignmentContext assignment() {
			return getRuleContext(AssignmentContext.class,0);
		}
		public WhileLoopContext whileLoop() {
			return getRuleContext(WhileLoopContext.class,0);
		}
		public ForLoopContext forLoop() {
			return getRuleContext(ForLoopContext.class,0);
		}
		public MethodCallContext methodCall() {
			return getRuleContext(MethodCallContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public MethodContext method() {
			return getRuleContext(MethodContext.class,0);
		}
		public TerminalNode RETURN() { return getToken(UCMParser.RETURN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 66, RULE_statement);
		try {
			setState(446);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,47,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(434);
				conditional();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(435);
				assignment();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(436);
				whileLoop();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(437);
				forLoop();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(438);
				methodCall();
				setState(439);
				match(SEMI);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(441);
				method();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(442);
				match(RETURN);
				setState(443);
				expr(0);
				setState(444);
				match(SEMI);
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
	public static class AssignmentContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode ASSIGN() { return getToken(UCMParser.ASSIGN, 0); }
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TerminalNode HIDDEN_() { return getToken(UCMParser.HIDDEN_, 0); }
		public TypeContext type() {
			return getRuleContext(TypeContext.class,0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_assignment; }
	}

	public final AssignmentContext assignment() throws RecognitionException {
		AssignmentContext _localctx = new AssignmentContext(_ctx, getState());
		enterRule(_localctx, 68, RULE_assignment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(449);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(448);
				match(HIDDEN_);
				}
			}

			setState(452);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,49,_ctx) ) {
			case 1:
				{
				setState(451);
				type();
				}
				break;
			}
			setState(454);
			match(ID);
			setState(455);
			match(ASSIGN);
			setState(456);
			expr(0);
			setState(457);
			match(SEMI);
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
	public static class ObjectDefenitionContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode ASSIGN() { return getToken(UCMParser.ASSIGN, 0); }
		public ObjectContext object() {
			return getRuleContext(ObjectContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TerminalNode HIDDEN_() { return getToken(UCMParser.HIDDEN_, 0); }
		public Object_tContext object_t() {
			return getRuleContext(Object_tContext.class,0);
		}
		public ObjectDefenitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_objectDefenition; }
	}

	public final ObjectDefenitionContext objectDefenition() throws RecognitionException {
		ObjectDefenitionContext _localctx = new ObjectDefenitionContext(_ctx, getState());
		enterRule(_localctx, 70, RULE_objectDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(460);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(459);
				match(HIDDEN_);
				}
			}

			setState(463);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,51,_ctx) ) {
			case 1:
				{
				setState(462);
				object_t();
				}
				break;
			}
			setState(465);
			match(ID);
			setState(466);
			match(ASSIGN);
			setState(467);
			object();
			setState(468);
			match(SEMI);
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
	public static class ArrayDefenitionContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(UCMParser.ID, 0); }
		public TerminalNode ASSIGN() { return getToken(UCMParser.ASSIGN, 0); }
		public ArrayContext array() {
			return getRuleContext(ArrayContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public TerminalNode HIDDEN_() { return getToken(UCMParser.HIDDEN_, 0); }
		public Array_tContext array_t() {
			return getRuleContext(Array_tContext.class,0);
		}
		public ArrayDefenitionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arrayDefenition; }
	}

	public final ArrayDefenitionContext arrayDefenition() throws RecognitionException {
		ArrayDefenitionContext _localctx = new ArrayDefenitionContext(_ctx, getState());
		enterRule(_localctx, 72, RULE_arrayDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(471);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(470);
				match(HIDDEN_);
				}
			}

			setState(474);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,53,_ctx) ) {
			case 1:
				{
				setState(473);
				array_t();
				}
				break;
			}
			setState(476);
			match(ID);
			setState(477);
			match(ASSIGN);
			setState(478);
			array();
			setState(479);
			match(SEMI);
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
	public static class DeclarationContext extends ParserRuleContext {
		public TypedIdContext typedId() {
			return getRuleContext(TypedIdContext.class,0);
		}
		public TerminalNode SEMI() { return getToken(UCMParser.SEMI, 0); }
		public DeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declaration; }
	}

	public final DeclarationContext declaration() throws RecognitionException {
		DeclarationContext _localctx = new DeclarationContext(_ctx, getState());
		enterRule(_localctx, 74, RULE_declaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(481);
			typedId();
			setState(482);
			match(SEMI);
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
	public static class RootContext extends ParserRuleContext {
		public List<TemplateDefenitionContext> templateDefenition() {
			return getRuleContexts(TemplateDefenitionContext.class);
		}
		public TemplateDefenitionContext templateDefenition(int i) {
			return getRuleContext(TemplateDefenitionContext.class,i);
		}
		public List<ObjectDefenitionContext> objectDefenition() {
			return getRuleContexts(ObjectDefenitionContext.class);
		}
		public ObjectDefenitionContext objectDefenition(int i) {
			return getRuleContext(ObjectDefenitionContext.class,i);
		}
		public List<ArrayDefenitionContext> arrayDefenition() {
			return getRuleContexts(ArrayDefenitionContext.class);
		}
		public ArrayDefenitionContext arrayDefenition(int i) {
			return getRuleContext(ArrayDefenitionContext.class,i);
		}
		public List<FunctionCollectionContext> functionCollection() {
			return getRuleContexts(FunctionCollectionContext.class);
		}
		public FunctionCollectionContext functionCollection(int i) {
			return getRuleContext(FunctionCollectionContext.class,i);
		}
		public List<FieldContext> field() {
			return getRuleContexts(FieldContext.class);
		}
		public FieldContext field(int i) {
			return getRuleContext(FieldContext.class,i);
		}
		public RootContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_root; }
	}

	public final RootContext root() throws RecognitionException {
		RootContext _localctx = new RootContext(_ctx, getState());
		enterRule(_localctx, 76, RULE_root);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(491);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4767482418044160L) != 0)) {
				{
				setState(489);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
				case 1:
					{
					setState(484);
					templateDefenition();
					}
					break;
				case 2:
					{
					setState(485);
					objectDefenition();
					}
					break;
				case 3:
					{
					setState(486);
					arrayDefenition();
					}
					break;
				case 4:
					{
					setState(487);
					functionCollection();
					}
					break;
				case 5:
					{
					setState(488);
					field();
					}
					break;
				}
				}
				setState(493);
				_errHandler.sync(this);
				_la = _input.LA(1);
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
	public static class StartContext extends ParserRuleContext {
		public RootContext root() {
			return getRuleContext(RootContext.class,0);
		}
		public StartContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_start; }
	}

	public final StartContext start() throws RecognitionException {
		StartContext _localctx = new StartContext(_ctx, getState());
		enterRule(_localctx, 78, RULE_start);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(494);
			root();
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
		case 23:
			return expr_sempred((ExprContext)_localctx, predIndex);
		case 24:
			return numExpr_sempred((NumExprContext)_localctx, predIndex);
		case 25:
			return boolExpr_sempred((BoolExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean numExpr_sempred(NumExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 1:
			return precpred(_ctx, 3);
		case 2:
			return precpred(_ctx, 2);
		}
		return true;
	}
	private boolean boolExpr_sempred(BoolExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 3:
			return precpred(_ctx, 3);
		case 4:
			return precpred(_ctx, 2);
		case 5:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u00014\u01f1\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
		"\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004\u0002"+
		"\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007\u0002"+
		"\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b\u0002"+
		"\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007\u000f"+
		"\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007\u0012"+
		"\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002\u0015\u0007\u0015"+
		"\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002\u0018\u0007\u0018"+
		"\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002\u001b\u0007\u001b"+
		"\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002\u001e\u0007\u001e"+
		"\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007!\u0002\"\u0007\"\u0002"+
		"#\u0007#\u0002$\u0007$\u0002%\u0007%\u0002&\u0007&\u0002\'\u0007\'\u0001"+
		"\u0000\u0001\u0000\u0001\u0001\u0001\u0001\u0003\u0001U\b\u0001\u0001"+
		"\u0001\u0001\u0001\u0004\u0001Y\b\u0001\u000b\u0001\f\u0001Z\u0001\u0002"+
		"\u0001\u0002\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003b\b\u0003"+
		"\u0001\u0004\u0001\u0004\u0003\u0004f\b\u0004\u0001\u0005\u0001\u0005"+
		"\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0003\u0006q\b\u0006\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0003\u0007w\b\u0007\u0001\u0007\u0001\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0003\u0007\u007f\b\u0007\u0001\u0007"+
		"\u0001\u0007\u0001\u0007\u0001\u0007\u0003\u0007\u0085\b\u0007\u0005\u0007"+
		"\u0087\b\u0007\n\u0007\f\u0007\u008a\t\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0005\b\u0092\b\b\n\b\f\b\u0095\t\b\u0001\t"+
		"\u0001\t\u0001\t\u0005\t\u009a\b\t\n\t\f\t\u009d\t\t\u0001\t\u0001\t\u0001"+
		"\n\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001\f\u0003\f\u00a7\b\f\u0001"+
		"\f\u0001\f\u0005\f\u00ab\b\f\n\f\f\f\u00ae\t\f\u0001\f\u0001\f\u0001\r"+
		"\u0003\r\u00b3\b\r\u0001\r\u0003\r\u00b6\b\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0005\u000e"+
		"\u00c1\b\u000e\n\u000e\f\u000e\u00c4\t\u000e\u0001\u000e\u0001\u000e\u0003"+
		"\u000e\u00c8\b\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001"+
		"\u000f\u0003\u000f\u00cf\b\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0003"+
		"\u000f\u00d4\b\u000f\u0005\u000f\u00d6\b\u000f\n\u000f\f\u000f\u00d9\t"+
		"\u000f\u0001\u000f\u0003\u000f\u00dc\b\u000f\u0001\u000f\u0001\u000f\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0003\u0010\u00e3\b\u0010\u0001\u0010\u0001"+
		"\u0010\u0003\u0010\u00e7\b\u0010\u0001\u0010\u0001\u0010\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0003\u0012\u00f1"+
		"\b\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0005\u0012\u00f6\b\u0012"+
		"\n\u0012\f\u0012\u00f9\t\u0012\u0001\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0005\u0013\u0102\b\u0013\n"+
		"\u0013\f\u0013\u0105\t\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0005\u0014\u010f"+
		"\b\u0014\n\u0014\f\u0014\u0112\t\u0014\u0001\u0014\u0003\u0014\u0115\b"+
		"\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0001"+
		"\u0014\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0016\u0003\u0016\u0121"+
		"\b\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0005"+
		"\u0016\u0128\b\u0016\n\u0016\f\u0016\u012b\t\u0016\u0001\u0016\u0003\u0016"+
		"\u012e\b\u0016\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0001\u0017\u0003\u0017\u0138\b\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0005\u0017\u013d\b\u0017\n\u0017\f\u0017\u0140"+
		"\t\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0003"+
		"\u0018\u014d\b\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0005\u0018\u0155\b\u0018\n\u0018\f\u0018\u0158\t\u0018"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0003\u0019"+
		"\u0165\b\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u0019\u0005\u0019\u0170\b\u0019"+
		"\n\u0019\f\u0019\u0173\t\u0019\u0001\u001a\u0001\u001a\u0001\u001b\u0001"+
		"\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001"+
		"\u001b\u0001\u001c\u0001\u001c\u0001\u001c\u0005\u001c\u0182\b\u001c\n"+
		"\u001c\f\u001c\u0185\t\u001c\u0001\u001c\u0001\u001c\u0003\u001c\u0189"+
		"\b\u001c\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0001\u001e\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0003\u001e\u0199\b\u001e\u0001\u001e\u0001"+
		"\u001e\u0001\u001e\u0001\u001e\u0001\u001e\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0003\u001f\u01a6\b\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001 \u0005 \u01ae"+
		"\b \n \f \u01b1\t \u0001!\u0001!\u0001!\u0001!\u0001!\u0001!\u0001!\u0001"+
		"!\u0001!\u0001!\u0001!\u0001!\u0003!\u01bf\b!\u0001\"\u0003\"\u01c2\b"+
		"\"\u0001\"\u0003\"\u01c5\b\"\u0001\"\u0001\"\u0001\"\u0001\"\u0001\"\u0001"+
		"#\u0003#\u01cd\b#\u0001#\u0003#\u01d0\b#\u0001#\u0001#\u0001#\u0001#\u0001"+
		"#\u0001$\u0003$\u01d8\b$\u0001$\u0003$\u01db\b$\u0001$\u0001$\u0001$\u0001"+
		"$\u0001$\u0001%\u0001%\u0001%\u0001&\u0001&\u0001&\u0001&\u0001&\u0005"+
		"&\u01ea\b&\n&\f&\u01ed\t&\u0001\'\u0001\'\u0001\'\u0001\u009b\u0003.0"+
		"2(\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a"+
		"\u001c\u001e \"$&(*,.02468:<>@BDFHJLN\u0000\u0006\u0002\u0000\u000b\u000b"+
		"44\u0002\u0000,-//\u0001\u000012\u0002\u0000\u000f\u0010\u0013\u0013\u0001"+
		"\u0000\u0011\u0012\u0001\u0000\u0016\u001b\u021c\u0000P\u0001\u0000\u0000"+
		"\u0000\u0002T\u0001\u0000\u0000\u0000\u0004\\\u0001\u0000\u0000\u0000"+
		"\u0006a\u0001\u0000\u0000\u0000\be\u0001\u0000\u0000\u0000\ng\u0001\u0000"+
		"\u0000\u0000\fp\u0001\u0000\u0000\u0000\u000er\u0001\u0000\u0000\u0000"+
		"\u0010\u0093\u0001\u0000\u0000\u0000\u0012\u0096\u0001\u0000\u0000\u0000"+
		"\u0014\u00a0\u0001\u0000\u0000\u0000\u0016\u00a3\u0001\u0000\u0000\u0000"+
		"\u0018\u00a6\u0001\u0000\u0000\u0000\u001a\u00b2\u0001\u0000\u0000\u0000"+
		"\u001c\u00bc\u0001\u0000\u0000\u0000\u001e\u00cb\u0001\u0000\u0000\u0000"+
		" \u00df\u0001\u0000\u0000\u0000\"\u00ea\u0001\u0000\u0000\u0000$\u00ed"+
		"\u0001\u0000\u0000\u0000&\u00fd\u0001\u0000\u0000\u0000(\u0109\u0001\u0000"+
		"\u0000\u0000*\u011c\u0001\u0000\u0000\u0000,\u0120\u0001\u0000\u0000\u0000"+
		".\u0137\u0001\u0000\u0000\u00000\u014c\u0001\u0000\u0000\u00002\u0164"+
		"\u0001\u0000\u0000\u00004\u0174\u0001\u0000\u0000\u00006\u0176\u0001\u0000"+
		"\u0000\u00008\u017e\u0001\u0000\u0000\u0000:\u018a\u0001\u0000\u0000\u0000"+
		"<\u0192\u0001\u0000\u0000\u0000>\u019f\u0001\u0000\u0000\u0000@\u01af"+
		"\u0001\u0000\u0000\u0000B\u01be\u0001\u0000\u0000\u0000D\u01c1\u0001\u0000"+
		"\u0000\u0000F\u01cc\u0001\u0000\u0000\u0000H\u01d7\u0001\u0000\u0000\u0000"+
		"J\u01e1\u0001\u0000\u0000\u0000L\u01eb\u0001\u0000\u0000\u0000N\u01ee"+
		"\u0001\u0000\u0000\u0000PQ\u0007\u0000\u0000\u0000Q\u0001\u0001\u0000"+
		"\u0000\u0000RU\u0003\u0004\u0002\u0000SU\u0003\u0000\u0000\u0000TR\u0001"+
		"\u0000\u0000\u0000TS\u0001\u0000\u0000\u0000UX\u0001\u0000\u0000\u0000"+
		"VW\u0005\"\u0000\u0000WY\u0005#\u0000\u0000XV\u0001\u0000\u0000\u0000"+
		"YZ\u0001\u0000\u0000\u0000ZX\u0001\u0000\u0000\u0000Z[\u0001\u0000\u0000"+
		"\u0000[\u0003\u0001\u0000\u0000\u0000\\]\u0007\u0001\u0000\u0000]\u0005"+
		"\u0001\u0000\u0000\u0000^b\u0003\u0000\u0000\u0000_b\u0003\u0002\u0001"+
		"\u0000`b\u0005.\u0000\u0000a^\u0001\u0000\u0000\u0000a_\u0001\u0000\u0000"+
		"\u0000a`\u0001\u0000\u0000\u0000b\u0007\u0001\u0000\u0000\u0000cf\u0003"+
		"\u0004\u0002\u0000df\u0003\u0006\u0003\u0000ec\u0001\u0000\u0000\u0000"+
		"ed\u0001\u0000\u0000\u0000f\t\u0001\u0000\u0000\u0000gh\u0007\u0002\u0000"+
		"\u0000h\u000b\u0001\u0000\u0000\u0000iq\u0003\n\u0005\u0000jq\u0003\u000e"+
		"\u0007\u0000kq\u0003\u0010\b\u0000lq\u0003\u0012\t\u0000mq\u00050\u0000"+
		"\u0000nq\u0003\u0018\f\u0000oq\u0003\u001c\u000e\u0000pi\u0001\u0000\u0000"+
		"\u0000pj\u0001\u0000\u0000\u0000pk\u0001\u0000\u0000\u0000pl\u0001\u0000"+
		"\u0000\u0000pm\u0001\u0000\u0000\u0000pn\u0001\u0000\u0000\u0000po\u0001"+
		"\u0000\u0000\u0000q\r\u0001\u0000\u0000\u0000rs\u0005+\u0000\u0000s\u0088"+
		"\u0005*\u0000\u0000tw\u00053\u0000\u0000uw\t\u0000\u0000\u0000vt\u0001"+
		"\u0000\u0000\u0000vu\u0001\u0000\u0000\u0000vw\u0001\u0000\u0000\u0000"+
		"wx\u0001\u0000\u0000\u0000xy\u0005 \u0000\u0000yz\u0003.\u0017\u0000z"+
		"{\u0005!\u0000\u0000{\u0087\u0001\u0000\u0000\u0000|\u007f\u00053\u0000"+
		"\u0000}\u007f\t\u0000\u0000\u0000~|\u0001\u0000\u0000\u0000~}\u0001\u0000"+
		"\u0000\u0000\u007f\u0084\u0001\u0000\u0000\u0000\u0080\u0081\u0005 \u0000"+
		"\u0000\u0081\u0082\u0003.\u0017\u0000\u0082\u0083\u0005!\u0000\u0000\u0083"+
		"\u0085\u0001\u0000\u0000\u0000\u0084\u0080\u0001\u0000\u0000\u0000\u0084"+
		"\u0085\u0001\u0000\u0000\u0000\u0085\u0087\u0001\u0000\u0000\u0000\u0086"+
		"v\u0001\u0000\u0000\u0000\u0086~\u0001\u0000\u0000\u0000\u0087\u008a\u0001"+
		"\u0000\u0000\u0000\u0088\u0086\u0001\u0000\u0000\u0000\u0088\u0089\u0001"+
		"\u0000\u0000\u0000\u0089\u008b\u0001\u0000\u0000\u0000\u008a\u0088\u0001"+
		"\u0000\u0000\u0000\u008b\u008c\u0005*\u0000\u0000\u008c\u000f\u0001\u0000"+
		"\u0000\u0000\u008d\u008e\u0003\u0012\t\u0000\u008e\u008f\u0005\u0011\u0000"+
		"\u0000\u008f\u0090\u0003\u0012\t\u0000\u0090\u0092\u0001\u0000\u0000\u0000"+
		"\u0091\u008d\u0001\u0000\u0000\u0000\u0092\u0095\u0001\u0000\u0000\u0000"+
		"\u0093\u0091\u0001\u0000\u0000\u0000\u0093\u0094\u0001\u0000\u0000\u0000"+
		"\u0094\u0011\u0001\u0000\u0000\u0000\u0095\u0093\u0001\u0000\u0000\u0000"+
		"\u0096\u009b\u0005*\u0000\u0000\u0097\u009a\u00053\u0000\u0000\u0098\u009a"+
		"\t\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000\u0099\u0098\u0001"+
		"\u0000\u0000\u0000\u009a\u009d\u0001\u0000\u0000\u0000\u009b\u009c\u0001"+
		"\u0000\u0000\u0000\u009b\u0099\u0001\u0000\u0000\u0000\u009c\u009e\u0001"+
		"\u0000\u0000\u0000\u009d\u009b\u0001\u0000\u0000\u0000\u009e\u009f\u0005"+
		"*\u0000\u0000\u009f\u0013\u0001\u0000\u0000\u0000\u00a0\u00a1\u0003\b"+
		"\u0004\u0000\u00a1\u00a2\u00054\u0000\u0000\u00a2\u0015\u0001\u0000\u0000"+
		"\u0000\u00a3\u00a4\u00054\u0000\u0000\u00a4\u0017\u0001\u0000\u0000\u0000"+
		"\u00a5\u00a7\u0003\u0016\u000b\u0000\u00a6\u00a5\u0001\u0000\u0000\u0000"+
		"\u00a6\u00a7\u0001\u0000\u0000\u0000\u00a7\u00a8\u0001\u0000\u0000\u0000"+
		"\u00a8\u00ac\u0005 \u0000\u0000\u00a9\u00ab\u0003\u001a\r\u0000\u00aa"+
		"\u00a9\u0001\u0000\u0000\u0000\u00ab\u00ae\u0001\u0000\u0000\u0000\u00ac"+
		"\u00aa\u0001\u0000\u0000\u0000\u00ac\u00ad\u0001\u0000\u0000\u0000\u00ad"+
		"\u00af\u0001\u0000\u0000\u0000\u00ae\u00ac\u0001\u0000\u0000\u0000\u00af"+
		"\u00b0\u0005!\u0000\u0000\u00b0\u0019\u0001\u0000\u0000\u0000\u00b1\u00b3"+
		"\u0005\n\u0000\u0000\u00b2\u00b1\u0001\u0000\u0000\u0000\u00b2\u00b3\u0001"+
		"\u0000\u0000\u0000\u00b3\u00b5\u0001\u0000\u0000\u0000\u00b4\u00b6\u0003"+
		"\b\u0004\u0000\u00b5\u00b4\u0001\u0000\u0000\u0000\u00b5\u00b6\u0001\u0000"+
		"\u0000\u0000\u00b6\u00b7\u0001\u0000\u0000\u0000\u00b7\u00b8\u00054\u0000"+
		"\u0000\u00b8\u00b9\u0005)\u0000\u0000\u00b9\u00ba\u0003.\u0017\u0000\u00ba"+
		"\u00bb\u0005$\u0000\u0000\u00bb\u001b\u0001\u0000\u0000\u0000\u00bc\u00c7"+
		"\u0005\"\u0000\u0000\u00bd\u00c2\u0003\f\u0006\u0000\u00be\u00bf\u0005"+
		"&\u0000\u0000\u00bf\u00c1\u0003\f\u0006\u0000\u00c0\u00be\u0001\u0000"+
		"\u0000\u0000\u00c1\u00c4\u0001\u0000\u0000\u0000\u00c2\u00c0\u0001\u0000"+
		"\u0000\u0000\u00c2\u00c3\u0001\u0000\u0000\u0000\u00c3\u00c8\u0001\u0000"+
		"\u0000\u0000\u00c4\u00c2\u0001\u0000\u0000\u0000\u00c5\u00c8\u0003>\u001f"+
		"\u0000\u00c6\u00c8\u0001\u0000\u0000\u0000\u00c7\u00bd\u0001\u0000\u0000"+
		"\u0000\u00c7\u00c5\u0001\u0000\u0000\u0000\u00c7\u00c6\u0001\u0000\u0000"+
		"\u0000\u00c8\u00c9\u0001\u0000\u0000\u0000\u00c9\u00ca\u0005#\u0000\u0000"+
		"\u00ca\u001d\u0001\u0000\u0000\u0000\u00cb\u00db\u0005\"\u0000\u0000\u00cc"+
		"\u00cf\u00032\u0019\u0000\u00cd\u00cf\u00054\u0000\u0000\u00ce\u00cc\u0001"+
		"\u0000\u0000\u0000\u00ce\u00cd\u0001\u0000\u0000\u0000\u00cf\u00d7\u0001"+
		"\u0000\u0000\u0000\u00d0\u00d3\u0005&\u0000\u0000\u00d1\u00d4\u00032\u0019"+
		"\u0000\u00d2\u00d4\u00054\u0000\u0000\u00d3\u00d1\u0001\u0000\u0000\u0000"+
		"\u00d3\u00d2\u0001\u0000\u0000\u0000\u00d4\u00d6\u0001\u0000\u0000\u0000"+
		"\u00d5\u00d0\u0001\u0000\u0000\u0000\u00d6\u00d9\u0001\u0000\u0000\u0000"+
		"\u00d7\u00d5\u0001\u0000\u0000\u0000\u00d7\u00d8\u0001\u0000\u0000\u0000"+
		"\u00d8\u00dc\u0001\u0000\u0000\u0000\u00d9\u00d7\u0001\u0000\u0000\u0000"+
		"\u00da\u00dc\u0001\u0000\u0000\u0000\u00db\u00ce\u0001\u0000\u0000\u0000"+
		"\u00db\u00da\u0001\u0000\u0000\u0000\u00dc\u00dd\u0001\u0000\u0000\u0000"+
		"\u00dd\u00de\u0005#\u0000\u0000\u00de\u001f\u0001\u0000\u0000\u0000\u00df"+
		"\u00e2\u0003\u0014\n\u0000\u00e0\u00e1\u0005)\u0000\u0000\u00e1\u00e3"+
		"\u0003\f\u0006\u0000\u00e2\u00e0\u0001\u0000\u0000\u0000\u00e2\u00e3\u0001"+
		"\u0000\u0000\u0000\u00e3\u00e6\u0001\u0000\u0000\u0000\u00e4\u00e5\u0005"+
		"\'\u0000\u0000\u00e5\u00e7\u0003\u001e\u000f\u0000\u00e6\u00e4\u0001\u0000"+
		"\u0000\u0000\u00e6\u00e7\u0001\u0000\u0000\u0000\u00e7\u00e8\u0001\u0000"+
		"\u0000\u0000\u00e8\u00e9\u0005$\u0000\u0000\u00e9!\u0001\u0000\u0000\u0000"+
		"\u00ea\u00eb\u0005\r\u0000\u0000\u00eb\u00ec\u00054\u0000\u0000\u00ec"+
		"#\u0001\u0000\u0000\u0000\u00ed\u00ee\u0005\b\u0000\u0000\u00ee\u00f0"+
		"\u00054\u0000\u0000\u00ef\u00f1\u0003\"\u0011\u0000\u00f0\u00ef\u0001"+
		"\u0000\u0000\u0000\u00f0\u00f1\u0001\u0000\u0000\u0000\u00f1\u00f2\u0001"+
		"\u0000\u0000\u0000\u00f2\u00f7\u0005 \u0000\u0000\u00f3\u00f6\u0003 \u0010"+
		"\u0000\u00f4\u00f6\u0003(\u0014\u0000\u00f5\u00f3\u0001\u0000\u0000\u0000"+
		"\u00f5\u00f4\u0001\u0000\u0000\u0000\u00f6\u00f9\u0001\u0000\u0000\u0000"+
		"\u00f7\u00f5\u0001\u0000\u0000\u0000\u00f7\u00f8\u0001\u0000\u0000\u0000"+
		"\u00f8\u00fa\u0001\u0000\u0000\u0000\u00f9\u00f7\u0001\u0000\u0000\u0000"+
		"\u00fa\u00fb\u0005!\u0000\u0000\u00fb\u00fc\u0005$\u0000\u0000\u00fc%"+
		"\u0001\u0000\u0000\u0000\u00fd\u00fe\u0005\f\u0000\u0000\u00fe\u00ff\u0005"+
		"4\u0000\u0000\u00ff\u0103\u0005 \u0000\u0000\u0100\u0102\u0003(\u0014"+
		"\u0000\u0101\u0100\u0001\u0000\u0000\u0000\u0102\u0105\u0001\u0000\u0000"+
		"\u0000\u0103\u0101\u0001\u0000\u0000\u0000\u0103\u0104\u0001\u0000\u0000"+
		"\u0000\u0104\u0106\u0001\u0000\u0000\u0000\u0105\u0103\u0001\u0000\u0000"+
		"\u0000\u0106\u0107\u0005!\u0000\u0000\u0107\u0108\u0005$\u0000\u0000\u0108"+
		"\'\u0001\u0000\u0000\u0000\u0109\u010a\u0003\u0014\n\u0000\u010a\u0114"+
		"\u0005\u001e\u0000\u0000\u010b\u0110\u0003\u0014\n\u0000\u010c\u010d\u0005"+
		"&\u0000\u0000\u010d\u010f\u0003\u0014\n\u0000\u010e\u010c\u0001\u0000"+
		"\u0000\u0000\u010f\u0112\u0001\u0000\u0000\u0000\u0110\u010e\u0001\u0000"+
		"\u0000\u0000\u0110\u0111\u0001\u0000\u0000\u0000\u0111\u0115\u0001\u0000"+
		"\u0000\u0000\u0112\u0110\u0001\u0000\u0000\u0000\u0113\u0115\u0001\u0000"+
		"\u0000\u0000\u0114\u010b\u0001\u0000\u0000\u0000\u0114\u0113\u0001\u0000"+
		"\u0000\u0000\u0115\u0116\u0001\u0000\u0000\u0000\u0116\u0117\u0005\u001f"+
		"\u0000\u0000\u0117\u0118\u0005 \u0000\u0000\u0118\u0119\u0003@ \u0000"+
		"\u0119\u011a\u0005!\u0000\u0000\u011a\u011b\u0005$\u0000\u0000\u011b)"+
		"\u0001\u0000\u0000\u0000\u011c\u011d\u00054\u0000\u0000\u011d\u011e\u0005"+
		"%\u0000\u0000\u011e+\u0001\u0000\u0000\u0000\u011f\u0121\u0003*\u0015"+
		"\u0000\u0120\u011f\u0001\u0000\u0000\u0000\u0120\u0121\u0001\u0000\u0000"+
		"\u0000\u0121\u0122\u0001\u0000\u0000\u0000\u0122\u0123\u00054\u0000\u0000"+
		"\u0123\u012d\u0005\u001e\u0000\u0000\u0124\u0129\u0003.\u0017\u0000\u0125"+
		"\u0126\u0005&\u0000\u0000\u0126\u0128\u0003.\u0017\u0000\u0127\u0125\u0001"+
		"\u0000\u0000\u0000\u0128\u012b\u0001\u0000\u0000\u0000\u0129\u0127\u0001"+
		"\u0000\u0000\u0000\u0129\u012a\u0001\u0000\u0000\u0000\u012a\u012e\u0001"+
		"\u0000\u0000\u0000\u012b\u0129\u0001\u0000\u0000\u0000\u012c\u012e\u0001"+
		"\u0000\u0000\u0000\u012d\u0124\u0001\u0000\u0000\u0000\u012d\u012c\u0001"+
		"\u0000\u0000\u0000\u012e\u012f\u0001\u0000\u0000\u0000\u012f\u0130\u0005"+
		"\u001f\u0000\u0000\u0130-\u0001\u0000\u0000\u0000\u0131\u0132\u0006\u0017"+
		"\uffff\uffff\u0000\u0132\u0138\u0003\f\u0006\u0000\u0133\u0138\u00054"+
		"\u0000\u0000\u0134\u0138\u0003,\u0016\u0000\u0135\u0138\u00032\u0019\u0000"+
		"\u0136\u0138\u00030\u0018\u0000\u0137\u0131\u0001\u0000\u0000\u0000\u0137"+
		"\u0133\u0001\u0000\u0000\u0000\u0137\u0134\u0001\u0000\u0000\u0000\u0137"+
		"\u0135\u0001\u0000\u0000\u0000\u0137\u0136\u0001\u0000\u0000\u0000\u0138"+
		"\u013e\u0001\u0000\u0000\u0000\u0139\u013a\n\u0002\u0000\u0000\u013a\u013b"+
		"\u0005\u0016\u0000\u0000\u013b\u013d\u0003.\u0017\u0003\u013c\u0139\u0001"+
		"\u0000\u0000\u0000\u013d\u0140\u0001\u0000\u0000\u0000\u013e\u013c\u0001"+
		"\u0000\u0000\u0000\u013e\u013f\u0001\u0000\u0000\u0000\u013f/\u0001\u0000"+
		"\u0000\u0000\u0140\u013e\u0001\u0000\u0000\u0000\u0141\u0142\u0006\u0018"+
		"\uffff\uffff\u0000\u0142\u014d\u0003\n\u0005\u0000\u0143\u014d\u0005\u000e"+
		"\u0000\u0000\u0144\u014d\u00054\u0000\u0000\u0145\u014d\u0003,\u0016\u0000"+
		"\u0146\u0147\u0005\u0012\u0000\u0000\u0147\u014d\u00030\u0018\u0004\u0148"+
		"\u0149\u0005\u001e\u0000\u0000\u0149\u014a\u00030\u0018\u0000\u014a\u014b"+
		"\u0005\u001f\u0000\u0000\u014b\u014d\u0001\u0000\u0000\u0000\u014c\u0141"+
		"\u0001\u0000\u0000\u0000\u014c\u0143\u0001\u0000\u0000\u0000\u014c\u0144"+
		"\u0001\u0000\u0000\u0000\u014c\u0145\u0001\u0000\u0000\u0000\u014c\u0146"+
		"\u0001\u0000\u0000\u0000\u014c\u0148\u0001\u0000\u0000\u0000\u014d\u0156"+
		"\u0001\u0000\u0000\u0000\u014e\u014f\n\u0003\u0000\u0000\u014f\u0150\u0007"+
		"\u0003\u0000\u0000\u0150\u0155\u00030\u0018\u0004\u0151\u0152\n\u0002"+
		"\u0000\u0000\u0152\u0153\u0007\u0004\u0000\u0000\u0153\u0155\u00030\u0018"+
		"\u0003\u0154\u014e\u0001\u0000\u0000\u0000\u0154\u0151\u0001\u0000\u0000"+
		"\u0000\u0155\u0158\u0001\u0000\u0000\u0000\u0156\u0154\u0001\u0000\u0000"+
		"\u0000\u0156\u0157\u0001\u0000\u0000\u0000\u01571\u0001\u0000\u0000\u0000"+
		"\u0158\u0156\u0001\u0000\u0000\u0000\u0159\u015a\u0006\u0019\uffff\uffff"+
		"\u0000\u015a\u0165\u00050\u0000\u0000\u015b\u0165\u0005\u000e\u0000\u0000"+
		"\u015c\u0165\u00054\u0000\u0000\u015d\u0165\u0003,\u0016\u0000\u015e\u015f"+
		"\u0005\u001c\u0000\u0000\u015f\u0165\u0003.\u0017\u0000\u0160\u0161\u0003"+
		"0\u0018\u0000\u0161\u0162\u00034\u001a\u0000\u0162\u0163\u00030\u0018"+
		"\u0000\u0163\u0165\u0001\u0000\u0000\u0000\u0164\u0159\u0001\u0000\u0000"+
		"\u0000\u0164\u015b\u0001\u0000\u0000\u0000\u0164\u015c\u0001\u0000\u0000"+
		"\u0000\u0164\u015d\u0001\u0000\u0000\u0000\u0164\u015e\u0001\u0000\u0000"+
		"\u0000\u0164\u0160\u0001\u0000\u0000\u0000\u0165\u0171\u0001\u0000\u0000"+
		"\u0000\u0166\u0167\n\u0003\u0000\u0000\u0167\u0168\u0005\u0016\u0000\u0000"+
		"\u0168\u0170\u00032\u0019\u0004\u0169\u016a\n\u0002\u0000\u0000\u016a"+
		"\u016b\u0005\u0014\u0000\u0000\u016b\u0170\u00032\u0019\u0003\u016c\u016d"+
		"\n\u0001\u0000\u0000\u016d\u016e\u0005\u0015\u0000\u0000\u016e\u0170\u0003"+
		"2\u0019\u0002\u016f\u0166\u0001\u0000\u0000\u0000\u016f\u0169\u0001\u0000"+
		"\u0000\u0000\u016f\u016c\u0001\u0000\u0000\u0000\u0170\u0173\u0001\u0000"+
		"\u0000\u0000\u0171\u016f\u0001\u0000\u0000\u0000\u0171\u0172\u0001\u0000"+
		"\u0000\u0000\u01723\u0001\u0000\u0000\u0000\u0173\u0171\u0001\u0000\u0000"+
		"\u0000\u0174\u0175\u0007\u0005\u0000\u0000\u01755\u0001\u0000\u0000\u0000"+
		"\u0176\u0177\u0005\u0003\u0000\u0000\u0177\u0178\u0005\u001e\u0000\u0000"+
		"\u0178\u0179\u00032\u0019\u0000\u0179\u017a\u0005\u001f\u0000\u0000\u017a"+
		"\u017b\u0005 \u0000\u0000\u017b\u017c\u0003B!\u0000\u017c\u017d\u0005"+
		"!\u0000\u0000\u017d7\u0001\u0000\u0000\u0000\u017e\u0183\u00036\u001b"+
		"\u0000\u017f\u0180\u0005\u0004\u0000\u0000\u0180\u0182\u00036\u001b\u0000"+
		"\u0181\u017f\u0001\u0000\u0000\u0000\u0182\u0185\u0001\u0000\u0000\u0000"+
		"\u0183\u0181\u0001\u0000\u0000\u0000\u0183\u0184\u0001\u0000\u0000\u0000"+
		"\u0184\u0188\u0001\u0000\u0000\u0000\u0185\u0183\u0001\u0000\u0000\u0000"+
		"\u0186\u0187\u0005\u0004\u0000\u0000\u0187\u0189\u0003B!\u0000\u0188\u0186"+
		"\u0001\u0000\u0000\u0000\u0188\u0189\u0001\u0000\u0000\u0000\u01899\u0001"+
		"\u0000\u0000\u0000\u018a\u018b\u0005\u0005\u0000\u0000\u018b\u018c\u0005"+
		"\u001e\u0000\u0000\u018c\u018d\u00032\u0019\u0000\u018d\u018e\u0005\u001f"+
		"\u0000\u0000\u018e\u018f\u0005 \u0000\u0000\u018f\u0190\u0003B!\u0000"+
		"\u0190\u0191\u0005!\u0000\u0000\u0191;\u0001\u0000\u0000\u0000\u0192\u0193"+
		"\u0005\u0006\u0000\u0000\u0193\u0194\u0005\u001e\u0000\u0000\u0194\u0195"+
		"\u00054\u0000\u0000\u0195\u0198\u0005\t\u0000\u0000\u0196\u0199\u0003"+
		"\u001c\u000e\u0000\u0197\u0199\u0003,\u0016\u0000\u0198\u0196\u0001\u0000"+
		"\u0000\u0000\u0198\u0197\u0001\u0000\u0000\u0000\u0199\u019a\u0001\u0000"+
		"\u0000\u0000\u019a\u019b\u0005\u001f\u0000\u0000\u019b\u019c\u0005 \u0000"+
		"\u0000\u019c\u019d\u0003B!\u0000\u019d\u019e\u0005!\u0000\u0000\u019e"+
		"=\u0001\u0000\u0000\u0000\u019f\u01a0\u0005\u0006\u0000\u0000\u01a0\u01a1"+
		"\u0005\u001e\u0000\u0000\u01a1\u01a2\u00054\u0000\u0000\u01a2\u01a5\u0005"+
		"\t\u0000\u0000\u01a3\u01a6\u0003\u001c\u000e\u0000\u01a4\u01a6\u0003,"+
		"\u0016\u0000\u01a5\u01a3\u0001\u0000\u0000\u0000\u01a5\u01a4\u0001\u0000"+
		"\u0000\u0000\u01a6\u01a7\u0001\u0000\u0000\u0000\u01a7\u01a8\u0005\u001f"+
		"\u0000\u0000\u01a8\u01a9\u0005 \u0000\u0000\u01a9\u01aa\u0003\f\u0006"+
		"\u0000\u01aa\u01ab\u0005!\u0000\u0000\u01ab?\u0001\u0000\u0000\u0000\u01ac"+
		"\u01ae\u0003B!\u0000\u01ad\u01ac\u0001\u0000\u0000\u0000\u01ae\u01b1\u0001"+
		"\u0000\u0000\u0000\u01af\u01ad\u0001\u0000\u0000\u0000\u01af\u01b0\u0001"+
		"\u0000\u0000\u0000\u01b0A\u0001\u0000\u0000\u0000\u01b1\u01af\u0001\u0000"+
		"\u0000\u0000\u01b2\u01bf\u00038\u001c\u0000\u01b3\u01bf\u0003D\"\u0000"+
		"\u01b4\u01bf\u0003:\u001d\u0000\u01b5\u01bf\u0003<\u001e\u0000\u01b6\u01b7"+
		"\u0003,\u0016\u0000\u01b7\u01b8\u0005$\u0000\u0000\u01b8\u01bf\u0001\u0000"+
		"\u0000\u0000\u01b9\u01bf\u0003(\u0014\u0000\u01ba\u01bb\u0005\u0007\u0000"+
		"\u0000\u01bb\u01bc\u0003.\u0017\u0000\u01bc\u01bd\u0005$\u0000\u0000\u01bd"+
		"\u01bf\u0001\u0000\u0000\u0000\u01be\u01b2\u0001\u0000\u0000\u0000\u01be"+
		"\u01b3\u0001\u0000\u0000\u0000\u01be\u01b4\u0001\u0000\u0000\u0000\u01be"+
		"\u01b5\u0001\u0000\u0000\u0000\u01be\u01b6\u0001\u0000\u0000\u0000\u01be"+
		"\u01b9\u0001\u0000\u0000\u0000\u01be\u01ba\u0001\u0000\u0000\u0000\u01bf"+
		"C\u0001\u0000\u0000\u0000\u01c0\u01c2\u0005\n\u0000\u0000\u01c1\u01c0"+
		"\u0001\u0000\u0000\u0000\u01c1\u01c2\u0001\u0000\u0000\u0000\u01c2\u01c4"+
		"\u0001\u0000\u0000\u0000\u01c3\u01c5\u0003\b\u0004\u0000\u01c4\u01c3\u0001"+
		"\u0000\u0000\u0000\u01c4\u01c5\u0001\u0000\u0000\u0000\u01c5\u01c6\u0001"+
		"\u0000\u0000\u0000\u01c6\u01c7\u00054\u0000\u0000\u01c7\u01c8\u0005)\u0000"+
		"\u0000\u01c8\u01c9\u0003.\u0017\u0000\u01c9\u01ca\u0005$\u0000\u0000\u01ca"+
		"E\u0001\u0000\u0000\u0000\u01cb\u01cd\u0005\n\u0000\u0000\u01cc\u01cb"+
		"\u0001\u0000\u0000\u0000\u01cc\u01cd\u0001\u0000\u0000\u0000\u01cd\u01cf"+
		"\u0001\u0000\u0000\u0000\u01ce\u01d0\u0003\u0000\u0000\u0000\u01cf\u01ce"+
		"\u0001\u0000\u0000\u0000\u01cf\u01d0\u0001\u0000\u0000\u0000\u01d0\u01d1"+
		"\u0001\u0000\u0000\u0000\u01d1\u01d2\u00054\u0000\u0000\u01d2\u01d3\u0005"+
		")\u0000\u0000\u01d3\u01d4\u0003\u0018\f\u0000\u01d4\u01d5\u0005$\u0000"+
		"\u0000\u01d5G\u0001\u0000\u0000\u0000\u01d6\u01d8\u0005\n\u0000\u0000"+
		"\u01d7\u01d6\u0001\u0000\u0000\u0000\u01d7\u01d8\u0001\u0000\u0000\u0000"+
		"\u01d8\u01da\u0001\u0000\u0000\u0000\u01d9\u01db\u0003\u0002\u0001\u0000"+
		"\u01da\u01d9\u0001\u0000\u0000\u0000\u01da\u01db\u0001\u0000\u0000\u0000"+
		"\u01db\u01dc\u0001\u0000\u0000\u0000\u01dc\u01dd\u00054\u0000\u0000\u01dd"+
		"\u01de\u0005)\u0000\u0000\u01de\u01df\u0003\u001c\u000e\u0000\u01df\u01e0"+
		"\u0005$\u0000\u0000\u01e0I\u0001\u0000\u0000\u0000\u01e1\u01e2\u0003\u0014"+
		"\n\u0000\u01e2\u01e3\u0005$\u0000\u0000\u01e3K\u0001\u0000\u0000\u0000"+
		"\u01e4\u01ea\u0003$\u0012\u0000\u01e5\u01ea\u0003F#\u0000\u01e6\u01ea"+
		"\u0003H$\u0000\u01e7\u01ea\u0003&\u0013\u0000\u01e8\u01ea\u0003\u001a"+
		"\r\u0000\u01e9\u01e4\u0001\u0000\u0000\u0000\u01e9\u01e5\u0001\u0000\u0000"+
		"\u0000\u01e9\u01e6\u0001\u0000\u0000\u0000\u01e9\u01e7\u0001\u0000\u0000"+
		"\u0000\u01e9\u01e8\u0001\u0000\u0000\u0000\u01ea\u01ed\u0001\u0000\u0000"+
		"\u0000\u01eb\u01e9\u0001\u0000\u0000\u0000\u01eb\u01ec\u0001\u0000\u0000"+
		"\u0000\u01ecM\u0001\u0000\u0000\u0000\u01ed\u01eb\u0001\u0000\u0000\u0000"+
		"\u01ee\u01ef\u0003L&\u0000\u01efO\u0001\u0000\u0000\u00008TZaepv~\u0084"+
		"\u0086\u0088\u0093\u0099\u009b\u00a6\u00ac\u00b2\u00b5\u00c2\u00c7\u00ce"+
		"\u00d3\u00d7\u00db\u00e2\u00e6\u00f0\u00f5\u00f7\u0103\u0110\u0114\u0120"+
		"\u0129\u012d\u0137\u013e\u014c\u0154\u0156\u0164\u016f\u0171\u0183\u0188"+
		"\u0198\u01a5\u01af\u01be\u01c1\u01c4\u01cc\u01cf\u01d7\u01da\u01e9\u01eb";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}