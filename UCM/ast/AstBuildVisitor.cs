using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public class AstBuildVisitor : UCMBaseVisitor<AstNode> 
{ 
    public override AstNode VisitRoot(UCMParser.RootContext context)
    {
        AstNode root = new RootNode();
        foreach (var child in context.children)
        {
            AstNode childNode = Visit(child);
            root.AddChild(childNode);
        }

        return root;
    }

    public override AstNode VisitExpr(UCMParser.ExprContext context) {
        AstNode expr = new ExpressionNode();
        
        foreach (var child in context.children)
        {
            AstNode childNode = Visit(child);
            expr.AddChild(childNode);
        }

        return expr;
    }

    public override AstNode VisitField(UCMParser.FieldContext context)
    {
        Console.WriteLine("Visiting Field");
        AstNode typeAnotationNode = Visit(context.type());
        AstNode identifyerNode = new IdentifyerNode(context.ID().GetText());
        AstNode expressionNode = Visit(context.expr());

        return new FieldNode(typeAnotationNode, identifyerNode, expressionNode);
    }

    public override AstNode VisitInt(UCMParser.IntContext context)
    {
        Console.WriteLine("Visiting Int");
        return new IntNode(context.GetText());
    }

    public override AstNode VisitPrimitiveType(UCMParser.PrimitiveTypeContext context)
    {
        Console.WriteLine("Visiting primitive type");
        return new TypeAnotationNode(context.GetText());
    }
}

