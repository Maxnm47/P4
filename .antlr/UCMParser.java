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
		THIS_KEYWORD=14, NULL=15, MULT=16, DIV=17, PLUS=18, MINUS=19, MOD=20, 
		AND=21, OR=22, EQ=23, NEQ=24, GT=25, LT=26, GTE=27, LTE=28, NOT=29, QUESTION=30, 
		LPAREN=31, RPAREN=32, LCURLY=33, RCURLY=34, LBRACKET=35, RBRACKET=36, 
		SEMI=37, DOT=38, COMMA=39, COLON=40, NEWLINE=41, ASSIGN=42, QUOTE=43, 
		DOLLAR=44, INT_T=45, FLOAT_T=46, STRING_T=47, BOOL_T=48, BOOL=49, INT=50, 
		FLOAT=51, ESCAPE_SEQUENCE=52, ID=53;
	public static final int
		RULE_object_t = 0, RULE_array_t = 1, RULE_primitiveType = 2, RULE_complexType = 3, 
		RULE_type = 4, RULE_int = 5, RULE_float = 6, RULE_num = 7, RULE_value = 8, 
		RULE_augmentedString = 9, RULE_concatanatedString = 10, RULE_string = 11, 
		RULE_typedId = 12, RULE_adapting = 13, RULE_object = 14, RULE_field = 15, 
		RULE_array = 16, RULE_evaluaterArray = 17, RULE_templateField = 18, RULE_templateExtention = 19, 
		RULE_templateDefenition = 20, RULE_functionCollection = 21, RULE_method = 22, 
		RULE_functionCollectionCall = 23, RULE_methodCall = 24, RULE_expr = 25, 
		RULE_numExpr = 26, RULE_boolExpr = 27, RULE_compExpr = 28, RULE_ifStatement = 29, 
		RULE_conditional = 30, RULE_whileLoop = 31, RULE_forLoop = 32, RULE_listConstruction = 33, 
		RULE_statementList = 34, RULE_statement = 35, RULE_assignment = 36, RULE_objectDefenition = 37, 
		RULE_arrayDefenition = 38, RULE_declaration = 39, RULE_root = 40, RULE_start = 41;
	private static String[] makeRuleNames() {
		return new String[] {
			"object_t", "array_t", "primitiveType", "complexType", "type", "int", 
			"float", "num", "value", "augmentedString", "concatanatedString", "string", 
			"typedId", "adapting", "object", "field", "array", "evaluaterArray", 
			"templateField", "templateExtention", "templateDefenition", "functionCollection", 
			"method", "functionCollectionCall", "methodCall", "expr", "numExpr", 
			"boolExpr", "compExpr", "ifStatement", "conditional", "whileLoop", "forLoop", 
			"listConstruction", "statementList", "statement", "assignment", "objectDefenition", 
			"arrayDefenition", "declaration", "root", "start"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, null, null, "'if'", "'else'", "'while'", "'for'", "'return'", "'template'", 
			"'in'", "'hidden'", "'object'", "'methods'", "'extends'", "'this'", "'null'", 
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
			"THIS_KEYWORD", "NULL", "MULT", "DIV", "PLUS", "MINUS", "MOD", "AND", 
			"OR", "EQ", "NEQ", "GT", "LT", "GTE", "LTE", "NOT", "QUESTION", "LPAREN", 
			"RPAREN", "LCURLY", "RCURLY", "LBRACKET", "RBRACKET", "SEMI", "DOT", 
			"COMMA", "COLON", "NEWLINE", "ASSIGN", "QUOTE", "DOLLAR", "INT_T", "FLOAT_T", 
			"STRING_T", "BOOL_T", "BOOL", "INT", "FLOAT", "ESCAPE_SEQUENCE", "ID"
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
			setState(84);
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
			setState(88);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT_T:
			case FLOAT_T:
			case BOOL_T:
				{
				setState(86);
				primitiveType();
				}
				break;
			case OBJECT_KEYWORD:
			case ID:
				{
				setState(87);
				object_t();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(92); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(90);
				match(LBRACKET);
				setState(91);
				match(RBRACKET);
				}
				}
				setState(94); 
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
			setState(96);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 387028092977152L) != 0)) ) {
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
			setState(101);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,2,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(98);
				object_t();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(99);
				array_t();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(100);
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
			setState(105);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,3,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(103);
				primitiveType();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(104);
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
	public static class IntContext extends ParserRuleContext {
		public TerminalNode INT() { return getToken(UCMParser.INT, 0); }
		public IntContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_int; }
	}

	public final IntContext int_() throws RecognitionException {
		IntContext _localctx = new IntContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_int);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(107);
			match(INT);
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
	public static class FloatContext extends ParserRuleContext {
		public TerminalNode FLOAT() { return getToken(UCMParser.FLOAT, 0); }
		public FloatContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_float; }
	}

	public final FloatContext float_() throws RecognitionException {
		FloatContext _localctx = new FloatContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_float);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(FLOAT);
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
		public IntContext int_() {
			return getRuleContext(IntContext.class,0);
		}
		public FloatContext float_() {
			return getRuleContext(FloatContext.class,0);
		}
		public NumContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_num; }
	}

	public final NumContext num() throws RecognitionException {
		NumContext _localctx = new NumContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_num);
		try {
			setState(113);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case INT:
				enterOuterAlt(_localctx, 1);
				{
				setState(111);
				int_();
				}
				break;
			case FLOAT:
				enterOuterAlt(_localctx, 2);
				{
				setState(112);
				float_();
				}
				break;
			default:
				throw new NoViableAltException(this);
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
		public TerminalNode NULL() { return getToken(UCMParser.NULL, 0); }
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_value);
		try {
			setState(123);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(115);
				num();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(116);
				augmentedString();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(117);
				concatanatedString();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(118);
				string();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(119);
				match(BOOL);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(120);
				object();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(121);
				array();
				}
				break;
			case 8:
				enterOuterAlt(_localctx, 8);
				{
				setState(122);
				match(NULL);
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
		enterRule(_localctx, 18, RULE_augmentedString);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(125);
			match(DOLLAR);
			setState(126);
			match(QUOTE);
			setState(147);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					setState(145);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
					case 1:
						{
						setState(129);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
						case 1:
							{
							setState(127);
							match(ESCAPE_SEQUENCE);
							}
							break;
						case 2:
							{
							setState(128);
							matchWildcard();
							}
							break;
						}
						{
						setState(131);
						match(LCURLY);
						setState(132);
						expr(0);
						setState(133);
						match(RCURLY);
						}
						}
						break;
					case 2:
						{
						setState(137);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
						case 1:
							{
							setState(135);
							match(ESCAPE_SEQUENCE);
							}
							break;
						case 2:
							{
							setState(136);
							matchWildcard();
							}
							break;
						}
						setState(143);
						_errHandler.sync(this);
						switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
						case 1:
							{
							setState(139);
							match(LCURLY);
							setState(140);
							expr(0);
							setState(141);
							match(RCURLY);
							}
							break;
						}
						}
						break;
					}
					} 
				}
				setState(149);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			}
			setState(150);
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
		enterRule(_localctx, 20, RULE_concatanatedString);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(152);
			string();
			setState(157);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(153);
					match(PLUS);
					setState(154);
					string();
					}
					} 
				}
				setState(159);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,11,_ctx);
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
		enterRule(_localctx, 22, RULE_string);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(160);
			match(QUOTE);
			setState(165);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1+1 ) {
					{
					setState(163);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,12,_ctx) ) {
					case 1:
						{
						setState(161);
						match(ESCAPE_SEQUENCE);
						}
						break;
					case 2:
						{
						setState(162);
						matchWildcard();
						}
						break;
					}
					} 
				}
				setState(167);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			}
			setState(168);
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
		enterRule(_localctx, 24, RULE_typedId);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(170);
			type();
			setState(171);
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
		enterRule(_localctx, 26, RULE_adapting);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(173);
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
		enterRule(_localctx, 28, RULE_object);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(176);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID) {
				{
				setState(175);
				adapting();
				}
			}

			setState(178);
			match(LCURLY);
			setState(182);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 9534964836076544L) != 0)) {
				{
				{
				setState(179);
				field();
				}
				}
				setState(184);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(185);
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
		enterRule(_localctx, 30, RULE_field);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(188);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(187);
				match(HIDDEN_);
				}
			}

			setState(191);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,17,_ctx) ) {
			case 1:
				{
				setState(190);
				type();
				}
				break;
			}
			setState(193);
			match(ID);
			setState(194);
			match(ASSIGN);
			setState(195);
			expr(0);
			setState(196);
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
		enterRule(_localctx, 32, RULE_array);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(198);
			match(LBRACKET);
			setState(209);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NULL:
			case LCURLY:
			case LBRACKET:
			case QUOTE:
			case DOLLAR:
			case BOOL:
			case INT:
			case FLOAT:
			case ID:
				{
				setState(199);
				value();
				setState(204);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(200);
					match(COMMA);
					setState(201);
					value();
					}
					}
					setState(206);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case FOR:
				{
				setState(207);
				listConstruction();
				}
				break;
			case RBRACKET:
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(211);
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
		enterRule(_localctx, 34, RULE_evaluaterArray);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(213);
			match(LBRACKET);
			setState(229);
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
				setState(216);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,20,_ctx) ) {
				case 1:
					{
					setState(214);
					boolExpr(0);
					}
					break;
				case 2:
					{
					setState(215);
					match(ID);
					}
					break;
				}
				setState(225);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(218);
					match(COMMA);
					setState(221);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
					case 1:
						{
						setState(219);
						boolExpr(0);
						}
						break;
					case 2:
						{
						setState(220);
						match(ID);
						}
						break;
					}
					}
					}
					setState(227);
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
			setState(231);
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
		enterRule(_localctx, 36, RULE_templateField);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
			typedId();
			setState(236);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ASSIGN) {
				{
				setState(234);
				match(ASSIGN);
				setState(235);
				value();
				}
			}

			setState(240);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(238);
				match(COLON);
				setState(239);
				evaluaterArray();
				}
			}

			setState(242);
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
		enterRule(_localctx, 38, RULE_templateExtention);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(244);
			match(EXTENDS_KEYWORD);
			setState(245);
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
		enterRule(_localctx, 40, RULE_templateDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(247);
			match(TEMPLATE_KEYWORD);
			setState(248);
			match(ID);
			setState(250);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==EXTENDS_KEYWORD) {
				{
				setState(249);
				templateExtention();
				}
			}

			setState(252);
			match(LCURLY);
			setState(257);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 9534964836075520L) != 0)) {
				{
				setState(255);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
				case 1:
					{
					setState(253);
					templateField();
					}
					break;
				case 2:
					{
					setState(254);
					method();
					}
					break;
				}
				}
				setState(259);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(260);
			match(RCURLY);
			setState(261);
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
		enterRule(_localctx, 42, RULE_functionCollection);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(263);
			match(FUNCTIONS_KEYWORD);
			setState(264);
			match(ID);
			setState(265);
			match(LCURLY);
			setState(269);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 9534964836075520L) != 0)) {
				{
				{
				setState(266);
				method();
				}
				}
				setState(271);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(272);
			match(RCURLY);
			setState(273);
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
		enterRule(_localctx, 44, RULE_method);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(275);
			typedId();
			setState(276);
			match(LPAREN);
			setState(286);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case OBJECT_KEYWORD:
			case INT_T:
			case FLOAT_T:
			case STRING_T:
			case BOOL_T:
			case ID:
				{
				setState(277);
				typedId();
				setState(282);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(278);
					match(COMMA);
					setState(279);
					typedId();
					}
					}
					setState(284);
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
			setState(288);
			match(RPAREN);
			setState(289);
			match(LCURLY);
			setState(290);
			statementList();
			setState(291);
			match(RCURLY);
			setState(292);
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
		enterRule(_localctx, 46, RULE_functionCollectionCall);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(294);
			match(ID);
			setState(295);
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
		enterRule(_localctx, 48, RULE_methodCall);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(298);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,32,_ctx) ) {
			case 1:
				{
				setState(297);
				functionCollectionCall();
				}
				break;
			}
			setState(300);
			match(ID);
			setState(301);
			match(LPAREN);
			setState(311);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case THIS_KEYWORD:
			case NULL:
			case MINUS:
			case NOT:
			case LPAREN:
			case LCURLY:
			case LBRACKET:
			case QUOTE:
			case DOLLAR:
			case BOOL:
			case INT:
			case FLOAT:
			case ID:
				{
				setState(302);
				expr(0);
				setState(307);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(303);
					match(COMMA);
					setState(304);
					expr(0);
					}
					}
					setState(309);
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
			setState(313);
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
		int _startState = 50;
		enterRecursionRule(_localctx, 50, RULE_expr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(321);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,35,_ctx) ) {
			case 1:
				{
				setState(316);
				value();
				}
				break;
			case 2:
				{
				setState(317);
				match(ID);
				}
				break;
			case 3:
				{
				setState(318);
				methodCall();
				}
				break;
			case 4:
				{
				setState(319);
				boolExpr(0);
				}
				break;
			case 5:
				{
				setState(320);
				numExpr(0);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(328);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expr);
					setState(323);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(324);
					match(EQ);
					setState(325);
					expr(3);
					}
					} 
				}
				setState(330);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,36,_ctx);
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
		int _startState = 52;
		enterRecursionRule(_localctx, 52, RULE_numExpr, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(342);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,37,_ctx) ) {
			case 1:
				{
				setState(332);
				num();
				}
				break;
			case 2:
				{
				setState(333);
				match(THIS_KEYWORD);
				}
				break;
			case 3:
				{
				setState(334);
				match(ID);
				}
				break;
			case 4:
				{
				setState(335);
				methodCall();
				}
				break;
			case 5:
				{
				setState(336);
				match(MINUS);
				setState(337);
				numExpr(4);
				}
				break;
			case 6:
				{
				setState(338);
				match(LPAREN);
				setState(339);
				numExpr(0);
				setState(340);
				match(RPAREN);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(352);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(350);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,38,_ctx) ) {
					case 1:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(344);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(345);
						_la = _input.LA(1);
						if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1245184L) != 0)) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(346);
						numExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new NumExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_numExpr);
						setState(347);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(348);
						_la = _input.LA(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.recoverInline(this);
						}
						else {
							if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
							_errHandler.reportMatch(this);
							consume();
						}
						setState(349);
						numExpr(3);
						}
						break;
					}
					} 
				}
				setState(354);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,39,_ctx);
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
		int _startState = 54;
		enterRecursionRule(_localctx, 54, RULE_boolExpr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(366);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,40,_ctx) ) {
			case 1:
				{
				setState(356);
				match(BOOL);
				}
				break;
			case 2:
				{
				setState(357);
				match(THIS_KEYWORD);
				}
				break;
			case 3:
				{
				setState(358);
				match(ID);
				}
				break;
			case 4:
				{
				setState(359);
				methodCall();
				}
				break;
			case 5:
				{
				setState(360);
				match(NOT);
				setState(361);
				expr(0);
				}
				break;
			case 6:
				{
				setState(362);
				numExpr(0);
				setState(363);
				compExpr();
				setState(364);
				numExpr(0);
				}
				break;
			}
			_ctx.stop = _input.LT(-1);
			setState(379);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(377);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,41,_ctx) ) {
					case 1:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(368);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(369);
						match(EQ);
						setState(370);
						boolExpr(4);
						}
						break;
					case 2:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(371);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(372);
						match(AND);
						setState(373);
						boolExpr(3);
						}
						break;
					case 3:
						{
						_localctx = new BoolExprContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_boolExpr);
						setState(374);
						if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
						setState(375);
						match(OR);
						setState(376);
						boolExpr(2);
						}
						break;
					}
					} 
				}
				setState(381);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,42,_ctx);
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
		enterRule(_localctx, 56, RULE_compExpr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(382);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 528482304L) != 0)) ) {
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
		enterRule(_localctx, 58, RULE_ifStatement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(384);
			match(IF);
			setState(385);
			match(LPAREN);
			setState(386);
			boolExpr(0);
			setState(387);
			match(RPAREN);
			setState(388);
			match(LCURLY);
			setState(389);
			statement();
			setState(390);
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
		enterRule(_localctx, 60, RULE_conditional);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(392);
			ifStatement();
			setState(397);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,43,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(393);
					match(ELSE);
					setState(394);
					ifStatement();
					}
					} 
				}
				setState(399);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,43,_ctx);
			}
			setState(402);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ELSE) {
				{
				setState(400);
				match(ELSE);
				setState(401);
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
		enterRule(_localctx, 62, RULE_whileLoop);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(404);
			match(WHILE);
			setState(405);
			match(LPAREN);
			setState(406);
			boolExpr(0);
			setState(407);
			match(RPAREN);
			setState(408);
			match(LCURLY);
			setState(409);
			statement();
			setState(410);
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
		enterRule(_localctx, 64, RULE_forLoop);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(412);
			match(FOR);
			setState(413);
			match(LPAREN);
			setState(414);
			match(ID);
			setState(415);
			match(IN);
			setState(418);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LBRACKET:
				{
				setState(416);
				array();
				}
				break;
			case ID:
				{
				setState(417);
				methodCall();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(420);
			match(RPAREN);
			setState(421);
			match(LCURLY);
			setState(422);
			statement();
			setState(423);
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
		enterRule(_localctx, 66, RULE_listConstruction);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(425);
			match(FOR);
			setState(426);
			match(LPAREN);
			setState(427);
			match(ID);
			setState(428);
			match(IN);
			setState(431);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case LBRACKET:
				{
				setState(429);
				array();
				}
				break;
			case ID:
				{
				setState(430);
				methodCall();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(433);
			match(RPAREN);
			setState(434);
			match(LCURLY);
			setState(435);
			value();
			setState(436);
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
		enterRule(_localctx, 68, RULE_statementList);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(441);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 9534964836076776L) != 0)) {
				{
				{
				setState(438);
				statement();
				}
				}
				setState(443);
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
		enterRule(_localctx, 70, RULE_statement);
		try {
			setState(456);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,48,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(444);
				conditional();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(445);
				assignment();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(446);
				whileLoop();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(447);
				forLoop();
				}
				break;
			case 5:
				enterOuterAlt(_localctx, 5);
				{
				setState(448);
				methodCall();
				setState(449);
				match(SEMI);
				}
				break;
			case 6:
				enterOuterAlt(_localctx, 6);
				{
				setState(451);
				method();
				}
				break;
			case 7:
				enterOuterAlt(_localctx, 7);
				{
				setState(452);
				match(RETURN);
				setState(453);
				expr(0);
				setState(454);
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
		enterRule(_localctx, 72, RULE_assignment);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(459);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(458);
				match(HIDDEN_);
				}
			}

			setState(462);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,50,_ctx) ) {
			case 1:
				{
				setState(461);
				type();
				}
				break;
			}
			setState(464);
			match(ID);
			setState(465);
			match(ASSIGN);
			setState(466);
			expr(0);
			setState(467);
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
		enterRule(_localctx, 74, RULE_objectDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(470);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(469);
				match(HIDDEN_);
				}
			}

			setState(473);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,52,_ctx) ) {
			case 1:
				{
				setState(472);
				object_t();
				}
				break;
			}
			setState(475);
			match(ID);
			setState(476);
			match(ASSIGN);
			setState(477);
			object();
			setState(478);
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
		enterRule(_localctx, 76, RULE_arrayDefenition);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(481);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==HIDDEN_) {
				{
				setState(480);
				match(HIDDEN_);
				}
			}

			setState(484);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,54,_ctx) ) {
			case 1:
				{
				setState(483);
				array_t();
				}
				break;
			}
			setState(486);
			match(ID);
			setState(487);
			match(ASSIGN);
			setState(488);
			array();
			setState(489);
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
		enterRule(_localctx, 78, RULE_declaration);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(491);
			typedId();
			setState(492);
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
		enterRule(_localctx, 80, RULE_root);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(501);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & 9534964836080896L) != 0)) {
				{
				setState(499);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,55,_ctx) ) {
				case 1:
					{
					setState(494);
					templateDefenition();
					}
					break;
				case 2:
					{
					setState(495);
					objectDefenition();
					}
					break;
				case 3:
					{
					setState(496);
					arrayDefenition();
					}
					break;
				case 4:
					{
					setState(497);
					functionCollection();
					}
					break;
				case 5:
					{
					setState(498);
					field();
					}
					break;
				}
				}
				setState(503);
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
		enterRule(_localctx, 82, RULE_start);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(504);
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
		case 25:
			return expr_sempred((ExprContext)_localctx, predIndex);
		case 26:
			return numExpr_sempred((NumExprContext)_localctx, predIndex);
		case 27:
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
		"\u0004\u00015\u01fb\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001\u0002"+
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
		"#\u0007#\u0002$\u0007$\u0002%\u0007%\u0002&\u0007&\u0002\'\u0007\'\u0002"+
		"(\u0007(\u0002)\u0007)\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001"+
		"\u0003\u0001Y\b\u0001\u0001\u0001\u0001\u0001\u0004\u0001]\b\u0001\u000b"+
		"\u0001\f\u0001^\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0001"+
		"\u0003\u0003\u0003f\b\u0003\u0001\u0004\u0001\u0004\u0003\u0004j\b\u0004"+
		"\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007"+
		"\u0003\u0007r\b\u0007\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b"+
		"\u0001\b\u0001\b\u0003\b|\b\b\u0001\t\u0001\t\u0001\t\u0001\t\u0003\t"+
		"\u0082\b\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0003\t\u008a"+
		"\b\t\u0001\t\u0001\t\u0001\t\u0001\t\u0003\t\u0090\b\t\u0005\t\u0092\b"+
		"\t\n\t\f\t\u0095\t\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0005\n\u009c"+
		"\b\n\n\n\f\n\u009f\t\n\u0001\u000b\u0001\u000b\u0001\u000b\u0005\u000b"+
		"\u00a4\b\u000b\n\u000b\f\u000b\u00a7\t\u000b\u0001\u000b\u0001\u000b\u0001"+
		"\f\u0001\f\u0001\f\u0001\r\u0001\r\u0001\u000e\u0003\u000e\u00b1\b\u000e"+
		"\u0001\u000e\u0001\u000e\u0005\u000e\u00b5\b\u000e\n\u000e\f\u000e\u00b8"+
		"\t\u000e\u0001\u000e\u0001\u000e\u0001\u000f\u0003\u000f\u00bd\b\u000f"+
		"\u0001\u000f\u0003\u000f\u00c0\b\u000f\u0001\u000f\u0001\u000f\u0001\u000f"+
		"\u0001\u000f\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0005\u0010\u00cb\b\u0010\n\u0010\f\u0010\u00ce\t\u0010\u0001\u0010\u0001"+
		"\u0010\u0003\u0010\u00d2\b\u0010\u0001\u0010\u0001\u0010\u0001\u0011\u0001"+
		"\u0011\u0001\u0011\u0003\u0011\u00d9\b\u0011\u0001\u0011\u0001\u0011\u0001"+
		"\u0011\u0003\u0011\u00de\b\u0011\u0005\u0011\u00e0\b\u0011\n\u0011\f\u0011"+
		"\u00e3\t\u0011\u0001\u0011\u0003\u0011\u00e6\b\u0011\u0001\u0011\u0001"+
		"\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0003\u0012\u00ed\b\u0012\u0001"+
		"\u0012\u0001\u0012\u0003\u0012\u00f1\b\u0012\u0001\u0012\u0001\u0012\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0003"+
		"\u0014\u00fb\b\u0014\u0001\u0014\u0001\u0014\u0001\u0014\u0005\u0014\u0100"+
		"\b\u0014\n\u0014\f\u0014\u0103\t\u0014\u0001\u0014\u0001\u0014\u0001\u0014"+
		"\u0001\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0005\u0015\u010c\b\u0015"+
		"\n\u0015\f\u0015\u010f\t\u0015\u0001\u0015\u0001\u0015\u0001\u0015\u0001"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0005\u0016\u0119"+
		"\b\u0016\n\u0016\f\u0016\u011c\t\u0016\u0001\u0016\u0003\u0016\u011f\b"+
		"\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0016\u0001"+
		"\u0016\u0001\u0017\u0001\u0017\u0001\u0017\u0001\u0018\u0003\u0018\u012b"+
		"\b\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0005"+
		"\u0018\u0132\b\u0018\n\u0018\f\u0018\u0135\t\u0018\u0001\u0018\u0003\u0018"+
		"\u0138\b\u0018\u0001\u0018\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u0019\u0003\u0019\u0142\b\u0019\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0005\u0019\u0147\b\u0019\n\u0019\f\u0019\u014a"+
		"\t\u0019\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001"+
		"\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0003"+
		"\u001a\u0157\b\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001"+
		"\u001a\u0001\u001a\u0005\u001a\u015f\b\u001a\n\u001a\f\u001a\u0162\t\u001a"+
		"\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0003\u001b"+
		"\u016f\b\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001b\u0005\u001b\u017a\b\u001b"+
		"\n\u001b\f\u001b\u017d\t\u001b\u0001\u001c\u0001\u001c\u0001\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001"+
		"\u001d\u0001\u001e\u0001\u001e\u0001\u001e\u0005\u001e\u018c\b\u001e\n"+
		"\u001e\f\u001e\u018f\t\u001e\u0001\u001e\u0001\u001e\u0003\u001e\u0193"+
		"\b\u001e\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001\u001f\u0001"+
		"\u001f\u0001\u001f\u0001\u001f\u0001 \u0001 \u0001 \u0001 \u0001 \u0001"+
		" \u0003 \u01a3\b \u0001 \u0001 \u0001 \u0001 \u0001 \u0001!\u0001!\u0001"+
		"!\u0001!\u0001!\u0001!\u0003!\u01b0\b!\u0001!\u0001!\u0001!\u0001!\u0001"+
		"!\u0001\"\u0005\"\u01b8\b\"\n\"\f\"\u01bb\t\"\u0001#\u0001#\u0001#\u0001"+
		"#\u0001#\u0001#\u0001#\u0001#\u0001#\u0001#\u0001#\u0001#\u0003#\u01c9"+
		"\b#\u0001$\u0003$\u01cc\b$\u0001$\u0003$\u01cf\b$\u0001$\u0001$\u0001"+
		"$\u0001$\u0001$\u0001%\u0003%\u01d7\b%\u0001%\u0003%\u01da\b%\u0001%\u0001"+
		"%\u0001%\u0001%\u0001%\u0001&\u0003&\u01e2\b&\u0001&\u0003&\u01e5\b&\u0001"+
		"&\u0001&\u0001&\u0001&\u0001&\u0001\'\u0001\'\u0001\'\u0001(\u0001(\u0001"+
		"(\u0001(\u0001(\u0005(\u01f4\b(\n(\f(\u01f7\t(\u0001)\u0001)\u0001)\u0001"+
		"\u00a5\u0003246*\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014"+
		"\u0016\u0018\u001a\u001c\u001e \"$&(*,.02468:<>@BDFHJLNPR\u0000\u0005"+
		"\u0002\u0000\u000b\u000b55\u0002\u0000-.00\u0002\u0000\u0010\u0011\u0014"+
		"\u0014\u0001\u0000\u0012\u0013\u0001\u0000\u0017\u001c\u0226\u0000T\u0001"+
		"\u0000\u0000\u0000\u0002X\u0001\u0000\u0000\u0000\u0004`\u0001\u0000\u0000"+
		"\u0000\u0006e\u0001\u0000\u0000\u0000\bi\u0001\u0000\u0000\u0000\nk\u0001"+
		"\u0000\u0000\u0000\fm\u0001\u0000\u0000\u0000\u000eq\u0001\u0000\u0000"+
		"\u0000\u0010{\u0001\u0000\u0000\u0000\u0012}\u0001\u0000\u0000\u0000\u0014"+
		"\u0098\u0001\u0000\u0000\u0000\u0016\u00a0\u0001\u0000\u0000\u0000\u0018"+
		"\u00aa\u0001\u0000\u0000\u0000\u001a\u00ad\u0001\u0000\u0000\u0000\u001c"+
		"\u00b0\u0001\u0000\u0000\u0000\u001e\u00bc\u0001\u0000\u0000\u0000 \u00c6"+
		"\u0001\u0000\u0000\u0000\"\u00d5\u0001\u0000\u0000\u0000$\u00e9\u0001"+
		"\u0000\u0000\u0000&\u00f4\u0001\u0000\u0000\u0000(\u00f7\u0001\u0000\u0000"+
		"\u0000*\u0107\u0001\u0000\u0000\u0000,\u0113\u0001\u0000\u0000\u0000."+
		"\u0126\u0001\u0000\u0000\u00000\u012a\u0001\u0000\u0000\u00002\u0141\u0001"+
		"\u0000\u0000\u00004\u0156\u0001\u0000\u0000\u00006\u016e\u0001\u0000\u0000"+
		"\u00008\u017e\u0001\u0000\u0000\u0000:\u0180\u0001\u0000\u0000\u0000<"+
		"\u0188\u0001\u0000\u0000\u0000>\u0194\u0001\u0000\u0000\u0000@\u019c\u0001"+
		"\u0000\u0000\u0000B\u01a9\u0001\u0000\u0000\u0000D\u01b9\u0001\u0000\u0000"+
		"\u0000F\u01c8\u0001\u0000\u0000\u0000H\u01cb\u0001\u0000\u0000\u0000J"+
		"\u01d6\u0001\u0000\u0000\u0000L\u01e1\u0001\u0000\u0000\u0000N\u01eb\u0001"+
		"\u0000\u0000\u0000P\u01f5\u0001\u0000\u0000\u0000R\u01f8\u0001\u0000\u0000"+
		"\u0000TU\u0007\u0000\u0000\u0000U\u0001\u0001\u0000\u0000\u0000VY\u0003"+
		"\u0004\u0002\u0000WY\u0003\u0000\u0000\u0000XV\u0001\u0000\u0000\u0000"+
		"XW\u0001\u0000\u0000\u0000Y\\\u0001\u0000\u0000\u0000Z[\u0005#\u0000\u0000"+
		"[]\u0005$\u0000\u0000\\Z\u0001\u0000\u0000\u0000]^\u0001\u0000\u0000\u0000"+
		"^\\\u0001\u0000\u0000\u0000^_\u0001\u0000\u0000\u0000_\u0003\u0001\u0000"+
		"\u0000\u0000`a\u0007\u0001\u0000\u0000a\u0005\u0001\u0000\u0000\u0000"+
		"bf\u0003\u0000\u0000\u0000cf\u0003\u0002\u0001\u0000df\u0005/\u0000\u0000"+
		"eb\u0001\u0000\u0000\u0000ec\u0001\u0000\u0000\u0000ed\u0001\u0000\u0000"+
		"\u0000f\u0007\u0001\u0000\u0000\u0000gj\u0003\u0004\u0002\u0000hj\u0003"+
		"\u0006\u0003\u0000ig\u0001\u0000\u0000\u0000ih\u0001\u0000\u0000\u0000"+
		"j\t\u0001\u0000\u0000\u0000kl\u00052\u0000\u0000l\u000b\u0001\u0000\u0000"+
		"\u0000mn\u00053\u0000\u0000n\r\u0001\u0000\u0000\u0000or\u0003\n\u0005"+
		"\u0000pr\u0003\f\u0006\u0000qo\u0001\u0000\u0000\u0000qp\u0001\u0000\u0000"+
		"\u0000r\u000f\u0001\u0000\u0000\u0000s|\u0003\u000e\u0007\u0000t|\u0003"+
		"\u0012\t\u0000u|\u0003\u0014\n\u0000v|\u0003\u0016\u000b\u0000w|\u0005"+
		"1\u0000\u0000x|\u0003\u001c\u000e\u0000y|\u0003 \u0010\u0000z|\u0005\u000f"+
		"\u0000\u0000{s\u0001\u0000\u0000\u0000{t\u0001\u0000\u0000\u0000{u\u0001"+
		"\u0000\u0000\u0000{v\u0001\u0000\u0000\u0000{w\u0001\u0000\u0000\u0000"+
		"{x\u0001\u0000\u0000\u0000{y\u0001\u0000\u0000\u0000{z\u0001\u0000\u0000"+
		"\u0000|\u0011\u0001\u0000\u0000\u0000}~\u0005,\u0000\u0000~\u0093\u0005"+
		"+\u0000\u0000\u007f\u0082\u00054\u0000\u0000\u0080\u0082\t\u0000\u0000"+
		"\u0000\u0081\u007f\u0001\u0000\u0000\u0000\u0081\u0080\u0001\u0000\u0000"+
		"\u0000\u0081\u0082\u0001\u0000\u0000\u0000\u0082\u0083\u0001\u0000\u0000"+
		"\u0000\u0083\u0084\u0005!\u0000\u0000\u0084\u0085\u00032\u0019\u0000\u0085"+
		"\u0086\u0005\"\u0000\u0000\u0086\u0092\u0001\u0000\u0000\u0000\u0087\u008a"+
		"\u00054\u0000\u0000\u0088\u008a\t\u0000\u0000\u0000\u0089\u0087\u0001"+
		"\u0000\u0000\u0000\u0089\u0088\u0001\u0000\u0000\u0000\u008a\u008f\u0001"+
		"\u0000\u0000\u0000\u008b\u008c\u0005!\u0000\u0000\u008c\u008d\u00032\u0019"+
		"\u0000\u008d\u008e\u0005\"\u0000\u0000\u008e\u0090\u0001\u0000\u0000\u0000"+
		"\u008f\u008b\u0001\u0000\u0000\u0000\u008f\u0090\u0001\u0000\u0000\u0000"+
		"\u0090\u0092\u0001\u0000\u0000\u0000\u0091\u0081\u0001\u0000\u0000\u0000"+
		"\u0091\u0089\u0001\u0000\u0000\u0000\u0092\u0095\u0001\u0000\u0000\u0000"+
		"\u0093\u0091\u0001\u0000\u0000\u0000\u0093\u0094\u0001\u0000\u0000\u0000"+
		"\u0094\u0096\u0001\u0000\u0000\u0000\u0095\u0093\u0001\u0000\u0000\u0000"+
		"\u0096\u0097\u0005+\u0000\u0000\u0097\u0013\u0001\u0000\u0000\u0000\u0098"+
		"\u009d\u0003\u0016\u000b\u0000\u0099\u009a\u0005\u0012\u0000\u0000\u009a"+
		"\u009c\u0003\u0016\u000b\u0000\u009b\u0099\u0001\u0000\u0000\u0000\u009c"+
		"\u009f\u0001\u0000\u0000\u0000\u009d\u009b\u0001\u0000\u0000\u0000\u009d"+
		"\u009e\u0001\u0000\u0000\u0000\u009e\u0015\u0001\u0000\u0000\u0000\u009f"+
		"\u009d\u0001\u0000\u0000\u0000\u00a0\u00a5\u0005+\u0000\u0000\u00a1\u00a4"+
		"\u00054\u0000\u0000\u00a2\u00a4\t\u0000\u0000\u0000\u00a3\u00a1\u0001"+
		"\u0000\u0000\u0000\u00a3\u00a2\u0001\u0000\u0000\u0000\u00a4\u00a7\u0001"+
		"\u0000\u0000\u0000\u00a5\u00a6\u0001\u0000\u0000\u0000\u00a5\u00a3\u0001"+
		"\u0000\u0000\u0000\u00a6\u00a8\u0001\u0000\u0000\u0000\u00a7\u00a5\u0001"+
		"\u0000\u0000\u0000\u00a8\u00a9\u0005+\u0000\u0000\u00a9\u0017\u0001\u0000"+
		"\u0000\u0000\u00aa\u00ab\u0003\b\u0004\u0000\u00ab\u00ac\u00055\u0000"+
		"\u0000\u00ac\u0019\u0001\u0000\u0000\u0000\u00ad\u00ae\u00055\u0000\u0000"+
		"\u00ae\u001b\u0001\u0000\u0000\u0000\u00af\u00b1\u0003\u001a\r\u0000\u00b0"+
		"\u00af\u0001\u0000\u0000\u0000\u00b0\u00b1\u0001\u0000\u0000\u0000\u00b1"+
		"\u00b2\u0001\u0000\u0000\u0000\u00b2\u00b6\u0005!\u0000\u0000\u00b3\u00b5"+
		"\u0003\u001e\u000f\u0000\u00b4\u00b3\u0001\u0000\u0000\u0000\u00b5\u00b8"+
		"\u0001\u0000\u0000\u0000\u00b6\u00b4\u0001\u0000\u0000\u0000\u00b6\u00b7"+
		"\u0001\u0000\u0000\u0000\u00b7\u00b9\u0001\u0000\u0000\u0000\u00b8\u00b6"+
		"\u0001\u0000\u0000\u0000\u00b9\u00ba\u0005\"\u0000\u0000\u00ba\u001d\u0001"+
		"\u0000\u0000\u0000\u00bb\u00bd\u0005\n\u0000\u0000\u00bc\u00bb\u0001\u0000"+
		"\u0000\u0000\u00bc\u00bd\u0001\u0000\u0000\u0000\u00bd\u00bf\u0001\u0000"+
		"\u0000\u0000\u00be\u00c0\u0003\b\u0004\u0000\u00bf\u00be\u0001\u0000\u0000"+
		"\u0000\u00bf\u00c0\u0001\u0000\u0000\u0000\u00c0\u00c1\u0001\u0000\u0000"+
		"\u0000\u00c1\u00c2\u00055\u0000\u0000\u00c2\u00c3\u0005*\u0000\u0000\u00c3"+
		"\u00c4\u00032\u0019\u0000\u00c4\u00c5\u0005%\u0000\u0000\u00c5\u001f\u0001"+
		"\u0000\u0000\u0000\u00c6\u00d1\u0005#\u0000\u0000\u00c7\u00cc\u0003\u0010"+
		"\b\u0000\u00c8\u00c9\u0005\'\u0000\u0000\u00c9\u00cb\u0003\u0010\b\u0000"+
		"\u00ca\u00c8\u0001\u0000\u0000\u0000\u00cb\u00ce\u0001\u0000\u0000\u0000"+
		"\u00cc\u00ca\u0001\u0000\u0000\u0000\u00cc\u00cd\u0001\u0000\u0000\u0000"+
		"\u00cd\u00d2\u0001\u0000\u0000\u0000\u00ce\u00cc\u0001\u0000\u0000\u0000"+
		"\u00cf\u00d2\u0003B!\u0000\u00d0\u00d2\u0001\u0000\u0000\u0000\u00d1\u00c7"+
		"\u0001\u0000\u0000\u0000\u00d1\u00cf\u0001\u0000\u0000\u0000\u00d1\u00d0"+
		"\u0001\u0000\u0000\u0000\u00d2\u00d3\u0001\u0000\u0000\u0000\u00d3\u00d4"+
		"\u0005$\u0000\u0000\u00d4!\u0001\u0000\u0000\u0000\u00d5\u00e5\u0005#"+
		"\u0000\u0000\u00d6\u00d9\u00036\u001b\u0000\u00d7\u00d9\u00055\u0000\u0000"+
		"\u00d8\u00d6\u0001\u0000\u0000\u0000\u00d8\u00d7\u0001\u0000\u0000\u0000"+
		"\u00d9\u00e1\u0001\u0000\u0000\u0000\u00da\u00dd\u0005\'\u0000\u0000\u00db"+
		"\u00de\u00036\u001b\u0000\u00dc\u00de\u00055\u0000\u0000\u00dd\u00db\u0001"+
		"\u0000\u0000\u0000\u00dd\u00dc\u0001\u0000\u0000\u0000\u00de\u00e0\u0001"+
		"\u0000\u0000\u0000\u00df\u00da\u0001\u0000\u0000\u0000\u00e0\u00e3\u0001"+
		"\u0000\u0000\u0000\u00e1\u00df\u0001\u0000\u0000\u0000\u00e1\u00e2\u0001"+
		"\u0000\u0000\u0000\u00e2\u00e6\u0001\u0000\u0000\u0000\u00e3\u00e1\u0001"+
		"\u0000\u0000\u0000\u00e4\u00e6\u0001\u0000\u0000\u0000\u00e5\u00d8\u0001"+
		"\u0000\u0000\u0000\u00e5\u00e4\u0001\u0000\u0000\u0000\u00e6\u00e7\u0001"+
		"\u0000\u0000\u0000\u00e7\u00e8\u0005$\u0000\u0000\u00e8#\u0001\u0000\u0000"+
		"\u0000\u00e9\u00ec\u0003\u0018\f\u0000\u00ea\u00eb\u0005*\u0000\u0000"+
		"\u00eb\u00ed\u0003\u0010\b\u0000\u00ec\u00ea\u0001\u0000\u0000\u0000\u00ec"+
		"\u00ed\u0001\u0000\u0000\u0000\u00ed\u00f0\u0001\u0000\u0000\u0000\u00ee"+
		"\u00ef\u0005(\u0000\u0000\u00ef\u00f1\u0003\"\u0011\u0000\u00f0\u00ee"+
		"\u0001\u0000\u0000\u0000\u00f0\u00f1\u0001\u0000\u0000\u0000\u00f1\u00f2"+
		"\u0001\u0000\u0000\u0000\u00f2\u00f3\u0005%\u0000\u0000\u00f3%\u0001\u0000"+
		"\u0000\u0000\u00f4\u00f5\u0005\r\u0000\u0000\u00f5\u00f6\u00055\u0000"+
		"\u0000\u00f6\'\u0001\u0000\u0000\u0000\u00f7\u00f8\u0005\b\u0000\u0000"+
		"\u00f8\u00fa\u00055\u0000\u0000\u00f9\u00fb\u0003&\u0013\u0000\u00fa\u00f9"+
		"\u0001\u0000\u0000\u0000\u00fa\u00fb\u0001\u0000\u0000\u0000\u00fb\u00fc"+
		"\u0001\u0000\u0000\u0000\u00fc\u0101\u0005!\u0000\u0000\u00fd\u0100\u0003"+
		"$\u0012\u0000\u00fe\u0100\u0003,\u0016\u0000\u00ff\u00fd\u0001\u0000\u0000"+
		"\u0000\u00ff\u00fe\u0001\u0000\u0000\u0000\u0100\u0103\u0001\u0000\u0000"+
		"\u0000\u0101\u00ff\u0001\u0000\u0000\u0000\u0101\u0102\u0001\u0000\u0000"+
		"\u0000\u0102\u0104\u0001\u0000\u0000\u0000\u0103\u0101\u0001\u0000\u0000"+
		"\u0000\u0104\u0105\u0005\"\u0000\u0000\u0105\u0106\u0005%\u0000\u0000"+
		"\u0106)\u0001\u0000\u0000\u0000\u0107\u0108\u0005\f\u0000\u0000\u0108"+
		"\u0109\u00055\u0000\u0000\u0109\u010d\u0005!\u0000\u0000\u010a\u010c\u0003"+
		",\u0016\u0000\u010b\u010a\u0001\u0000\u0000\u0000\u010c\u010f\u0001\u0000"+
		"\u0000\u0000\u010d\u010b\u0001\u0000\u0000\u0000\u010d\u010e\u0001\u0000"+
		"\u0000\u0000\u010e\u0110\u0001\u0000\u0000\u0000\u010f\u010d\u0001\u0000"+
		"\u0000\u0000\u0110\u0111\u0005\"\u0000\u0000\u0111\u0112\u0005%\u0000"+
		"\u0000\u0112+\u0001\u0000\u0000\u0000\u0113\u0114\u0003\u0018\f\u0000"+
		"\u0114\u011e\u0005\u001f\u0000\u0000\u0115\u011a\u0003\u0018\f\u0000\u0116"+
		"\u0117\u0005\'\u0000\u0000\u0117\u0119\u0003\u0018\f\u0000\u0118\u0116"+
		"\u0001\u0000\u0000\u0000\u0119\u011c\u0001\u0000\u0000\u0000\u011a\u0118"+
		"\u0001\u0000\u0000\u0000\u011a\u011b\u0001\u0000\u0000\u0000\u011b\u011f"+
		"\u0001\u0000\u0000\u0000\u011c\u011a\u0001\u0000\u0000\u0000\u011d\u011f"+
		"\u0001\u0000\u0000\u0000\u011e\u0115\u0001\u0000\u0000\u0000\u011e\u011d"+
		"\u0001\u0000\u0000\u0000\u011f\u0120\u0001\u0000\u0000\u0000\u0120\u0121"+
		"\u0005 \u0000\u0000\u0121\u0122\u0005!\u0000\u0000\u0122\u0123\u0003D"+
		"\"\u0000\u0123\u0124\u0005\"\u0000\u0000\u0124\u0125\u0005%\u0000\u0000"+
		"\u0125-\u0001\u0000\u0000\u0000\u0126\u0127\u00055\u0000\u0000\u0127\u0128"+
		"\u0005&\u0000\u0000\u0128/\u0001\u0000\u0000\u0000\u0129\u012b\u0003."+
		"\u0017\u0000\u012a\u0129\u0001\u0000\u0000\u0000\u012a\u012b\u0001\u0000"+
		"\u0000\u0000\u012b\u012c\u0001\u0000\u0000\u0000\u012c\u012d\u00055\u0000"+
		"\u0000\u012d\u0137\u0005\u001f\u0000\u0000\u012e\u0133\u00032\u0019\u0000"+
		"\u012f\u0130\u0005\'\u0000\u0000\u0130\u0132\u00032\u0019\u0000\u0131"+
		"\u012f\u0001\u0000\u0000\u0000\u0132\u0135\u0001\u0000\u0000\u0000\u0133"+
		"\u0131\u0001\u0000\u0000\u0000\u0133\u0134\u0001\u0000\u0000\u0000\u0134"+
		"\u0138\u0001\u0000\u0000\u0000\u0135\u0133\u0001\u0000\u0000\u0000\u0136"+
		"\u0138\u0001\u0000\u0000\u0000\u0137\u012e\u0001\u0000\u0000\u0000\u0137"+
		"\u0136\u0001\u0000\u0000\u0000\u0138\u0139\u0001\u0000\u0000\u0000\u0139"+
		"\u013a\u0005 \u0000\u0000\u013a1\u0001\u0000\u0000\u0000\u013b\u013c\u0006"+
		"\u0019\uffff\uffff\u0000\u013c\u0142\u0003\u0010\b\u0000\u013d\u0142\u0005"+
		"5\u0000\u0000\u013e\u0142\u00030\u0018\u0000\u013f\u0142\u00036\u001b"+
		"\u0000\u0140\u0142\u00034\u001a\u0000\u0141\u013b\u0001\u0000\u0000\u0000"+
		"\u0141\u013d\u0001\u0000\u0000\u0000\u0141\u013e\u0001\u0000\u0000\u0000"+
		"\u0141\u013f\u0001\u0000\u0000\u0000\u0141\u0140\u0001\u0000\u0000\u0000"+
		"\u0142\u0148\u0001\u0000\u0000\u0000\u0143\u0144\n\u0002\u0000\u0000\u0144"+
		"\u0145\u0005\u0017\u0000\u0000\u0145\u0147\u00032\u0019\u0003\u0146\u0143"+
		"\u0001\u0000\u0000\u0000\u0147\u014a\u0001\u0000\u0000\u0000\u0148\u0146"+
		"\u0001\u0000\u0000\u0000\u0148\u0149\u0001\u0000\u0000\u0000\u01493\u0001"+
		"\u0000\u0000\u0000\u014a\u0148\u0001\u0000\u0000\u0000\u014b\u014c\u0006"+
		"\u001a\uffff\uffff\u0000\u014c\u0157\u0003\u000e\u0007\u0000\u014d\u0157"+
		"\u0005\u000e\u0000\u0000\u014e\u0157\u00055\u0000\u0000\u014f\u0157\u0003"+
		"0\u0018\u0000\u0150\u0151\u0005\u0013\u0000\u0000\u0151\u0157\u00034\u001a"+
		"\u0004\u0152\u0153\u0005\u001f\u0000\u0000\u0153\u0154\u00034\u001a\u0000"+
		"\u0154\u0155\u0005 \u0000\u0000\u0155\u0157\u0001\u0000\u0000\u0000\u0156"+
		"\u014b\u0001\u0000\u0000\u0000\u0156\u014d\u0001\u0000\u0000\u0000\u0156"+
		"\u014e\u0001\u0000\u0000\u0000\u0156\u014f\u0001\u0000\u0000\u0000\u0156"+
		"\u0150\u0001\u0000\u0000\u0000\u0156\u0152\u0001\u0000\u0000\u0000\u0157"+
		"\u0160\u0001\u0000\u0000\u0000\u0158\u0159\n\u0003\u0000\u0000\u0159\u015a"+
		"\u0007\u0002\u0000\u0000\u015a\u015f\u00034\u001a\u0004\u015b\u015c\n"+
		"\u0002\u0000\u0000\u015c\u015d\u0007\u0003\u0000\u0000\u015d\u015f\u0003"+
		"4\u001a\u0003\u015e\u0158\u0001\u0000\u0000\u0000\u015e\u015b\u0001\u0000"+
		"\u0000\u0000\u015f\u0162\u0001\u0000\u0000\u0000\u0160\u015e\u0001\u0000"+
		"\u0000\u0000\u0160\u0161\u0001\u0000\u0000\u0000\u01615\u0001\u0000\u0000"+
		"\u0000\u0162\u0160\u0001\u0000\u0000\u0000\u0163\u0164\u0006\u001b\uffff"+
		"\uffff\u0000\u0164\u016f\u00051\u0000\u0000\u0165\u016f\u0005\u000e\u0000"+
		"\u0000\u0166\u016f\u00055\u0000\u0000\u0167\u016f\u00030\u0018\u0000\u0168"+
		"\u0169\u0005\u001d\u0000\u0000\u0169\u016f\u00032\u0019\u0000\u016a\u016b"+
		"\u00034\u001a\u0000\u016b\u016c\u00038\u001c\u0000\u016c\u016d\u00034"+
		"\u001a\u0000\u016d\u016f\u0001\u0000\u0000\u0000\u016e\u0163\u0001\u0000"+
		"\u0000\u0000\u016e\u0165\u0001\u0000\u0000\u0000\u016e\u0166\u0001\u0000"+
		"\u0000\u0000\u016e\u0167\u0001\u0000\u0000\u0000\u016e\u0168\u0001\u0000"+
		"\u0000\u0000\u016e\u016a\u0001\u0000\u0000\u0000\u016f\u017b\u0001\u0000"+
		"\u0000\u0000\u0170\u0171\n\u0003\u0000\u0000\u0171\u0172\u0005\u0017\u0000"+
		"\u0000\u0172\u017a\u00036\u001b\u0004\u0173\u0174\n\u0002\u0000\u0000"+
		"\u0174\u0175\u0005\u0015\u0000\u0000\u0175\u017a\u00036\u001b\u0003\u0176"+
		"\u0177\n\u0001\u0000\u0000\u0177\u0178\u0005\u0016\u0000\u0000\u0178\u017a"+
		"\u00036\u001b\u0002\u0179\u0170\u0001\u0000\u0000\u0000\u0179\u0173\u0001"+
		"\u0000\u0000\u0000\u0179\u0176\u0001\u0000\u0000\u0000\u017a\u017d\u0001"+
		"\u0000\u0000\u0000\u017b\u0179\u0001\u0000\u0000\u0000\u017b\u017c\u0001"+
		"\u0000\u0000\u0000\u017c7\u0001\u0000\u0000\u0000\u017d\u017b\u0001\u0000"+
		"\u0000\u0000\u017e\u017f\u0007\u0004\u0000\u0000\u017f9\u0001\u0000\u0000"+
		"\u0000\u0180\u0181\u0005\u0003\u0000\u0000\u0181\u0182\u0005\u001f\u0000"+
		"\u0000\u0182\u0183\u00036\u001b\u0000\u0183\u0184\u0005 \u0000\u0000\u0184"+
		"\u0185\u0005!\u0000\u0000\u0185\u0186\u0003F#\u0000\u0186\u0187\u0005"+
		"\"\u0000\u0000\u0187;\u0001\u0000\u0000\u0000\u0188\u018d\u0003:\u001d"+
		"\u0000\u0189\u018a\u0005\u0004\u0000\u0000\u018a\u018c\u0003:\u001d\u0000"+
		"\u018b\u0189\u0001\u0000\u0000\u0000\u018c\u018f\u0001\u0000\u0000\u0000"+
		"\u018d\u018b\u0001\u0000\u0000\u0000\u018d\u018e\u0001\u0000\u0000\u0000"+
		"\u018e\u0192\u0001\u0000\u0000\u0000\u018f\u018d\u0001\u0000\u0000\u0000"+
		"\u0190\u0191\u0005\u0004\u0000\u0000\u0191\u0193\u0003F#\u0000\u0192\u0190"+
		"\u0001\u0000\u0000\u0000\u0192\u0193\u0001\u0000\u0000\u0000\u0193=\u0001"+
		"\u0000\u0000\u0000\u0194\u0195\u0005\u0005\u0000\u0000\u0195\u0196\u0005"+
		"\u001f\u0000\u0000\u0196\u0197\u00036\u001b\u0000\u0197\u0198\u0005 \u0000"+
		"\u0000\u0198\u0199\u0005!\u0000\u0000\u0199\u019a\u0003F#\u0000\u019a"+
		"\u019b\u0005\"\u0000\u0000\u019b?\u0001\u0000\u0000\u0000\u019c\u019d"+
		"\u0005\u0006\u0000\u0000\u019d\u019e\u0005\u001f\u0000\u0000\u019e\u019f"+
		"\u00055\u0000\u0000\u019f\u01a2\u0005\t\u0000\u0000\u01a0\u01a3\u0003"+
		" \u0010\u0000\u01a1\u01a3\u00030\u0018\u0000\u01a2\u01a0\u0001\u0000\u0000"+
		"\u0000\u01a2\u01a1\u0001\u0000\u0000\u0000\u01a3\u01a4\u0001\u0000\u0000"+
		"\u0000\u01a4\u01a5\u0005 \u0000\u0000\u01a5\u01a6\u0005!\u0000\u0000\u01a6"+
		"\u01a7\u0003F#\u0000\u01a7\u01a8\u0005\"\u0000\u0000\u01a8A\u0001\u0000"+
		"\u0000\u0000\u01a9\u01aa\u0005\u0006\u0000\u0000\u01aa\u01ab\u0005\u001f"+
		"\u0000\u0000\u01ab\u01ac\u00055\u0000\u0000\u01ac\u01af\u0005\t\u0000"+
		"\u0000\u01ad\u01b0\u0003 \u0010\u0000\u01ae\u01b0\u00030\u0018\u0000\u01af"+
		"\u01ad\u0001\u0000\u0000\u0000\u01af\u01ae\u0001\u0000\u0000\u0000\u01b0"+
		"\u01b1\u0001\u0000\u0000\u0000\u01b1\u01b2\u0005 \u0000\u0000\u01b2\u01b3"+
		"\u0005!\u0000\u0000\u01b3\u01b4\u0003\u0010\b\u0000\u01b4\u01b5\u0005"+
		"\"\u0000\u0000\u01b5C\u0001\u0000\u0000\u0000\u01b6\u01b8\u0003F#\u0000"+
		"\u01b7\u01b6\u0001\u0000\u0000\u0000\u01b8\u01bb\u0001\u0000\u0000\u0000"+
		"\u01b9\u01b7\u0001\u0000\u0000\u0000\u01b9\u01ba\u0001\u0000\u0000\u0000"+
		"\u01baE\u0001\u0000\u0000\u0000\u01bb\u01b9\u0001\u0000\u0000\u0000\u01bc"+
		"\u01c9\u0003<\u001e\u0000\u01bd\u01c9\u0003H$\u0000\u01be\u01c9\u0003"+
		">\u001f\u0000\u01bf\u01c9\u0003@ \u0000\u01c0\u01c1\u00030\u0018\u0000"+
		"\u01c1\u01c2\u0005%\u0000\u0000\u01c2\u01c9\u0001\u0000\u0000\u0000\u01c3"+
		"\u01c9\u0003,\u0016\u0000\u01c4\u01c5\u0005\u0007\u0000\u0000\u01c5\u01c6"+
		"\u00032\u0019\u0000\u01c6\u01c7\u0005%\u0000\u0000\u01c7\u01c9\u0001\u0000"+
		"\u0000\u0000\u01c8\u01bc\u0001\u0000\u0000\u0000\u01c8\u01bd\u0001\u0000"+
		"\u0000\u0000\u01c8\u01be\u0001\u0000\u0000\u0000\u01c8\u01bf\u0001\u0000"+
		"\u0000\u0000\u01c8\u01c0\u0001\u0000\u0000\u0000\u01c8\u01c3\u0001\u0000"+
		"\u0000\u0000\u01c8\u01c4\u0001\u0000\u0000\u0000\u01c9G\u0001\u0000\u0000"+
		"\u0000\u01ca\u01cc\u0005\n\u0000\u0000\u01cb\u01ca\u0001\u0000\u0000\u0000"+
		"\u01cb\u01cc\u0001\u0000\u0000\u0000\u01cc\u01ce\u0001\u0000\u0000\u0000"+
		"\u01cd\u01cf\u0003\b\u0004\u0000\u01ce\u01cd\u0001\u0000\u0000\u0000\u01ce"+
		"\u01cf\u0001\u0000\u0000\u0000\u01cf\u01d0\u0001\u0000\u0000\u0000\u01d0"+
		"\u01d1\u00055\u0000\u0000\u01d1\u01d2\u0005*\u0000\u0000\u01d2\u01d3\u0003"+
		"2\u0019\u0000\u01d3\u01d4\u0005%\u0000\u0000\u01d4I\u0001\u0000\u0000"+
		"\u0000\u01d5\u01d7\u0005\n\u0000\u0000\u01d6\u01d5\u0001\u0000\u0000\u0000"+
		"\u01d6\u01d7\u0001\u0000\u0000\u0000\u01d7\u01d9\u0001\u0000\u0000\u0000"+
		"\u01d8\u01da\u0003\u0000\u0000\u0000\u01d9\u01d8\u0001\u0000\u0000\u0000"+
		"\u01d9\u01da\u0001\u0000\u0000\u0000\u01da\u01db\u0001\u0000\u0000\u0000"+
		"\u01db\u01dc\u00055\u0000\u0000\u01dc\u01dd\u0005*\u0000\u0000\u01dd\u01de"+
		"\u0003\u001c\u000e\u0000\u01de\u01df\u0005%\u0000\u0000\u01dfK\u0001\u0000"+
		"\u0000\u0000\u01e0\u01e2\u0005\n\u0000\u0000\u01e1\u01e0\u0001\u0000\u0000"+
		"\u0000\u01e1\u01e2\u0001\u0000\u0000\u0000\u01e2\u01e4\u0001\u0000\u0000"+
		"\u0000\u01e3\u01e5\u0003\u0002\u0001\u0000\u01e4\u01e3\u0001\u0000\u0000"+
		"\u0000\u01e4\u01e5\u0001\u0000\u0000\u0000\u01e5\u01e6\u0001\u0000\u0000"+
		"\u0000\u01e6\u01e7\u00055\u0000\u0000\u01e7\u01e8\u0005*\u0000\u0000\u01e8"+
		"\u01e9\u0003 \u0010\u0000\u01e9\u01ea\u0005%\u0000\u0000\u01eaM\u0001"+
		"\u0000\u0000\u0000\u01eb\u01ec\u0003\u0018\f\u0000\u01ec\u01ed\u0005%"+
		"\u0000\u0000\u01edO\u0001\u0000\u0000\u0000\u01ee\u01f4\u0003(\u0014\u0000"+
		"\u01ef\u01f4\u0003J%\u0000\u01f0\u01f4\u0003L&\u0000\u01f1\u01f4\u0003"+
		"*\u0015\u0000\u01f2\u01f4\u0003\u001e\u000f\u0000\u01f3\u01ee\u0001\u0000"+
		"\u0000\u0000\u01f3\u01ef\u0001\u0000\u0000\u0000\u01f3\u01f0\u0001\u0000"+
		"\u0000\u0000\u01f3\u01f1\u0001\u0000\u0000\u0000\u01f3\u01f2\u0001\u0000"+
		"\u0000\u0000\u01f4\u01f7\u0001\u0000\u0000\u0000\u01f5\u01f3\u0001\u0000"+
		"\u0000\u0000\u01f5\u01f6\u0001\u0000\u0000\u0000\u01f6Q\u0001\u0000\u0000"+
		"\u0000\u01f7\u01f5\u0001\u0000\u0000\u0000\u01f8\u01f9\u0003P(\u0000\u01f9"+
		"S\u0001\u0000\u0000\u00009X^eiq{\u0081\u0089\u008f\u0091\u0093\u009d\u00a3"+
		"\u00a5\u00b0\u00b6\u00bc\u00bf\u00cc\u00d1\u00d8\u00dd\u00e1\u00e5\u00ec"+
		"\u00f0\u00fa\u00ff\u0101\u010d\u011a\u011e\u012a\u0133\u0137\u0141\u0148"+
		"\u0156\u015e\u0160\u016e\u0179\u017b\u018d\u0192\u01a2\u01af\u01b9\u01c8"+
		"\u01cb\u01ce\u01d6\u01d9\u01e1\u01e4\u01f3\u01f5";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}