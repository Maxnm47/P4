using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using UCM.ast.numExp;
using UCM.ast.statements;

namespace UCM.ast;

public class AstBuildVisitor : UCMBaseVisitor<AstNode>
{
    /* ------------------------ Root ------------------------ */
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

    /* ------------------------ Statements ------------------------ */
    public override AstNode VisitField(UCMParser.FieldContext context)
    {
        Console.WriteLine("Visiting Field: " + context.GetText());
        AstNode typeAnotationNode = Visit(context.type());
        AstNode identifyerNode = Visit(context.id());
        AstNode expressionNode = Visit(context.expr());

        return new FieldNode(typeAnotationNode, identifyerNode, expressionNode);
    }

    public override AstNode VisitMethodCall(UCMParser.MethodCallContext context)
    {
        Console.WriteLine("Visiting MethodCall: " + context.GetText());
        AstNode methodCall = new MethodCallNode(context.GetText());

        foreach (var child in context.children)
        {
            if (child is UCMParser.ExprContext)
            {
                AstNode expr = Visit(child);
                methodCall.AddChild(expr);
            }
        }

        return methodCall;
    }

    public override AstNode VisitId(UCMParser.IdContext context)
    {
        Console.WriteLine("Visiting Id: " + context.GetText());
        return new IdentifyerNode(context.GetText());
    }

    public override AstNode VisitType(UCMParser.TypeContext context)
    {
        Console.WriteLine("Visiting Type: " + context.GetText());
        return new TypeAnotationNode(context.GetText());
    }

    /* ------------------------ Exxpresions ------------------------ */
    public override AstNode VisitExpr(UCMParser.ExprContext context)
    {
        Console.WriteLine("Visiting Expr: " + context.GetText());
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
            return new MultiplicationNode(
                Visit(context.GetChild<UCMParser.NumExprContext>(0)),
                Visit(context.GetChild<UCMParser.NumExprContext>(1))
            );
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

    public override AstNode VisitInt(UCMParser.IntContext context)
    {
        Console.WriteLine("Visiting Int: " + context.GetText());
        return new IntNode(context.GetText());
    }


    public override AstNode VisitFloat(UCMParser.FloatContext context)
    {
        Console.WriteLine("Visiting Float: " + context.GetText());
        return new FloatNode(context.GetText());
    }




    /* ------------------------ Utility ------------------------ */
    protected override AstNode AggregateResult(AstNode aggregate, AstNode nextResult)
    {
        if (nextResult == null)
        {
            return aggregate;
        }

        return nextResult;
    }
}

