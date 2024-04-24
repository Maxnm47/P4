using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;

namespace UCM.astVisitor
{
    public class AstTestVisitor : AstBaseVisitor<AstNode>
    {

        public override AstNode VisitField(FieldNode node)
        {
            Console.WriteLine("Visiting AST FieldNode");
            return base.VisitField(node);
        }
    }
}