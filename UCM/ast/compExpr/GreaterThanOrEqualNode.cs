namespace UCM.ast.boolExpr;

public class GreaterThanOrEqualNode : BoolExpr
{
    public GreaterThanOrEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}