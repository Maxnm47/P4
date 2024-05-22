using System.IO.Pipes;
using System.Linq.Expressions;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.loopConstruction;
using UCM.ast.numExpr;
using UCM.ast.root;
using UCM.typechecker;
namespace UCM.astVisitor;

[TestClass]
public class TypeCheckerTest
{
    private TypeChecker typeChecker;
    private AstBuildVisitor visitor;
    private UCMLexer lexer;
    private UCMParser parser;

    [TestInitialize]
    public void Setup()
    {
        typeChecker = new TypeChecker();
        visitor = new AstBuildVisitor();
    }

    private AstNode GetNode(string program)
    {
        var stream = CharStreams.fromString(program);
        lexer = new UCMLexer(stream);
        var tokens = new CommonTokenStream(lexer);
        parser = new UCMParser(tokens);
        var parseTree = parser.root();
        return visitor.VisitRoot(parseTree); // Now visitor is initialized
    }

    private AstNode GetTypeCheckedAst(string program)
    {
        AstNode rootNode = GetNode(program);
        return typeChecker.VisitRoot(rootNode as RootNode);
    }

    [TestMethod]
    public void CorrectlyTypedInt()
    {
        string program = "int x = 5;";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        IntNode intnode = root.Fields[0].Expr.GetChild<IntNode>(0);
        Assert.AreEqual(5, intnode.value);
        Assert.AreEqual(TypeEnum.Int, intnode.typeInfo.type);
    }


    [TestMethod]
    public void CorrectlyTypedFloat()
    {
        string program = "float x = 5.0;";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        FloatNode floatnode = root.Fields[0].Expr.GetChild<FloatNode>(0);
        Assert.AreEqual(5.0, floatnode.value);
        Assert.AreEqual(TypeEnum.Float, floatnode.typeInfo.type);
    }

