// Generated from /home/max/Desktop/uni/4. semester/p4/UCM.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue", "this-escape"})
public class UCMLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"WS", "COMMENT", "LINE_COMMENT", "BLOCK_COMMENT", "IF", "ELSE", "WHILE", 
			"FOR", "RETURN", "TEMPLATE_KEYWORD", "IN", "HIDDEN_", "OBJECT_KEYWORD", 
			"FUNCTIONS_KEYWORD", "EXTENDS_KEYWORD", "THIS_KEYWORD", "MULT", "DIV", 
			"PLUS", "MINUS", "MOD", "AND", "OR", "EQ", "NEQ", "GT", "LT", "GTE", 
			"LTE", "NOT", "QUESTION", "LPAREN", "RPAREN", "LCURLY", "RCURLY", "LBRACKET", 
			"RBRACKET", "SEMI", "DOT", "COMMA", "COLON", "NEWLINE", "ASSIGN", "QUOTE", 
			"DOLLAR", "INT_T", "FLOAT_T", "STRING_T", "BOOL_T", "BOOL", "INT", "FLOAT", 
			"STRING_BODY", "ESCAPE_SEQUENCE", "UNICODE_ESCAPE", "HEX_DIGIT", "ID"
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


	public UCMLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "UCM.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\u0004\u00004\u0178\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002\u0001"+
		"\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004"+
		"\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007"+
		"\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b"+
		"\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002"+
		"\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002"+
		"\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0002"+
		"\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017\u0002"+
		"\u0018\u0007\u0018\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a\u0002"+
		"\u001b\u0007\u001b\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d\u0002"+
		"\u001e\u0007\u001e\u0002\u001f\u0007\u001f\u0002 \u0007 \u0002!\u0007"+
		"!\u0002\"\u0007\"\u0002#\u0007#\u0002$\u0007$\u0002%\u0007%\u0002&\u0007"+
		"&\u0002\'\u0007\'\u0002(\u0007(\u0002)\u0007)\u0002*\u0007*\u0002+\u0007"+
		"+\u0002,\u0007,\u0002-\u0007-\u0002.\u0007.\u0002/\u0007/\u00020\u0007"+
		"0\u00021\u00071\u00022\u00072\u00023\u00073\u00024\u00074\u00025\u0007"+
		"5\u00026\u00076\u00027\u00077\u00028\u00078\u0001\u0000\u0004\u0000u\b"+
		"\u0000\u000b\u0000\f\u0000v\u0001\u0000\u0001\u0000\u0001\u0001\u0001"+
		"\u0001\u0003\u0001}\b\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001"+
		"\u0002\u0005\u0002\u0083\b\u0002\n\u0002\f\u0002\u0086\t\u0002\u0001\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0005\u0003\u008c\b\u0003\n\u0003"+
		"\f\u0003\u008f\t\u0003\u0001\u0003\u0001\u0003\u0001\u0003\u0001\u0004"+
		"\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0005"+
		"\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0006"+
		"\u0001\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\b\u0001"+
		"\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\b\u0001\t\u0001\t\u0001\t\u0001"+
		"\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\n\u0001"+
		"\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001\u000b\u0001"+
		"\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\r"+
		"\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001\r\u0001"+
		"\r\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e\u0001\u000e"+
		"\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001\u000f\u0001\u000f"+
		"\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0012"+
		"\u0001\u0012\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0015"+
		"\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001\u0016\u0001\u0017"+
		"\u0001\u0017\u0001\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0019"+
		"\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001b\u0001\u001b\u0001\u001b"+
		"\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0001\u001e"+
		"\u0001\u001e\u0001\u001f\u0001\u001f\u0001 \u0001 \u0001!\u0001!\u0001"+
		"\"\u0001\"\u0001#\u0001#\u0001$\u0001$\u0001%\u0001%\u0001&\u0001&\u0001"+
		"\'\u0001\'\u0001(\u0001(\u0001)\u0001)\u0001*\u0001*\u0001+\u0001+\u0001"+
		",\u0001,\u0001-\u0001-\u0001-\u0001-\u0001.\u0001.\u0001.\u0001.\u0001"+
		".\u0001.\u0001/\u0001/\u0001/\u0001/\u0001/\u0001/\u0001/\u00010\u0001"+
		"0\u00010\u00010\u00010\u00011\u00011\u00011\u00011\u00011\u00011\u0001"+
		"1\u00011\u00011\u00031\u013d\b1\u00012\u00042\u0140\b2\u000b2\f2\u0141"+
		"\u00013\u00053\u0145\b3\n3\f3\u0148\t3\u00013\u00013\u00043\u014c\b3\u000b"+
		"3\f3\u014d\u00013\u00043\u0151\b3\u000b3\f3\u0152\u00013\u00013\u0005"+
		"3\u0157\b3\n3\f3\u015a\t3\u00033\u015c\b3\u00014\u00014\u00054\u0160\b"+
		"4\n4\f4\u0163\t4\u00015\u00015\u00015\u00035\u0168\b5\u00016\u00016\u0001"+
		"6\u00016\u00016\u00016\u00017\u00017\u00018\u00018\u00058\u0174\b8\n8"+
		"\f8\u0177\t8\u0002\u008d\u0161\u00009\u0001\u0001\u0003\u0002\u0005\u0000"+
		"\u0007\u0000\t\u0003\u000b\u0004\r\u0005\u000f\u0006\u0011\u0007\u0013"+
		"\b\u0015\t\u0017\n\u0019\u000b\u001b\f\u001d\r\u001f\u000e!\u000f#\u0010"+
		"%\u0011\'\u0012)\u0013+\u0014-\u0015/\u00161\u00173\u00185\u00197\u001a"+
		"9\u001b;\u001c=\u001d?\u001eA\u001fC E!G\"I#K$M%O&Q\'S(U)W*Y+[,]-_.a/"+
		"c0e1g2i\u0000k3m\u0000o\u0000q4\u0001\u0000\u0007\u0003\u0000\t\n\r\r"+
		"  \u0002\u0000\n\n\r\r\u0001\u000009\u0003\u0000\"\"\'\'\\\\\u0003\u0000"+
		"09AFaf\u0003\u0000AZ__az\u0004\u000009AZ__az\u0181\u0000\u0001\u0001\u0000"+
		"\u0000\u0000\u0000\u0003\u0001\u0000\u0000\u0000\u0000\t\u0001\u0000\u0000"+
		"\u0000\u0000\u000b\u0001\u0000\u0000\u0000\u0000\r\u0001\u0000\u0000\u0000"+
		"\u0000\u000f\u0001\u0000\u0000\u0000\u0000\u0011\u0001\u0000\u0000\u0000"+
		"\u0000\u0013\u0001\u0000\u0000\u0000\u0000\u0015\u0001\u0000\u0000\u0000"+
		"\u0000\u0017\u0001\u0000\u0000\u0000\u0000\u0019\u0001\u0000\u0000\u0000"+
		"\u0000\u001b\u0001\u0000\u0000\u0000\u0000\u001d\u0001\u0000\u0000\u0000"+
		"\u0000\u001f\u0001\u0000\u0000\u0000\u0000!\u0001\u0000\u0000\u0000\u0000"+
		"#\u0001\u0000\u0000\u0000\u0000%\u0001\u0000\u0000\u0000\u0000\'\u0001"+
		"\u0000\u0000\u0000\u0000)\u0001\u0000\u0000\u0000\u0000+\u0001\u0000\u0000"+
		"\u0000\u0000-\u0001\u0000\u0000\u0000\u0000/\u0001\u0000\u0000\u0000\u0000"+
		"1\u0001\u0000\u0000\u0000\u00003\u0001\u0000\u0000\u0000\u00005\u0001"+
		"\u0000\u0000\u0000\u00007\u0001\u0000\u0000\u0000\u00009\u0001\u0000\u0000"+
		"\u0000\u0000;\u0001\u0000\u0000\u0000\u0000=\u0001\u0000\u0000\u0000\u0000"+
		"?\u0001\u0000\u0000\u0000\u0000A\u0001\u0000\u0000\u0000\u0000C\u0001"+
		"\u0000\u0000\u0000\u0000E\u0001\u0000\u0000\u0000\u0000G\u0001\u0000\u0000"+
		"\u0000\u0000I\u0001\u0000\u0000\u0000\u0000K\u0001\u0000\u0000\u0000\u0000"+
		"M\u0001\u0000\u0000\u0000\u0000O\u0001\u0000\u0000\u0000\u0000Q\u0001"+
		"\u0000\u0000\u0000\u0000S\u0001\u0000\u0000\u0000\u0000U\u0001\u0000\u0000"+
		"\u0000\u0000W\u0001\u0000\u0000\u0000\u0000Y\u0001\u0000\u0000\u0000\u0000"+
		"[\u0001\u0000\u0000\u0000\u0000]\u0001\u0000\u0000\u0000\u0000_\u0001"+
		"\u0000\u0000\u0000\u0000a\u0001\u0000\u0000\u0000\u0000c\u0001\u0000\u0000"+
		"\u0000\u0000e\u0001\u0000\u0000\u0000\u0000g\u0001\u0000\u0000\u0000\u0000"+
		"k\u0001\u0000\u0000\u0000\u0000q\u0001\u0000\u0000\u0000\u0001t\u0001"+
		"\u0000\u0000\u0000\u0003|\u0001\u0000\u0000\u0000\u0005\u0080\u0001\u0000"+
		"\u0000\u0000\u0007\u0087\u0001\u0000\u0000\u0000\t\u0093\u0001\u0000\u0000"+
		"\u0000\u000b\u0096\u0001\u0000\u0000\u0000\r\u009b\u0001\u0000\u0000\u0000"+
		"\u000f\u00a1\u0001\u0000\u0000\u0000\u0011\u00a5\u0001\u0000\u0000\u0000"+
		"\u0013\u00ac\u0001\u0000\u0000\u0000\u0015\u00b5\u0001\u0000\u0000\u0000"+
		"\u0017\u00b8\u0001\u0000\u0000\u0000\u0019\u00bf\u0001\u0000\u0000\u0000"+
		"\u001b\u00c6\u0001\u0000\u0000\u0000\u001d\u00d0\u0001\u0000\u0000\u0000"+
		"\u001f\u00d8\u0001\u0000\u0000\u0000!\u00dd\u0001\u0000\u0000\u0000#\u00df"+
		"\u0001\u0000\u0000\u0000%\u00e1\u0001\u0000\u0000\u0000\'\u00e3\u0001"+
		"\u0000\u0000\u0000)\u00e5\u0001\u0000\u0000\u0000+\u00e7\u0001\u0000\u0000"+
		"\u0000-\u00ea\u0001\u0000\u0000\u0000/\u00ed\u0001\u0000\u0000\u00001"+
		"\u00f0\u0001\u0000\u0000\u00003\u00f3\u0001\u0000\u0000\u00005\u00f5\u0001"+
		"\u0000\u0000\u00007\u00f7\u0001\u0000\u0000\u00009\u00fa\u0001\u0000\u0000"+
		"\u0000;\u00fd\u0001\u0000\u0000\u0000=\u00ff\u0001\u0000\u0000\u0000?"+
		"\u0101\u0001\u0000\u0000\u0000A\u0103\u0001\u0000\u0000\u0000C\u0105\u0001"+
		"\u0000\u0000\u0000E\u0107\u0001\u0000\u0000\u0000G\u0109\u0001\u0000\u0000"+
		"\u0000I\u010b\u0001\u0000\u0000\u0000K\u010d\u0001\u0000\u0000\u0000M"+
		"\u010f\u0001\u0000\u0000\u0000O\u0111\u0001\u0000\u0000\u0000Q\u0113\u0001"+
		"\u0000\u0000\u0000S\u0115\u0001\u0000\u0000\u0000U\u0117\u0001\u0000\u0000"+
		"\u0000W\u0119\u0001\u0000\u0000\u0000Y\u011b\u0001\u0000\u0000\u0000["+
		"\u011d\u0001\u0000\u0000\u0000]\u0121\u0001\u0000\u0000\u0000_\u0127\u0001"+
		"\u0000\u0000\u0000a\u012e\u0001\u0000\u0000\u0000c\u013c\u0001\u0000\u0000"+
		"\u0000e\u013f\u0001\u0000\u0000\u0000g\u015b\u0001\u0000\u0000\u0000i"+
		"\u0161\u0001\u0000\u0000\u0000k\u0164\u0001\u0000\u0000\u0000m\u0169\u0001"+
		"\u0000\u0000\u0000o\u016f\u0001\u0000\u0000\u0000q\u0171\u0001\u0000\u0000"+
		"\u0000su\u0007\u0000\u0000\u0000ts\u0001\u0000\u0000\u0000uv\u0001\u0000"+
		"\u0000\u0000vt\u0001\u0000\u0000\u0000vw\u0001\u0000\u0000\u0000wx\u0001"+
		"\u0000\u0000\u0000xy\u0006\u0000\u0000\u0000y\u0002\u0001\u0000\u0000"+
		"\u0000z}\u0003\u0007\u0003\u0000{}\u0003\u0005\u0002\u0000|z\u0001\u0000"+
		"\u0000\u0000|{\u0001\u0000\u0000\u0000}~\u0001\u0000\u0000\u0000~\u007f"+
		"\u0006\u0001\u0000\u0000\u007f\u0004\u0001\u0000\u0000\u0000\u0080\u0084"+
		"\u0005#\u0000\u0000\u0081\u0083\b\u0001\u0000\u0000\u0082\u0081\u0001"+
		"\u0000\u0000\u0000\u0083\u0086\u0001\u0000\u0000\u0000\u0084\u0082\u0001"+
		"\u0000\u0000\u0000\u0084\u0085\u0001\u0000\u0000\u0000\u0085\u0006\u0001"+
		"\u0000\u0000\u0000\u0086\u0084\u0001\u0000\u0000\u0000\u0087\u0088\u0005"+
		"#\u0000\u0000\u0088\u0089\u0005#\u0000\u0000\u0089\u008d\u0001\u0000\u0000"+
		"\u0000\u008a\u008c\t\u0000\u0000\u0000\u008b\u008a\u0001\u0000\u0000\u0000"+
		"\u008c\u008f\u0001\u0000\u0000\u0000\u008d\u008e\u0001\u0000\u0000\u0000"+
		"\u008d\u008b\u0001\u0000\u0000\u0000\u008e\u0090\u0001\u0000\u0000\u0000"+
		"\u008f\u008d\u0001\u0000\u0000\u0000\u0090\u0091\u0005#\u0000\u0000\u0091"+
		"\u0092\u0005#\u0000\u0000\u0092\b\u0001\u0000\u0000\u0000\u0093\u0094"+
		"\u0005i\u0000\u0000\u0094\u0095\u0005f\u0000\u0000\u0095\n\u0001\u0000"+
		"\u0000\u0000\u0096\u0097\u0005e\u0000\u0000\u0097\u0098\u0005l\u0000\u0000"+
		"\u0098\u0099\u0005s\u0000\u0000\u0099\u009a\u0005e\u0000\u0000\u009a\f"+
		"\u0001\u0000\u0000\u0000\u009b\u009c\u0005w\u0000\u0000\u009c\u009d\u0005"+
		"h\u0000\u0000\u009d\u009e\u0005i\u0000\u0000\u009e\u009f\u0005l\u0000"+
		"\u0000\u009f\u00a0\u0005e\u0000\u0000\u00a0\u000e\u0001\u0000\u0000\u0000"+
		"\u00a1\u00a2\u0005f\u0000\u0000\u00a2\u00a3\u0005o\u0000\u0000\u00a3\u00a4"+
		"\u0005r\u0000\u0000\u00a4\u0010\u0001\u0000\u0000\u0000\u00a5\u00a6\u0005"+
		"r\u0000\u0000\u00a6\u00a7\u0005e\u0000\u0000\u00a7\u00a8\u0005t\u0000"+
		"\u0000\u00a8\u00a9\u0005u\u0000\u0000\u00a9\u00aa\u0005r\u0000\u0000\u00aa"+
		"\u00ab\u0005n\u0000\u0000\u00ab\u0012\u0001\u0000\u0000\u0000\u00ac\u00ad"+
		"\u0005t\u0000\u0000\u00ad\u00ae\u0005e\u0000\u0000\u00ae\u00af\u0005m"+
		"\u0000\u0000\u00af\u00b0\u0005p\u0000\u0000\u00b0\u00b1\u0005l\u0000\u0000"+
		"\u00b1\u00b2\u0005a\u0000\u0000\u00b2\u00b3\u0005t\u0000\u0000\u00b3\u00b4"+
		"\u0005e\u0000\u0000\u00b4\u0014\u0001\u0000\u0000\u0000\u00b5\u00b6\u0005"+
		"i\u0000\u0000\u00b6\u00b7\u0005n\u0000\u0000\u00b7\u0016\u0001\u0000\u0000"+
		"\u0000\u00b8\u00b9\u0005h\u0000\u0000\u00b9\u00ba\u0005i\u0000\u0000\u00ba"+
		"\u00bb\u0005d\u0000\u0000\u00bb\u00bc\u0005d\u0000\u0000\u00bc\u00bd\u0005"+
		"e\u0000\u0000\u00bd\u00be\u0005n\u0000\u0000\u00be\u0018\u0001\u0000\u0000"+
		"\u0000\u00bf\u00c0\u0005o\u0000\u0000\u00c0\u00c1\u0005b\u0000\u0000\u00c1"+
		"\u00c2\u0005j\u0000\u0000\u00c2\u00c3\u0005e\u0000\u0000\u00c3\u00c4\u0005"+
		"c\u0000\u0000\u00c4\u00c5\u0005t\u0000\u0000\u00c5\u001a\u0001\u0000\u0000"+
		"\u0000\u00c6\u00c7\u0005f\u0000\u0000\u00c7\u00c8\u0005u\u0000\u0000\u00c8"+
		"\u00c9\u0005n\u0000\u0000\u00c9\u00ca\u0005c\u0000\u0000\u00ca\u00cb\u0005"+
		"t\u0000\u0000\u00cb\u00cc\u0005i\u0000\u0000\u00cc\u00cd\u0005o\u0000"+
		"\u0000\u00cd\u00ce\u0005n\u0000\u0000\u00ce\u00cf\u0005s\u0000\u0000\u00cf"+
		"\u001c\u0001\u0000\u0000\u0000\u00d0\u00d1\u0005e\u0000\u0000\u00d1\u00d2"+
		"\u0005x\u0000\u0000\u00d2\u00d3\u0005t\u0000\u0000\u00d3\u00d4\u0005e"+
		"\u0000\u0000\u00d4\u00d5\u0005n\u0000\u0000\u00d5\u00d6\u0005d\u0000\u0000"+
		"\u00d6\u00d7\u0005s\u0000\u0000\u00d7\u001e\u0001\u0000\u0000\u0000\u00d8"+
		"\u00d9\u0005t\u0000\u0000\u00d9\u00da\u0005h\u0000\u0000\u00da\u00db\u0005"+
		"i\u0000\u0000\u00db\u00dc\u0005s\u0000\u0000\u00dc \u0001\u0000\u0000"+
		"\u0000\u00dd\u00de\u0005*\u0000\u0000\u00de\"\u0001\u0000\u0000\u0000"+
		"\u00df\u00e0\u0005/\u0000\u0000\u00e0$\u0001\u0000\u0000\u0000\u00e1\u00e2"+
		"\u0005+\u0000\u0000\u00e2&\u0001\u0000\u0000\u0000\u00e3\u00e4\u0005-"+
		"\u0000\u0000\u00e4(\u0001\u0000\u0000\u0000\u00e5\u00e6\u0005%\u0000\u0000"+
		"\u00e6*\u0001\u0000\u0000\u0000\u00e7\u00e8\u0005&\u0000\u0000\u00e8\u00e9"+
		"\u0005&\u0000\u0000\u00e9,\u0001\u0000\u0000\u0000\u00ea\u00eb\u0005|"+
		"\u0000\u0000\u00eb\u00ec\u0005|\u0000\u0000\u00ec.\u0001\u0000\u0000\u0000"+
		"\u00ed\u00ee\u0005=\u0000\u0000\u00ee\u00ef\u0005=\u0000\u0000\u00ef0"+
		"\u0001\u0000\u0000\u0000\u00f0\u00f1\u0005!\u0000\u0000\u00f1\u00f2\u0005"+
		"=\u0000\u0000\u00f22\u0001\u0000\u0000\u0000\u00f3\u00f4\u0005>\u0000"+
		"\u0000\u00f44\u0001\u0000\u0000\u0000\u00f5\u00f6\u0005<\u0000\u0000\u00f6"+
		"6\u0001\u0000\u0000\u0000\u00f7\u00f8\u0005>\u0000\u0000\u00f8\u00f9\u0005"+
		"=\u0000\u0000\u00f98\u0001\u0000\u0000\u0000\u00fa\u00fb\u0005<\u0000"+
		"\u0000\u00fb\u00fc\u0005=\u0000\u0000\u00fc:\u0001\u0000\u0000\u0000\u00fd"+
		"\u00fe\u0005!\u0000\u0000\u00fe<\u0001\u0000\u0000\u0000\u00ff\u0100\u0005"+
		"?\u0000\u0000\u0100>\u0001\u0000\u0000\u0000\u0101\u0102\u0005(\u0000"+
		"\u0000\u0102@\u0001\u0000\u0000\u0000\u0103\u0104\u0005)\u0000\u0000\u0104"+
		"B\u0001\u0000\u0000\u0000\u0105\u0106\u0005{\u0000\u0000\u0106D\u0001"+
		"\u0000\u0000\u0000\u0107\u0108\u0005}\u0000\u0000\u0108F\u0001\u0000\u0000"+
		"\u0000\u0109\u010a\u0005[\u0000\u0000\u010aH\u0001\u0000\u0000\u0000\u010b"+
		"\u010c\u0005]\u0000\u0000\u010cJ\u0001\u0000\u0000\u0000\u010d\u010e\u0005"+
		";\u0000\u0000\u010eL\u0001\u0000\u0000\u0000\u010f\u0110\u0005.\u0000"+
		"\u0000\u0110N\u0001\u0000\u0000\u0000\u0111\u0112\u0005,\u0000\u0000\u0112"+
		"P\u0001\u0000\u0000\u0000\u0113\u0114\u0005:\u0000\u0000\u0114R\u0001"+
		"\u0000\u0000\u0000\u0115\u0116\u0005\n\u0000\u0000\u0116T\u0001\u0000"+
		"\u0000\u0000\u0117\u0118\u0005=\u0000\u0000\u0118V\u0001\u0000\u0000\u0000"+
		"\u0119\u011a\u0005\"\u0000\u0000\u011aX\u0001\u0000\u0000\u0000\u011b"+
		"\u011c\u0005$\u0000\u0000\u011cZ\u0001\u0000\u0000\u0000\u011d\u011e\u0005"+
		"i\u0000\u0000\u011e\u011f\u0005n\u0000\u0000\u011f\u0120\u0005t\u0000"+
		"\u0000\u0120\\\u0001\u0000\u0000\u0000\u0121\u0122\u0005f\u0000\u0000"+
		"\u0122\u0123\u0005l\u0000\u0000\u0123\u0124\u0005o\u0000\u0000\u0124\u0125"+
		"\u0005a\u0000\u0000\u0125\u0126\u0005t\u0000\u0000\u0126^\u0001\u0000"+
		"\u0000\u0000\u0127\u0128\u0005s\u0000\u0000\u0128\u0129\u0005t\u0000\u0000"+
		"\u0129\u012a\u0005r\u0000\u0000\u012a\u012b\u0005i\u0000\u0000\u012b\u012c"+
		"\u0005n\u0000\u0000\u012c\u012d\u0005g\u0000\u0000\u012d`\u0001\u0000"+
		"\u0000\u0000\u012e\u012f\u0005b\u0000\u0000\u012f\u0130\u0005o\u0000\u0000"+
		"\u0130\u0131\u0005o\u0000\u0000\u0131\u0132\u0005l\u0000\u0000\u0132b"+
		"\u0001\u0000\u0000\u0000\u0133\u0134\u0005t\u0000\u0000\u0134\u0135\u0005"+
		"r\u0000\u0000\u0135\u0136\u0005u\u0000\u0000\u0136\u013d\u0005e\u0000"+
		"\u0000\u0137\u0138\u0005f\u0000\u0000\u0138\u0139\u0005a\u0000\u0000\u0139"+
		"\u013a\u0005l\u0000\u0000\u013a\u013b\u0005s\u0000\u0000\u013b\u013d\u0005"+
		"e\u0000\u0000\u013c\u0133\u0001\u0000\u0000\u0000\u013c\u0137\u0001\u0000"+
		"\u0000\u0000\u013dd\u0001\u0000\u0000\u0000\u013e\u0140\u0007\u0002\u0000"+
		"\u0000\u013f\u013e\u0001\u0000\u0000\u0000\u0140\u0141\u0001\u0000\u0000"+
		"\u0000\u0141\u013f\u0001\u0000\u0000\u0000\u0141\u0142\u0001\u0000\u0000"+
		"\u0000\u0142f\u0001\u0000\u0000\u0000\u0143\u0145\u0007\u0002\u0000\u0000"+
		"\u0144\u0143\u0001\u0000\u0000\u0000\u0145\u0148\u0001\u0000\u0000\u0000"+
		"\u0146\u0144\u0001\u0000\u0000\u0000\u0146\u0147\u0001\u0000\u0000\u0000"+
		"\u0147\u0149\u0001\u0000\u0000\u0000\u0148\u0146\u0001\u0000\u0000\u0000"+
		"\u0149\u014b\u0005.\u0000\u0000\u014a\u014c\u0007\u0002\u0000\u0000\u014b"+
		"\u014a\u0001\u0000\u0000\u0000\u014c\u014d\u0001\u0000\u0000\u0000\u014d"+
		"\u014b\u0001\u0000\u0000\u0000\u014d\u014e\u0001\u0000\u0000\u0000\u014e"+
		"\u015c\u0001\u0000\u0000\u0000\u014f\u0151\u0007\u0002\u0000\u0000\u0150"+
		"\u014f\u0001\u0000\u0000\u0000\u0151\u0152\u0001\u0000\u0000\u0000\u0152"+
		"\u0150\u0001\u0000\u0000\u0000\u0152\u0153\u0001\u0000\u0000\u0000\u0153"+
		"\u0154\u0001\u0000\u0000\u0000\u0154\u0158\u0005.\u0000\u0000\u0155\u0157"+
		"\u0007\u0002\u0000\u0000\u0156\u0155\u0001\u0000\u0000\u0000\u0157\u015a"+
		"\u0001\u0000\u0000\u0000\u0158\u0156\u0001\u0000\u0000\u0000\u0158\u0159"+
		"\u0001\u0000\u0000\u0000\u0159\u015c\u0001\u0000\u0000\u0000\u015a\u0158"+
		"\u0001\u0000\u0000\u0000\u015b\u0146\u0001\u0000\u0000\u0000\u015b\u0150"+
		"\u0001\u0000\u0000\u0000\u015ch\u0001\u0000\u0000\u0000\u015d\u0160\u0003"+
		"k5\u0000\u015e\u0160\t\u0000\u0000\u0000\u015f\u015d\u0001\u0000\u0000"+
		"\u0000\u015f\u015e\u0001\u0000\u0000\u0000\u0160\u0163\u0001\u0000\u0000"+
		"\u0000\u0161\u0162\u0001\u0000\u0000\u0000\u0161\u015f\u0001\u0000\u0000"+
		"\u0000\u0162j\u0001\u0000\u0000\u0000\u0163\u0161\u0001\u0000\u0000\u0000"+
		"\u0164\u0167\u0005\\\u0000\u0000\u0165\u0168\u0007\u0003\u0000\u0000\u0166"+
		"\u0168\u0003m6\u0000\u0167\u0165\u0001\u0000\u0000\u0000\u0167\u0166\u0001"+
		"\u0000\u0000\u0000\u0168l\u0001\u0000\u0000\u0000\u0169\u016a\u0005u\u0000"+
		"\u0000\u016a\u016b\u0003o7\u0000\u016b\u016c\u0003o7\u0000\u016c\u016d"+
		"\u0003o7\u0000\u016d\u016e\u0003o7\u0000\u016en\u0001\u0000\u0000\u0000"+
		"\u016f\u0170\u0007\u0004\u0000\u0000\u0170p\u0001\u0000\u0000\u0000\u0171"+
		"\u0175\u0007\u0005\u0000\u0000\u0172\u0174\u0007\u0006\u0000\u0000\u0173"+
		"\u0172\u0001\u0000\u0000\u0000\u0174\u0177\u0001\u0000\u0000\u0000\u0175"+
		"\u0173\u0001\u0000\u0000\u0000\u0175\u0176\u0001\u0000\u0000\u0000\u0176"+
		"r\u0001\u0000\u0000\u0000\u0177\u0175\u0001\u0000\u0000\u0000\u0010\u0000"+
		"v|\u0084\u008d\u013c\u0141\u0146\u014d\u0152\u0158\u015b\u015f\u0161\u0167"+
		"\u0175\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}