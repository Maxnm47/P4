
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime;
using UCM.ast;
using UCM.ErrorListeners;
using UCM.Exceptions;
using UCM.astVisitor;
using System.Runtime.CompilerServices;
using UCM.JSONGeneration;
using UCM.astJunior;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UCM.UCMJuniorGeneration;
using UCM.astVisitor;
using UCM.typeEnum;
namespace UCM.Tests;

[TestClass]
public class EndToEndTest
{
    [TestMethod]
    public void SmallEndtoEndTest()
    {
        //this test is to ensure the value is 10 and the type is int throughout the entire process.
        string input = @"
            int a = 10;
        ";
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());

        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());
        //ensure each parser rule is correct
        //ensure a is the id
        UCMParser.FieldContext parserField = parseTree.field(0);
        UCMParser.FieldIdContext fieldId = parserField.fieldId();
        UCMParser.IdContext id = fieldId.id();
        Assert.AreEqual("a", id.GetText());

        //ensure the type is int
        UCMParser.TypeContext type = parserField.type();
        UCMParser.PrimitiveTypeContext primitiveType = type.primitiveType();
        Assert.IsNotNull(primitiveType.INT_T());
        Assert.IsNull(primitiveType.FLOAT_T());

        //ensure value is 10.
        UCMParser.ExprContext expr = parserField.expr();
        UCMParser.ValueContext value = expr.value();
        UCMParser.NumContext num = value.num();
        Assert.AreEqual("10", num.GetText());


        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        var ASTrootNode = (RootNode)astBuildVisitor.VisitRoot(parseTree);

        var fieldNode = ASTrootNode.Fields[0];
        //check the fields
        Assert.AreEqual("a", fieldNode.Key.Id.value);
        Assert.IsInstanceOfType(fieldNode.Type, typeof(TypeAnotationNode));
        Assert.AreEqual(TypeEnum.Int, ((TypeAnotationNode)fieldNode.Type).type);
        Assert.AreEqual(10, fieldNode.Expr.GetChild<IntNode>(0).value);


        // Type checking TEST Type checking
        TypeChecker typeChecker = new TypeChecker();
        RootNode typeCheckedField = (RootNode)typeChecker.VisitRoot(ASTrootNode as RootNode);
        //check the fields
        Assert.AreEqual("a", typeCheckedField.Fields[0].Key.Id.value);
        Assert.IsInstanceOfType(typeCheckedField.Fields[0].Type, typeof(TypeAnotationNode));
        Assert.AreEqual(TypeEnum.Int, ((TypeAnotationNode)typeCheckedField.Fields[0].Type).type); //check the node connected to the field
        Assert.AreEqual(TypeEnum.Int, typeCheckedField.Fields[0].typeInfo.type); //check the type info synthesised.
        Assert.AreEqual(10, typeCheckedField.Fields[0].Expr.GetChild<IntNode>(0).value);

        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(typeCheckedField);
        Assert.IsInstanceOfType(intermediateAst, typeof(JRootNode));
        JRootNode jRootNode = intermediateAst as JRootNode;
        Assert.AreEqual(1, jRootNode.Fields.Count);
        Assert.AreEqual("a", jRootNode.Fields[0].Key.Value);
        Assert.IsInstanceOfType(jRootNode.Fields[0].Value, typeof(JIntNode));
        Assert.AreEqual(10, (jRootNode.Fields[0].Value as JIntNode).Value);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        Assert.AreEqual("{\"a\": 10}", jsonString);

    }
    public void ObjectEndToEndTest()
    {
        string input = @"
            object myObj = {
                int x = 10,
                float y = 20.5,
                string z = ""hello""
            };
        ";
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());

        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        UCMParser.FieldContext parserField = parseTree.field(0);
        UCMParser.FieldIdContext fieldId = parserField.fieldId();
        UCMParser.IdContext id = fieldId.id();
        Assert.AreEqual("myObj", id.GetText());

        UCMParser.TypeContext type = parserField.type();
        UCMParser.ComplexTypeContext complexType = type.complexType();
        Assert.IsNotNull(complexType.object_t());

        //value
        UCMParser.ExprContext expr = parserField.expr();
        UCMParser.ValueContext obj = expr.value();
        UCMParser.ObjectContext objectContext = obj.@object();
        Assert.IsNotNull(objectContext);

        UCMParser.FieldContext field1 = objectContext.field(0);
        UCMParser.FieldIdContext fieldId1 = field1.fieldId();
        UCMParser.IdContext id1 = fieldId1.id();
        Assert.AreEqual("x", id1.GetText());

        UCMParser.ExprContext expr1 = field1.expr();
        UCMParser.ValueContext value1 = expr1.value();
        UCMParser.NumContext num1 = value1.num();
        Assert.AreEqual("10", num1.GetText());


        UCMParser.TypeContext type1 = field1.type();
        UCMParser.PrimitiveTypeContext primitiveType1 = type1.primitiveType();
        Assert.IsNotNull(primitiveType1.INT_T());
        Assert.IsNull(primitiveType1.FLOAT_T());

        UCMParser.FieldContext field2 = objectContext.field(1);
        UCMParser.FieldIdContext fieldId2 = field2.fieldId();
        UCMParser.IdContext id2 = fieldId2.id();
        Assert.AreEqual("y", id2.GetText());

        UCMParser.ExprContext expr2 = field2.expr();
        UCMParser.ValueContext value2 = expr2.value();
        UCMParser.NumContext num2 = value2.num();
        Assert.AreEqual("20.5", num2.GetText());

        UCMParser.TypeContext type2 = field2.type();
        UCMParser.PrimitiveTypeContext primitiveType2 = type2.primitiveType();
        Assert.IsNotNull(primitiveType2.FLOAT_T());
        Assert.IsNull(primitiveType2.INT_T());

        UCMParser.FieldContext field3 = objectContext.field(2);
        UCMParser.FieldIdContext fieldId3 = field3.fieldId();
        UCMParser.IdContext id3 = fieldId3.id();
        Assert.AreEqual("z", id3.GetText());

        UCMParser.ExprContext expr3 = field3.expr();
        UCMParser.ValueContext value3 = expr3.value();
        UCMParser.StringContext stringContext = value3.@string();
        Assert.AreEqual("\"hello\"", stringContext.GetText());

        UCMParser.TypeContext type3 = field3.type();
        UCMParser.ComplexTypeContext complexType3 = type3.complexType();
        Assert.IsNotNull(complexType.STRING_T());

        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        AstNode ast = astBuildVisitor.VisitRoot(parseTree);

        var ASTrootNode = (RootNode)astBuildVisitor.VisitRoot(parseTree);
        var fieldNode = ASTrootNode.Fields[0];
        //check the fields
        Assert.AreEqual("myObj", fieldNode.Key.Id.value);
        Assert.IsInstanceOfType(fieldNode.Type, typeof(TypeAnotationNode));
        Assert.AreEqual(TypeEnum.Object, ((TypeAnotationNode)fieldNode.Type).type);
        var AstObjectNode = fieldNode.Expr.GetChild<ObjectNode>(0);
        Assert.AreEqual(3, AstObjectNode.Fields.Count);
        Assert.AreEqual("x", AstObjectNode.Fields[0].Key.Id.value);
        Assert.AreEqual(10, AstObjectNode.Fields[0].Expr.GetChild<IntNode>(0).value);
        Assert.AreEqual("y", AstObjectNode.Fields[1].Key.Id.value);
        Assert.AreEqual(20.5, AstObjectNode.Fields[1].Expr.GetChild<FloatNode>(0).value);
        Assert.AreEqual("z", AstObjectNode.Fields[2].Key.Id.value);
        Assert.AreEqual("hello", AstObjectNode.Fields[2].Expr.GetChild<StringNode>(0).value);


        // Type checking TEST Type checking
        TypeChecker typeChecker = new TypeChecker();
        var semanticNode = typeChecker.Visit(ast);
        var typeCheckedField = (RootNode)semanticNode;
        //check the fields
        Assert.AreEqual("myObj", typeCheckedField.Fields[0].Key.Id.value);
        Assert.IsInstanceOfType(typeCheckedField.Fields[0].Type, typeof(TypeAnotationNode));
        Assert.AreEqual(TypeEnum.Object, ((TypeAnotationNode)typeCheckedField.Fields[0].Type).type); //check the node connected to the field
        Assert.AreEqual(TypeEnum.Object, typeCheckedField.Fields[0].typeInfo.type); //check the type info synthesised.
        var typeCheckedObjectNode = typeCheckedField.Fields[0].Expr.GetChild<ObjectNode>(0);
        Assert.AreEqual(3, typeCheckedObjectNode.Fields.Count);
        Assert.AreEqual("x", typeCheckedObjectNode.Fields[0].Key.Id.value);
        Assert.AreEqual(10, typeCheckedObjectNode.Fields[0].Expr.GetChild<IntNode>(0).value);
        Assert.AreEqual("y", typeCheckedObjectNode.Fields[1].Key.Id.value);
        Assert.AreEqual(20.5, typeCheckedObjectNode.Fields[1].Expr.GetChild<FloatNode>(0).value);
        Assert.AreEqual("z", typeCheckedObjectNode.Fields[2].Key.Id.value);
        Assert.AreEqual("hello", typeCheckedObjectNode.Fields[2].Expr.GetChild<StringNode>(0).value);

        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ast);
        Assert.IsInstanceOfType(intermediateAst, typeof(JObjectNode));
        JObjectNode jRootNode = intermediateAst as JObjectNode;
        Assert.AreEqual(1, jRootNode.Fields.Count);
        Assert.AreEqual("myObj", jRootNode.Fields[0].Key.Value);
        Assert.IsInstanceOfType(jRootNode.Fields[0].Value, typeof(JObjectNode));
        JObjectNode jObjectNode = jRootNode.Fields[0].Value as JObjectNode;
        Assert.AreEqual(3, jObjectNode.Fields.Count);
        Assert.AreEqual("x", jObjectNode.Fields[0].Key.Value);
        Assert.IsInstanceOfType(jObjectNode.Fields[0].Value, typeof(JIntNode));
        Assert.AreEqual(10, (jObjectNode.Fields[0].Value as JIntNode).Value);
        Assert.AreEqual("y", jObjectNode.Fields[1].Key.Value);
        Assert.IsInstanceOfType(jObjectNode.Fields[1].Value, typeof(JFloatNode));
        Assert.AreEqual(20.5, (jObjectNode.Fields[1].Value as JFloatNode).Value);
        Assert.AreEqual("z", jObjectNode.Fields[2].Key.Value);
        Assert.IsInstanceOfType(jObjectNode.Fields[2].Value, typeof(JStringNode));
        Assert.AreEqual("hello", (jObjectNode.Fields[2].Value as JStringNode).Value);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        Assert.AreEqual("{\"myObj\": {\"x\": 10, \"y\": 20.5, \"z\": \"hello\"}}", jsonString);

    }

    [TestMethod]
    public void TestEndToEndTemplate()
    {
        string input = """
            template A{
                int a;
            }

            A aA = {
                int a = 10; 
            };
        """;
        ICharStream stream = CharStreams.fromString(input);

        // Create tokens
        UCMLexer lexer = new UCMLexer(stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        //add errorlistener
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());

        // Create parser 
        UCMParser parser = new UCMParser(tokens);
        UCMParser.RootContext parseTree = parser.root();
        //add error listenr
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        //template
        UCMParser.TemplateDefenitionContext template = parseTree.templateDefenition(0);
        Assert.AreEqual("A", template.id().GetText());
        UCMParser.TemplateFieldContext templateField = template.templateField(0);
        UCMParser.TypeContext type = templateField.type();
        UCMParser.PrimitiveTypeContext primitiveType = type.primitiveType();
        Assert.IsNotNull(primitiveType.INT_T());
        Assert.IsNull(primitiveType.FLOAT_T());
        UCMParser.IdContext Defid = templateField.id();
        Assert.AreEqual("a", Defid.GetText());

        //template instance
        UCMParser.FieldContext parserField = parseTree.field(0);
        UCMParser.FieldIdContext fieldId = parserField.fieldId();
        UCMParser.IdContext instanceId = fieldId.id();
        Assert.AreEqual("aA", instanceId.GetText());

        UCMParser.TypeContext instanceType = parserField.type();
        UCMParser.ComplexTypeContext complexType = instanceType.complexType();
        Assert.IsNotNull(complexType.object_t());

        //value
        UCMParser.ExprContext expr = parserField.expr();
        UCMParser.ValueContext obj = expr.value();
        UCMParser.ObjectContext objectContext = obj.@object();
        Assert.IsNotNull(objectContext);

        UCMParser.FieldContext field1 = objectContext.field(0);
        UCMParser.FieldIdContext fieldId1 = field1.fieldId();
        UCMParser.IdContext id1 = fieldId1.id();
        Assert.AreEqual("a", id1.GetText());

        UCMParser.ExprContext expr1 = field1.expr();
        UCMParser.ValueContext value1 = expr1.value();
        UCMParser.NumContext num1 = value1.num();
        Assert.AreEqual("10", num1.GetText());

        // Build AST TEST AST
        AstBuildVisitor astBuildVisitor = new AstBuildVisitor();
        var ASTrootNode = (RootNode)astBuildVisitor.VisitRoot(parseTree);
        var ASTTemplateDef = ASTrootNode.Templates[0];
        //check the template
        Assert.AreEqual("A", ASTTemplateDef.Id.value);
        Assert.AreEqual(1, ASTTemplateDef.Fields.Count);
        Assert.AreEqual("a", ASTTemplateDef.Fields[0].Id.value);

        var fieldNode = ASTrootNode.Fields[0];
        //check the fields
        Assert.AreEqual("aA", fieldNode.Key.Id.value);
        Assert.IsInstanceOfType(fieldNode.Type, typeof(TypeAnotationNode));

        Assert.AreEqual(TypeEnum.Object, ((TypeAnotationNode)fieldNode.Type).type);

        var AstObjectNode = fieldNode.Expr.GetChild<ObjectNode>(0);
        Assert.AreEqual(1, AstObjectNode.Fields.Count);
        Assert.AreEqual("a", AstObjectNode.Fields[0].Key.Id.value);
        Assert.AreEqual(10, AstObjectNode.Fields[0].Expr.GetChild<IntNode>(0).value);


        // Type checking TEST Type checking
        TypeChecker typeChecker = new TypeChecker();
        RootNode TypeCheckedNode = (RootNode)typeChecker.Visit(ASTrootNode);
        //check the template
        Assert.AreEqual("A", TypeCheckedNode.Templates[0].Id.value);
        Assert.AreEqual(1, TypeCheckedNode.Templates[0].Fields.Count);
        Assert.AreEqual("a", TypeCheckedNode.Templates[0].Fields[0].Id.value);

        //check the fields
        Assert.AreEqual("aA", TypeCheckedNode.Fields[0].Key.Id.value);
        Assert.IsInstanceOfType(TypeCheckedNode.Fields[0].Type, typeof(TypeAnotationNode));
        Assert.AreEqual(TypeCheckedNode.Fields[0].typeInfo.templateId, "A");

        var typeCheckedObjectNode = TypeCheckedNode.Fields[0].Expr.GetChild<ObjectNode>(0);
        Assert.AreEqual(1, typeCheckedObjectNode.Fields.Count);
        Assert.AreEqual("a", typeCheckedObjectNode.Fields[0].Key.Id.value);
        Assert.AreEqual(10, typeCheckedObjectNode.Fields[0].Expr.GetChild<IntNode>(0).value);


        // Intermediate Generation TEST INTERMEDIATE GENERATION
        JAstNode intermediateAst = new IntermediateGenerationVisitor().Visit(ASTrootNode);
        Assert.IsInstanceOfType(intermediateAst, typeof(JRootNode));
        JRootNode jRootNode = intermediateAst as JRootNode;
        Assert.AreEqual(1, jRootNode.Fields.Count);
        Assert.AreEqual("aA", jRootNode.Fields[0].Key.Value);
        Assert.IsInstanceOfType(jRootNode.Fields[0].Value, typeof(JObjectNode));
        JObjectNode jObjectNode = jRootNode.Fields[0].Value as JObjectNode;
        Assert.AreEqual(1, jObjectNode.Fields.Count);
        Assert.AreEqual("a", jObjectNode.Fields[0].Key.Value);
        Assert.IsInstanceOfType(jObjectNode.Fields[0].Value, typeof(JIntNode));
        Assert.AreEqual(10, (jObjectNode.Fields[0].Value as JIntNode).Value);

        // JSON Generation TEST JSON GENERATION
        string jsonString = new JSONGenerator().Visit(intermediateAst);
        Assert.AreEqual("{\"aA\": {\"a\": 10}}", jsonString);

    }

}