// Generated from UCM.g4 by ANTLR 4.9.0-SNAPSHOT


import { ParseTreeListener } from "antlr4ts/tree/ParseTreeListener";

import { TypeContext } from "./UCMParser";


/**
 * This interface defines a complete listener for a parse tree produced by
 * `UCMParser`.
 */
export interface UCMListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by `UCMParser.type`.
	 * @param ctx the parse tree
	 */
	enterType?: (ctx: TypeContext) => void;
	/**
	 * Exit a parse tree produced by `UCMParser.type`.
	 * @param ctx the parse tree
	 */
	exitType?: (ctx: TypeContext) => void;
}

