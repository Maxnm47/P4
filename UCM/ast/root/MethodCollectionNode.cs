using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.statements;

namespace UCM.ast.root
{
    public class MethodCollectionNode : AstNode
    {
        public MethodCollectionNode(IdentifyerNode id, List<MethodDefenitionNode> methods)
        {
            this.AddChild(id);
            this.AddChildren(methods);
        }

        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
        public List<MethodDefenitionNode> Methods => GetChildren<MethodDefenitionNode>();

        public override T Accept<T>(astVisitor.AstBaseVisitor<T> visitor)
        {
            return visitor.VisitMethodCollection(this);
        }
    }
}