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

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitBool(this);
        }
    }
}
