//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from UCM.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="UCMParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IUCMVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.object_t"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObject_t([NotNull] UCMParser.Object_tContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.array_t"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray_t([NotNull] UCMParser.Array_tContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.primitiveType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimitiveType([NotNull] UCMParser.PrimitiveTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.complexType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComplexType([NotNull] UCMParser.ComplexTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] UCMParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.int"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt([NotNull] UCMParser.IntContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.float"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloat([NotNull] UCMParser.FloatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.num"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNum([NotNull] UCMParser.NumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitValue([NotNull] UCMParser.ValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.augmentedString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAugmentedString([NotNull] UCMParser.AugmentedStringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.concatanatedString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConcatanatedString([NotNull] UCMParser.ConcatanatedStringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] UCMParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.typedId"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypedId([NotNull] UCMParser.TypedIdContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.adapting"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdapting([NotNull] UCMParser.AdaptingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObject([NotNull] UCMParser.ObjectContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitField([NotNull] UCMParser.FieldContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray([NotNull] UCMParser.ArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.evaluaterArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEvaluaterArray([NotNull] UCMParser.EvaluaterArrayContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.templateField"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTemplateField([NotNull] UCMParser.TemplateFieldContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.templateExtention"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTemplateExtention([NotNull] UCMParser.TemplateExtentionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.templateDefenition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTemplateDefenition([NotNull] UCMParser.TemplateDefenitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.functionCollection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCollection([NotNull] UCMParser.FunctionCollectionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.method"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMethod([NotNull] UCMParser.MethodContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.functionCollectionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCollectionCall([NotNull] UCMParser.FunctionCollectionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.methodCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMethodCall([NotNull] UCMParser.MethodCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] UCMParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.numExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumExpr([NotNull] UCMParser.NumExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.boolExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolExpr([NotNull] UCMParser.BoolExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.compExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompExpr([NotNull] UCMParser.CompExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] UCMParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.conditional"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConditional([NotNull] UCMParser.ConditionalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.whileLoop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileLoop([NotNull] UCMParser.WhileLoopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.forLoop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForLoop([NotNull] UCMParser.ForLoopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.listConstruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListConstruction([NotNull] UCMParser.ListConstructionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.statementList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatementList([NotNull] UCMParser.StatementListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] UCMParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] UCMParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.objectDefenition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitObjectDefenition([NotNull] UCMParser.ObjectDefenitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.arrayDefenition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrayDefenition([NotNull] UCMParser.ArrayDefenitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] UCMParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.root"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRoot([NotNull] UCMParser.RootContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="UCMParser.start"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStart([NotNull] UCMParser.StartContext context);
}
