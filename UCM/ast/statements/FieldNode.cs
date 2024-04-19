using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.statements;

namespace UCM.ast;

public class FieldNode : AstNode
{
    public FieldNode(HiddenAnotationNode hidden, TypeAnotationNode type, FieldId id, ExpressionNode expr)
    {
        children.Add(hidden);
        children.Add(type);
        children.Add(id);
        children.Add(expr);
    }
    public HiddenAnotationNode Hidden => GetChild<HiddenAnotationNode>(0);
    public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
    public FieldId Id => GetChild<FieldId>(0);

    public ExpressionNode Expr => GetChild<ExpressionNode>(0);
}
