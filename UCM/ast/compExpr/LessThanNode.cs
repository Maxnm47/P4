namespace UCM.ast.boolExpr;

public class LessThanNode : BoolExpr
{
    public LessThanNode(AstNode left, AstNode right) : base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitLessThan(this);
    }
}