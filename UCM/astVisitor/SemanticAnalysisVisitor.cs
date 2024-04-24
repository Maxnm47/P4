using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Xml.XPath;
using Newtonsoft.Json;
using UCM.ast;
using UCM.ast.statements;
using UCM.scope;
using UCM.tables;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class VisitorReturn
    {
        public TypeEnum Type { get; set; }
        public string? Id { get; set; }
    }
    public class SemanticAnalysisVisitor : AstBaseVisitor<VisitorReturn>
    {
        
       private Stack<Scope> ScopeStack { get; } = new Stack<Scope>();
        private void EnterScope(Scope scope) 
        {
            if (ScopeStack.Count() != 0) 
            {
                scope.CopyFrom(GetCurrentScope()); 
            }
            ScopeStack.Push(scope);
        }

        private void ExitScope()
        {
            _ = ScopeStack.Pop();
        }
        private Scope GetCurrentScope()
        {
            return ScopeStack.Peek();
}
        // Errors
        public List<string> Errors { get; set; } = new List<string>();
        

        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            ScopeStack.Push(new Scope());
        }

        public override VisitorReturn VisitField(FieldNode node)
        {
            Console.WriteLine("Visiting AST FieldNode");
            string id = node.Key.Id.value;
            ExpressionNode expressionNode = node.Expr;
            TypeEnum type = node.Type.type;
            VisitorReturn expr = Visit(expressionNode);
            if(expr.Type != type)
            {
                Errors.Add("Type mismatch");
                Console.WriteLine("Type mismatch");
            }

            Console.WriteLine("this is isd" +expr.Id);
            

            
            VTableEntry vTableEntry = new VTableEntry(type, expressionNode);
            

            
    
            return base.VisitField(node);
        }

        public override VisitorReturn VisitExpression(ExpressionNode node)
        {
            Console.WriteLine("Visiting AST ExpressionNode");
            TypeEnum type = Visit(node.children[0]).Type;
            string id = null;
            foreach (var child in node.children.Skip(1))
            {
                if(child is IdentifyerNode){
                    id = ((IdentifyerNode)child).value;
                }
                if (type != Visit(child).Type)
                {
                    Errors.Add("Type mismatch");
                    Console.WriteLine("Type mismatch"); 
                }
            }
            return new VisitorReturn { Type = type, Id = id };
        }

        public override VisitorReturn VisitInt(IntNode node)
        {
            Console.WriteLine("Visiting AST IntNode");
            return new VisitorReturn { Type = TypeEnum.INT, Id = node.value.ToString() };
        }
    }
}