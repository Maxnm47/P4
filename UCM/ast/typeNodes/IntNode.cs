using UCM.typechecker;

namespace UCM.ast
{
    public class IntNode : AstLeafNode
    {
        public IntNode(string value) ://constructor for int node
            base(value)
        {
            type = TypeEnum.INT;
        }
    }
}
