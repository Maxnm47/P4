using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.loopConstruction
{
    public class LoopConstructionNode : AstNode
    {
        public LoopConstructionNode(IdentifyerNode entity, ExpressionNode array, LoopConstructContentNode evaluationContent)
        {
            this.AddChild(entity);
            this.AddChild(array);
            this.AddChild(evaluationContent);
        }

        public IdentifyerNode Entity => GetChild<IdentifyerNode>(0);
        public ExpressionNode Array => GetChild<ExpressionNode>(0);
        public LoopConstructContentNode EvaluationContent => GetChild<LoopConstructContentNode>(0);
    }
}

