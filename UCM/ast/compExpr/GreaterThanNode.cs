
namespace UCM.ast.boolExpr;

public class GreaterThanNode : BoolExpr
{
    public GreaterThanNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitGreaterThan(this);
    }
}