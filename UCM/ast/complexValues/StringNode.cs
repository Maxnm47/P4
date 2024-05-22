using UCM.TypeEnum;

namespace UCM.ast
{
    public class StringNode : AstLeafNode<string>
    {
        public StringNode(string value) :
            base(value)
        {
            type = TypeEnum.TypeEnum.String;
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitString(this);
        }
    }
}
