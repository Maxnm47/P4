using UCM.typechecker;

namespace UCM.ast
{
    public class VoidNode : AstLeafNode<string>
    {
        public VoidNode(string value) :
            base(value)
        {
            type = TypeEnum.VOID;
        }
    }
}
