
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using UCM.ast;
namespace UCM.astVisitor;

[TestClass]
public class EndToEndTest{
    private SemanticAnalysisVisitor typeChecker;
    private AstBuildVisitor visitor; 
    private UCMLexer lexer;
    private UCMParser parser;

}