using UCM.TypeEnum;

namespace UCM.ast
{
    public class VoidNode : AstLeafNode<string>
    {
        public VoidNode() :
            base(TypeEnum.TypeEnum.Void.ToString())
        {
            type = TypeEnum.TypeEnum.Void;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitVoid(this);
        }
    }
}
