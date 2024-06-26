using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast;

public class AssignmentNode : AstNode
{
    public AssignmentNode(TypeAnotationNode type, IdentifyerNode id, ExpressionNode expr)
    {
        children.Add(type);
        children.Add(id);
        children.Add(expr);
    }

    public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
    public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
    public ExpressionNode Expr => GetChild<ExpressionNode>(0);

    public override T Accept<T>(AstBaseVisitor<T> visitor)
    {
        return visitor.VisitAssignment(this);
    }
}
