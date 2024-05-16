using Antlr4.Runtime.Misc;
using UCM.ast.boolExpr;
using UCM.ast.numExpr;
using UCM.ast.complexValues;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.ast.statements.condition;
using UCM.ast.statements.forLoops;
using UCM.ast.statements.whileLoop;
using UCM.ast.loopConstruction;
using System.Runtime.CompilerServices;
using UCM.scope;
using UCM.typechecker;
using System.Globalization;

namespace UCM.ast;

public class AstBuildVisitor : UCMBaseVisitor<AstNode>
{
    /* ------------------------ Root ------------------------ */

    public override AstNode VisitRoot(UCMParser.RootContext context)
    {
        Console.WriteLine("Visiting Root: " + context.GetText());
        List<FieldNode> fields = context.field().Select(field => (FieldNode)Visit(field)).ToList();
        List<MethodCollectionNode> methodCollections = context.functionCollection().Select(methodCollection => (MethodCollectionNode)Visit(methodCollection)).ToList();
        List<TemplateNode> templates = context.templateDefenition().Select(template => (TemplateNode)Visit(template)).ToList();

        return new RootNode(methodCollections, templates, fields);
    }

    public override MethodCollectionNode VisitFunctionCollection(UCMParser.FunctionCollectionContext context)
    {
        Console.WriteLine("Visiting MethodCollection: " + context.GetText());

        IdentifyerNode id = (IdentifyerNode)Visit(context.id());
        List<MethodDefenitionNode> methods = context.method().Select(method => (MethodDefenitionNode)Visit(method)).ToList();

        return new MethodCollectionNode(id, methods);
    }

    public override AstNode VisitTemplateDefenition(UCMParser.TemplateDefenitionContext context)
    {
        Console.WriteLine("Visiting Template: " + context.GetText());

        IdentifyerNode id = (IdentifyerNode)Visit(context.id());
        List<TemplateFieldNode> fields = context.templateField().Select(field => (TemplateFieldNode)Visit(field)).ToList();
        List<MethodDefenitionNode> methods = context.method().Select(method => (MethodDefenitionNode)Visit(method)).ToList();
        IdentifyerNode? parent = context.templateExtention() is not null ? (IdentifyerNode)Visit(context.templateExtention()) : null;


        return new TemplateNode(id, fields, methods, parent);
    }


    public override AstNode VisitTemplateField(UCMParser.TemplateFieldContext context)
    {
        Console.WriteLine("Visiting TemplateField: " + context.GetText());
        IdentifyerNode id = (IdentifyerNode)Visit(context.id());
        TypeAnotationNode type = (TypeAnotationNode)Visit(context.type());
        ExpressionNode? expr = context.expr() is not null ? (ExpressionNode)Visit(context.expr()) : null;

        if (context.evaluaterArray() is null)
        {
            return new TemplateFieldNode(type, id, expr);
        }

        ArrayNode array = (ArrayNode)Visit(context.evaluaterArray());
        return new TemplateFieldNode(type, id, expr, array);
    }

    public override ArrayNode VisitEvaluaterArray(UCMParser.EvaluaterArrayContext context)
    {
        Console.WriteLine("Visiting EvaluaterArray: " + context.GetText());

        List<ExpressionNode> expressions = context.expr().Select(expr => (ExpressionNode)Visit(expr)).ToList();

        return new ArrayNode(expressions);
    }

