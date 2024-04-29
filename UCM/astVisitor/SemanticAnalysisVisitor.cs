using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UCM.ast;
using UCM.ast.boolExpr;
using UCM.ast.complexValues;
using UCM.ast.numExpr;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class SemanticAnalysisVisitor : AstBaseVisitor<AstNode>
    {

        public Stack<Dictionary<string, ObjectNode>> ObjectTables { get; set; } = new Stack<Dictionary<string, ObjectNode>>();
        public Stack<Dictionary<string, AstNode>> Scopes { get; set; } = new Stack<Dictionary<string, AstNode>>();
        public List<string> Errors { get; set; } = new List<string>();

        public Dictionary<string, AstNode> CurrentScope => Scopes.Peek();

        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            Scopes.Push(new Dictionary<string, AstNode>());
        }

        public override AstNode VisitRoot(RootNode node)
        {
            foreach (var field in node.Fields)
            {
                Visit(field);
            }
            foreach (var methodCollection in node.MethodCollections)
            {
                Visit(methodCollection);
            }
            foreach (var template in node.Templates)
            {
                Visit(template);
            }

            return node;
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
                node.type = (TypeEnum)type; // set the type of the field

                if(type != exprType)
                {
                    Errors.Add($"Type mismatch in field {key}");
                }
            }
                        
            //scope checking
            if(CurrentScope.ContainsKey(key))
            {
                Errors.Add($"Variable {key} already declared in this scope");
            }
            else{
                Console.WriteLine("Adding field to scope");
                CurrentScope.Add(key, node);
            } 

            return node; 
        }

        public override AstNode VisitExpression(ExpressionNode node)
        {
            AstNode firstChild= Visit(node.children[0]);
            
            node.type = firstChild.type;
            
            foreach (var child in node.children.Skip(0)) 
            {
                child.Accept(this);
                node.type = child.type;
            }

            return node;
        }

        public override AstNode VisitAddition(AdditionNode node)
        {
            
            AstNode left = Visit(node.Left);
            AstNode right = Visit(node.Right);
            if (left is IdentifyerNode identifierNode)
            {   
                Console.WriteLine("Left is an identifier");
                left = CurrentScope[identifierNode.value];
                left.type = CurrentScope[identifierNode.value].type;
            }
            if (right is IdentifyerNode identifierNode1)
            {
                Console.WriteLine("Right is an identifier");
                right = CurrentScope[identifierNode1.value];
                right.type = CurrentScope[identifierNode1.value].type;
            }

            if (!(left.type == TypeEnum.Int || left.type == TypeEnum.Float || left.type == TypeEnum.String) ||
                !(right.type == TypeEnum.Int || right.type == TypeEnum.Float || right.type == TypeEnum.String))
            {
                Console.WriteLine("Type mismatch in addition, illegal type cannot add " + left.type + " and " + right.type);
            }

            if (left.type != right.type)
            {
                Errors.Add("Type mismatch in addition");
            }

            node.type = left.type;
            return node;
        }

        public override AstNode VisitIdentifyer(IdentifyerNode node)
        {
            foreach (var scope in Scopes)
            {
                if (scope.ContainsKey(node.value))
                {
                    return scope[node.value];
                }
            }
            Errors.Add($"Variable {node.value} not declared in this scope");
            return node;
        }
        public override AstNode VisitTypeAnotation (TypeAnotationNode node)
        {
            return node.type switch
            {
                TypeEnum.Int => new TypeAnotationNode(node.value, TypeEnum.Int),
                TypeEnum.Float => new TypeAnotationNode(node.value, TypeEnum.Float),
                TypeEnum.String => new TypeAnotationNode(node.value, TypeEnum.String),
                TypeEnum.Bool => new TypeAnotationNode(node.value, TypeEnum.Bool),
            };
        }

        public override AstNode VisitTemplate(TemplateNode node)
        {

            CurrentScope.Add(node.Id.value, node);

            Scopes.Push(new Dictionary<string, AstNode>());
            foreach (var field in node.Fields)
            {
               AstNode templateField = Visit(field);
               //DER ER IKKE NOGET FIELDID
               CurrentScope.Add(field.Id.value, templateField);
            }

            return node;
        }

        public override AstNode VisitTemplateField(TemplateFieldNode node)
        {
            TypeEnum type;
            TypeEnum? exprType;
            
            TypeAnotationNode typeAnotationNode= (TypeAnotationNode)Visit(node.Type);
            type = typeAnotationNode.type;
            
            if(node.Expr != null){
                ExpressionNode Expr = (ExpressionNode)Visit(node.Expr);
                exprType = Expr.type;
                if(type != exprType)
                { 
                    Console.WriteLine(type + " ____" +  exprType);  //hvorfor er den pik???
                    Errors.Add($"Type mismatch in field {node.Id.value}");
                }

                AstNode test = Visit(node.Expr);
                if(Visit(test) is IdentifyerNode){
                    
                    test = CurrentScope[((IdentifyerNode) test).value];
                    
                }

            }

            node.type = type;
            return node;
        }

        public override AstNode VisitInt(IntNode node)
        {
            node.type = TypeEnum.Int;
            return node;
        }

        public override AstNode VisitBool(BoolNode node)
        {
            node.type = TypeEnum.Bool;
            return node;
        }

        public override AstNode VisitFloat(FloatNode node)
        {
            node.type = TypeEnum.Float;
            return node;
        }

        public override AstNode VisitObject(ObjectNode node)
        {
            node.type = TypeEnum.Object;
            return node;
        }

        public override AstNode VisitString(StringNode node)
        {
            node.type = TypeEnum.String;
            return node;
        }
    }
}