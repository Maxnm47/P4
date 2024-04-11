using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using UCM.ast.numExp;

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

    public override AstNode VisitExpr(UCMParser.ExprContext context)
    {
        AstNode expr = new ExpressionNode();

        foreach (var child in context.children)
        {
            AstNode childNode = Visit(child);
            expr.AddChild(childNode);
        }

        return expr;
    }

    public override AstNode VisitNumExpr([NotNull] UCMParser.NumExprContext context)
    {
        Console.WriteLine("Visiting NumExpr: " + context.GetText());
        if (context.PLUS() != null)
        {
            return new AdditionNode(
                Visit(context.GetChild<UCMParser.NumExprContext>(0)),
                Visit(context.GetChild<UCMParser.NumExprContext>(1))
            );
        }
        else if (context.MINUS() != null)
        {
            return new SubtractionNode(
                Visit(context.GetChild<UCMParser.NumExprContext>(0)),
                Visit(context.GetChild<UCMParser.NumExprContext>(1))
            );
        }
        else if (context.MULT() != null)
        {
            AstNode c1 = Visit(context.GetChild<UCMParser.NumExprContext>(0));
            AstNode c2 = Visit(context.GetChild<UCMParser.NumExprContext>(1));
            AstNode dud = new MultiplicationNode(c1, c2);
            return dud;
        }
        else if (context.DIV() != null)
        {
            return new DivisionNode(
                Visit(context.GetChild<UCMParser.NumExprContext>(0)),
                Visit(context.GetChild<UCMParser.NumExprContext>(1))
            );
        }
        else if (context.MOD() != null)
        {
            return new ModuloNode(
                Visit(context.GetChild<UCMParser.NumExprContext>(0)),
                Visit(context.GetChild<UCMParser.NumExprContext>(1))
            );
        }
        else
        {
            return VisitChildren(context);
        }
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

    public override AstNode VisitFloat(UCMParser.FloatContext context)
    {
        Console.WriteLine("Visiting Float");
        return new FloatNode(context.GetText());
    }

    protected override AstNode AggregateResult(AstNode aggregate, AstNode nextResult)
    {
        if (nextResult == null)
        {
            return aggregate;
        }

        return nextResult;
    }
}

