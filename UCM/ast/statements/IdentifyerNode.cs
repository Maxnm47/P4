using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.astVisitor;
using UCM.typeEnum;

namespace UCM.ast;

public class IdentifyerNode : AstLeafNode<string>
{
    public IdentifyerNode(string value) : base(value)
    {
    }

    public IdentifyerNode(string value, typeEnum.TypeEnum type) : base(value, type)
    {
    }

    public override T Accept<T>(AstBaseVisitor<T> visitor)
    {
        return visitor.VisitIdentifyer(this);
    }
}

