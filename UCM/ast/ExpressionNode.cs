using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast
{
    public class ExpressionNode : AstNode
    {
        public ExpressionNode()
        {
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitExpression(this);
        }
    }
}
