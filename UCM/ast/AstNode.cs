using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public abstract class AstNode
{
    public Dictionary<AstNodeName, AstNode> children;

    public override string ToString() {
        string str = this.GetType().Name + " ( ";
        
        foreach (KeyValuePair<AstNodeName, AstNode> entry in children)
        {
            str += entry.Value.ToString();
        }

        str += " )";
        return str;
    }
}
