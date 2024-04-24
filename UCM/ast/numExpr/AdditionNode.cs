
namespace UCM.ast.numExpr;

public class AdditionNode : NumExpr
{
    public AdditionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }

    public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitAddition(this);
    }
}

