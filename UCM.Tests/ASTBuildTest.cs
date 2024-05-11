using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM;
using UCM.ast;
using UCM.ast.numExpr;
using UCM.ast.root;
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
    //template tests
    [TestMethod]
    public void VisitTemplateTest()
    {
        string program = "template A{ int b; }";
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var templateNode = rootNode.Templates[0];
        Assert.AreEqual("A", templateNode.Id.value);
        Assert.AreEqual(1, templateNode.Fields.Count);
    }

    [TestMethod]
    public void VisitNestedTemplateTest()
    {
        string program = """
        template B{
            int c;
        }

        template A{ 
            B b;
        }
        """;
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var templateNode = rootNode.Templates[1];
        Assert.AreEqual("A", templateNode.Id.value);
        Assert.AreEqual(1, templateNode.Fields.Count);
        var fieldNode = templateNode.Fields[0];
        Assert.AreEqual("b", fieldNode.Id.value);
        Assert.AreEqual("B", fieldNode.Type.value);
    }

    //primitives
    [TestMethod]
    public void VisitIntTest()
    {
        string program = "int a = 10;";
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var fieldNode = rootNode.Fields[0];
        Assert.AreEqual(TypeEnum.Int, ((TypeAnotationNode)fieldNode.Type).type);
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.AreEqual(10, fieldNode.Expr.GetChild<IntNode>(0).value);
    }

    [TestMethod]
    public void VisitTemplateDefintionTest()
    {
        string program = """
        template A{
                int b;
            }
        A a = {
            b = 10;
        };
        """;
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var fieldNode = rootNode.Fields[0];
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.AreEqual("A", fieldNode.Type.value);
        var templateObject = fieldNode.Expr.GetChild<ObjectNode>(0);
        var field = templateObject.Fields[0];
        Assert.AreEqual("b", field.Key.Id.value);
        Assert.AreEqual(10, field.Expr.GetChild<IntNode>(0).value);
        

    }

    [TestMethod]
    public void VisitFloatTest()
    {
        string program = "float a = 10.0;";
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var fieldNode = rootNode.Fields[0];
        Assert.AreEqual(TypeEnum.Float, ((TypeAnotationNode)fieldNode.Type).type);
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.AreEqual(10.0, fieldNode.Expr.GetChild<FloatNode>(0).value);
    }

    [TestMethod]
    public void VisitStringTest()
    {
        string program = "string a = \"Hello\";";
        var node = GetNode(program);
        var rootNode = (RootNode)node;
        var fieldNode = rootNode.Fields[0];
        Assert.AreEqual(TypeEnum.String, ((TypeAnotationNode)fieldNode.Type).type);
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.AreEqual("Hello", fieldNode.Expr.GetChild<StringNode>(0).value);
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
