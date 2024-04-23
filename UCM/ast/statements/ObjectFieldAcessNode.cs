using System.Runtime.CompilerServices;
using UCM.ast;

public class ObjectFieldAcessNode : AstNode
{
    public ObjectFieldAcessNode(List<IdentifyerNode> ids)
    {
        AddChildren(ids);
    }

    public List<IdentifyerNode> Id => GetChildren<IdentifyerNode>();
    
}
