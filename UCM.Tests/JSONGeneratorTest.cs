using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM.JSONGeneration;
using UCM.astJunior;  // Ensure this namespace correctly points to where your JAstNode definitions are.

namespace UCM.Tests
{
    [TestClass]
    public class JSONGeneratorTests
    {
        private JSONGenerator jsonGenerator;

        [TestInitialize]
        public void Setup()
        {
            jsonGenerator = new JSONGenerator();
        }

        [TestMethod]
        public void TestGenerateSimpleObject()
        {
            JObjectNode objectNode = new JObjectNode(new List<JFieldNode>
            {
                new JFieldNode(new JKeyNode("id"), new JIntNode(123))
            });

            string result = jsonGenerator.VisitObject(objectNode);
            string expectedJson = "{\"id\": 123}";
            Assert.AreEqual(expectedJson, result);
        }
        //unit test
        [TestMethod]
        public void TestGenerateArray()
        {
            // Create an array node
            JArrayNode arrayNode = new JArrayNode(new List<JAstNode>
            {
                new JIntNode(1),
                new JIntNode(2),
                new JIntNode(3)
            });

            string result = jsonGenerator.VisitArray(arrayNode);
            string expectedJson = "[1, 2, 3]";
            Assert.AreEqual(expectedJson, result);
        }

        //unit test
        [TestMethod]
        public void TestGenerateComplexObject()
        {
            // Create a complex object node with multiple fields and nested objects
            JObjectNode objectNode = new JObjectNode(new List<JFieldNode>
            {
                new JFieldNode(new JKeyNode("name"), new JStringNode("example")),
                new JFieldNode(new JKeyNode("details"), new JObjectNode(new List<JFieldNode>
                {
                    new JFieldNode(new JKeyNode("age"), new JIntNode(25)),
                    new JFieldNode(new JKeyNode("active"), new JBoolNode(true))
                }))
            });

            string result = jsonGenerator.VisitObject(objectNode);
            string expectedJson = "{\"name\": \"example\", \"details\": {\"age\": 25, \"active\": true}}";
            Assert.AreEqual(expectedJson, result);
        }

        //unit test
        [TestMethod]
        public void TestFloatNode()
        {
            JObjectNode objectNode = new JObjectNode(new List<JFieldNode>
            {
                new JFieldNode(new JKeyNode("value"), new JFloatNode((float)3.14))
            });

            string result = jsonGenerator.VisitObject(objectNode);
            string expectedJson = "{\"value\": 3.14}";
            Assert.AreEqual(expectedJson, result);
        }

        [TestMethod]
        public void TestFloatArray(){
            JArrayNode arrayNode = new JArrayNode(new List<JAstNode>
            {
                new JFloatNode((float)1.1),
                new JFloatNode((float)2.2),
                new JFloatNode((float)3.3)
            });

            string result = jsonGenerator.VisitArray(arrayNode);
            string expectedJson = "[1.1, 2.2, 3.3]";
            Assert.AreEqual(expectedJson, result);
        }

        [TestMethod]
        public void TestIdentifyerlFloatArray(){
            JFieldNode jFieldNode = new JFieldNode(new JKeyNode("a"), new JArrayNode(new List<JAstNode>
            {
                new JFloatNode((float)1.1),
                new JFloatNode((float)2.2),
                new JFloatNode((float)3.3)
            }));

            string result = jsonGenerator.VisitField(jFieldNode);
            string expectedJson = "\"a\": [1.1, 2.2, 3.3]";
            Assert.AreEqual(expectedJson, result);
        }

        [TestMethod]
        public void TestIdentifyerlFloatObject(){
            JFieldNode jFieldNode = new JFieldNode(new JKeyNode("a"), new JObjectNode(new List<JFieldNode>
            {
                new JFieldNode(new JKeyNode("b"), new JFloatNode((float)1.1)),
                new JFieldNode(new JKeyNode("c"), new JFloatNode((float)2.2)),
                new JFieldNode(new JKeyNode("d"), new JFloatNode((float)3.3))
            }));

            string result = jsonGenerator.VisitField(jFieldNode);
            string expectedJson = "\"a\": {\"b\": 1.1, \"c\": 2.2, \"d\": 3.3}";
            Assert.AreEqual(expectedJson, result);
        }


    }
}
