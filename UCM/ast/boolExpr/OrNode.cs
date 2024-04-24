namespace UCM.ast.boolExpr;


public class OrNode : BoolExpr
{
    public OrNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitOr(this);
    }
}