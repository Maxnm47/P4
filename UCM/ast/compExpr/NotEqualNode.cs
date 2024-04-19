namespace UCM.ast.boolExpr;

public class NotEqualNode : BoolExpr
{
    public NotEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}