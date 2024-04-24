
using UCM.typechecker;

namespace UCM.ast
{
    public class AugmentedStringNode : AstNode
    {
        public AugmentedStringNode()
        {

        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitAugmentedString(this);
        }

    }
}
