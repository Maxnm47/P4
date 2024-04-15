using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast.statements
{
    public class MethodDefenitionNode : AstNode
    {
        public MethodDefenitionNode(
            TypeAnotationNode type,
            IdentifyerNode id,
            ArgumentsDefenitionNode argumentsDefs,
            BodyNode body)
        {
            children.Add(type);
            children.Add(id);
            children.Add(argumentsDefs);
            children.Add(body);
        }

        public TypeAnotationNode Type => GetChild<TypeAnotationNode>(0);
        public IdentifyerNode Id => GetChild<IdentifyerNode>(0);
        public ArgumentsDefenitionNode ArgumentsDefs => GetChild<ArgumentsDefenitionNode>(0);
        public BodyNode Body => GetChild<BodyNode>(0);
    }


}