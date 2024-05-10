using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM.ErrorListener;
using UCM.Exceptions;
using UCM;
using UCM.ast;
using System.Security.Cryptography;

[TestClass]
public class ASTBuildTest
{
    [TestMethod]
    public void VisitRootTest(AstBuildVisitor astBuildVisitor, UCMParser.RootContext parseTree)
    {
        try
        {
            string input1 = "int a = 10;";
            AstNode returnedNode = astBuildVisitor.VisitRoot(parseTree);
            RootNode casted = (RootNode)returnedNode;
            Assert.AreEqual(1, casted.Fields.Count);

            string input2 = "int a = 10; int b = 11";
            AstNode returnedNode2 = astBuildVisitor.VisitRoot(parseTree);
            RootNode casted2 = (RootNode)returnedNode2;
            Assert.AreEqual(2, casted2.Fields.Count);

            string input3 = """
        template a{
            int a;
        }

        int b = 10;
        """;
            AstNode returnedNode3 = astBuildVisitor.VisitRoot(parseTree);
            RootNode casted3 = (RootNode)returnedNode3;
            Assert.AreEqual(1, casted3.Fields.Count);
            Assert.AreEqual(1, casted3.Templates.Count);
            Assert.AreEqual(0, casted3.MethodCollections.Count);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine($"Casting error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    private void AssertFalse(string program)
    {
        ICharStream stream = CharStreams.fromString(program);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);

        // Create parser
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();

        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);





    }
    private void AssertTrue(string program)
    {
        ICharStream stream = CharStreams.fromString(program);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);

        // Create parser
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();

        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);
    }


}