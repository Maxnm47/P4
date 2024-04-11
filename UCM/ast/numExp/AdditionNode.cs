using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast.numExp;

namespace UCM.ast
{
    public class AdditionNode : Operation
    {
        public AdditionNode(AstNode left, AstNode right) :
            base(left, right)
        {
        }
    }
}
