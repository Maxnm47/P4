using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.boolExpr;

namespace UCM.ast.statements.whileLoop
{
    public class WhileLoopNode : AstNode
    {
        public WhileLoopNode(ExpressionNode condition, BodyNode body)
        {
            AddChild(condition);
            AddChild(body);
        }
        public ExpressionNode Condition => GetChild<ExpressionNode>(0);
        public BodyNode Body => GetChild<BodyNode>(0);

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitWhileLoop(this);
        }
    }
}