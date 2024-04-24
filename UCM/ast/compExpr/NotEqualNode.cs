namespace UCM.ast.boolExpr;

public class NotEqualNode : BoolExpr
{
    public NotEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitNotEqual(this);
    }
}