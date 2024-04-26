using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.complexValues;
using UCM.ast.numExpr;
using UCM.ast.root;
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
            Visit(node.Key);

            // Set key to id if it exist, else set it to a random guid
            string key = node.Key.Id is not null ? node.Key.Id!.value : Guid.NewGuid().ToString();

            if (CurrentScope.ContainsKey(key))
            {
                Errors.Add($"Field ({key}) already declared in this scope");
                return new TypeInfo(TypeEnum.Error);
            }

            TypeInfo exprType = Visit(node.Expr);
            TypeInfo typeAnotation = node.Type is not null ? Visit(node.Type) : exprType;

            if (typeAnotation.type == TypeEnum.Error || exprType.type == TypeEnum.Error)
            {
                return new TypeInfo(TypeEnum.Error);
            }

            if (typeAnotation.type != exprType.type)
            {
                Errors.Add($"Type mismatch in field {key}: {typeAnotation.type} != {exprType.type}");
                return new TypeInfo(TypeEnum.Error);
            }

            if (typeAnotation.templateId is not null)
            {
                ObjectTypeChecker objectTypeChecker = new ObjectTypeChecker();

                TypeInfo result = objectTypeChecker.CheckObjectType(typeAnotation, exprType);

                if (result.type == TypeEnum.Error)
                {
                    Errors.Add($"Type mismatch in field {key}: value does not match template type ({typeAnotation.templateId})");
                    return new TypeInfo(TypeEnum.Error);
                }
            }

            TypeInfo typeInfo = new TypeInfo(typeAnotation.type, fieldKey: key);
            CurrentScope.Add(key, typeInfo);
            return typeInfo;
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
            if (node.type == TypeEnum.Object && node.value != "object")
            {
                string templateId = node.value;

                foreach (var scope in Scopes)
                {
                    if (scope.TryGetValue(templateId, out TypeInfo? value))
                    {
                        return value;
                    }
                }

                Errors.Add($"Template {templateId} not found");
                return new TypeInfo(TypeEnum.Error);
            }

            return new TypeInfo(node.type);
        }



        public override TypeInfo VisitIdentifyer(IdentifyerNode node)
        {
            foreach (var scope in Scopes)
            {
                if (scope.TryGetValue(node.value, out TypeInfo? typeInfo))
                {
                    return typeInfo;
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

        public override TypeInfo VisitTemplate(TemplateNode node)
        {
            Scopes.Push(new Dictionary<string, TypeInfo>());

            List<TypeInfo> templateFields = new List<TypeInfo>();

            foreach (TemplateFieldNode field in node.Fields)
            {
                templateFields.Add(Visit(field));
            }

            foreach (MethodDefenitionNode method in node.Methods)
            {
                Visit(method);
            }

            Scopes.Pop();

            CurrentScope.Add(node.Id.value, new TypeInfo(TypeEnum.Object, templateId: node.Id.value, subFields: templateFields));

            return new TypeInfo(TypeEnum.Object, templateId: node.Id.value, subFields: templateFields);
        }

        public override TypeInfo VisitTemplateField(TemplateFieldNode node)
        {
            TypeInfo typeAnotation = Visit(node.Type);
            string key = node.Id.value;

            if (node.Expr is null)
            {
                return new TypeInfo(typeAnotation.type, fieldKey: key);
            }

            TypeInfo exprType = Visit(node.Expr);

            if (typeAnotation.type == TypeEnum.Error || exprType.type == TypeEnum.Error)
            {
                return new TypeInfo(TypeEnum.Error);
            }

            if (typeAnotation.type != exprType.type)
            {
                Errors.Add($"Type mismatch in template field {key}: {typeAnotation.type} != {exprType.type}");
                return new TypeInfo(TypeEnum.Error);
            }

            return new TypeInfo(typeAnotation.type, fieldKey: key);
        }
    }
}