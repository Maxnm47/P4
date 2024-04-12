using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements
{
    public class MethodCallNode : AstNode
    {
        public MethodCallNode(IdentifyerNode identifyer, ArgumentsNode arguments)
        {
            this.AddChild(identifyer);
            this.AddChild(arguments);
        }

        public IdentifyerNode Id => this.GetChild<IdentifyerNode>(0);
        public ArgumentsNode Arguments => this.GetChild<ArgumentsNode>(0);
    }

}