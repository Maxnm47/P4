namespace UCM.ast.numExpr;

public class ModuloNode : NumExpr
{
    public ModuloNode(AstNode left, AstNode right) : base(left, right)
    {
    }

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitModulo(this);
    }
}



