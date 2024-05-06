using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JKeyNode(string value) : JAstLeafNode<string>(value)
    {
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitKey(this);
        }
    }
}