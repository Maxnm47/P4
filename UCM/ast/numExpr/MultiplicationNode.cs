using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.numExp;

public class MultiplicationNode : BinaryOperation
{
    public MultiplicationNode(AstNode left, AstNode right) : base(left, right)
    {
    }
}
