using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public abstract class AstNode
{    public List<AstNode> children = new List<AstNode>();

    public override string ToString() {
        string indent = "  ";
        string str = indent + this.GetType().Name + " ( \n";

        foreach (AstNode child in children)
        {
            str += child.ToString(indent + "  ") + "\n";
        }

        str += indent + ")";
        return str;
    }

    public virtual string ToString(string indent) {
        string str = indent + this.GetType().Name + " ( \n";
        
        foreach (AstNode child in children)
        {
            str += child.ToString(indent + "  ") + "\n";
        }

        str += indent + ")";
        return str;
    }

    public void AddChild(AstNode node) {
        children.Add(node);
    }

    public virtual T GetChild<T>(int i) where T : AstNode
    {
        if (children == null || i < 0 || i >= children.Count)
        {
            return default(T);
        }

        int num = -1;
        foreach (AstNode child in children)
        {
            if (child is T)
            {
                num++;
                if (num == i)
                {
                    return (T)child;
                }
            }
        }

        return default(T);
    }
}
