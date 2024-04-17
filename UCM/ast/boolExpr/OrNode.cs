namespace UCM.ast.boolExpr;


public class OrNode : BinaryOperation
{
    public OrNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}