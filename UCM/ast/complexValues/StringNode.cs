using UCM.typechecker;

namespace UCM.ast
{
    public class StringNode : AstLeafNode<string>
    {
        public StringNode(string value) :
            base(value)
        {
            type = TypeEnum.STRING;
        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitString(this);
        }
    }
}
