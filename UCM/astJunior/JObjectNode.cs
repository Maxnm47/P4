using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JObjectNode : JAstNode
    {
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitObject(this);
        }

        List<JFieldNode> Fields => Children.OfType<JFieldNode>().ToList();
    }
}