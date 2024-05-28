using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JRootNode : JAstNode
    {
        public JRootNode(List<JFieldNode> fields)
        {
            AddChildren(fields);
        }

        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitRoot(this);
        }

        public List<JFieldNode> Fields => Children.OfType<JFieldNode>().ToList();
    }
}