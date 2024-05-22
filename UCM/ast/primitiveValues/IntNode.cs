using Antlr4.Runtime.Misc;
using UCM.typeEnum;

namespace UCM.ast
{
    public class IntNode : AstLeafNode<int>
    {
        public IntNode(int value) :
            base(value)
        {
            type = typeEnum.TypeEnum.Int;
        }


        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitInt(this);
        }
    }

}