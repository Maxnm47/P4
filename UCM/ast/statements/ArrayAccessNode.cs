using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.statements
{
    public class ArrayAccessNode : AstNode
    {

        public ArrayAccessNode(IdentifyerNode arrayName, List<ExpressionNode> indexs)
        {
            AddChild(arrayName);
            AddChildren(indexs);
        }

        public IdentifyerNode ArrayName => GetChild<IdentifyerNode>(0);
        public List<ExpressionNode> Indexs => GetChildren<ExpressionNode>();
        public override T? Accept<T>(AstBaseVisitor<T> visitor) where T : default
        {
            return visitor.VisitArrayAccess(this);
        }
    }
}