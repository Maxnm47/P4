using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.complexValues;

namespace UCM.ast.root
{
    public class TemplateFieldNode : AstNode
    {
        public TemplateFieldNode(TypeAnotationNode type, IdentifyerNode id, ExpressionNode? expr, ArrayNode? evaluatorArray = null)
        {
            AddChild(type);
            AddChild(id);

            if (expr != null)
                AddChild(expr);

            if (evaluatorArray != null)
                AddChild(evaluatorArray);
        }

        public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);

        public ExpressionNode? Expr => GetChild<ExpressionNode>(0);

        public ArrayNode? EvaluatorArray => GetChild<ArrayNode>(0);

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitTemplateField(this);
        }
    }
}