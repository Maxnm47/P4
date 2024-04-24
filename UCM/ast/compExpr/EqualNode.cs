
namespace UCM.ast.boolExpr;


public class EqualNode : BoolExpr
{
    public EqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitEqual(this);
    }
}