using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.ast
{
    public class IntNode : AstLeafNode<int>
    {
        public IntNode(int value) :
            base(value)
        {
            type = TypeEnum.INT;
        }
    }
}
