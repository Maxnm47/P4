
using UCM.typeEnum;

namespace UCM.ast
{
    public class FloatNode : AstLeafNode<float>
    {
        public FloatNode(float value) : base(value)
        {
            type = TypeEnum.Float;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitFloat(this);
        }
    }
}