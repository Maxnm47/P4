using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.boolExpr
{
    public class BoolExpr : BinaryOperation
    {
        public BoolExpr(AstNode left, AstNode right) : base(left, right)
        {
        }
    }
}