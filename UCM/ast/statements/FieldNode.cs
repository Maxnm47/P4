using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public class FieldNode<T>: AstNode
{
    public FieldNode(HiddenAnotationNode hidden, TypeAnotationNode type, IdentifyerNode<T>id, ExpressionNode expr)
    {
        children.Add(hidden);
        children.Add(type);
        children.Add(id);
        children.Add(expr);
    }
    public HiddenAnotationNode Hidden => GetChild<HiddenAnotationNode>(0);
    public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
    public IdentifyerNode<T> Id => GetChild<IdentifyerNode<T>>(0);
    
    public ExpressionNode Expr => GetChild<ExpressionNode>(0);
}
