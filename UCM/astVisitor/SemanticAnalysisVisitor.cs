using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.statements;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class SemanticAnalysisVisitor : AstBaseVisitor<string>
    {
        public Stack<Dictionary<string, AstNode>> Scopes { get; set; } = new Stack<Dictionary<string, AstNode>>();

        // Errors
        public List<string> Errors { get; set; } = new List<string>();

        public Dictionary<string, AstNode> CurrentScope => Scopes.Peek();

        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            Scopes.Push(new Dictionary<string, AstNode>());
        }

        public override string VisitField(FieldNode node)
        {
            FieldId key = node.Key;
            string referenceId;

            // In case the field uses dynamic key asignment, the actual key can only be known later upon evaluation
            if (key.Id is null)
            {
                referenceId = Guid.NewGuid().ToString();
                node.referenceId = referenceId;
                CurrentScope.Add(referenceId, node);
                return base.VisitField(node);
            };

            referenceId = key.Id!.value;

            if (CurrentScope.ContainsKey(referenceId))
            {
                Errors.Add($"Error: Field {referenceId} already declared in scope.");
                return base.VisitField(node);
            }

            node.referenceId = referenceId;
            CurrentScope.Add(referenceId, node);

            return base.VisitField(node);
        }

        public override string VisitExpression(ExpressionNode node)
        {
            return base.VisitExpression(node);
        }
    }
}