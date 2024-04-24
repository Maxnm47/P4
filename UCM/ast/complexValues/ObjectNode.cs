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

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitObject(this);
        }
    }
}
