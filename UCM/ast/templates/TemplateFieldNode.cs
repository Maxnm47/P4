using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.Template
{
    public class TemplateFieldNode : AstNode
    {
        public TemplateFieldNode(TypeAnotationNode type, IdentifyerNode id, ExpressionNode? expr) //har lavet expr nullable
        {
            children.Add(type);
            children.Add(id);
            if (expr != null)
            {
                children.Add(expr);
            }
        }

        public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
        public ExpressionNode Expr => GetChild<ExpressionNode>(0);
    }
}