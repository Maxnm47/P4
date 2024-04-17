using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.boolExpr;

namespace UCM.ast.statements.condition
{
    public class IfStatementNode : AstNode
    {
        public IfStatementNode(BoolExpr condition, BodyNode body)
        {
            AddChild(condition);
            AddChild(body);
        }
        public BoolExpr Condition => GetChild<BoolExpr>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}