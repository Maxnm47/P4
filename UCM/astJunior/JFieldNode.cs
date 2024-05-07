using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JFieldNode : JAstNode
    {

        public JFieldNode(JKeyNode key, JAstNode value)
        {
            AddChild(key);
            AddChild(value);
        }

        public JKeyNode Key => GetChild(0) as JKeyNode;
        public JAstNode Value => GetChild(1);
        public override T Accept<T>(JAstVisitor<T> visitor)
        {
            return visitor.VisitField(this);
        }

        public JKeyNode Key => Children.OfType<JKeyNode>().First();
        public JAstNode Value => Children.OfType<JAstNode>().ElementAt(1);
    }
}