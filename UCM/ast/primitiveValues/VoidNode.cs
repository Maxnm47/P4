using UCM.typeEnum;

namespace UCM.ast
{
    public class VoidNode : AstLeafNode<string>
    {
        public VoidNode() :
            base(typeEnum.TypeEnum.Void.ToString())
        {
            type = typeEnum.TypeEnum.Void;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitVoid(this);
        }
    }
}
