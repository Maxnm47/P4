using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public abstract class JAstNode
    {
        readonly public List<JAstNode> Children = [];

        public void AddChild(JAstNode? child)
        {
            if (child != null)
                Children.Add(child);
        }

        public void AddChildren(List<JAstNode> children)
        {
            this.Children.AddRange(children);
        }

        public abstract T Accept<T>(JAstVisitor<T> visitor);
    }
}