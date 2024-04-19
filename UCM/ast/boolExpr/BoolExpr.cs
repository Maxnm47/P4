using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.boolExpr
{
    public abstract class BoolExpr : BinaryOperation
    {
        protected BoolExpr(AstNode left, AstNode right) : base(left, right)
        {
        }
    }
}