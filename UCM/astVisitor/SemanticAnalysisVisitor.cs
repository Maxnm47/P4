using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.numExpr;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class SemanticAnalysisVisitor : AstBaseVisitor<AstNode>
    {

        public Stack<Dictionary<string, TypeInfo>> ObjectTables { get; set; } = new Stack<Dictionary<string, TypeInfo>>();
        public Stack<Dictionary<string, AstNode>> Scopes { get; set; } = new Stack<Dictionary<string, AstNode>>();
        public List<string> Errors { get; set; } = new List<string>();

        public Dictionary<string, AstNode> CurrentScope => Scopes.Peek();

        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            Scopes.Push(new Dictionary<string, AstNode>());
        }

        public override AstNode VisitField(FieldNode node)
        {
            TypeEnum? type;
            TypeEnum? exprType;
            
            string key = node.Key.Id is not null ? node.Key.Id!.value : Guid.NewGuid().ToString();
            
            if (node.Type != null)
            {

                TypeAnotationNode typeAnotationNode= (TypeAnotationNode)Visit(node.Type);
                type = typeAnotationNode.type;
                ExpressionNode Expr = (ExpressionNode)Visit(node.Expr);
                exprType = Expr.type;
                Console.WriteLine($"Type: {type} ExprType: {exprType}");
            }

            //scope checking
            if(CurrentScope.ContainsKey(key))
            {
                Errors.Add($"Variable {key} already declared in this scope");
            }
            else{
                CurrentScope.Add(key, node);
            } 

            return node; 
        }

        public override AstNode VisitExpression(ExpressionNode node)
        {
            Console.WriteLine("Visiting Expression");

            TypeEnum exprNodeType = TypeEnum.Unknown;
            node.type = exprNodeType;

            foreach (var child in node.children)
            {
                child.Accept(this);
                exprNodeType = child.type;
            }

            node.type = exprNodeType;
            return node;
        }

        public override AstNode VisitTypeAnotation (TypeAnotationNode node)
        {
            return node.type switch
            {
                TypeEnum.Int => new TypeAnotationNode(node.value, TypeEnum.Int),
                TypeEnum.String => new TypeAnotationNode(node.value, TypeEnum.String),
                TypeEnum.Bool => new TypeAnotationNode(node.value, TypeEnum.Bool),
            };
        }



    }
}