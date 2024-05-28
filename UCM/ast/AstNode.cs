using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;
using UCM.typeEnum;

namespace UCM.ast;

public abstract class AstNode
{
    public List<AstNode> children = new List<AstNode>();

    public AstNode parent { get; set; }

    public string referenceId;

    public TypeEnum? type { get; set; }
    public TypeInfo? typeInfo { get; set; }

    public abstract T? Accept<T>(astVisitor.AstBaseVisitor<T> visitor);

    public virtual string ToString()
    {
        string indent = "  ";
        string str = indent + this.GetType().Name + " ( \n";

        foreach (AstNode child in children)
        {
            str += child.ToString(indent + "  ") + "\n";
        }

        str += indent + ")";
        return str;
    }

    public virtual string ToString(string indent)
    {
        string str = indent + this.GetType().Name + " ( \n";

        foreach (AstNode child in children)
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

    public void AddChild<T>(T? node) where T : AstNode
    {
        if (node == null)
        {
            return;
        }
        node.parent = this;
        children.Add(node);
    }

    public void AddChildren<T>(List<T> children) where T : AstNode
    {
        foreach (AstNode child in children)
        {
            AddChild(child);
        }
    }

    public List<T>? GetChildren<T>() where T : AstNode
    {
        List<T> result = null;
        foreach (AstNode child in children)
        {
            if (child is T)
            {
                result ??= new List<T>();
                result.Add((T)child);
            }
        }

        return result;
    }


    public T GetChild<T>(int i) where T : AstNode
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
