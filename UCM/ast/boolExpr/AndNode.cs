using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.boolExpr
{
    public class AndNode : BoolExpr
    {
        public AndNode(AstNode left, AstNode right) : base(left, right)
        {
        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitAnd(this);
        }
    }
}