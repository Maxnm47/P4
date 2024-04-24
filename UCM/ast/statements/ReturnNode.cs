using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;

namespace UCM.ast.statements
{
    public class ReturnNode : AstNode
    {
        public override T Accept<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitReturn(this);
        }
    }
}