using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.numExpr;
using UCM.ast.statements;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class SemanticAnalysisVisitor : AstBaseVisitor<TypeInfo>
    {

        public Stack<Dictionary<string, TypeInfo>> ObjectTables { get; set; } = new Stack<Dictionary<string, TypeInfo>>();
        public Stack<Dictionary<string, TypeInfo>> Scopes { get; set; } = new Stack<Dictionary<string, TypeInfo>>();
        public List<string> Errors { get; set; } = new List<string>();

        public Dictionary<string, TypeInfo> CurrentScope => Scopes.Peek();

        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            Scopes.Push(new Dictionary<string, TypeInfo>());
        }

        public override TypeInfo VisitField(FieldNode node)
        {
            bool hasDynamicKey = node.Key.Id is null;
            string refId;

            if (hasDynamicKey)
            {
                // Asign random id if the key is dynamic
                refId = Guid.NewGuid().ToString();
                Visit(node.Key);
            }
            else
            {
                refId = node.Key.Id!.value;
            }

            node.referenceId = refId;

            if (CurrentScope.ContainsKey(refId))
            {
                // If the field is already declared in the current scope add an error and return error type
                Errors.Add($"Variable {refId} already declared in this scope");
                return new TypeInfo(TypeEnum.Error);
            }

            // Check if the type is valid
            TypeInfo typeAnotation = Visit(node.Type);
            TypeInfo exprType = Visit(node.Expr);

            if (typeAnotation.type == TypeEnum.Error || exprType.type == TypeEnum.Error)
            {
                return new TypeInfo(TypeEnum.Error);
            }

            if (typeAnotation.type == TypeEnum.None)
            {
                typeAnotation = exprType;
            }

            if (typeAnotation.type != exprType.type)
            {
                // If the type is not valid add an error and return error type
                Errors.Add($"Type mismatch in field {refId}: {typeAnotation.type} != {exprType.type}");
                return new TypeInfo(TypeEnum.Error);
            }

            // Add the field to the current scope
            CurrentScope.Add(refId, new TypeInfo(typeAnotation));
            return new TypeInfo(TypeEnum.Object);
        }

        public override TypeInfo VisitExpression(ExpressionNode node)
        {
            TypeInfo typeInfo = new TypeInfo(TypeEnum.Unknown);

            foreach (var child in node.children)
            {
                TypeInfo childTypeInfo = Visit(child);

                if (typeInfo.type == TypeEnum.Unknown)
                {
                    typeInfo = childTypeInfo;
                }
                else if (typeInfo.type != childTypeInfo.type)
                {
                    // If the type is not valid add an error and return error type
                    Errors.Add($"Type mismatch in expression: {typeInfo.type} != {childTypeInfo.type}");
                    return new TypeInfo(TypeEnum.Error);
                }

            }

            return typeInfo;
        }

        public override TypeInfo VisitAddition(AdditionNode node)
        {
            TypeInfo leftTypeInfo = Visit(node.Left);
            TypeInfo rightTypeInfo = Visit(node.Right);

            if (leftTypeInfo.type != rightTypeInfo.type)
            {
                // If the type is not valid add an error and return error type
                Errors.Add($"Type mismatch in addition: {leftTypeInfo.type} != {rightTypeInfo.type}");
                return new TypeInfo(TypeEnum.Error);
            }

            if (leftTypeInfo.type != TypeEnum.Int && leftTypeInfo.type != TypeEnum.Float && leftTypeInfo.type != TypeEnum.String)
            {
                // If the type is not valid add an error and return error type
                Errors.Add($"Type \"{leftTypeInfo.type}\" is undefined for addition.");
                return new TypeInfo(TypeEnum.Error);
            }

            return leftTypeInfo;
        }

        public override TypeInfo VisitObject(ObjectNode objectNode)
        {
            Scopes.Push(new Dictionary<string, TypeInfo>());

            List<TypeInfo> fieldTypes = new List<TypeInfo>();
            foreach (FieldNode field in objectNode.Fields)
            {
                fieldTypes.Add(Visit(field));
            }

            Scopes.Pop();

            return new TypeInfo(TypeEnum.Object, fieldTypes);
        }

        public override TypeInfo VisitArray(ArrayNode arrayNode)
        {

            return new TypeInfo(TypeEnum.Array);
        }

        public override TypeInfo VisitString(StringNode stringNode)
        {
            return new TypeInfo(TypeEnum.String);
        }

        public override TypeInfo VisitBool(BoolNode booleanNode)
        {
            return new TypeInfo(TypeEnum.Bool);
        }
        public override TypeInfo VisitFloat(FloatNode floatNode)
        {
            return new TypeInfo(TypeEnum.Float);
        }
        public override TypeInfo VisitInt(IntNode intNode)
        {
            return new TypeInfo(TypeEnum.Int);
        }

        public override TypeInfo VisitVoid(VoidNode voidNode)
        {
            return new TypeInfo(TypeEnum.Void);
        }

        public override TypeInfo VisitTypeAnotation(TypeAnotationNode node)
        {
            return new TypeInfo(node.type);
        }



        public override TypeInfo VisitIdentifyer(IdentifyerNode node)
        {
            foreach (var scope in Scopes)
            {
                if (scope.ContainsKey(node.value))
                {
                    return scope[node.value];
                }
            }

            Errors.Add($"{node.value} not declared");
            return new TypeInfo(TypeEnum.Undefined);
        }

        public override TypeInfo VisitFieldId(FieldId node)
        {
            bool hasDynamicKey = node.Id is null;

            if (!hasDynamicKey)
            {
                return new TypeInfo(TypeEnum.String);
            }

            TypeEnum type = Visit(node.Expr!).type;

            if (type != TypeEnum.String)
            {
                // If the type is not valid add an error and return error type
                Errors.Add($"Type mismatch in field key: {type} != STRING");
                return new TypeInfo(TypeEnum.Error);
            }

            return new TypeInfo(TypeEnum.String);
        }
    }
}