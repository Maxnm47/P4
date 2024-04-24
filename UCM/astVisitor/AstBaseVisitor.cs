using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.boolExpr;
using UCM.ast.complexValues;
using UCM.ast.loopConstruction;
using UCM.ast.numExpr;
using UCM.ast.root;
using UCM.ast.statements;
using UCM.ast.statements.condition;
using UCM.ast.statements.forLoops;
using UCM.ast.statements.whileLoop;

namespace UCM.astVisitor
{
    public partial class AstBaseVisitor<Result>
    {
        public virtual Result Visit(AstNode node)
        {
            Console.WriteLine(node.GetType());
            return VisitChildren(node);
        }

        public virtual Result VisitChildren(AstNode node)
        {
            Result? result = default(Result);
            foreach (AstNode child in node.children)
            {
                Result? nextResult = child.Accept(this);
                if (nextResult != null)
                {
                    result = nextResult;
                }
            }

            return result;
        }

        public virtual Result VisitField(FieldNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitMethodCollection(MethodCollectionNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitMethodDefenition(MethodDefenitionNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitArguments(ArgumentsNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitIdentifyer(IdentifyerNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitTypeAnotation(TypeAnotationNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitBody(BodyNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitReturn(ReturnNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitExpression(ExpressionNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitRoot(RootNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitHiddenAnotation(HiddenAnotationNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitFieldId(FieldId node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitArgumentDefenition(ArgumentDefenitionNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitAssignment(AssignmentNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitIfStatement(IfStatementNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitConditional(ConditionalNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitWhileLoop(WhileLoopNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitMethodCall(MethodCallNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitForLoop(ForLoopNode node)
        {
            return VisitChildren(node);
        }


        // Template
        public virtual Result VisitTemplate(TemplateNode node)
        {
            return VisitChildren(node);
        }

        // TemplateField
        public virtual Result VisitTemplateField(TemplateFieldNode node)
        {
            return VisitChildren(node);
        }

        // Bool
        public virtual Result VisitBool(BoolNode node)
        {
            return VisitChildren(node);
        }

        // Int
        public virtual Result VisitInt(IntNode node)
        {
            return VisitChildren(node);
        }

        // String
        public virtual Result VisitString(StringNode node)
        {
            return VisitChildren(node);
        }

        // Float
        public virtual Result VisitFloat(FloatNode node)
        {
            return VisitChildren(node);
        }

        // Void
        public virtual Result VisitVoid(VoidNode node)
        {
            return VisitChildren(node);
        }

        // Addition
        public virtual Result VisitAddition(AdditionNode node)
        {
            return VisitChildren(node);
        }

        // Subtraction
        public virtual Result VisitSubtraction(SubtractionNode node)
        {
            return VisitChildren(node);
        }

        // Multiplication
        public virtual Result VisitMultiplication(MultiplicationNode node)
        {
            return VisitChildren(node);
        }

        // Division
        public virtual Result VisitDivision(DivisionNode node)
        {
            return VisitChildren(node);
        }

        // Modulo
        public virtual Result VisitModulo(ModuloNode node)
        {
            return VisitChildren(node);
        }

        // LessThan
        public virtual Result VisitLessThan(LessThanNode node)
        {
            return VisitChildren(node);
        }

        // LessThanOrEqual
        public virtual Result VisitLessThanOrEqual(LessThanOrEqualNode node)
        {
            return VisitChildren(node);
        }

        // GreaterThan
        public virtual Result VisitGreaterThan(GreaterThanNode node)
        {
            return VisitChildren(node);
        }

        // GreaterThanOrEqual
        public virtual Result VisitGreaterThanOrEqual(GreaterThanOrEqualNode node)
        {
            return VisitChildren(node);
        }

        // Equal
        public virtual Result VisitEqual(EqualNode node)
        {
            return VisitChildren(node);
        }

        // NotEqual
        public virtual Result VisitNotEqual(NotEqualNode node)
        {
            return VisitChildren(node);
        }

        // Not
        public virtual Result VisitNot(NotNode node)
        {
            return VisitChildren(node);
        }

        // And
        public virtual Result VisitAnd(AndNode node)
        {
            return VisitChildren(node);
        }

        // Or
        public virtual Result VisitOr(OrNode node)
        {
            return VisitChildren(node);
        }

        public virtual Result VisitArray(ArrayNode arrayNode)
        {
            return VisitChildren(arrayNode);
        }

        public virtual Result VisitAugmentedString(AugmentedStringNode augmentedStringNode)
        {
            return VisitChildren(augmentedStringNode);
        }

        public virtual Result VisitObject(ObjectNode objectNode)
        {
            return VisitChildren(objectNode);
        }

        public virtual Result VisitLoopConstructContent(LoopConstructContentNode loopConstructContentNode)
        {
            return VisitChildren(loopConstructContentNode);
        }

        public virtual Result VisitLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            return VisitChildren(loopConstructionNode);
        }

        public virtual Result VisitObjectFieldAcess(ObjectFieldAcessNode objectFieldAcessNode)
        {
            return VisitChildren(objectFieldAcessNode);
        }
    }
}