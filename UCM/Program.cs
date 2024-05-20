using System;
using System.IO;
using Antlr4.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UCM;
using UCM.ast;
using UCM.astJunior;
using UCM.astVisitor;
using UCM.JSONGeneration;
using UCM.UCMJuniorGeneration;
using UCM.ErrorListeners;
using UCM.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        string rootPath = "balls.ucm";
        ExecuteUcmFile(rootPath);
    }

    static void ExecuteUcmFile(string filePath)
    {
        Console.WriteLine("Executing file: " + filePath);
        string input = File.ReadAllText(filePath);

        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());

        // Create parser
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());
        parser.ErrorHandler = new ErrorStrategy();

        if(parser.NumberOfSyntaxErrors > 0)
        {
            Console.WriteLine("Syntax errors encountered.");
            return;
        }

        // Build AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);
        Console.WriteLine(ast.ToString());

        // Semantic Analysis
        SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
        semanticAnalyser.Visit(ast);

        // Intermediate Generation
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

        Console.WriteLine(intermediateAst.ToString());

        string jsonString = new JSONGenerator().Visit(intermediateAst);
        JObject jsonObject = JObject.Parse(jsonString);
        jsonString = jsonObject.ToString(Formatting.Indented);
        string ucmJuniorString = new UCMJuniorGenerator().Visit(intermediateAst);
        Console.WriteLine(jsonString);
        Console.WriteLine(ucmJuniorString);
    }
}