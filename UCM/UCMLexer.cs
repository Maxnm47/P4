//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from UCM.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class UCMLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		WS=1, COMMENT=2, IF=3, ELSE=4, WHILE=5, FOR=6, RETURN=7, TEMPLATE_KEYWORD=8, 
		IN=9, HIDDEN_=10, OBJECT_KEYWORD=11, FUNCTIONS_KEYWORD=12, EXTENDS_KEYWORD=13, 
		THIS_KEYWORD=14, NULL=15, MULT=16, DIV=17, PLUS=18, MINUS=19, MOD=20, 
		AND=21, OR=22, EQ=23, NEQ=24, GT=25, LT=26, GTE=27, LTE=28, NOT=29, QUESTION=30, 
		LPAREN=31, RPAREN=32, LCURLY=33, RCURLY=34, LBRACKET=35, RBRACKET=36, 
		SEMI=37, DOT=38, COMMA=39, COLON=40, NEWLINE=41, ASSIGN=42, QUOTE=43, 
		DOLLAR=44, INT_T=45, FLOAT_T=46, STRING_T=47, BOOL_T=48, BOOL=49, INT=50, 
		FLOAT=51, ESCAPE_SEQUENCE=52, ID=53;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"WS", "COMMENT", "LINE_COMMENT", "BLOCK_COMMENT", "IF", "ELSE", "WHILE", 
		"FOR", "RETURN", "TEMPLATE_KEYWORD", "IN", "HIDDEN_", "OBJECT_KEYWORD", 
		"FUNCTIONS_KEYWORD", "EXTENDS_KEYWORD", "THIS_KEYWORD", "NULL", "MULT", 
		"DIV", "PLUS", "MINUS", "MOD", "AND", "OR", "EQ", "NEQ", "GT", "LT", "GTE", 
		"LTE", "NOT", "QUESTION", "LPAREN", "RPAREN", "LCURLY", "RCURLY", "LBRACKET", 
		"RBRACKET", "SEMI", "DOT", "COMMA", "COLON", "NEWLINE", "ASSIGN", "QUOTE", 
		"DOLLAR", "INT_T", "FLOAT_T", "STRING_T", "BOOL_T", "BOOL", "INT", "FLOAT", 
		"STRING_BODY", "ESCAPE_SEQUENCE", "UNICODE_ESCAPE", "HEX_DIGIT", "ID"
	};


	public UCMLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public UCMLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, "'if'", "'else'", "'while'", "'for'", "'return'", "'template'", 
		"'in'", "'hidden'", "'object'", "'methods'", "'extends'", "'this'", "'null'", 
		"'*'", "'/'", "'+'", "'-'", "'%'", "'&&'", "'||'", "'=='", "'!='", "'>'", 
		"'<'", "'>='", "'<='", "'!'", "'?'", "'('", "')'", "'{'", "'}'", "'['", 
		"']'", "';'", "'.'", "','", "':'", "'\\n'", "'='", "'\"'", "'$'", "'int'", 
		"'float'", "'string'", "'bool'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "WS", "COMMENT", "IF", "ELSE", "WHILE", "FOR", "RETURN", "TEMPLATE_KEYWORD", 
		"IN", "HIDDEN_", "OBJECT_KEYWORD", "FUNCTIONS_KEYWORD", "EXTENDS_KEYWORD", 
		"THIS_KEYWORD", "NULL", "MULT", "DIV", "PLUS", "MINUS", "MOD", "AND", 
		"OR", "EQ", "NEQ", "GT", "LT", "GTE", "LTE", "NOT", "QUESTION", "LPAREN", 
		"RPAREN", "LCURLY", "RCURLY", "LBRACKET", "RBRACKET", "SEMI", "DOT", "COMMA", 
		"COLON", "NEWLINE", "ASSIGN", "QUOTE", "DOLLAR", "INT_T", "FLOAT_T", "STRING_T", 
		"BOOL_T", "BOOL", "INT", "FLOAT", "ESCAPE_SEQUENCE", "ID"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "UCM.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static UCMLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,53,381,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,2,46,7,46,2,47,7,47,2,48,7,48,2,49,
		7,49,2,50,7,50,2,51,7,51,2,52,7,52,2,53,7,53,2,54,7,54,2,55,7,55,2,56,
		7,56,2,57,7,57,1,0,4,0,119,8,0,11,0,12,0,120,1,0,1,0,1,1,1,1,3,1,127,8,
		1,1,1,1,1,1,2,1,2,5,2,133,8,2,10,2,12,2,136,9,2,1,3,1,3,1,3,1,3,5,3,142,
		8,3,10,3,12,3,145,9,3,1,3,1,3,1,3,1,4,1,4,1,4,1,5,1,5,1,5,1,5,1,5,1,6,
		1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,
		9,1,9,1,9,1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,
		1,11,1,11,1,12,1,12,1,12,1,12,1,12,1,12,1,12,1,13,1,13,1,13,1,13,1,13,
		1,13,1,13,1,13,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,14,1,15,1,15,1,15,
		1,15,1,15,1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,18,1,18,1,19,1,19,1,20,
		1,20,1,21,1,21,1,22,1,22,1,22,1,23,1,23,1,23,1,24,1,24,1,24,1,25,1,25,
		1,25,1,26,1,26,1,27,1,27,1,28,1,28,1,28,1,29,1,29,1,29,1,30,1,30,1,31,
		1,31,1,32,1,32,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,36,1,37,1,37,1,38,
		1,38,1,39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,43,1,43,1,44,1,44,1,45,
		1,45,1,46,1,46,1,46,1,46,1,47,1,47,1,47,1,47,1,47,1,47,1,48,1,48,1,48,
		1,48,1,48,1,48,1,48,1,49,1,49,1,49,1,49,1,49,1,50,1,50,1,50,1,50,1,50,
		1,50,1,50,1,50,1,50,3,50,322,8,50,1,51,4,51,325,8,51,11,51,12,51,326,1,
		52,5,52,330,8,52,10,52,12,52,333,9,52,1,52,1,52,4,52,337,8,52,11,52,12,
		52,338,1,52,4,52,342,8,52,11,52,12,52,343,1,52,1,52,5,52,348,8,52,10,52,
		12,52,351,9,52,3,52,353,8,52,1,53,1,53,5,53,357,8,53,10,53,12,53,360,9,
		53,1,54,1,54,1,54,3,54,365,8,54,1,55,1,55,1,55,1,55,1,55,1,55,1,56,1,56,
		1,57,1,57,5,57,377,8,57,10,57,12,57,380,9,57,2,143,358,0,58,1,1,3,2,5,
		0,7,0,9,3,11,4,13,5,15,6,17,7,19,8,21,9,23,10,25,11,27,12,29,13,31,14,
		33,15,35,16,37,17,39,18,41,19,43,20,45,21,47,22,49,23,51,24,53,25,55,26,
		57,27,59,28,61,29,63,30,65,31,67,32,69,33,71,34,73,35,75,36,77,37,79,38,
		81,39,83,40,85,41,87,42,89,43,91,44,93,45,95,46,97,47,99,48,101,49,103,
		50,105,51,107,0,109,52,111,0,113,0,115,53,1,0,7,3,0,9,10,13,13,32,32,2,
		0,10,10,13,13,1,0,48,57,3,0,34,34,39,39,92,92,3,0,48,57,65,70,97,102,3,
		0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,390,0,1,1,0,0,0,0,3,
		1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,
		0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,
		1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,
		0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,
		1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,
		0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,
		1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,
		0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,0,93,1,0,0,0,0,95,
		1,0,0,0,0,97,1,0,0,0,0,99,1,0,0,0,0,101,1,0,0,0,0,103,1,0,0,0,0,105,1,
		0,0,0,0,109,1,0,0,0,0,115,1,0,0,0,1,118,1,0,0,0,3,126,1,0,0,0,5,130,1,
		0,0,0,7,137,1,0,0,0,9,149,1,0,0,0,11,152,1,0,0,0,13,157,1,0,0,0,15,163,
		1,0,0,0,17,167,1,0,0,0,19,174,1,0,0,0,21,183,1,0,0,0,23,186,1,0,0,0,25,
		193,1,0,0,0,27,200,1,0,0,0,29,208,1,0,0,0,31,216,1,0,0,0,33,221,1,0,0,
		0,35,226,1,0,0,0,37,228,1,0,0,0,39,230,1,0,0,0,41,232,1,0,0,0,43,234,1,
		0,0,0,45,236,1,0,0,0,47,239,1,0,0,0,49,242,1,0,0,0,51,245,1,0,0,0,53,248,
		1,0,0,0,55,250,1,0,0,0,57,252,1,0,0,0,59,255,1,0,0,0,61,258,1,0,0,0,63,
		260,1,0,0,0,65,262,1,0,0,0,67,264,1,0,0,0,69,266,1,0,0,0,71,268,1,0,0,
		0,73,270,1,0,0,0,75,272,1,0,0,0,77,274,1,0,0,0,79,276,1,0,0,0,81,278,1,
		0,0,0,83,280,1,0,0,0,85,282,1,0,0,0,87,284,1,0,0,0,89,286,1,0,0,0,91,288,
		1,0,0,0,93,290,1,0,0,0,95,294,1,0,0,0,97,300,1,0,0,0,99,307,1,0,0,0,101,
		321,1,0,0,0,103,324,1,0,0,0,105,352,1,0,0,0,107,358,1,0,0,0,109,361,1,
		0,0,0,111,366,1,0,0,0,113,372,1,0,0,0,115,374,1,0,0,0,117,119,7,0,0,0,
		118,117,1,0,0,0,119,120,1,0,0,0,120,118,1,0,0,0,120,121,1,0,0,0,121,122,
		1,0,0,0,122,123,6,0,0,0,123,2,1,0,0,0,124,127,3,7,3,0,125,127,3,5,2,0,
		126,124,1,0,0,0,126,125,1,0,0,0,127,128,1,0,0,0,128,129,6,1,0,0,129,4,
		1,0,0,0,130,134,5,35,0,0,131,133,8,1,0,0,132,131,1,0,0,0,133,136,1,0,0,
		0,134,132,1,0,0,0,134,135,1,0,0,0,135,6,1,0,0,0,136,134,1,0,0,0,137,138,
		5,35,0,0,138,139,5,35,0,0,139,143,1,0,0,0,140,142,9,0,0,0,141,140,1,0,
		0,0,142,145,1,0,0,0,143,144,1,0,0,0,143,141,1,0,0,0,144,146,1,0,0,0,145,
		143,1,0,0,0,146,147,5,35,0,0,147,148,5,35,0,0,148,8,1,0,0,0,149,150,5,
		105,0,0,150,151,5,102,0,0,151,10,1,0,0,0,152,153,5,101,0,0,153,154,5,108,
		0,0,154,155,5,115,0,0,155,156,5,101,0,0,156,12,1,0,0,0,157,158,5,119,0,
		0,158,159,5,104,0,0,159,160,5,105,0,0,160,161,5,108,0,0,161,162,5,101,
		0,0,162,14,1,0,0,0,163,164,5,102,0,0,164,165,5,111,0,0,165,166,5,114,0,
		0,166,16,1,0,0,0,167,168,5,114,0,0,168,169,5,101,0,0,169,170,5,116,0,0,
		170,171,5,117,0,0,171,172,5,114,0,0,172,173,5,110,0,0,173,18,1,0,0,0,174,
		175,5,116,0,0,175,176,5,101,0,0,176,177,5,109,0,0,177,178,5,112,0,0,178,
		179,5,108,0,0,179,180,5,97,0,0,180,181,5,116,0,0,181,182,5,101,0,0,182,
		20,1,0,0,0,183,184,5,105,0,0,184,185,5,110,0,0,185,22,1,0,0,0,186,187,
		5,104,0,0,187,188,5,105,0,0,188,189,5,100,0,0,189,190,5,100,0,0,190,191,
		5,101,0,0,191,192,5,110,0,0,192,24,1,0,0,0,193,194,5,111,0,0,194,195,5,
		98,0,0,195,196,5,106,0,0,196,197,5,101,0,0,197,198,5,99,0,0,198,199,5,
		116,0,0,199,26,1,0,0,0,200,201,5,109,0,0,201,202,5,101,0,0,202,203,5,116,
		0,0,203,204,5,104,0,0,204,205,5,111,0,0,205,206,5,100,0,0,206,207,5,115,
		0,0,207,28,1,0,0,0,208,209,5,101,0,0,209,210,5,120,0,0,210,211,5,116,0,
		0,211,212,5,101,0,0,212,213,5,110,0,0,213,214,5,100,0,0,214,215,5,115,
		0,0,215,30,1,0,0,0,216,217,5,116,0,0,217,218,5,104,0,0,218,219,5,105,0,
		0,219,220,5,115,0,0,220,32,1,0,0,0,221,222,5,110,0,0,222,223,5,117,0,0,
		223,224,5,108,0,0,224,225,5,108,0,0,225,34,1,0,0,0,226,227,5,42,0,0,227,
		36,1,0,0,0,228,229,5,47,0,0,229,38,1,0,0,0,230,231,5,43,0,0,231,40,1,0,
		0,0,232,233,5,45,0,0,233,42,1,0,0,0,234,235,5,37,0,0,235,44,1,0,0,0,236,
		237,5,38,0,0,237,238,5,38,0,0,238,46,1,0,0,0,239,240,5,124,0,0,240,241,
		5,124,0,0,241,48,1,0,0,0,242,243,5,61,0,0,243,244,5,61,0,0,244,50,1,0,
		0,0,245,246,5,33,0,0,246,247,5,61,0,0,247,52,1,0,0,0,248,249,5,62,0,0,
		249,54,1,0,0,0,250,251,5,60,0,0,251,56,1,0,0,0,252,253,5,62,0,0,253,254,
		5,61,0,0,254,58,1,0,0,0,255,256,5,60,0,0,256,257,5,61,0,0,257,60,1,0,0,
		0,258,259,5,33,0,0,259,62,1,0,0,0,260,261,5,63,0,0,261,64,1,0,0,0,262,
		263,5,40,0,0,263,66,1,0,0,0,264,265,5,41,0,0,265,68,1,0,0,0,266,267,5,
		123,0,0,267,70,1,0,0,0,268,269,5,125,0,0,269,72,1,0,0,0,270,271,5,91,0,
		0,271,74,1,0,0,0,272,273,5,93,0,0,273,76,1,0,0,0,274,275,5,59,0,0,275,
		78,1,0,0,0,276,277,5,46,0,0,277,80,1,0,0,0,278,279,5,44,0,0,279,82,1,0,
		0,0,280,281,5,58,0,0,281,84,1,0,0,0,282,283,5,10,0,0,283,86,1,0,0,0,284,
		285,5,61,0,0,285,88,1,0,0,0,286,287,5,34,0,0,287,90,1,0,0,0,288,289,5,
		36,0,0,289,92,1,0,0,0,290,291,5,105,0,0,291,292,5,110,0,0,292,293,5,116,
		0,0,293,94,1,0,0,0,294,295,5,102,0,0,295,296,5,108,0,0,296,297,5,111,0,
		0,297,298,5,97,0,0,298,299,5,116,0,0,299,96,1,0,0,0,300,301,5,115,0,0,
		301,302,5,116,0,0,302,303,5,114,0,0,303,304,5,105,0,0,304,305,5,110,0,
		0,305,306,5,103,0,0,306,98,1,0,0,0,307,308,5,98,0,0,308,309,5,111,0,0,
		309,310,5,111,0,0,310,311,5,108,0,0,311,100,1,0,0,0,312,313,5,116,0,0,
		313,314,5,114,0,0,314,315,5,117,0,0,315,322,5,101,0,0,316,317,5,102,0,
		0,317,318,5,97,0,0,318,319,5,108,0,0,319,320,5,115,0,0,320,322,5,101,0,
		0,321,312,1,0,0,0,321,316,1,0,0,0,322,102,1,0,0,0,323,325,7,2,0,0,324,
		323,1,0,0,0,325,326,1,0,0,0,326,324,1,0,0,0,326,327,1,0,0,0,327,104,1,
		0,0,0,328,330,7,2,0,0,329,328,1,0,0,0,330,333,1,0,0,0,331,329,1,0,0,0,
		331,332,1,0,0,0,332,334,1,0,0,0,333,331,1,0,0,0,334,336,5,46,0,0,335,337,
		7,2,0,0,336,335,1,0,0,0,337,338,1,0,0,0,338,336,1,0,0,0,338,339,1,0,0,
		0,339,353,1,0,0,0,340,342,7,2,0,0,341,340,1,0,0,0,342,343,1,0,0,0,343,
		341,1,0,0,0,343,344,1,0,0,0,344,345,1,0,0,0,345,349,5,46,0,0,346,348,7,
		2,0,0,347,346,1,0,0,0,348,351,1,0,0,0,349,347,1,0,0,0,349,350,1,0,0,0,
		350,353,1,0,0,0,351,349,1,0,0,0,352,331,1,0,0,0,352,341,1,0,0,0,353,106,
		1,0,0,0,354,357,3,109,54,0,355,357,9,0,0,0,356,354,1,0,0,0,356,355,1,0,
		0,0,357,360,1,0,0,0,358,359,1,0,0,0,358,356,1,0,0,0,359,108,1,0,0,0,360,
		358,1,0,0,0,361,364,5,92,0,0,362,365,7,3,0,0,363,365,3,111,55,0,364,362,
		1,0,0,0,364,363,1,0,0,0,365,110,1,0,0,0,366,367,5,117,0,0,367,368,3,113,
		56,0,368,369,3,113,56,0,369,370,3,113,56,0,370,371,3,113,56,0,371,112,
		1,0,0,0,372,373,7,4,0,0,373,114,1,0,0,0,374,378,7,5,0,0,375,377,7,6,0,
		0,376,375,1,0,0,0,377,380,1,0,0,0,378,376,1,0,0,0,378,379,1,0,0,0,379,
		116,1,0,0,0,380,378,1,0,0,0,16,0,120,126,134,143,321,326,331,338,343,349,
		352,356,358,364,378,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
