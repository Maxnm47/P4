using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JArrayNode : JAstNode
    {
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitArray(this);
        }

        public List<JAstNode> Elements => Children;
    }
}