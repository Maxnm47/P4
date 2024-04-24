using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast
{
    public class HiddenAnotationNode : AstLeafNode<bool>
    {
        public HiddenAnotationNode(bool value) : base(value)
        {

        }

        public override T Accept1<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitHiddenAnotation(this);
        }
    }
}