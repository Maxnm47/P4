// Generated from /home/max/Desktop/uni/4. semester/p4/UCM.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link UCMParser}.
 */
public interface UCMListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link UCMParser#object_t}.
	 * @param ctx the parse tree
	 */
	void enterObject_t(UCMParser.Object_tContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#object_t}.
	 * @param ctx the parse tree
	 */
	void exitObject_t(UCMParser.Object_tContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#array_t}.
	 * @param ctx the parse tree
	 */
	void enterArray_t(UCMParser.Array_tContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#array_t}.
	 * @param ctx the parse tree
	 */
	void exitArray_t(UCMParser.Array_tContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#primitiveType}.
	 * @param ctx the parse tree
	 */
	void enterPrimitiveType(UCMParser.PrimitiveTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#primitiveType}.
	 * @param ctx the parse tree
	 */
	void exitPrimitiveType(UCMParser.PrimitiveTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#complexType}.
	 * @param ctx the parse tree
	 */
	void enterComplexType(UCMParser.ComplexTypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#complexType}.
	 * @param ctx the parse tree
	 */
	void exitComplexType(UCMParser.ComplexTypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(UCMParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(UCMParser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#num}.
	 * @param ctx the parse tree
	 */
	void enterNum(UCMParser.NumContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#num}.
	 * @param ctx the parse tree
	 */
	void exitNum(UCMParser.NumContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#value}.
	 * @param ctx the parse tree
	 */
	void enterValue(UCMParser.ValueContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#value}.
	 * @param ctx the parse tree
	 */
	void exitValue(UCMParser.ValueContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#augmentedString}.
	 * @param ctx the parse tree
	 */
	void enterAugmentedString(UCMParser.AugmentedStringContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#augmentedString}.
	 * @param ctx the parse tree
	 */
	void exitAugmentedString(UCMParser.AugmentedStringContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#concatanatedString}.
	 * @param ctx the parse tree
	 */
	void enterConcatanatedString(UCMParser.ConcatanatedStringContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#concatanatedString}.
	 * @param ctx the parse tree
	 */
	void exitConcatanatedString(UCMParser.ConcatanatedStringContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#string}.
	 * @param ctx the parse tree
	 */
	void enterString(UCMParser.StringContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#string}.
	 * @param ctx the parse tree
	 */
	void exitString(UCMParser.StringContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#typedId}.
	 * @param ctx the parse tree
	 */
	void enterTypedId(UCMParser.TypedIdContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#typedId}.
	 * @param ctx the parse tree
	 */
	void exitTypedId(UCMParser.TypedIdContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#adapting}.
	 * @param ctx the parse tree
	 */
	void enterAdapting(UCMParser.AdaptingContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#adapting}.
	 * @param ctx the parse tree
	 */
	void exitAdapting(UCMParser.AdaptingContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#object}.
	 * @param ctx the parse tree
	 */
	void enterObject(UCMParser.ObjectContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#object}.
	 * @param ctx the parse tree
	 */
	void exitObject(UCMParser.ObjectContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#field}.
	 * @param ctx the parse tree
	 */
	void enterField(UCMParser.FieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#field}.
	 * @param ctx the parse tree
	 */
	void exitField(UCMParser.FieldContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#array}.
	 * @param ctx the parse tree
	 */
	void enterArray(UCMParser.ArrayContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#array}.
	 * @param ctx the parse tree
	 */
	void exitArray(UCMParser.ArrayContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#evaluaterArray}.
	 * @param ctx the parse tree
	 */
	void enterEvaluaterArray(UCMParser.EvaluaterArrayContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#evaluaterArray}.
	 * @param ctx the parse tree
	 */
	void exitEvaluaterArray(UCMParser.EvaluaterArrayContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#templateField}.
	 * @param ctx the parse tree
	 */
	void enterTemplateField(UCMParser.TemplateFieldContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#templateField}.
	 * @param ctx the parse tree
	 */
	void exitTemplateField(UCMParser.TemplateFieldContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#templateExtention}.
	 * @param ctx the parse tree
	 */
	void enterTemplateExtention(UCMParser.TemplateExtentionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#templateExtention}.
	 * @param ctx the parse tree
	 */
	void exitTemplateExtention(UCMParser.TemplateExtentionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#templateDefenition}.
	 * @param ctx the parse tree
	 */
	void enterTemplateDefenition(UCMParser.TemplateDefenitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#templateDefenition}.
	 * @param ctx the parse tree
	 */
	void exitTemplateDefenition(UCMParser.TemplateDefenitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#functionCollection}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCollection(UCMParser.FunctionCollectionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#functionCollection}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCollection(UCMParser.FunctionCollectionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#method}.
	 * @param ctx the parse tree
	 */
	void enterMethod(UCMParser.MethodContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#method}.
	 * @param ctx the parse tree
	 */
	void exitMethod(UCMParser.MethodContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#functionCollectionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCollectionCall(UCMParser.FunctionCollectionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#functionCollectionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCollectionCall(UCMParser.FunctionCollectionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#methodCall}.
	 * @param ctx the parse tree
	 */
	void enterMethodCall(UCMParser.MethodCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#methodCall}.
	 * @param ctx the parse tree
	 */
	void exitMethodCall(UCMParser.MethodCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(UCMParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(UCMParser.ExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#numExpr}.
	 * @param ctx the parse tree
	 */
	void enterNumExpr(UCMParser.NumExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#numExpr}.
	 * @param ctx the parse tree
	 */
	void exitNumExpr(UCMParser.NumExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#boolExpr}.
	 * @param ctx the parse tree
	 */
	void enterBoolExpr(UCMParser.BoolExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#boolExpr}.
	 * @param ctx the parse tree
	 */
	void exitBoolExpr(UCMParser.BoolExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#compExpr}.
	 * @param ctx the parse tree
	 */
	void enterCompExpr(UCMParser.CompExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#compExpr}.
	 * @param ctx the parse tree
	 */
	void exitCompExpr(UCMParser.CompExprContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(UCMParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(UCMParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#conditional}.
	 * @param ctx the parse tree
	 */
	void enterConditional(UCMParser.ConditionalContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#conditional}.
	 * @param ctx the parse tree
	 */
	void exitConditional(UCMParser.ConditionalContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#whileLoop}.
	 * @param ctx the parse tree
	 */
	void enterWhileLoop(UCMParser.WhileLoopContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#whileLoop}.
	 * @param ctx the parse tree
	 */
	void exitWhileLoop(UCMParser.WhileLoopContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#forLoop}.
	 * @param ctx the parse tree
	 */
	void enterForLoop(UCMParser.ForLoopContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#forLoop}.
	 * @param ctx the parse tree
	 */
	void exitForLoop(UCMParser.ForLoopContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#listConstruction}.
	 * @param ctx the parse tree
	 */
	void enterListConstruction(UCMParser.ListConstructionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#listConstruction}.
	 * @param ctx the parse tree
	 */
	void exitListConstruction(UCMParser.ListConstructionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#statementList}.
	 * @param ctx the parse tree
	 */
	void enterStatementList(UCMParser.StatementListContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#statementList}.
	 * @param ctx the parse tree
	 */
	void exitStatementList(UCMParser.StatementListContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(UCMParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(UCMParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(UCMParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(UCMParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#objectDefenition}.
	 * @param ctx the parse tree
	 */
	void enterObjectDefenition(UCMParser.ObjectDefenitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#objectDefenition}.
	 * @param ctx the parse tree
	 */
	void exitObjectDefenition(UCMParser.ObjectDefenitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#arrayDefenition}.
	 * @param ctx the parse tree
	 */
	void enterArrayDefenition(UCMParser.ArrayDefenitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#arrayDefenition}.
	 * @param ctx the parse tree
	 */
	void exitArrayDefenition(UCMParser.ArrayDefenitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#declaration}.
	 * @param ctx the parse tree
	 */
	void enterDeclaration(UCMParser.DeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#declaration}.
	 * @param ctx the parse tree
	 */
	void exitDeclaration(UCMParser.DeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#root}.
	 * @param ctx the parse tree
	 */
	void enterRoot(UCMParser.RootContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#root}.
	 * @param ctx the parse tree
	 */
	void exitRoot(UCMParser.RootContext ctx);
	/**
	 * Enter a parse tree produced by {@link UCMParser#start}.
	 * @param ctx the parse tree
	 */
	void enterStart(UCMParser.StartContext ctx);
	/**
	 * Exit a parse tree produced by {@link UCMParser#start}.
	 * @param ctx the parse tree
	 */
	void exitStart(UCMParser.StartContext ctx);
}