using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JFloatNode(float value) : JAstLeafNode<float>(value)
    {
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitFloat(this);
        }
    }
}