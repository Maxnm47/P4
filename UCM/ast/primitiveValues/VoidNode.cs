using UCM.typechecker;

namespace UCM.ast
{
    public class VoidNode : AstLeafNode<string>
    {
        public VoidNode() :
            base(TypeEnum.VOID.ToString())
        {
            type = TypeEnum.VOID;
        }
    }
}
