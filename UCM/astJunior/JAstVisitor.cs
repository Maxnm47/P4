using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.astJunior
{
    public class JAstVisitor<Result>
    {
        public virtual Result Visit(JAstNode node)
        {
            return node.Accept(this);
        }

        public virtual Result VisitNull(JNullNode jNullNode)
        {
            return VisitChildren(jNullNode);
        }

        public Result VisitChildren(JAstNode node)
        {
            Result? result = default;
            foreach (var child in node.Children)
            {
                result ??= Visit(child);
            }

            return result;
        }

        public virtual Result VisitArray(JArrayNode jArrayNode)
        {
            return VisitChildren(jArrayNode);
        }

        public virtual Result VisitBool(JBoolNode jBoolNode)
        {
            return VisitChildren(jBoolNode);
        }

        public virtual Result VisitField(JFieldNode jFieldNode)
        {
            return VisitChildren(jFieldNode);
        }

        public virtual Result VisitFloat(JFloatNode jFloatNode)
        {
            return VisitChildren(jFloatNode);
        }

        public virtual Result VisitInt(JIntNode jIntNode)
        {
            return VisitChildren(jIntNode);
        }

        public virtual Result VisitKey(JKeyNode jKeyNode)
        {
            return VisitChildren(jKeyNode);
        }

        public virtual Result VisitObject(JObjectNode jObjectNode)
        {
            return VisitChildren(jObjectNode);
        }

        public virtual Result VisitString(JStringNode jStringNode)
        {
            return VisitChildren(jStringNode);
        }
    }
}