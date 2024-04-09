using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public class FieldNode : AstNode
{
    public FieldNode(AstNode type, AstNode id, AstNode expr)
    {
        children = new Dictionary<AstNodeName, AstNode>
        {
            { AstNodeName.TYPE, type },
            { AstNodeName.ID, id },
            { AstNodeName.EXPR, expr }
        };
    }

    public AstNode Type => children[AstNodeName.TYPE];
    public AstNode Id => children[AstNodeName.ID];
    public AstNode Expr => children[AstNodeName.EXPR];
}
