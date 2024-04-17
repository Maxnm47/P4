namespace UCM.ast.compExpr;


public class EqualNode : BinaryOperation
{
    public EqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}