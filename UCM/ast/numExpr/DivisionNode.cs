namespace UCM.ast.numExpr;

public class DivisionNode : NumExpr
{
    public DivisionNode(AstNode left, AstNode right) : base(left, right)
    {
    }

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitDivision(this);
    }
}
