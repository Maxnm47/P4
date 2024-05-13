
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;
using UCM.ast;
using UCM.ErrorListeners;
using UCM.Exceptions;
using UCM.astVisitor;
using System.Runtime.CompilerServices;
using UCM.JSONGeneration;
using UCM.astJunior;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UCM.UCMJuniorGeneration;

namespace UCM.Tests;

[TestClass]
public class EndToEndTest
{
    [TestMethod]
    public void SmallEndtoEndTest()
    {
        string input = @"
            int a = 10;
        ";
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());


        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        // Semantic Analysis TEST SEMANTIC ANALYSIS
        SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
        semanticAnalyser.Visit(ast);

        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        JObject jsonObject = JObject.Parse(jsonString);
        Console.WriteLine(jsonObject.ToString());


    }
    public void ObjectEndToEndTest()
    {
        string input = @"
            object myObj = {
                int x = 10,
                float y = 20.5,
                bool z = true
            };
        ";
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());


        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        // Semantic Analysis TEST SEMANTIC ANALYSIS
        SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
        semanticAnalyser.Visit(ast);

        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        JObject jsonObject = JObject.Parse(jsonString);
        Console.WriteLine(jsonObject.ToString());
    }

    [TestMethod]
    public void TestEndToEndTemplate()
    {
        string input = """
            template A{
                int a;
            }

            A aA = {
                int a = 10; 
            };
        """;
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());


        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        // Semantic Analysis TEST SEMANTIC ANALYSIS
        SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
        semanticAnalyser.Visit(ast);

        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        JObject jsonObject = JObject.Parse(jsonString);
        Console.WriteLine(jsonObject.ToString());
    }

}