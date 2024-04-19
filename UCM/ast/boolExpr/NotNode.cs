namespace UCM.ast.boolExpr;

public class NotNode : AstNode
{
    public NotNode(AstNode child)
    {
        children.Add(child);
    }

    public AstNode Child => children[0];
}