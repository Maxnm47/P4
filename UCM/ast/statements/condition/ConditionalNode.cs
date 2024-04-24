using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.statements.condition
{
    public class ConditionalNode : AstNode
    {
        public AstNode ElseBody => GetChild<BodyNode>(0);

        public override T Accept<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitConditional(this);
        }
    }
}