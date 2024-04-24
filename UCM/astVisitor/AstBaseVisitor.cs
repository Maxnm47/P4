using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;

namespace UCM.astVisitor
{
    public partial class AstBaseVisitor<T>
    {
        public virtual AstNode? Visit(AstNode node)
        {
            Console.WriteLine(node.GetType());
            return VisitChildren(node);
        }

        public virtual T? VisitChildren<T>(T node) where T : AstNode
        {
            T? result = null;
            foreach (T child in node.children)
            {
                T? nextResult = Visit(child);
                if (nextResult != null)
                {
                    result = nextResult;
                }
            }

            return result;
        }
    }

}