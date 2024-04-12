using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM;
using UCM.typechecker;
using UCM.ast;


namespace UCM.ast;

public partial class AstLeafNode : AstNode
{
    public string value { get; set; }

    public TypeEnum type { get; set; }

    public AstLeafNode(string value) //constructor
    {
        this.value = value;
    }

    public AstLeafNode(string value, TypeEnum type)
    {
        this.value = value;
        this.type = type;
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + value;
    }

    public override string ToString(string indent)
    {
        return indent + ToString();
    }
}
