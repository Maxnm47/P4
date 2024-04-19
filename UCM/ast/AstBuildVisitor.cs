using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using UCM.ast.boolExpr;
using UCM.ast.compExpr;
using UCM.ast.numExpr;
using UCM.ast.boolExpr;
using UCM.ast.complexValues;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.ast.statements.condition;
using UCM.ast.statements.forLoops;
using UCM.ast.statements.whileLoop;

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

        bool isCompounAssignment = context.compoundasign() is not null;

        var hidden = new HiddenAnotationNode(isHidden);
        var type = (isTyped) ?
            (TypeAnotationNode)Visit(context.type()) :
            new TypeAnotationNode(typechecker.TypeEnum.NONE.ToString(), typechecker.TypeEnum.NONE);

        var _id = Visit(context.fieldId());
        FieldId? id = default;

        if (_id is IdentifyerNode idNode)
        {
            id = new FieldId(idNode);
        }
        else if (_id is ExpressionNode exprNode)
        {
            id = new FieldId(exprNode);
        }

        var expr = (ExpressionNode)Visit(context.expr());

        if (!isCompounAssignment)
        {
            return new FieldNode(hidden, type, id, expr);
        }

        string compoundOperator = context.compoundasign().GetText();
        if (compoundOperator == "+=")
        {
            ExpressionNode expr2 = new ExpressionNode();

            expr2.AddChild(new AdditionNode(id, expr));

            return new FieldNode(hidden, type, id, expr2);
        }
        else if (compoundOperator == "-=")
        {
            ExpressionNode expr2 = new ExpressionNode();
            expr2.AddChild(new SubtractionNode(id, expr));
            return new FieldNode(hidden, type, id, expr2);
        }
        else if (compoundOperator == "*=")
        {
            ExpressionNode expr2 = new ExpressionNode();
            expr2.AddChild(new MultiplicationNode(id, expr));
            return new FieldNode(hidden, type, id, expr2);
        }
        else if (compoundOperator == "/=")
        {
            ExpressionNode expr2 = new ExpressionNode();
            expr2.AddChild(new DivisionNode(id, expr));
            return new FieldNode(hidden, type, id, expr2);
        }
        else if (compoundOperator == "%=")
        {
            ExpressionNode expr2 = new ExpressionNode();
            expr2.AddChild(new ModuloNode(id, expr));
            return new FieldNode(hidden, type, id, expr2);
        }

        return null; // skal nok være noget andet
    }

    public override AstNode VisitFieldId([NotNull] UCMParser.FieldIdContext context)
    {
        Console.WriteLine("Visiting FieldId: " + context.GetText());
        if (context.id() is not null)
        {
            return Visit(context.id());
        }
        return Visit(context.stringId());
    }

    /* ------------------------ Statements ------------------------ */
    public override AstNode VisitAssignment(UCMParser.AssignmentContext context)
    {
        Console.WriteLine("Visiting Assignment: " + context.GetText());

        bool isTyped = context.type() is not null;

        var type = (isTyped) ?
            (TypeAnotationNode)Visit(context.type()) :
            new TypeAnotationNode(typechecker.TypeEnum.NONE.ToString(), typechecker.TypeEnum.NONE);
        var id = (IdentifyerNode)Visit(context.id());
        var expr = (ExpressionNode)Visit(context.expr());

        bool isCompounAssignment = context.compoundasign() is not null;

        if (!isCompounAssignment)
        {
            return new AssignmentNode(type, id, expr); //ændre til assignnode
        }

        if (isCompounAssignment)
        {
            string compoundOperator = context.compoundasign().GetText();
            if (compoundOperator == "+=")
            {
                ExpressionNode expr2 = new ExpressionNode();
                expr2.AddChild(new AdditionNode(new IdentifyerNode(id.value), expr));
                return new AssignmentNode(type, id, expr2);
            }
            else if (compoundOperator == "-=")
            {
                ExpressionNode expr2 = new ExpressionNode();
                expr2.AddChild(new SubtractionNode(new IdentifyerNode(id.value), expr));
                return new AssignmentNode(type, id, expr2);
            }
            else if (compoundOperator == "*=")
            {
                ExpressionNode expr2 = new ExpressionNode();
                expr2.AddChild(new MultiplicationNode(new IdentifyerNode(id.value), expr));
                return new AssignmentNode(type, id, expr2);
            }
            else if (compoundOperator == "/=")
            {
                ExpressionNode expr2 = new ExpressionNode();
                expr2.AddChild(new DivisionNode(new IdentifyerNode(id.value), expr));
                return new AssignmentNode(type, id, expr2);
            }
            else if (compoundOperator == "%=")
            {
                ExpressionNode expr2 = new ExpressionNode();
                expr2.AddChild(new ModuloNode(new IdentifyerNode(id.value), expr));
                return new AssignmentNode(type, id, expr2);
            }
        }

        return null; //skal nok være noget andet
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

        if (context.children == null)
        {
            return arguments;
        }

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

        if (context.children == null)
        {
            return body;
        }

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

    public override ConditionalNode VisitConditional(UCMParser.ConditionalContext context)
    {
        Console.WriteLine("Visiting Conditional: " + context.GetText());
        ConditionalNode conditional = new ConditionalNode();

        foreach (var child in context.children)
        {
            if (child is UCMParser.IfStatementContext)
            {
                IfStatementNode ifStatement = (IfStatementNode)Visit(child);
                conditional.AddChild(ifStatement);
            }
            else if (child is UCMParser.StatementListContext)
            {
                BodyNode body = (BodyNode)Visit(child);
                conditional.AddChild(body);
            }
        }

        return conditional;
    }

    public override IfStatementNode VisitIfStatement(UCMParser.IfStatementContext context)
    {
        Console.WriteLine("Visiting IfStatement: " + context.GetText());

        BoolExpr condition = (BoolExpr)Visit(context.boolExpr());
        BodyNode body = (BodyNode)Visit(context.statementList());

        return new IfStatementNode(condition, body);
    }

    public override WhileLoopNode VisitWhileLoop([NotNull] UCMParser.WhileLoopContext context)
    {
        Console.WriteLine("Visiting WhileLoop: " + context.GetText());
        BoolExpr condition = (BoolExpr)Visit(context.boolExpr());
        BodyNode body = (BodyNode)Visit(context.statementList());

        return new WhileLoopNode(condition, body);
    }

    public override ForLoopNode VisitForLoop([NotNull] UCMParser.ForLoopContext context)
    {
        Console.WriteLine("Visiting ForLoop: " + context.GetText());
        IdentifyerNode enumeratorId = (IdentifyerNode)Visit(context.id());
        ExpressionNode loopArray = (ExpressionNode)Visit(context.expr());
        BodyNode body = (BodyNode)Visit(context.statementList());

        return new ForLoopNode(enumeratorId, loopArray, body);
    }

    public override AstNode VisitArray([NotNull] UCMParser.ArrayContext context)
    {
        Console.WriteLine("Visiting Array: " + context.GetText());
        ArrayNode array = new ArrayNode();

        foreach (var child in context.children)
        {
            if (child is UCMParser.ExprContext)
            {
                AstNode expr = Visit(child);
                array.AddChild(expr);
            }
        }

        return array;
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

    public override AstNode VisitBoolExpr([NotNull] UCMParser.BoolExprContext context)
    {
        Console.WriteLine("Visiting BoolExpr: " + context.GetText());
        if (context.AND() != null)
        {
            return new AndNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.OR() != null)
        {
            return new OrNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }

        if (context.compExpr() == null)
        {
            return VisitChildren(context);
        }

        if (context.compExpr().GT() != null)
        {
            return new GreaterThanNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.compExpr().GTE() != null)
        {
            return new GreaterThanOrEqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.compExpr().LT() != null)
        {
            return new LessThanNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.compExpr().LTE() != null)
        {
            return new LessThanOrEqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.compExpr().EQ() != null)
        {
            return new EqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.compExpr().NEQ() != null)
        {
            return new NotEqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }

        return default;
    }

    public override BoolNode VisitBool([NotNull] UCMParser.BoolContext context)
    {
        return new BoolNode(bool.Parse(context.GetText()));
    }

    public override AstNode VisitCompExpr([NotNull] UCMParser.CompExprContext context)
    {
        Console.WriteLine("Visiting CompExpr: " + context.GetText());
        if (context.GT() != null)
        {
            return new GreaterThanNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.GTE() != null)
        {
            return new GreaterThanOrEqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.LT() != null)
        {
            return new LessThanNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else if (context.LTE() != null)
        {
            return new LessThanOrEqualNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0)),
                Visit(context.GetChild<UCMParser.BoolExprContext>(1))
            );
        }
        else
        {
            return VisitChildren(context);
        }
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

    /*public override BoolNode VisitFloat(UCMParser.BoolExprContext context)
    {
        Console.WriteLine("Visiting Bool: " + context.GetText());
        return new BoolNode(bool.Parse(context.GetText()));
    }*/


    /* ------------------------ Complex Types ------------------------ */
    public override ObjectNode VisitObject(UCMParser.ObjectContext context)
    {
        Console.WriteLine("Visiting Object");
        ObjectNode objectNode = new ObjectNode();

        foreach (var child in context.children)
        {
            if (child is UCMParser.FieldContext)
            {
                AstNode fieldNode = Visit(child);
                objectNode.AddChild(fieldNode);
            }
        }

        return objectNode;
    }

    /* ------------------------ Strings and stuff ------------------------ */
    public override StringNode VisitString([NotNull] UCMParser.StringContext context)
    {
        Console.WriteLine("Visiting String: " + context.GetText());
        string content = CleanString(context.GetText());

        StringNode stringNode = new StringNode(content);
        return stringNode;
    }


    public override AugmentedStringNode VisitAugmentedString([NotNull] UCMParser.AugmentedStringContext context)
    {
        Console.WriteLine("Visiting augmented string " + context.GetText());
        AugmentedStringNode augmentedStringNode = new AugmentedStringNode();

        foreach (var child in context.children)
        {
            if (child is Antlr4.Runtime.Tree.TerminalNodeImpl terminalNode)
            {
                string strvalue = CleanString(terminalNode.GetText());

                if (strvalue.Length == 0) continue; //den er linje kan ædelægge det hele, dette er for ikke at have et tomt barn

                StringNode stringExpr = new StringNode(strvalue);
                augmentedStringNode.AddChild(stringExpr);
            }
            else if (child is UCMParser.ExprContext exprContext)
            {
                ExpressionNode expr = (ExpressionNode)Visit(exprContext);
                augmentedStringNode.AddChild(expr);
            }
            else if (child is UCMParser.StringExprContext stringExprContext)
            {

                ExpressionNode expr = (ExpressionNode)Visit(stringExprContext);
                augmentedStringNode.AddChild(expr);
            }
        }

        return augmentedStringNode;
    }


    public override AstNode VisitStringExpr([NotNull] UCMParser.StringExprContext context)
    {
        Console.WriteLine("Visiting StringExpr: " + context.GetText());
        if (context.PLUS() != null)
        {
            return new AdditionNode(
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

    string CleanString(string str)
    {
        str = str.Remove(str.Length - 1);
        str = str.Remove(0, str[0].Equals('$') ? 2 : 1);
        str.Trim('`', '´');

        return str;
    }
}

