using Antlr4.Runtime.Misc;

namespace UCM
{
    public class CustomUCMVisitor : UCMBaseVisitor<object>
    {
        public override object VisitObject_t([NotNull] UCMParser.Object_tContext context)
        {
            Console.WriteLine("Visiting Object_t");
            return base.VisitObject_t(context);
        }

        public override object VisitArray_t([NotNull] UCMParser.Array_tContext context)
        {
            Console.WriteLine("Visiting Array_t");
            return base.VisitArray_t(context);
        }

        public override object VisitPrimitiveType([NotNull] UCMParser.PrimitiveTypeContext context)
        {
            Console.WriteLine("Visiting PrimitiveType");
            return base.VisitPrimitiveType(context);
        }

        public override object VisitComplexType([NotNull] UCMParser.ComplexTypeContext context)
        {
            Console.WriteLine("Visiting ComplexType");
            return base.VisitComplexType(context);
        }

        public override object VisitType([NotNull] UCMParser.TypeContext context)
        {
            Console.WriteLine("Visiting Type");
            return base.VisitType(context);
        }

        public override object VisitInt([NotNull] UCMParser.IntContext context)
        {
            Console.WriteLine("Visiting Int");
            return base.VisitInt(context);
        }

        public override object VisitFloat([NotNull] UCMParser.FloatContext context)
        {
            Console.WriteLine("Visiting Float");
            return base.VisitFloat(context);
        }

        public override object VisitNum([NotNull] UCMParser.NumContext context)
        {
            Console.WriteLine("Visiting Num");
            return base.VisitNum(context);
        }

        public override object VisitValue([NotNull] UCMParser.ValueContext context)
        {
            Console.WriteLine("Visiting Value");
            return base.VisitValue(context);
        }

        public override object VisitAugmentedString([NotNull] UCMParser.AugmentedStringContext context)
        {
            Console.WriteLine("Visiting AugmentedString");
            return base.VisitAugmentedString(context);
        }

        public override object VisitConcatanatedString([NotNull] UCMParser.ConcatanatedStringContext context)
        {
            Console.WriteLine("Visiting ConcatanatedString");
            return base.VisitConcatanatedString(context);
        }

        public override object VisitString([NotNull] UCMParser.StringContext context)
        {
            Console.WriteLine("Visiting String");
            return base.VisitString(context);
        }

        public override object VisitTypedId([NotNull] UCMParser.TypedIdContext context)
        {
            Console.WriteLine("Visiting TypedId");
            return base.VisitTypedId(context);
        }

        public override object VisitAdapting([NotNull] UCMParser.AdaptingContext context)
        {
            Console.WriteLine("Visiting Adapting");
            return base.VisitAdapting(context);
        }

        public override object VisitObject([NotNull] UCMParser.ObjectContext context)
        {
            Console.WriteLine("Visiting Object");
            return base.VisitObject(context);
        }

        public override object VisitField([NotNull] UCMParser.FieldContext context)
        {
            Console.WriteLine("Visiting Field");
            return base.VisitField(context);
        }

        public override object VisitArray([NotNull] UCMParser.ArrayContext context)
        {
            Console.WriteLine("Visiting Array");
            return base.VisitArray(context);
        }

        public override object VisitEvaluaterArray([NotNull] UCMParser.EvaluaterArrayContext context)
        {
            Console.WriteLine("Visiting EvaluaterArray");
            return base.VisitEvaluaterArray(context);
        }

        public override object VisitTemplateField([NotNull] UCMParser.TemplateFieldContext context)
        {
            Console.WriteLine("Visiting TemplateField");
            return base.VisitTemplateField(context);
        }

        public override object VisitTemplateExtention([NotNull] UCMParser.TemplateExtentionContext context)
        {
            Console.WriteLine("Visiting TemplateExtention");
            return base.VisitTemplateExtention(context);
        }

        public override object VisitTemplateDefenition([NotNull] UCMParser.TemplateDefenitionContext context)
        {
            Console.WriteLine("Visiting TemplateDefenition");
            return base.VisitTemplateDefenition(context);
        }

