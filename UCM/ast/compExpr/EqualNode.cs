
namespace UCM.ast.boolExpr;


public class EqualNode : BoolExpr
{
    public EqualNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}