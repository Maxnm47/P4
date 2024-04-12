using UCM.ast.numExp;

namespace UCM.ast;

public class AdditionNode : BinaryOperation
{
    public AdditionNode(AstNode left, AstNode right) :
        base(left, right)
    {
    }
}

