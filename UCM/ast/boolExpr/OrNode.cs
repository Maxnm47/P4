namespace UCM.ast.boolExpr;


public class OrNode : BoolExpr
{
    public OrNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}