using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

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

        public override T Accept1<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitArgumentDefenition(this);
        }
    }

}