namespace UCM.ast.compExpr;

public class GreaterThanNode : BinaryOperation
{
    public GreaterThanNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}