using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.ast.numExp
{
    public class FloatNode : AstLeafNode<float>
    {
        public FloatNode(float value) : base(value)
        {
            type = TypeEnum.FLOAT;
        }
    }
}