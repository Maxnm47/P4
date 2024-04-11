using UCM.typechecker;

namespace UCM.ast
{
    public class ObjectNode: AstLeafNode
    {
        public ObjectNode(string value) :
            base(value)
        {
            type = TypeEnum.OBJECT;
        }
    }
}
