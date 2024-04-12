using UCM.typechecker;

namespace UCM.ast
{
    public class BoolNode: AstLeafNode
    {
        public BoolNode(string value) :
            base(value)
        {
            type = TypeEnum.BOOL;
        }
    }
}
