using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements.forLoops
{
    public class ForLoopNode : AstNode
    {
        public ForLoopNode(IdentifyerNode entity, ExpressionNode array, BodyNode body)
        {
            this.AddChild(entity);
            this.AddChild(array);
            this.AddChild(body);
        }
        public IdentifyerNode Entity => GetChild<IdentifyerNode>(0);
        public ExpressionNode Array => GetChild<ExpressionNode>(0);
        public BodyNode Body => GetChild<BodyNode>(0);

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitForLoop(this);
        }
    }
}