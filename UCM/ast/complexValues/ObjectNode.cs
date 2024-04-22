using UCM.typechecker;

namespace UCM.ast
{
    public class ObjectNode : AstNode
    {
        public ObjectNode()
        {

        }

        public List<FieldNode> Fields => GetChildren<FieldNode>();
        public IdentifyerNode? Id => GetChild<IdentifyerNode>(0);
    }
}
