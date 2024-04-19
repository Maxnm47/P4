using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements.forLoops
{
    public class ForLoopNode : AstNode
    {
        public ForLoopNode(IdentifyerNode enumeratorId, ExpressionNode loopArray, BodyNode body)
        {
            this.AddChild(enumeratorId);
            this.AddChild(loopArray);
            this.AddChild(body);
        }
        public IdentifyerNode EnumeratorId => GetChild<IdentifyerNode>(0);
        public ExpressionNode LoopArray => GetChild<ExpressionNode>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}