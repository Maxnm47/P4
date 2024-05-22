using UCM.typeEnum;

namespace UCM.ast
{
    public class BoolNode : AstLeafNode<bool>
    {
        public BoolNode(bool value) :
            base(value)
        {
            type = typeEnum.TypeEnum.Bool;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitBool(this);
        }
    }
}
