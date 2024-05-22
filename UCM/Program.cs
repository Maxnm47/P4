﻿using System;
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
using UCM.YAMLGeneration;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the UCM file.");
            return;
        }

        string inputFilePath = args[0];                                         // Get the input file path
        AstNode ast = FrontEnd(inputFilePath);                                  // Reading UCM file and building AST
        JAstNode EvaluatedAst = new IntermediateGenerationVisitor().Visit(ast); // Intepreting AST to UCM-Junior AST


        string? outputFilePath = null;
        // Check if '-json' option is present
        if (Array.IndexOf(args, "-json") != -1)
        {
            outputFilePath = Path.ChangeExtension(inputFilePath, ".json");
            TranspileJSON(EvaluatedAst, outputFilePath);
        }
        else if (Array.IndexOf(args, "-ucm") != -1)
        {
            outputFilePath = Path.ChangeExtension(inputFilePath, ".ucm");
            TranspileUCMJunior(EvaluatedAst, outputFilePath);
        }
        else if (Array.IndexOf(args, "-yaml") != -1)
        {
            outputFilePath = Path.ChangeExtension(inputFilePath, ".yaml");
            TranspileYaml(EvaluatedAst, outputFilePath);
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Transpilation completed successfully: output written to {outputFilePath}");
        Console.ResetColor();

    }

    static AstNode FrontEnd(string inputFilePath)
    {
        string input = File.ReadAllText(inputFilePath);
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

        if (parser.NumberOfSyntaxErrors > 0)
        {
            throw new Exception("Syntax errors encountered.");
        }

        // Build AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        // Semantic Analysis
        TypeChecker typeChecker = new TypeChecker();
        typeChecker.Visit(ast);

        return ast;
    }
    static void TranspileJSON(JAstNode evaluatedAst, string outputFile)
    {
        // Translating the UCM-Junior AST to JSON
        string jsonString = new JSONGenerator().Visit(evaluatedAst);
        JObject jsonObject = JObject.Parse(jsonString);
        jsonString = jsonObject.ToString(Formatting.Indented);

        // Output handling
        File.WriteAllText(outputFile, jsonString);
    }

    static void TranspileUCMJunior(JAstNode evaluatedAst, string outputFile)
    {
        // Translating the UCM-Junior AST to UCM-Junior code
        string ucmJuniorString = new UCMJuniorGenerator().Visit(evaluatedAst);

        // Output handling
        File.WriteAllText(outputFile, ucmJuniorString);
    }

    static void TranspileYaml(JAstNode evaluatedAst, string outputFile)
    {
        // Translating the UCM-Junior AST to UCM-Junior code
        string ucmJuniorString = new YamlGenerator().Visit(evaluatedAst);

        // Output handling
        File.WriteAllText(outputFile, ucmJuniorString);
    }
}

// using System;
// using System.IO;
// using Antlr4.Runtime;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
// using UCM;
// using UCM.ast;
// using UCM.astJunior;
// using UCM.astVisitor;
// using UCM.JSONGeneration;
// using UCM.UCMJuniorGeneration;
// using UCM.ErrorListeners;
// using UCM.Exceptions;

// class Program
// {
//     static void Main(string[] args)
//     {
//         // Read file
//         if (args.Length == 0)
//         {
//             Console.WriteLine("No file specified.");
//             return;
//         }

//         foreach (string filePath in args)
//         {
//             ValidateFilepath(filePath);
//             ExecuteUcmFile2(filePath);
//         }
//     }


//     static void ValidateFilepath(string filePath)
//     {
//         if (!File.Exists(filePath))
//         {
//             throw new Exception("File does not exist: " + filePath);
//         }

//         if (Path.GetExtension(filePath) != ".ucm")
//         {
//             throw new Exception("File is not a .ucm file: " + filePath);
//         }
//     }

//     static void ExecuteUcmFile2(string filePath)
//     {

//     }
//     static void ExecuteUcmFile(string filePath)
//     {
//         Console.WriteLine("Executing file: " + filePath);
//         string input = File.ReadAllText(filePath);

//         ICharStream stream = CharStreams.fromString(input);

//         // Create tokens
//         UCMLexer lexer = new UCMLexer(stream);
//         CommonTokenStream tokens = new CommonTokenStream(lexer);
//         lexer.RemoveErrorListeners();
//         lexer.AddErrorListener(new ErrorListener());

//         // Create parser
//         UCMParser parser = new UCMParser(tokens);
//         UCMParser.RootContext parseTree = parser.root();
//         parser.RemoveErrorListeners();
//         parser.AddErrorListener(new ErrorListener());
//         parser.ErrorHandler = new ErrorStrategy();

//         if (parser.NumberOfSyntaxErrors > 0)
//         {
//             Console.WriteLine("Syntax errors encountered.");
//             return;
//         }

//         // Build AST
//         AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
//         AstNode ast = astBuildVisitor.VisitRoot(parseTree);
//         Console.WriteLine(ast.ToString());

//         // Semantic Analysis
//         SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
//         semanticAnalyser.Visit(ast);

//         // Intermediate Generation
//         JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

//         Console.WriteLine(intermediateAst.ToString());

//         string jsonString = new JSONGenerator().Visit(intermediateAst);
//         JObject jsonObject = JObject.Parse(jsonString);
//         jsonString = jsonObject.ToString(Formatting.Indented);
//         string ucmJuniorString = new UCMJuniorGenerator().Visit(intermediateAst);
//         Console.WriteLine(ucmJuniorString);
//         Console.WriteLine("__________________________________________________________________________");
//         Console.WriteLine(jsonString);
//     }
// }