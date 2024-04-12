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
    }
}
