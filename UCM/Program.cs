using Antlr4.Runtime;
using UCM;
using UCM.ast;
using UCM.astVisitor;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "balls.ucm";
        string input = File.ReadAllText(filePath);

        ICharStream stream = CharStreams.fromString(input);

        //create tokens
        UCMLexer lexer = new UCMLexer(stream);

        CommonTokenStream tokens = new CommonTokenStream(lexer); //makes tokens

        // Create parser
        UCMParser parser = new UCMParser(tokens);

        UCMParser.RootContext parseTree = parser.root(); //create tree

        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        AstTestVisitor astTestVisitor = new AstTestVisitor();
        astTestVisitor.Visit(ast);

        // Console.WriteLine("AST done");
        // Console.WriteLine(ast.ToString());
    }
}

