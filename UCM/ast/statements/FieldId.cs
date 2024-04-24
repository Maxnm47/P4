using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.statements
{
    public class FieldId : AstNode
    {
        public FieldId(IdentifyerNode id)
        {
            this.AddChild(id);
        }

        public FieldId(ExpressionNode expr)
        {
            this.AddChild(expr);
        }


        public IdentifyerNode? Id => GetChild<IdentifyerNode>(0);
        public ExpressionNode? Expr => GetChild<ExpressionNode>(0);

        public override T Accept<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitFieldId(this);
        }
    }
}