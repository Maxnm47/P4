using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;

namespace UCM.astVisitor
{
    public class AstTestVisitor : AstBaseVisitor<AstNode>
    {
        public FieldNode Visit(FieldNode node)
        {
            Console.WriteLine("Visiting object");
            return VisitChildren(node);
        }
    }
}