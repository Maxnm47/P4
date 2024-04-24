using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.loopConstruction
{
    public class LoopConstructContentNode : AstNode
    {
        public LoopConstructContentNode()
        {
        }

        List<FieldNode> Fields => GetChildren<FieldNode>();
        List<ExpressionNode> Expressions => GetChildren<ExpressionNode>();

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitLoopConstructContent(this);
        }
    }
}