using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM.astVisitor;
using UCM.ast;
using UCM.astJunior;
using Antlr4.Runtime;

namespace UCM.Tests
{
    [TestClass]
    public class IntermediateGenerationTests
    {
        private IntermediateGenerationVisitor visitor;
        private AstBuildVisitor astBuilder;

        [TestInitialize]
        public void Setup()
        {
            visitor = new IntermediateGenerationVisitor();
            astBuilder = new AstBuildVisitor();  // Assuming you have this setup based on your AST nodes
        }

        private JAstNode GenerateIntermediateRepresentation(string code)
        {
            var stream = CharStreams.fromString(code);
            var lexer = new UCMLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new UCMParser(tokens);
            var parseTree = parser.root();
            AstNode astRoot = astBuilder.VisitRoot(parseTree);
            return visitor.VisitRoot(astRoot as RootNode);
        }

        [TestMethod]
        public void TestSimpleVariableDeclaration()
        {
            string code = "int x = 5;";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode objectNode = result as JObjectNode;
            Assert.AreEqual(1, objectNode.Fields.Count);
            JFieldNode field = objectNode.Fields.First();
            Assert.AreEqual("x", field.Key.Value);
            Assert.IsInstanceOfType(field.Value, typeof(JIntNode));
        }

        [TestMethod]
        public void TestComplexVariableDeclaration()
        {
            string code = @"
                int x = 10;
                object a = 
                    { 
                        int x = 10;
                    };
             ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode outerx = rootNode.Fields[0];
            Assert.AreEqual("x", outerx.Key.Value); //outer x
            Assert.IsInstanceOfType(outerx.Value, typeof(JIntNode));
            Assert.AreEqual(2, rootNode.Fields.Count());

            JFieldNode outerObject = rootNode.Fields[1];
            Assert.AreEqual("a", outerObject.Key.Value);
            Assert.IsInstanceOfType(outerObject.Value, typeof(JObjectNode));

            JObjectNode innerObject = outerObject.Value as JObjectNode;
            JFieldNode innerx = innerObject.Fields[0];
            Assert.AreEqual("x", innerx.Key.Value); //inner x
            Assert.IsInstanceOfType(innerx.Value, typeof(JIntNode));
        }

        [TestMethod]
        public void testAssignment()
        {
            string code = @"
                int x = 10;
                int b = x;
            ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode x = rootNode.Fields[0];
            Assert.AreEqual("x", x.Key.Value);
            Assert.IsInstanceOfType(x.Value, typeof(JIntNode));

            JFieldNode b = rootNode.Fields[1];
            Assert.AreEqual("b", b.Key.Value);
            Assert.IsInstanceOfType(b.Value, typeof(JIntNode));
        }

        [TestMethod]
        public void testAssigmentInScope()
        {
            string code = @"
                int x = 10;
                object a = 
                {
                    int x = x;
                };
            ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode x = rootNode.Fields[0];
            Assert.AreEqual("x", x.Key.Value);
            Assert.IsInstanceOfType(x.Value, typeof(JIntNode));

            JObjectNode scope = rootNode.Fields[1].Value as JObjectNode;
            JFieldNode innerx = scope.Fields[0];
            Assert.AreEqual("x", innerx.Key.Value);
            Assert.IsInstanceOfType(innerx.Value, typeof(JIntNode));

            JIntNode innerxValue = innerx.Value as JIntNode;
            Assert.AreEqual(10, innerxValue.Value);

        }


        [TestMethod]
        public void testArray()
        {
            string code = @"
                int[] x = [1,2,3];
            ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode x = rootNode.Fields[0];
            Assert.AreEqual("x", x.Key.Value);
            Assert.IsInstanceOfType(x.Value, typeof(JArrayNode));

            JArrayNode array = x.Value as JArrayNode;
            Assert.AreEqual(3, array.Elements.Count);
            Assert.IsInstanceOfType(array.Elements[0], typeof(JIntNode));
            Assert.IsInstanceOfType(array.Elements[1], typeof(JIntNode));
            Assert.IsInstanceOfType(array.Elements[2], typeof(JIntNode));
        }

        [TestMethod]
        public void AssignToNonexisting()
        {
            string code = @"
                int x = y;
            ";
            Assert.ThrowsException<System.Exception>(() => GenerateIntermediateRepresentation(code));
        }

        [TestMethod]
        public void AssignToNonexistingInScope()
        {
            string code = @"
                object a = 
                {
                    int x = y;
                };
            ";
            Assert.ThrowsException<System.Exception>(() => GenerateIntermediateRepresentation(code));
        }

        [TestMethod]
        public void AssignToNonexistingInArray()
        {
            string code = @"
                int[] x = [1,y,3];
            ";
            Assert.ThrowsException<System.Exception>(() => GenerateIntermediateRepresentation(code));
        }

        [TestMethod]
        public void AssignFutureScope()
        {

            string code = @"
                int a = a.y;
                object a = 
                {
                    int y = 10;   
                };
            ";
            Assert.ThrowsException<System.Exception>(() => GenerateIntermediateRepresentation(code));
        }

        [TestMethod]
        public void AnyarrayTest(){
            string code = @"
                any[] a = [1,2.1,3];
            ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode a = rootNode.Fields[0];
            Assert.AreEqual("a", a.Key.Value);
            Assert.IsInstanceOfType(a.Value, typeof(JArrayNode));
            JArrayNode array = a.Value as JArrayNode;
            Assert.AreEqual(3, array.Elements.Count);
            Assert.IsInstanceOfType(array.Elements[0], typeof(JIntNode));
            Assert.IsInstanceOfType(array.Elements[1], typeof(JFloatNode));
            Assert.IsInstanceOfType(array.Elements[2], typeof(JIntNode));

            //value assesement
            JIntNode intNode = array.Elements[0] as JIntNode;
            Assert.AreEqual(1, intNode.Value);
            JFloatNode floatNode = array.Elements[1] as JFloatNode;
            Assert.AreEqual(2.1, floatNode.Value, 0.0001); // The third parameter is the delta

            intNode = array.Elements[2] as JIntNode;
            Assert.AreEqual(3, intNode.Value);

        }

        public void AnyArrayTest2(){
            string code = @"
                any[] a = [1,2.0,3];
            ";
            JAstNode result = GenerateIntermediateRepresentation(code);
            Assert.IsInstanceOfType(result, typeof(JObjectNode));
            JObjectNode rootNode = result as JObjectNode;
            JFieldNode a = rootNode.Fields[0];
            Assert.AreEqual("a", a.Key.Value);
            Assert.IsInstanceOfType(a.Value, typeof(JArrayNode));
            JArrayNode array = a.Value as JArrayNode;
            Assert.AreEqual(3, array.Elements.Count);
            Assert.IsInstanceOfType(array.Elements[0], typeof(JIntNode));
            Assert.IsInstanceOfType(array.Elements[1], typeof(JFloatNode));
            Assert.IsInstanceOfType(array.Elements[2], typeof(JIntNode));

            //value assesement
            JIntNode intNode = array.Elements[0] as JIntNode;
            Assert.AreEqual(1, intNode.Value);
            JFloatNode floatNode = array.Elements[1] as JFloatNode;
            Assert.AreEqual(2.0, floatNode.Value, 0.0001); // The third parameter is the delta

            intNode = array.Elements[2] as JIntNode;
            Assert.AreEqual(3, intNode.Value);

        }
    }
}
