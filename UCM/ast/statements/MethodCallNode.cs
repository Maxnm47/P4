using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements
{
    public class MethodCallNode : AstNode
    {
        public MethodCallNode(string methodId) : base(methodId)
        {
        }

        public IdentifyerNode Id => this.GetChild<IdentifyerNode>(0);
        public ArgumentsNode Arguments => this.GetChild<ArgumentsNode>(0);


    }

}