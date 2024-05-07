using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using UCM.ast;
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

        public override JAstNode VisitField(FieldNode node)
        {
            JKeyNode key = Visit(node.Key) as JKeyNode;
            JAstNode value = Visit(node.Expr);
            return new JFieldNode(key, value);
        }

        public override JAstNode VisitFieldId(FieldId node)
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
            return binOp(node.typeInfo, left, right, "+");

            throw new Exception("Addition type not implemented yet");
        }

        public override JAstNode VisitMultiplication(MultiplicationNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);
            return binOp(node.typeInfo, left, right, "*");

            throw new Exception("Addition type not implemented yet");
        }

        public override JAstNode VisitDivision(DivisionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);
            return binOp(node.typeInfo, left, right, "/");

            throw new Exception("Division failed");
        }

        public override JAstNode VisitSubtraction(SubtractionNode node)
        {
            JAstNode left = Visit(node.Left);
            JAstNode right = Visit(node.Right);
            return binOp(node.typeInfo, left, right, "-");

            throw new Exception("subtraction failed");
        } 

        public override JAstNode VisitInt(IntNode node)
        {
            return new JIntNode(node.value);
        }

        public override JAstNode VisitFloat(FloatNode node)
        {
            return new JFloatNode(node.value);
        }

        public override JAstNode VisitString(StringNode node)
        {
            return new JStringNode(node.value);
        }
        private JAstNode binOp(TypeInfo typeInfo, JAstNode left, JAstNode right, string op)
        {
            if (typeInfo.type == TypeEnum.Int)
            {
                int leftValue = ((JIntNode)left).Value;
                int rightValue = ((JIntNode)right).Value;

                switch (op)
                {
                    case "+":
                        return new JIntNode(leftValue + rightValue);
                    case "-":
                        return new JIntNode(leftValue - rightValue);
                    case "*":
                        return new JIntNode(leftValue * rightValue);
                    case "/":
                        if(rightValue == 0)
                            throw new Exception("Division by zero");
                        return new JIntNode(leftValue / rightValue); 
                    default:
                        throw new Exception($"Invalid operation {op} for type Int");
                }
            }

            if (typeInfo.type == TypeEnum.Float)
            {
                float leftValue = ((JFloatNode)left).Value;
                float rightValue = ((JFloatNode)right).Value;

                switch (op)
                {
                    case "+":
                        return new JFloatNode(leftValue + rightValue);
                    case "-":
                        return new JFloatNode(leftValue - rightValue);
                    case "*":
                        return new JFloatNode(leftValue * rightValue);
                    case "/":
                        if(rightValue == 0)
                            throw new Exception("Division by zero");
                        return new JFloatNode(leftValue / rightValue); 
                    default:
                        throw new Exception($"Invalid operation {op} for type Float");
                }
            }

            if (typeInfo.type == TypeEnum.String)
            {
                if (op == "+")
                {
                    string leftValue = ((JStringNode)left).Value;
                    string rightValue = ((JStringNode)right).Value;
                    return new JStringNode(leftValue + rightValue);
                }
                throw new Exception($"Invalid operation {op} for type String");
            }

            throw new Exception($"Cannot {op} {typeInfo.type}");
        }

    }
}