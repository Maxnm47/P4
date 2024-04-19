namespace UCM.ast.numExpr;

public class SubtractionNode : NumExpr
{
    public SubtractionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}