    public override AstNode VisitField(UCMParser.FieldContext context)
    {
        Console.WriteLine("Visiting Field: " + context.GetText());
        bool isHidden = context.HIDDEN_() is not null;
        bool isTyped = context.type() is not null;

        bool isCompounAssignment = context.compoundasign() is not null;

        var hidden = isHidden ? new HiddenAnotationNode(isHidden) : null;
        var type = (isTyped) ?
            (TypeAnotationNode)Visit(context.type()) :
            null;

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
            new TypeAnotationNode(typechecker.TypeEnum.None.ToString(), typechecker.TypeEnum.None);
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

        if (context.GetText() == "void")
        {
            return new TypeAnotationNode(typechecker.TypeEnum.Void.ToString(), typechecker.TypeEnum.Void);
        }
        else if (context.GetText() == "string")
        {
            return new TypeAnotationNode(typechecker.TypeEnum.String.ToString(), typechecker.TypeEnum.String);
        }
        else if (context.GetText() == "int")
        {
            return new TypeAnotationNode(typechecker.TypeEnum.Int.ToString(), typechecker.TypeEnum.Int);
        }
        else if (context.GetText() == "float")
        {
            return new TypeAnotationNode(typechecker.TypeEnum.Float.ToString(), typechecker.TypeEnum.Float);
        }
        else if (context.GetText() == "bool")
        {
            return new TypeAnotationNode(typechecker.TypeEnum.Bool.ToString(), typechecker.TypeEnum.Bool);
        }
        else if (context.complexType() != null)
        {
            return (TypeAnotationNode)Visit(context.complexType());
        }

        return new TypeAnotationNode(context.GetText(), typechecker.TypeEnum.Undefined);
    }

    public override TypeAnotationNode VisitComplexType(UCMParser.ComplexTypeContext context)
    {
        Console.WriteLine("Visiting ComplexType: " + context.GetText());

        if (context.object_t() != null)
        {
            return new TypeAnotationNode(context.object_t().GetText(), typechecker.TypeEnum.Object);
        }
        else if (context.array_t() != null)
        {
            return new TypeAnotationNode(context.array_t().GetText(), typechecker.TypeEnum.Array);
        }

        return new TypeAnotationNode(context.GetText(), typechecker.TypeEnum.Undefined);
    }

    public override AstNode VisitMethod(UCMParser.MethodContext context)
    {
        Console.WriteLine("Visiting MethodDef: " + context.GetText());
        var type = (TypeAnotationNode)Visit(context.type());
        var id = (IdentifyerNode)Visit(context.id());
        List<ArgumentDefenitionNode> arguments = context.arguments()
            .argument()
            .Select(argument => (ArgumentDefenitionNode)Visit(argument))
            .ToList();

        var body = (BodyNode)Visit(context.statementList());

        return new MethodDefenitionNode(type, id, arguments, body);
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

        ExpressionNode condition = (ExpressionNode)Visit(context.expr());
        BodyNode body = (BodyNode)Visit(context.statementList());

        return new IfStatementNode(condition, body);
    }

