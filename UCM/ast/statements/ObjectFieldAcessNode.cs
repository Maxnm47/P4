using System.Runtime.CompilerServices;
using UCM.ast;
using UCM.astVisitor;

public class ObjectFieldAcessNode : AstNode
{
    public ObjectFieldAcessNode(List<IdentifyerNode> ids)
    {
        AddChildren(ids);
    }

    public List<IdentifyerNode> Id => GetChildren<IdentifyerNode>();

    public override T? Accept<T>(AstBaseVisitor<T> visitor) where T : default
    {
        return visitor.VisitObjectFieldAcess(this);
    }
}
