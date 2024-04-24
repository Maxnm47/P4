namespace UCM.ast.numExpr;

public class SubtractionNode : NumExpr
{
    public SubtractionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }


    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitSubtraction(this);
    }
}

