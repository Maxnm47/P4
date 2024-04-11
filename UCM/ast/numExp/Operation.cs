using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.numExp
{
    public class Operation : AstNode
    {
        public Operation(AstNode left, AstNode right)
        {
            children.Add (left);
            children.Add (right);
        }

        public AstNode Left => GetChild<AstNode>(0);

        public AstNode Right => GetChild<AstNode>(1);
    }
}
