using UCM.TypeEnum;

namespace UCM.ast
{
    public class NullNode : AstLeafNode<string>
    {
        public NullNode(string nuller) :
            base(nuller)
        {
        }

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return default(T);
        }
    }
}
