using System.Runtime.CompilerServices;
using UCM.ast;
using UCM.astVisitor;

public class ObjectFieldAcessNode : AstNode
{
    public ObjectFieldAcessNode(List<AstNode> ids)
    {
        AddChildren(ids);
    }

    public List<AstNode> Id => GetChildren<AstNode>();
    

    public override T? Accept<T>(AstBaseVisitor<T> visitor) where T : default
    {
        return visitor.VisitObjectFieldAcess(this);
    }
}
