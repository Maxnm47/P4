using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.loopConstruction;
using UCM.ast.numExpr;
using UCM.ast.statements;
using UCM.astJunior;
using UCM.typeEnum;

namespace UCM.astVisitor
{
    public class IntermediateGenerationVisitor : AstBaseVisitor<JAstNode?>
    {
        public Stack<Dictionary<string, JAstNode>> SymbolTable = [];

        public Dictionary<string, JAstNode> CurrentScope => SymbolTable.Peek();

        public IntermediateGenerationVisitor()
        {
            SymbolTable.Push([]);
        }

        public override JAstNode VisitRoot(RootNode node)
        {
            List<JFieldNode> fields = new List<JFieldNode>();
            foreach (AstNode child in node.children)
            {
                if (child is FieldNode fieldNode)
                {
                    JFieldNode? field = VisitField(fieldNode);
                    if (field != null)
                    {
                        fields.Add(field);
                    }
                }
            }

            return new JRootNode(fields);
        }


        public override JNullNode VisitNull(NullNode node)
        {
            return new JNullNode("null");
        }
        public override JFieldNode? VisitField(FieldNode node)
        {
            JKeyNode key = Visit(node.Key) as JKeyNode;
            JAstNode value = Visit(node.Expr);
            if (value is null)
            {
                value = new JNullNode("null");
            }
            CurrentScope.Add(key.Value, value);

            bool isHidden = node.Hidden != null;
            if (isHidden)
            {
                return null;
            }


            return new JFieldNode(key, value);
        }

        public override JObjectNode VisitObject(ObjectNode objectNode)
        {
            List<JFieldNode> fields = new List<JFieldNode>();
            SymbolTable.Push([]);

            bool isAdapted = objectNode.Id != null;

            if (isAdapted)
            {
                JObjectNode parrentObject = FindSymbol(objectNode.Id!.value) as JObjectNode;

                foreach (JFieldNode field in parrentObject!.Fields)
                {
                    fields.Add(field);
                }
            }



            foreach (AstNode child in objectNode.children)
            {
                if (child is FieldNode fieldNode)
                {
                    JFieldNode? field = VisitField(fieldNode) as JFieldNode;
                    if (field != null)
                    {
                        if (isAdapted)
                        {
                            fields.RemoveAll(f => f.Key.Value == field.Key.Value);
                        }
                        fields.Add(field);
                    }
                }

                if (child is LoopConstructionNode loopConstructionNode)
                {
                    fields.AddRange(VisitObjectLoopConstruction(loopConstructionNode));
                }
            }

            SymbolTable.Pop();

            return new JObjectNode(fields);
        }


        // This is used instead of VisitLoopConstructuon as it can be implememted seperatly for loop constructuon in array 
        // and with more profereable retrurn type.
        public List<JFieldNode> VisitObjectLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            JArrayNode array = Visit(loopConstructionNode.Array) as JArrayNode;
            List<JFieldNode> fields = new List<JFieldNode>();

            SymbolTable.Push([]);
            foreach (JAstNode child in array.Elements)
            {
                CurrentScope[loopConstructionNode.Entity.value] = child;
                fields.Add(Visit(loopConstructionNode.EvaluationContent) as JFieldNode);
            }

            SymbolTable.Pop();
            return fields;
        }

        public List<JAstNode> VisitArrayLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            JArrayNode array = Visit(loopConstructionNode.Array) as JArrayNode;
            List<JAstNode> evaluatedElements = new List<JAstNode>();

            SymbolTable.Push([]);
            CurrentScope.Add(loopConstructionNode.Entity.value, null);
            foreach (JAstNode child in array.Elements)
            {
                CurrentScope[loopConstructionNode.Entity.value] = child;
                evaluatedElements.Add(Visit(loopConstructionNode.EvaluationContent));
            }

