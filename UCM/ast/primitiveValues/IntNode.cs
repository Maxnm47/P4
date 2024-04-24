using UCM.typechecker;

namespace UCM.ast
{
    public class IntNode : AstLeafNode<int>
    {
        public IntNode(int value) :
            base(value)
        {
            type = TypeEnum.INT;
        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitInt(this);
        }
    }
}