using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.loopConstruction;

namespace UCM.ast.complexValues
{
    public class ArrayNode : AstNode
    {
        public ArrayNode()
        {
        }
        public ArrayNode(List<ExpressionNode> expressions)
        {
            AddChildren(expressions);
        }

        public List<ExpressionNode>? Elements => GetChildren<ExpressionNode>();

        public List<LoopConstructionNode>? LoopConstructionNodes => GetChildren<LoopConstructionNode>();

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitArray(this);
        }
    }
}