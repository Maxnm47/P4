using UCM.typechecker;

namespace UCM.ast
{
    public class BoolNode : AstLeafNode<bool>
    {
        public BoolNode(bool value) :
            base(value)
        {
            type = TypeEnum.BOOL;
        }
    }
}
