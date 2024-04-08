using Antlr4.Runtime;
using UCM;

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

        UCMParser.RootContext tree = parser.root(); //create tree

        CustomUCMVisitor visitor = new CustomUCMVisitor();

        visitor.VisitRoot (tree);

        Console.WriteLine(tree.ToStringTree(parser));

        
    }
}
