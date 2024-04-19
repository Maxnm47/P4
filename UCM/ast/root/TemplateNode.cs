using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.statements;

namespace UCM.ast.root
{
    public class TemplateNode : AstNode
    {
        public TemplateNode(IdentifyerNode id, List<TemplateFieldNode> fields, List<MethodDefenitionNode> methods, IdentifyerNode? parent = null)
        {
            this.AddChild(id);
            if (parent != null)
                this.AddChild(parent);

            this.AddChildren(fields);
            this.AddChildren(methods);
        }

        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
        public List<MethodDefenitionNode> Methods => GetChildren<MethodDefenitionNode>();
        public List<FieldNode> Fields => GetChildren<FieldNode>();
        public IdentifyerNode? Parent => GetChild<IdentifyerNode>(1);
    }
}