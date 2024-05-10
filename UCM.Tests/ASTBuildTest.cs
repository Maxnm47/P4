using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM;
using UCM.ast;
using UCM.ast.numExpr;
using UCM.typechecker;

[TestClass]
public class ASTBuildTest
{
    private AstBuildVisitor visitor;
    private UCMLexer lexer;
    private UCMParser parser;

    [TestInitialize]
    public void Setup()
    {
        visitor = new AstBuildVisitor();  // Initialize visitor
    }

    private AstNode GetNode(string program)
    {
        var stream = CharStreams.fromString(program);
        lexer = new UCMLexer(stream);
        var tokens = new CommonTokenStream(lexer);
        parser = new UCMParser(tokens);
        var parseTree = parser.root();
        return visitor.VisitRoot(parseTree);
    }

    private FieldNode ParseAndVisitField(string input)
    {
        var stream = CharStreams.fromString(input);
        lexer = new UCMLexer(stream);
        var tokens = new CommonTokenStream(lexer);
        parser = new UCMParser(tokens);
        var context = parser.field();  // Ensure there is a 'field' rule in the grammar
        return visitor.VisitField(context) as FieldNode;
    }

    [TestMethod]
    public void VisitRootTest()
    {
        string program1 = "int a = 10;";
        string program2 = "int a = 10; int b = 11;";
        string program3 = """
        template a{ 
            int a; 
        } 
        int b = 10;
        """;

        AssertFieldCount(program1, 1);
        AssertFieldCount(program2, 2);
        AssertCompositeCount(program3);
    }

    [TestMethod]
    public void VisitFieldTest()
    {
        string input1 = "int x = 5;";
        FieldNode fieldNode1 = ParseAndVisitField(input1);

        AssertFieldProperties(fieldNode1, TypeEnum.Int, "x", 5);

        string input = "int x = 1 + 1;";
        FieldNode fieldNode = ParseAndVisitField(input);

        AssertFieldAdditionNode(fieldNode, TypeEnum.Int, "x");
    }

    private void AssertFieldProperties(FieldNode field, TypeEnum expectedType, string expectedId, int expectedExprValue)
    {
        Assert.IsNotNull(field);
        Assert.AreEqual(expectedType, ((TypeAnotationNode)field.Type).type);
        Assert.AreEqual(expectedId, field.Key.Id.value);
        Assert.AreEqual(expectedExprValue, field.Expr.GetChild<IntNode>(0).value);
    }

    private void AssertFieldAdditionNode(FieldNode field, TypeEnum expectedType, string expectedId)
    {
        Assert.IsNotNull(field);
        Assert.AreEqual(expectedType, ((TypeAnotationNode)field.Type).type);
        Assert.AreEqual(expectedId, field.Key.Id.value);
        AdditionNode additionNode = field.Expr.GetChild<AdditionNode>(0);
        Assert.IsNotNull(additionNode);
    }

    private void AssertFieldCount(string program, int expectedCount)
    {
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        Assert.AreEqual(expectedCount, rootNode.Fields.Count);
    }

    private void AssertCompositeCount(string program)
    {
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        Assert.AreEqual(1, rootNode.Fields.Count);
        Assert.AreEqual(1, rootNode.Templates.Count);
    }
}
