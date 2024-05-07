using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.loopConstruction;
using UCM.ast.numExpr;
using UCM.ast.statements;
using UCM.astJunior;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class IntermediateGenerationVisitor : AstBaseVisitor<JAstNode>
    {
        public Stack<Dictionary<string, JAstNode>> SymbolTable = [];

        public Dictionary<string, JAstNode> CurrentScope => SymbolTable.Peek();

        public IntermediateGenerationVisitor()
        {
            SymbolTable.Push([]);
        }

        public override JFieldNode VisitField(FieldNode node)
        {
            JKeyNode key = Visit(node.Key) as JKeyNode;
            JAstNode value = Visit(node.Expr);

            CurrentScope.Add(key.Value, value);
            return new JFieldNode(key, value);
        }

        public override JObjectNode VisitObject(ObjectNode objectNode)
        {
            List<JFieldNode> fields = new List<JFieldNode>();

            foreach (AstNode child in objectNode.children)
            {
                if (child is FieldNode fieldNode)
                {
                    fields.Add(VisitField(fieldNode));
                }

                if (child is LoopConstructionNode loopConstructionNode)
                {
                    fields.AddRange(VisitObjectLoopConstruction(loopConstructionNode));
                }
            }

            return new JObjectNode(fields);
        }


        // This is used instead of VisitLoopConstructuon as it can be implememted seperatly for loop constructuon in array 
        // and with more profereable retrurn type.
        public List<JFieldNode> VisitObjectLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            return null;
        }

        public List<JAstNode> VisitArrayLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            return null;
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
            }

            return new JArrayNode(elements);
        }

        // public override JAstNode VisitArrayAccess(ArrayAccessNode arrayAccessNode)
        // {
        //     int dimentions = arrayAccessNode.Indexs.Count;
        //     JArrayNode array = FindSymbol(arrayAccessNode.ArrayName.value) as JArrayNode;

        //     for (int dim = 0; dim < dimentions; dim++)
        //     {
        //         JAstNode index = Visit(arrayAccessNode.Indexs[dim]);
        //         if (index is JIntNode intNode)
        //         {
        //             array = array.GetElement(intNode.Value) as JArrayNode;
        //         }
        //         else
        //         {
        //             throw new Exception("Array index not implemented yet");
        //         }
        //     }
        // }

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
            throw new Exception("Key type not implemented yet");
        }

        public override JAstNode VisitAddition(AdditionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);

            if (node.typeInfo.type == TypeEnum.Int)
            {
                int leftValue = ((JIntNode)left).Value;
                int rightValue = ((JIntNode)right).Value;

                return new JIntNode(leftValue + rightValue);
            }

            if (node.typeInfo.type == TypeEnum.Float)
            {
                float leftValue = ((JFloatNode)left).Value;
                float rightValue = ((JFloatNode)right).Value;

                return new JFloatNode(leftValue + rightValue);
            }

            if (node.typeInfo.type == TypeEnum.String)
            {
                string leftValue = ((JStringNode)left).Value;
                string rightValue = ((JStringNode)right).Value;

                return new JStringNode(leftValue + rightValue);
            }

            throw new Exception("Addition type not implemented yet");
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