using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.ast
{
    public class TypeAnotationNode : AstLeafNode<string>
    {
        public TypeAnotationNode(string value) :
            base(value)
        {
        }

        public TypeAnotationNode(string value, TypeEnum type) :
            base(value, type)
        {
        }
    }
}
