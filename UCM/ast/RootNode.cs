using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.root;

namespace UCM.ast;

public class RootNode : AstNode
{
    public RootNode()
    {
    }

    public RootNode(
        List<MethodCollectionNode> methodCollections,
        List<TemplateNode> templates,
        List<FieldNode> fields)
    {
        this.AddChildren(templates);
        this.AddChildren(methodCollections);
        this.AddChildren(fields);
        this.parent = null;
    }

    public List<FieldNode> Fields => GetChildren<FieldNode>();
    public List<MethodCollectionNode> MethodCollections => GetChildren<MethodCollectionNode>();
    public List<TemplateNode> Templates => GetChildren<TemplateNode>();

    public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
    {
        return visitor.VisitRoot(this);
    }
}
