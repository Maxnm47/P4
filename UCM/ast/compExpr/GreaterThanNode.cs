
namespace UCM.ast.boolExpr;

public class GreaterThanNode : BoolExpr
{
    public GreaterThanNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}