using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.numExpr
{
    public abstract class NumExpr : BinaryOperation
    {
        protected NumExpr(AstNode left, AstNode right) : base(left, right)
        {
        }
    }
}