using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JBoolNode(bool value) : JAstLeafNode<bool>(value)
    {
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitBool(this);
        }
    }
}