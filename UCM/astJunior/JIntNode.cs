using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior;

public class JIntNode(int value) : JAstLeafNode<int>(value)
{
    public override T Accept<T>(JAstVisitor<T> visitor)
    {
        return visitor.VisitInt(this);
    }
}
