namespace UCM.ast.boolExpr;


public class OrNode : BoolExpr
{
    public OrNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitOr(this);
    }
}