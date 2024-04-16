using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.boolExpr;

namespace UCM.ast.statements.condition
{
    public class IfStatementNode : AstNode
    {
        public BoolExpr Condition => GetChild<BoolExpr>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}