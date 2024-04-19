using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements.condition
{
    public class ConditionalNode : AstNode
    {
        public AstNode ElseBody => GetChild<BodyNode>(0);
    }
}