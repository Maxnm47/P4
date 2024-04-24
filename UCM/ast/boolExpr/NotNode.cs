namespace UCM.ast.boolExpr;

public class NotNode : AstNode
{
    public NotNode(AstNode child)
    {
        children.Add(child);
    }

    public AstNode Child => children[0];

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitNot(this);
    }
}