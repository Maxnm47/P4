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


        public override string ToString()
        {
            string indent = "  ";
            string str = indent + this.GetType().Name + " ( \n";

            foreach (JAstNode child in Children)
            {
                str += child.ToString(indent + "  ") + "\n";
            }

            str += indent + ")";
            return str;
        }

        public string ToString(string indent)
        {
            string str = indent + this.GetType().Name + " ( \n";

            foreach (JAstNode child in Children)
            {
                if (child == null)
                {
                    str += indent + "  null\n";
                    continue;
                }

                str += child.ToString(indent + "  ") + "\n";
            }

            str += indent + ")";
            return str;
        }

    }
}