namespace UCM.ast.numExpr;

public class MultiplicationNode : NumExpr
{
    public MultiplicationNode(AstNode left, AstNode right) : base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitMultiplication(this);
    }
}
