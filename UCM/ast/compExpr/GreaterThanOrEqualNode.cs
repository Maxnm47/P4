namespace UCM.ast.compExpr;

public class GreaterThanOrEqualNode : BinaryOperation
{
    public GreaterThanOrEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}