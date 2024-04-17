using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typechecker;

namespace UCM.ast;

public class IdentifyerNode<T> : AstLeafNode<T>
{
    public IdentifyerNode(T value) : base(value)
    {
    }

    public IdentifyerNode(T value, TypeEnum type) : base(value, type)
    {
    }

    
}

