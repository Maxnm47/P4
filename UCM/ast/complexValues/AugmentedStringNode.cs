
using UCM.typechecker;

namespace UCM.ast
{
    public class AugmentedStringNode : AstNode
    {
        public AugmentedStringNode()
        {

        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitAugmentedString(this);
        }

    }
}
