using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using UCM.ast.numExp;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.ast.statements.condition;

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

    public override MethodCollectionNode VisitFunctionCollection(UCMParser.FunctionCollectionContext context)
    {
        Console.WriteLine("Visiting MethodCollection: " + context.GetText());
        MethodCollectionNode methodCollection = new MethodCollectionNode();
        foreach (var child in context.children)
        {
            if (child is UCMParser.MethodContext)
            {
                AstNode method = Visit(child);
                methodCollection.AddChild(method);
            }
        }

        return methodCollection;
    }

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

    /* ------------------------ Statements ------------------------ */
    public override AstNode VisitAssignment(UCMParser.AssignmentContext context)
    {
        Console.WriteLine("Visiting Assignment: " + context.GetText());

        bool isTyped = context.type() is not null;

        var hidden = new HiddenAnotationNode(false);
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
        var type = (TypeAnotationNode)Visit(context.type());
        var id = (IdentifyerNode)Visit(context.id());
        var argumentsDefs = (ArgumentsDefenitionNode)Visit(context.arguments());
        var body = (BodyNode)Visit(context.statementList());

        return new MethodDefenitionNode(type, id, argumentsDefs, body);
    }

    public override ArgumentsDefenitionNode VisitArguments(UCMParser.ArgumentsContext context)
    {
        Console.WriteLine("Visiting Arguments: " + context.GetText());
        ArgumentsDefenitionNode arguments = new ArgumentsDefenitionNode();
        foreach (var child in context.children)
        {
            if (child is UCMParser.ArgumentContext)
            {
                AstNode argument = Visit(child);
                arguments.AddChild(argument);
            }
        }

        return arguments;
    }

    public override AstNode VisitArgument(UCMParser.ArgumentContext context)
    {
        Console.WriteLine("Visiting Argument: " + context.GetText());
        var type = (TypeAnotationNode)Visit(context.type());
        var id = (IdentifyerNode)Visit(context.id());

        return new ArgumentDefenitionNode(type, id);
    }

    public override BodyNode VisitStatementList(UCMParser.StatementListContext context)
    {
        Console.WriteLine("Visiting StatementList: " + context.GetText());
        BodyNode body = new BodyNode();
        foreach (var child in context.children)
        {
            if (child is UCMParser.StatementContext)
            {
                AstNode statement = Visit(child);
                body.AddChild(statement);
            }
        }

        return body;
    }

    public override AstNode VisitReturn_(UCMParser.Return_Context context)
    {
        Console.WriteLine("Visiting Return: " + context.GetText());
        ReturnNode returnNode = new ReturnNode();

        if (context.expr() != null)
        {
            returnNode.AddChild(Visit(context.expr()));
        }
        else
        {
            returnNode.AddChild(new VoidNode());
        }

        return returnNode;
    }

    public override AstNode VisitStatement(UCMParser.StatementContext context)
    {
        Console.WriteLine("Visiting Statement: " + context.GetText());

        if (context.conditional() != null)
        {
            return Visit(context.conditional());
        }
        else if (context.assignment() != null)
        {
            return Visit(context.assignment());
        }
        else if (context.whileLoop() != null)
        {
            return Visit(context.whileLoop());
        }
        else if (context.forLoop() != null)
        {
            return Visit(context.forLoop());
        }
        else if (context.methodCall() != null)
        {
            return Visit(context.methodCall());
        }
        else if (context.method() != null)
        {
            return Visit(context.method());
        }
        else if (context.field() != null)
        {
            return Visit(context.field());
        }
        else if (context.return_() != null)
        {
            return Visit(context.return_());
        }
        else
        {
            return VisitChildren(context);
        }
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



    /* ------------------------ Complex Types ------------------------ */ 
    public override ObjectNode VisitObject(UCMParser.ObjectContext context)
    {
        Console.WriteLine("Visiting Object");
        ObjectNode objectNode = new ObjectNode();

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

    
    /* ------------------------ Strings and shit ------------------------ */
    public override StringNode VisitString([NotNull] UCMParser.StringContext context)
    {
        Console.WriteLine("Visiting String: " + context.GetText());

        StringNode stringNode = new StringNode(context.GetText());
        return stringNode;
    }

    public override AstNode VisitStringExpr([NotNull] UCMParser.StringExprContext context)
    {
        Console.WriteLine("Visiting StringExpr" + context.GetText());        
        if (context.PLUS != null){
        return new AdditionNode
            (
                Visit(context.GetChild<UCMParser.StringExprContext>(0)),
                Visit(context.GetChild<UCMParser.StringExprContext>(1))
            );
        }

        return VisitChildren(context);
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

