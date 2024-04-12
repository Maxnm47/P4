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

        bool isHidden = context.HIDDEN_() is not null;
        bool isTyped = context.type() is not null;

        var hidden = new HiddenAnotationNode(isHidden);

        var type = (isTyped) ?
            (TypeAnotationNode)Visit(context.type()) :
            new TypeAnotationNode(typechecker.TypeEnum.NONE.ToString(), typechecker.TypeEnum.NONE);

        var id = (IdentifyerNode)Visit(context.id());
        var expr = (ExpressionNode)Visit(context.expr());

        return new FieldNode(hidden, type, id, expr);
    }

    public override AstNode VisitMethodCall(UCMParser.MethodCallContext context)
    {
        Console.WriteLine("Visiting MethodCall: " + context.GetText());

        ArgumentsNode arguments = new ArgumentsNode();
        foreach (var child in context.children)
        {
            if (child is UCMParser.ExprContext)
            {
                AstNode expr = Visit(child);
                arguments.AddChild(expr);
            }
        }

        IdentifyerNode identifyer = (IdentifyerNode)Visit(context.id());

        return new MethodCallNode(identifyer, arguments);
    }

    public override IdentifyerNode VisitId(UCMParser.IdContext context)
    {
        Console.WriteLine("Visiting Id: " + context.GetText());
        return new IdentifyerNode(context.GetText());
    }

    public override TypeAnotationNode VisitType(UCMParser.TypeContext context)
    {
        Console.WriteLine("Visiting Type: " + context.GetText());
        return new TypeAnotationNode(context.GetText());
    }

    public override AstNode VisitMethod(UCMParser.MethodContext context)
    {
        Console.WriteLine("Visiting MethodDef: " + context.GetText());

        var id = (IdentifyerNode)Visit(context.id());
        var argumentsDefs = (ArgumentsDefenitionNode)Visit(context.argumentsDef());
        var body = (BodyNode)Visit(context.body());

        return new MethodDefenitionNode(type, id, argumentsDefs, body);
    }

    /* ------------------------ Exxpresions ------------------------ */
    public override ExpressionNode VisitExpr(UCMParser.ExprContext context)
    {
        Console.WriteLine("Visiting Expr: " + context.GetText());
        ExpressionNode expr = new ExpressionNode();

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

    public override IntNode VisitInt(UCMParser.IntContext context)
    {
        Console.WriteLine("Visiting Int: " + context.GetText());
        return new IntNode(int.Parse(context.GetText()));
    }


    public override FloatNode VisitFloat(UCMParser.FloatContext context)
    {
        Console.WriteLine("Visiting Float: " + context.GetText());
        return new FloatNode(float.Parse(context.GetText()));
    }


    /* ------------------------ ComplexValues ------------------------ */

    public override AstLeafNode VisitString(UCMParser.StringContext context)
    {
        Console.WriteLine("Visiting String: " + context.GetText());
        return new StringNode(context.GetText());
    }

    public override AstNode VisitConcatanatedString([NotNull] UCMParser.ConcatanatedStringContext context)
    {
        return base.VisitConcatanatedString(context);
    }

    
    public override AstNode VisitObject(UCMParser.ObjectContext context)
    {
        Console.WriteLine("Visiting Object");
        AstNode objectNode = new ObjectNode();

        foreach (var child in context.children)
        {
            if(child is UCMParser.FieldContext)
            {
                AstNode fieldNode = Visit(child);
                objectNode.AddChild(fieldNode);
            }
        }

        return objectNode;
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

