using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.astJunior;

namespace UCM.astVisitor
{
    public class IntermediateGenerationVisitor : AstBaseVisitor<JAstNode>
    {
        public Stack<Dictionary<string, JAstNode>> SymbolTable = [];

        public Dictionary<string, JAstNode> CurrentScope => SymbolTable.Peek();

        public IntermediateGenerationVisitor()
        {
            SymbolTable.Push([]);
        }

        // public override JAstNode VisitRoot(RootNode node)
        // {
        //     JObjectNode obj = new JObjectNode();
        //     foreach (var field in node.Fields)
        //     {
        //         obj.AddChild(field.Accept(this));
        //     }
        // }
    }
}