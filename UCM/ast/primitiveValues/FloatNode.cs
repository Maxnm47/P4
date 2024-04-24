
using UCM.typechecker;

namespace UCM.ast
{
    public class FloatNode : AstLeafNode<float>
    {
        public FloatNode(float value) : base(value)
        {
            type = TypeEnum.FLOAT;
        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitFloat(this);
        }
    }
}