    public override WhileLoopNode VisitWhileLoop([NotNull] UCMParser.WhileLoopContext context)
    {
        Console.WriteLine("Visiting WhileLoop: " + context.GetText());
        ExpressionNode condition = (ExpressionNode)Visit(context.expr());
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
        if(expr.children.Count == 0)
        {
            expr.AddChild(new NullNode("null"));
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
        else if (context.NOT() != null)
        {
            return new NotNode(
                Visit(context.GetChild<UCMParser.BoolExprContext>(0))
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
            AstNode left = null;
            AstNode right = null;

            for (int i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);

                if(child is UCMParser.BoolExprContext)
                {
                    if (left == null)
                        left = Visit(child as UCMParser.BoolExprContext);
                    else
                        right = Visit(child as UCMParser.BoolExprContext);
                }
                else if(child is UCMParser.NumExprContext)
                {
                    if (left == null)
                        left = Visit(child as UCMParser.NumExprContext);
                    else
                        right = Visit(child as UCMParser.NumExprContext);
                }
            }

            return new EqualNode(left, right);
        }

        else if (context.compExpr().NEQ() != null)
        {
            AstNode left = null;
            AstNode right = null;

            for (int i = 0; i < context.ChildCount; i++)
            {
                var child = context.GetChild(i);

                if(child is UCMParser.BoolExprContext)
                {
                    if (left == null)
                        left = Visit(child as UCMParser.BoolExprContext);
                    else
                        right = Visit(child as UCMParser.BoolExprContext);
                }
                else if(child is UCMParser.NumExprContext)
                {
                    if (left == null)
                        left = Visit(child as UCMParser.NumExprContext);
                    else
                        right = Visit(child as UCMParser.NumExprContext);
                }
            }

            return new NotEqualNode(left, right);
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
        return new FloatNode(float.Parse(context.GetText(), CultureInfo.InvariantCulture));
    }




    /* ------------------------ Complex Types ------------------------ */
    public override ObjectNode VisitObject(UCMParser.ObjectContext context)
    {
        Console.WriteLine("Visiting Object");
        ObjectNode objectNode = new ObjectNode();

        if (context.adapting() != null)
        {
            objectNode.AddChild(Visit(context.adapting()));
        }

        foreach (var child in context.children)
        {
            if (child is UCMParser.FieldContext)
            {
                AstNode fieldNode = Visit(child);
                objectNode.AddChild(fieldNode);
            }

            if (child is UCMParser.LoopConstructionContext)
            {
                AstNode listConstruction = Visit(child);
                objectNode.AddChild(listConstruction);
            }
        }

        return objectNode;
    }

    public override ObjectFieldAcessNode VisitObjectFieldAcess(UCMParser.ObjectFieldAcessContext context)
    {
        Console.WriteLine("Visiting ObjectFieldAcess: " + context.GetText());
        List<AstNode> ids = new List<AstNode>();
        foreach (var child in context.children)
        {
            if (child is UCMParser.IdContext)
            {
                AstNode id = Visit(child);
                ids.Add(id);
            }
            if(child is UCMParser.ArrayAccessContext)
            {
                AstNode arrayAccess = Visit(child);
                ids.Add(arrayAccess);
            }
        }
        
        return new ObjectFieldAcessNode(ids);
    }


    public override AstNode VisitArray([NotNull] UCMParser.ArrayContext context)
    {
        Console.WriteLine("Visiting Array: " + context.GetText());
        ArrayNode array = new ArrayNode();

        foreach (var child in context.children)
        {
            if (child is UCMParser.ArrayElementContext)
            {
                AstNode expr = Visit(child);
                array.AddChild(expr);
            }

            if (child is UCMParser.LoopConstructionContext)
            {
                AstNode x = Visit(child);
                array.AddChild(x);
            }

            if (child is UCMParser.RangeContext)
            {
                AstNode range = Visit(child);
                array.AddChild(range);
            }
        }

        return array;
    }

    public override AstNode VisitRange([NotNull] UCMParser.RangeContext context)
    {
        Console.WriteLine("Visiting Range: " + context.GetText());
        ExpressionNode start = (ExpressionNode)Visit(context.expr(0));
        ExpressionNode end = (ExpressionNode)Visit(context.expr(1));

        return new RangeNode(start, end);
    }

    public override AstNode VisitArrayAccess([NotNull] UCMParser.ArrayAccessContext context)
    {
        List<ExpressionNode> indexs = context.expr().Select(expr => (ExpressionNode)Visit(expr)).ToList();

        IdentifyerNode arrayName = Visit(context.id()) as IdentifyerNode;

        return new ArrayAccessNode(arrayName, indexs);
    }


    public override LoopConstructionNode VisitLoopConstruction([NotNull] UCMParser.LoopConstructionContext context)
    {
        Console.WriteLine("Visiting ListConstruction: " + context.GetText());


        TypeAnotationNode? type = (context.type() != null) ? (TypeAnotationNode)Visit(context.type()) : null;

        IdentifyerNode entity = (IdentifyerNode)Visit(context.id());
        ExpressionNode array = (ExpressionNode)Visit(context.expr());
        LoopConstructContentNode evaluationContent = (LoopConstructContentNode)Visit(context.loopConstructContent());

        return new LoopConstructionNode(type, entity, array, evaluationContent);
    }

    public override LoopConstructContentNode VisitLoopConstructContent([NotNull] UCMParser.LoopConstructContentContext context)
    {
        Console.WriteLine("Visiting LoopConstructContent: " + context.GetText());
        LoopConstructContentNode loopConstructContent = new LoopConstructContentNode();

        foreach (var child in context.children)
        {
            if (child is UCMParser.ExprContext || child is UCMParser.FieldContext)
            {
                AstNode content = Visit(child);
                loopConstructContent.AddChild(content);
            }
        }

        return loopConstructContent;
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

