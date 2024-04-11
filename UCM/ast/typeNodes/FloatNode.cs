using UCM.typechecker;

namespace UCM.ast
{
    public class FloatNode: AstLeafNode
    {
        public FloatNode(string value) :
            base(value)
        {
            type = TypeEnum.VOID;
        }
    }
}
