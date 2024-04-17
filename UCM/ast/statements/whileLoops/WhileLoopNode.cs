using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.boolExpr;

namespace UCM.ast.statements.whileLoop
{
    public class WhileLoopNode : AstNode
    {
        public WhileLoopNode(BoolExpr condition, BodyNode body)
        {
            AddChild(condition);
            AddChild(body);
        }
        public BoolExpr Condition => GetChild<BoolExpr>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}