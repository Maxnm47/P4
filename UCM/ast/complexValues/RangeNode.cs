using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.complexValues
{
    public class RangeNode : AstNode
    {
        public override T? Accept<T>(AstBaseVisitor<T> visitor) where T : default
        {
            return visitor.VisitRange(this);
        }

        public RangeNode(ExpressionNode start, ExpressionNode end)
        {
            this.AddChild(start);
            this.AddChild(end);
        }

        public ExpressionNode Start => GetChild<ExpressionNode>(0);
        public ExpressionNode End => GetChild<ExpressionNode>(1);
    }
}