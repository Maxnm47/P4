using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements
{
    public class MethodDefenitionNode : AstNode
    {
        public MethodDefenitionNode(
            TypeAnotationNode type,
            IdentifyerNode id,
            List<ArgumentDefenitionNode> argumentDefs,
            BodyNode body)
        {
            this.AddChild(type);
            this.AddChild(id);
            this.AddChildren(argumentDefs);
            this.AddChild(body);
        }

        public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
        public List<ArgumentDefenitionNode> ArgumentsDefs => GetChildren<ArgumentDefenitionNode>();
        public BodyNode Body => GetChild<BodyNode>(0);
    }
}