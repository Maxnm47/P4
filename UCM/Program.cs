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
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the UCM file.");
            return;
        }

        string inputFile = args[0];
        string outputFile = null;

        // Check if '-json' option is present
        if (Array.IndexOf(args, "-json") != -1)
        {
            outputFile = Path.ChangeExtension(inputFile, ".json");
        }

        ExecuteUcmFile(inputFile, outputFile);
    }

    static void ExecuteUcmFile(string filePath, string outputFile)
    {
        Console.WriteLine("Executing file: " + filePath);
        try
        {
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

            if (parser.NumberOfSyntaxErrors > 0)
            {
                Console.WriteLine("Syntax errors encountered.");
                return;
            }

            // Build AST
            AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
            AstNode ast = astBuildVisitor.VisitRoot(parseTree);

            // Semantic Analysis
            SemanticAnalysisVisitor semanticAnalyser = new SemanticAnalysisVisitor();
            semanticAnalyser.Visit(ast);

            // Intermediate Generation
            JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);

            string jsonString = new JSONGenerator().Visit(intermediateAst);
            JObject jsonObject = JObject.Parse(jsonString);
            jsonString = jsonObject.ToString(Formatting.Indented);

            // Output handling
            if (!string.IsNullOrEmpty(outputFile))
            {
                File.WriteAllText(outputFile, jsonString);
                Console.WriteLine($"JSON output written to {outputFile}");
            }
            else
            {
                Console.WriteLine(jsonString);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to process the file:");
            Console.WriteLine(ex.Message);
        }
    }
}
