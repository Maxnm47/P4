using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements
{
    public class ArgumentDefenitionNode : AstNode
    {
        public ArgumentDefenitionNode(TypeAnotationNode type, IdentifyerNode id)
        {
            children.Add(type);
            children.Add(id);
        }

        public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
    }

}