    [TestMethod]
    public void CorrectlyTypedAndValuedFloatArray()
    {
        string program = "float[] x = [1.0, 2.0, 3.0];";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        ArrayNode arrayNode = root.Fields[0].Expr.GetChild<ArrayNode>(0);
        Assert.AreEqual(1.0, arrayNode.Elements[0].GetChild<FloatNode>(0).value);
        Assert.AreEqual(2.0, arrayNode.Elements[1].GetChild<FloatNode>(0).value);
        Assert.AreEqual(3.0, arrayNode.Elements[2].GetChild<FloatNode>(0).value);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[0].typeInfo.type);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[1].typeInfo.type);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[2].typeInfo.type);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[0].GetChild<FloatNode>(0).typeInfo.type);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[1].GetChild<FloatNode>(0).typeInfo.type);
        Assert.AreEqual(TypeEnum.Float, arrayNode.Elements[2].GetChild<FloatNode>(0).typeInfo.type);

    }

    [TestMethod]
    public void CorrectlyTypedString()
    {
        string program = "string x = \"Hello\";";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        StringNode stringnode = root.Fields[0].Expr.GetChild<StringNode>(0);
        Assert.AreEqual("Hello", stringnode.value);
        Assert.AreEqual(TypeEnum.String, stringnode.typeInfo.type);
    }

    [TestMethod]
    public void CorrectlyTypedBool()
    {
        string program = "bool x = true;";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        BoolNode boolnode = root.Fields[0].Expr.GetChild<BoolNode>(0);
        Assert.AreEqual(true, boolnode.value);
        Assert.AreEqual(TypeEnum.Bool, boolnode.typeInfo.type);
    }

    [TestMethod]
    public void TestCorrectTypes()
    {
        string program = "int x = 5;";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        IntNode intnode = root.Fields[0].Expr.GetChild<IntNode>(0);
        Assert.AreEqual(TypeEnum.Int, intnode.typeInfo.type);
        Assert.IsInstanceOfType(root.Fields[0].Expr.GetChild<AstNode>(0), typeof(IntNode));
        Assert.AreEqual(5, root.Fields[0].Expr.GetChild<IntNode>(0).value);
    }

    [TestMethod]
    public void TestIncorrectTypes()
    {
        string program = "int x = \"hello!\";";
        try
        {
            RootNode root = (RootNode)GetTypeCheckedAst(program);
            var field = root.Fields[0].Expr.GetChild<IntNode>(0);
            IntNode intnode = root.Fields[0].Expr.GetChild<IntNode>(0);
            Assert.AreEqual(TypeEnum.Int, intnode.typeInfo.type);
            Assert.AreEqual(5, field.value);
        }
        catch (Exception ex)
        {
            Assert.AreEqual("Semantic analysis failed", ex.Message);
        }
    }

    [TestMethod]
    public void TestCorrectTypesInObject()
    {
        string program = "object a = {int x = 5; int y = 10;};";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        var objectNode = root.Fields[0].Expr.GetChild<ObjectNode>(0);
        Assert.AreEqual(5, objectNode.Fields[0].Expr.GetChild<IntNode>(0).value);
        Assert.AreEqual(10, objectNode.Fields[1].Expr.GetChild<IntNode>(0).value);

        Assert.AreEqual(TypeEnum.Int, objectNode.Fields[0].Expr.GetChild<IntNode>(0).typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, objectNode.Fields[1].Expr.GetChild<IntNode>(0).typeInfo.type);
    }

    [TestMethod]
    public void testIncorrectTypesInObject()
    {
        string program = "object a = {int x = 5; int y = 10.0;};";
        try
        {
            RootNode root = (RootNode)GetTypeCheckedAst(program);
            var objectNode = root.Fields[0].Expr.GetChild<ObjectNode>(0);
            Assert.AreEqual(5, objectNode.Fields[0].Expr.GetChild<IntNode>(0).value);
            Assert.AreEqual(10, objectNode.Fields[1].Expr.GetChild<IntNode>(0).value);

            Assert.AreEqual(TypeEnum.Int, objectNode.Fields[0].Expr.GetChild<IntNode>(0).typeInfo.type);
            Assert.AreEqual(TypeEnum.Int, objectNode.Fields[1].Expr.GetChild<IntNode>(0).typeInfo.type);
        }
        catch (Exception ex)
        {
            // EXTREMELY HACKY
            Assert.AreEqual("Semantic analysis failed", ex.Message);
        }
    }

    [TestMethod]
    public void TestCorrectTypesInArray()
    {
        string program = "int[] a = [1,2,3];";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        var arrayNode = root.Fields[0].Expr.GetChild<ArrayNode>(0);
        Assert.AreEqual(1, arrayNode.Elements[0].GetChild<IntNode>(0).value);
        Assert.AreEqual(2, arrayNode.Elements[1].GetChild<IntNode>(0).value);
        Assert.AreEqual(3, arrayNode.Elements[2].GetChild<IntNode>(0).value);

        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[0].typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[1].typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[2].typeInfo.type);
    }

    [TestMethod]
    public void TestIncorrectArrayTypes()
    {
        string program = "int[] a = [1,2.0,3];";
        try
        {
            RootNode root = (RootNode)GetTypeCheckedAst(program);
            var arrayNode = root.Fields[0].Expr.GetChild<ArrayNode>(0);
            Assert.AreEqual(1, arrayNode.Elements[0].GetChild<IntNode>(0).value);
            Assert.AreEqual(2, arrayNode.Elements[1].GetChild<IntNode>(0).value);
            Assert.AreEqual(3, arrayNode.Elements[2].GetChild<IntNode>(0).value);

            Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[0].typeInfo.type);
            Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[1].typeInfo.type);
            Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[2].typeInfo.type);
        }
        catch (Exception ex)
        {
            // EXTREMELY HACKY
            Assert.AreEqual("Semantic analysis failed", ex.Message);
        }
    }

    [TestMethod]
    public void TestCorrectTypesInLoop()
    {
        string program = "object a = {for(int i in [1,2,3]){int x = i;}};";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        var objectNode = root.Fields[0].Expr.GetChild<ObjectNode>(0);
        var loopNode = objectNode.Loops[0];
        var arrayNode = loopNode.Array.GetChild<ArrayNode>(0);
        Assert.AreEqual(1, arrayNode.Elements[0].GetChild<IntNode>(0).value);
        Assert.AreEqual(2, arrayNode.Elements[1].GetChild<IntNode>(0).value);
        Assert.AreEqual(3, arrayNode.Elements[2].GetChild<IntNode>(0).value);

        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[0].typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[1].typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[2].typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[0].GetChild<IntNode>(0).typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[1].GetChild<IntNode>(0).typeInfo.type);
        Assert.AreEqual(TypeEnum.Int, arrayNode.Elements[2].GetChild<IntNode>(0).typeInfo.type);
    }

    [TestMethod]
    public void TestTemplateObject()
    {
        string program = """
        template A{
                int b;
            }
        A a = {
            b = 10;
        };
        """;

        RootNode root = (RootNode)GetTypeCheckedAst(program);
        var fieldNode = root.Fields[0];
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.AreEqual("A", fieldNode.Type.value);
        var templateObject = fieldNode.Expr.GetChild<ObjectNode>(0);
        var field = templateObject.Fields[0];
        Assert.AreEqual("b", field.Key.Id.value);
        Assert.AreEqual(10, field.Expr.GetChild<IntNode>(0).value);

        Assert.AreEqual(TypeEnum.Int, field.Expr.GetChild<IntNode>(0).typeInfo.type);
    }

    [TestMethod]
    public void AnyarrayTest()
    {
        string program = "[]a = [10, 1.0, \"1\", true];";
        RootNode root = (RootNode)GetTypeCheckedAst(program);
        var arrayNode = root.Fields[0].Expr.GetChild<ArrayNode>(0);
        Assert.AreEqual(10, arrayNode.Elements[0].GetChild<IntNode>(0).value);
        Assert.AreEqual(1.0, arrayNode.Elements[1].GetChild<FloatNode>(0).value);
        Assert.AreEqual("1", arrayNode.Elements[2].GetChild<StringNode>(0).value);
        Assert.AreEqual(true, arrayNode.Elements[3].GetChild<BoolNode>(0).value);
    }

}
