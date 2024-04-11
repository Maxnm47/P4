using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.ast
{
    public class IntNode : AstLeafNode
    {
        public IntNode(string value) :
            base(value)
        {
            type = TypeEnum.INT;
        }
    }
}
