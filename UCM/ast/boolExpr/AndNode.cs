namespace UCM.ast.boolExpr;


public class AndNode : BinaryOperation
{
    public AndNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}