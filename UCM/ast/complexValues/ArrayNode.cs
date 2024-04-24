using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.complexValues
{
    public class ArrayNode : AstNode
    {
        public ArrayNode()
        {
        }
        public ArrayNode(List<ExpressionNode> expressions)
        {
            AddChildren(expressions);
        }

        public override T Accept1<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitArray(this);
        }
    }
}