            SymbolTable.Pop();
            return evaluatedElements;
        }

        public override JAstNode VisitIdentifyer(IdentifyerNode node)
        {
            foreach (Dictionary<string, JAstNode> scope in SymbolTable)
            {
                if (scope.ContainsKey(node.value))
                {
                    return scope[node.value];
                }
            }

            throw new Exception("Variable not found: shoudl have been handleded by typechecker");
        }

        public override JAstNode VisitArray(ArrayNode arrayNode)
        {
            List<JAstNode> elements = new List<JAstNode>();

            foreach (AstNode child in arrayNode.children)
            {
                if (child is ExpressionNode expressionNode)
                {
                    elements.Add(Visit(expressionNode));
                }

                if (child is LoopConstructionNode loopConstructionNode)
                {
                    elements.AddRange(VisitArrayLoopConstruction(loopConstructionNode));
                }

                if (child is RangeNode range)
                {
                    elements.AddRange((VisitRange(range) as JArrayNode).Elements);
                }
            }

            return new JArrayNode(elements);
        }

        public override JAstNode VisitRange(RangeNode rangeNode)
        {
            int start = (Visit(rangeNode.Start) as JIntNode).Value;
            int end = (Visit(rangeNode.End) as JIntNode).Value;

            List<JAstNode> elements = [];

            for (int i = start; i < end; i++)
            {
                elements.Add(new JIntNode(i));
            }

            return new JArrayNode(elements);
        }

        public override JAstNode VisitArrayAccess(ArrayAccessNode arrayAccessNode)
        {
            int dimentions = arrayAccessNode.Indexs.Count;
            JArrayNode array = FindSymbol(arrayAccessNode.ArrayName.value) as JArrayNode;

            for (int dim = 0; dim < dimentions - 1; dim++)
            {
                int _index = (Visit(arrayAccessNode.Indexs[dim]) as JIntNode).Value;

                try
                {
                    array = array.Elements[_index] as JArrayNode;
                }
                catch
                {
                    throw new IndexOutOfRangeException($"Array index {_index} out of range in array: {arrayAccessNode.ArrayName.value}.");
                }
            }

            int index = (Visit(arrayAccessNode.Indexs[dimentions - 1]) as JIntNode).Value;
            try
            {
                return array.Elements[index];
            }
            catch
            {
                throw new IndexOutOfRangeException($"Array index {index} out of range in array: {arrayAccessNode.ArrayName.value}.");
            }
        }

        public override JKeyNode VisitFieldId(FieldId node)
        {
            if (node.Id != null)
            {
                return new JKeyNode(node.Id.value);
            }

            JAstNode expr = Visit(node.Expr!);

            if (expr is JStringNode stringNode)
            {
                return new JKeyNode(stringNode.Value);
            }

            // Add for int and float
            if (expr is JIntNode intNode)
            {
                return new JKeyNode(intNode.Value.ToString());
            }

            if (expr is JFloatNode floatNode)
            {
                return new JKeyNode(floatNode.Value.ToString(CultureInfo.InvariantCulture));
            }

            throw new Exception("Key type not suported");
        }
        public override JAstNode VisitObjectFieldAcess(ObjectFieldAcessNode objectFieldAccessNode)
        {
            JAstNode currentNode = null;
            List<AstNode> identifiers = objectFieldAccessNode.Id;

            if (identifiers.Count == 0)
            {
                throw new Exception("Identifier list is empty.");
            }

            JObjectNode currentObject = null;

            for (int i = 0; i < identifiers.Count; i++)
            {
                var identifier = identifiers[i];

                if (identifier is IdentifyerNode identifyer)
                {
                    if (i == 0) // First identifier, find the symbol
                    {
                        currentObject = FindSymbol(identifyer.value) as JObjectNode;
                        currentNode = currentObject;
                    }
                    else
                    {
                        if (currentObject == null)
                        {
                            throw new Exception("Current object is null.");
                        }

                        JFieldNode field = null;
                        for (int j = 0; j < currentObject.Fields.Count; j++)
                        {
                            if (currentObject.Fields[j].Key.Value == identifyer.value)
                            {
                                field = currentObject.Fields[j];
                                return field.Value;
                            }
                        }

                        if (field == null)
                        {
                            throw new Exception("Field not found in object.");
                        }

                        currentNode = field.Value as JObjectNode;
                        currentObject = currentNode as JObjectNode;
                    }
                }
                else if (identifier is ArrayAccessNode arrayAccess)
                {
                    currentNode = Visit(arrayAccess);
                    currentObject = currentNode as JObjectNode;
                }
                else
                {
                    throw new Exception("Unsupported node type.");
                }
            }

            return currentNode ?? throw new Exception("No valid node processed.");
        }

        public override JAstNode VisitMultiplication(MultiplicationNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);

            if (node.typeInfo.type == TypeEnum.Int)
            {
                return new JIntNode((left as JIntNode).Value * (right as JIntNode).Value);
            }

            if (node.typeInfo.type == TypeEnum.Float)
            {
                return new JFloatNode((left as JFloatNode).Value * (right as JFloatNode).Value);
            }

            throw new Exception("Multiplication failed");
        }

        public override JAstNode VisitDivision(DivisionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);

            if (node.typeInfo.type == TypeEnum.Int)
            {
                return new JIntNode((left as JIntNode).Value / (right as JIntNode).Value);
            }

            if (node.typeInfo.type == TypeEnum.Float)
            {
                return new JFloatNode((left as JFloatNode).Value / (right as JFloatNode).Value);
            }

            throw new Exception("Division failed");
        }

        public override JAstNode VisitSubtraction(SubtractionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);

            if (node.typeInfo.type == TypeEnum.Int)
            {
                return new JIntNode((left as JIntNode).Value - (right as JIntNode).Value);
            }

            if (node.typeInfo.type == TypeEnum.Float)
            {
                return new JFloatNode((left as JFloatNode).Value - (right as JFloatNode).Value);
            }

            throw new Exception("subtraction failed");
        }

        public override JAstNode VisitAddition(AdditionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);

            if (node.typeInfo.type == TypeEnum.Int)
            {
                return new JIntNode((left as JIntNode).Value + (right as JIntNode).Value);
            }

            if (node.typeInfo.type == TypeEnum.Float)
            {
                return new JFloatNode((left as JFloatNode).Value + (right as JFloatNode).Value);
            }

            if (node.typeInfo.type == TypeEnum.String)
            {
                return new JStringNode((left as JStringNode).Value + (right as JStringNode).Value);
            }


            throw new Exception("Addition failed");
        }


        public override JIntNode VisitInt(IntNode node)
        {
            return new JIntNode(node.value);
        }

        public override JFloatNode VisitFloat(FloatNode node)
        {
            return new JFloatNode(node.value);
        }

        public override JStringNode VisitString(StringNode node)
        {
            return new JStringNode(node.value);
        }

        public override JBoolNode VisitBool(BoolNode node)
        {
            return new JBoolNode(node.value);
        }

        public override JAstNode VisitAugmentedString(AugmentedStringNode augmentedStringNode)
        {
            string result = "";

            foreach (AstNode child in augmentedStringNode.children)
            {
                if (child is StringNode stringNode)
                {
                    JStringNode jStringNode = Visit(stringNode) as JStringNode;
                    result += jStringNode.Value;
                }

                if (child is ExpressionNode expressionNode)
                {
                    JAstNode expr = Visit(expressionNode);
                    if (expr is JStringNode stringExprNode)
                    {
                        result += stringExprNode.Value;
                    }

                    if (expr is JIntNode intExprNode)
                    {
                        result += intExprNode.Value.ToString();
                    }

                    if (expr is JFloatNode floatExprNode)
                    {
                        result += floatExprNode.Value.ToString();
                    }
                }
            }

            return new JStringNode(result);
        }

        public JAstNode FindSymbol(string key)
        {
            foreach (Dictionary<string, JAstNode> scope in SymbolTable)
            {
                if (scope.ContainsKey(key))
                {
                    return scope[key];
                }
            }

            throw new Exception("Variable not found: shoudl have been handleded by typechecker");
        }
    }
}