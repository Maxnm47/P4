using UCM.typechecker;

namespace UCM.ast
{
    public class VoidNode : AstLeafNode<string>
    {
        public VoidNode() :
            base(TypeEnum.Void.ToString())
        {
            type = TypeEnum.Void;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitVoid(this);
        }
    }
}
