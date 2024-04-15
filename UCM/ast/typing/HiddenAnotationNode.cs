using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast
{
    public class HiddenAnotationNode : AstLeafNode<bool>
    {
        public HiddenAnotationNode(bool value) : base(value)
        {

        }
    }
}