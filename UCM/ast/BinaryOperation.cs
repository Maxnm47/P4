namespace UCM.ast
{
    public abstract class BinaryOperation : AstNode
    {
        public BinaryOperation(AstNode left, AstNode right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            children.Add(left);
            children.Add(right);
        }

        public AstNode Left => GetChild<AstNode>(0);

        public AstNode Right => GetChild<AstNode>(1);
    }
}
