namespace UCM.ast.boolExpr;

public class GreaterThanOrEqualNode : BoolExpr
{
    public GreaterThanOrEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitGreaterThanOrEqual(this);
    }
}