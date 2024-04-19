namespace UCM.ast.numExpr;

public class SubtractionNode : BinaryOperation
{
    public SubtractionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}

