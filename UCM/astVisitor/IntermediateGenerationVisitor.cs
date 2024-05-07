using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}