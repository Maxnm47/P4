using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UCM.ast;

public class AstBuildVisitor : UCMBaseVisitor<AstNode> 
{ 
    // public override AstNode VisitStart(UCMParser.StartContext context)
    // {
    //     return Visit(context.);
    // }

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

