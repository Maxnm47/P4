using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.loopConstruction
{
    public class LoopConstructionNode : AstNode
    {
        public LoopConstructionNode(TypeAnotationNode? entityType, IdentifyerNode entity, ExpressionNode array, LoopConstructContentNode evaluationContent)
        {
            this.AddChild(entityType);
            this.AddChild(entity);
            this.AddChild(array);
            this.AddChild(evaluationContent);
        }


        public TypeAnotationNode? EntityType => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Entity => GetChild<IdentifyerNode>(0);
        public ExpressionNode Array => GetChild<ExpressionNode>(0);
        public LoopConstructContentNode EvaluationContent => GetChild<LoopConstructContentNode>(0);

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitLoopConstruction(this);
        }
    }


}