        public override object VisitFunctionCollection([NotNull] UCMParser.FunctionCollectionContext context)
        {
            Console.WriteLine("Visiting FunctionCollection");
            return base.VisitFunctionCollection(context);
        }

        public override object VisitMethod([NotNull] UCMParser.MethodContext context)
        {
            Console.WriteLine("Visiting Method");
            return base.VisitMethod(context);
        }

        public override object VisitFunctionCollectionCall([NotNull] UCMParser.FunctionCollectionCallContext context)
        {
            Console.WriteLine("Visiting FunctionCollectionCall");
            return base.VisitFunctionCollectionCall(context);
        }

        public override object VisitMethodCall([NotNull] UCMParser.MethodCallContext context)
        {
            Console.WriteLine("Visiting MethodCall");
            return base.VisitMethodCall(context);
        }

        public override object VisitExpr([NotNull] UCMParser.ExprContext context)
        {
            Console.WriteLine("Visiting Expr");
            return base.VisitExpr(context);
        }

        public override object VisitNumExpr([NotNull] UCMParser.NumExprContext context)
        {
            Console.WriteLine("Visiting NumExpr");
            return base.VisitNumExpr(context);
        }

        public override object VisitBoolExpr([NotNull] UCMParser.BoolExprContext context)
        {
            Console.WriteLine("Visiting BoolExpr");
            return base.VisitBoolExpr(context);
        }

        public override object VisitCompExpr([NotNull] UCMParser.CompExprContext context)
        {
            Console.WriteLine("Visiting CompExpr");
            return base.VisitCompExpr(context);
        }

        public override object VisitIfStatement([NotNull] UCMParser.IfStatementContext context)
        {
            Console.WriteLine("Visiting IfStatement");
            return base.VisitIfStatement(context);
        }

        public override object VisitConditional([NotNull] UCMParser.ConditionalContext context)
        {
            Console.WriteLine("Visiting Conditional");
            return base.VisitConditional(context);
        }

        public override object VisitWhileLoop([NotNull] UCMParser.WhileLoopContext context)
        {
            Console.WriteLine("Visiting WhileLoop");
            return base.VisitWhileLoop(context);
        }

        public override object VisitForLoop([NotNull] UCMParser.ForLoopContext context)
        {
            Console.WriteLine("Visiting ForLoop");
            return base.VisitForLoop(context);
        }

        public override object VisitListConstruction([NotNull] UCMParser.ListConstructionContext context)
        {
            Console.WriteLine("Visiting ListConstruction");
            return base.VisitListConstruction(context);
        }

        public override object VisitStatementList([NotNull] UCMParser.StatementListContext context)
        {
            Console.WriteLine("Visiting StatementList");
            return base.VisitStatementList(context);
        }

        public override object VisitStatement([NotNull] UCMParser.StatementContext context)
        {
            Console.WriteLine("Visiting Statement");
            return base.VisitStatement(context);
        }

        public override object VisitAssignment([NotNull] UCMParser.AssignmentContext context)
        {
            Console.WriteLine("Visiting Assignment");
            return base.VisitAssignment(context);
        }

        public override object VisitObjectDefenition([NotNull] UCMParser.ObjectDefenitionContext context)
        {
            Console.WriteLine("Visiting ObjectDefenition");
            return base.VisitObjectDefenition(context);
        }

        public override object VisitArrayDefenition([NotNull] UCMParser.ArrayDefenitionContext context)
        {
            Console.WriteLine("Visiting ArrayDefenition");
            return base.VisitArrayDefenition(context);
        }

        public override object VisitDeclaration([NotNull] UCMParser.DeclarationContext context)
        {
            Console.WriteLine("Visiting Declaration");
            return base.VisitDeclaration(context);
        }

        public override object VisitRoot([NotNull] UCMParser.RootContext context)
        {
            Console.WriteLine("Visiting Root");
            return base.VisitRoot(context);
        }

        public override object VisitStart([NotNull] UCMParser.StartContext context)
        {
            Console.WriteLine("Visiting Start");
            return base.VisitStart(context);
        }
    }
}
