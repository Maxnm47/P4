namespace UCM.ast.boolExpr;

public class LessThanOrEqualNode : BoolExpr
{
    public LessThanOrEqualNode(AstNode left, AstNode right) : base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitLessThanOrEqual(this);
    }
}