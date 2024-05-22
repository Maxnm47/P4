using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;
using UCM.TypeEnum;

namespace UCM.ast
{
    public class TypeAnotationNode : AstLeafNode<string>
    {
        public TypeAnotationNode(string value) :
            base(value)
        {
        }

        public TypeAnotationNode(string value, TypeEnum.TypeEnum type) :
            base(value, type)
        {
        }

        public override T Accept<T>(AstBaseVisitor<T> visitor)
        {
            return visitor.VisitTypeAnotation(this);
        }
    }
}
