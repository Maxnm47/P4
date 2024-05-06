using System;
using System.IO;
using Antlr4.Runtime;
using UCM;
using UCM.ast;
using UCM.astVisitor;

class Program
{
    static void Main(string[] args)
    {
        //testing
        // string rootPath = args.Length > 0 ? args[0] : "UCM_TestFiles";
        // ExecuteUcmFiles(rootPath);

        string rootPath = "balls.ucm";
        ExecuteUcmFile(rootPath);
    }

    static void ExecuteUcmFiles(string directoryPath)
    {
        // Recursively handle all subdirectories
        foreach (var subdirectory in Directory.GetDirectories(directoryPath))
        {
            ExecuteUcmFiles(subdirectory);
        }

        // Execute each .ucm file in the current directory
        foreach (var filePath in Directory.GetFiles(directoryPath, "*.ucm"))
        {
            ExecuteUcmFile(filePath);
        }
    }

    static void ExecuteUcmFile(string filePath)
    {
        Console.WriteLine("Executing file: " + filePath);
        string input = File.ReadAllText(filePath);

        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);

        // Create parser
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root(); 

        // Build AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        // Semantic Analysis
        SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
        semanticAnalyser.Visit(ast);

    }
}
