using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.boolExpr;

namespace UCM.ast.statements.condition
{
    public class IfStatementNode : AstNode
    {
        public IfStatementNode(ExpressionNode condition, BodyNode body)
        {
            AddChild(condition);
            AddChild(body);
        }
        public ExpressionNode Condition => GetChild<ExpressionNode>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}