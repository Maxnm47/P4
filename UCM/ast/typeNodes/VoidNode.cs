using UCM.typechecker;

namespace UCM.ast
{
    public class VoidNode: AstLeafNode
    {
        public VoidNode(string value) :
            base(value)
        {
            type = TypeEnum.VOID;
        }
    }
}
