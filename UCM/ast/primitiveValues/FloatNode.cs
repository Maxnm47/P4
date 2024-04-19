
using UCM.typechecker;

namespace UCM.ast
{
    public class FloatNode : AstLeafNode<float>
    {
        public FloatNode(float value) : base(value)
        {
            type = TypeEnum.FLOAT;
        }
    }
}