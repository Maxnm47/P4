namespace UCM.ast.numExpr;

public class AdditionNode : BinaryOperation
{
    public AdditionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}

