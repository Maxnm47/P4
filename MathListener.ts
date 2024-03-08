// Generated from Math.g4 by ANTLR 4.9.0-SNAPSHOT


import { ParseTreeListener } from "antlr4ts/tree/ParseTreeListener";

import { ExprContext } from "./MathParser";


/**
 * This interface defines a complete listener for a parse tree produced by
 * `MathParser`.
 */
export interface MathListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by `MathParser.expr`.
	 * @param ctx the parse tree
	 */
	enterExpr?: (ctx: ExprContext) => void;
	/**
	 * Exit a parse tree produced by `MathParser.expr`.
	 * @param ctx the parse tree
	 */
	exitExpr?: (ctx: ExprContext) => void;
}

