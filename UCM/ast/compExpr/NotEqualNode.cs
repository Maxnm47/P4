namespace UCM.ast.compExpr;

public class NotEqualNode : BinaryOperation
{
    public NotEqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}