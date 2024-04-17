using UCM.typechecker;

namespace UCM.ast
{
    public class IntNode : AstLeafNode<int>
    {
        public IntNode(int value) :
            base(value)
        {
            type = TypeEnum.INT;
        }
    }
}
