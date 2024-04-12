using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public class FieldNode : AstNode
{
    public FieldNode(HiddenAnotationNode isHidden, TypeAnotationNode type, IdentifyerNode id, ExpressionNode expr)
    {
        children.Add(isHidden);
        children.Add(type);
        children.Add(id);
        children.Add(expr);
    }

    public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
    public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
    public ExpressionNode Expr => GetChild<ExpressionNode>(0);
}
