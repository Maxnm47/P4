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
    public class SemanticAnalysisVisitor : AstBaseVisitor<AstNode>
    {
        public Dictionary<string, TemplateNode> TemplateTalbe { get; set; } = [];

        public TemplateTypeChecker templateTypeChecker = new();
        public Stack<Dictionary<string, AstNode>> SymbolTables { get; set; } = new Stack<Dictionary<string, AstNode>>();
        public List<string> Errors { get; set; } = new List<string>();
        public Dictionary<string, AstNode> CurrentScope => SymbolTables.Peek();


        public SemanticAnalysisVisitor()
        {
            // Initilise the SymbolTables with the global scope
            SymbolTables.Push([]);
        }


        public override AstNode VisitField(FieldNode fieldNode)
        {
            string key = fieldNode.Key.Id is not null ? fieldNode.Key.Id.value : Guid.NewGuid().ToString();
            fieldNode.typeInfo ??= new TypeInfo(TypeEnum.Any);

            if (fieldNode.typeInfo.templateId != null)
            {
                TypeInfo typeInfo = templateTypeChecker.GetFieldType(fieldNode.typeInfo.templateId, key);
                if (typeInfo == null)
                {
                    Errors.Add($"Field {key} is not declared in template {fieldNode.typeInfo.templateId}");
                    //return base.VisitField(fieldNode);
                }

                fieldNode.typeInfo = typeInfo ?? new TypeInfo(TypeEnum.Any);
            }

            if (CurrentScope.ContainsKey(key))
            {
                Errors.Add($"Feild {key} already declared in scope");
                return base.VisitField(fieldNode);
            }

            // If type anotated, check if the type anotation is correct and get the more precise type into fieldNode.typeInfo.
            if (fieldNode.Type is not null)
            {
                fieldNode.Type.typeInfo = fieldNode.typeInfo;
                Visit(fieldNode.Type);
                fieldNode.typeInfo = fieldNode.Type.typeInfo;
            }


            // Check if expression type matches the field type
            ExpressionNode expression = fieldNode.Expr;
            expression.typeInfo = fieldNode.typeInfo;
            Visit(expression);



            CurrentScope.Add(key, fieldNode);
            return fieldNode;
        }




        public override AstNode VisitTypeAnotation(TypeAnotationNode typeAnotationNode)
        {
            TypeInfo exprectedType = typeAnotationNode.typeInfo;

            if (exprectedType.type == TypeEnum.Unknown)
            {
                exprectedType.type = typeAnotationNode.type ?? TypeEnum.Any;
                if (typeAnotationNode.type == TypeEnum.Object)
                {
                    exprectedType.templateId = typeAnotationNode.value;
                }
            }


            if (typeAnotationNode.type == TypeEnum.Object && typeAnotationNode.value != "object")
            {
                if (!CurrentScope.ContainsKey(typeAnotationNode.value))
                {
                    Errors.Add($"Template {typeAnotationNode.value} not declared");
                    return base.VisitTypeAnotation(typeAnotationNode);
                }

                if (!typeAnotationNode.value.Equals(exprectedType.templateId))
                {
                    Errors.Add($"Type mismatch: {typeAnotationNode.value} != {exprectedType.templateId}");
                    return base.VisitTypeAnotation(typeAnotationNode);
                }
            }

            if (typeAnotationNode.type == TypeEnum.Array)
            {
                TypeInfo arrayType = calcArrayType(typeAnotationNode.value);
                if (!arrayType.Equals(exprectedType.arrayType) && exprectedType.arrayType != null && exprectedType.arrayType.type != TypeEnum.Any && exprectedType.arrayType.type != TypeEnum.Unknown)
                {
                    Errors.Add($"Type mismatch: {arrayType.type} != {exprectedType.arrayType.type}");
                    return base.VisitTypeAnotation(typeAnotationNode);
                }

                exprectedType.type = TypeEnum.Array;
                exprectedType.arrayType = arrayType;

            }

            return typeAnotationNode;
        }

        public override AstNode VisitObject(ObjectNode objectNode)
        {
            Dictionary<string, AstNode> objectScope = new Dictionary<string, AstNode>();
            SymbolTables.Push(objectScope);

            foreach (FieldNode field in objectNode.Fields)
            {
                // Pass potential type info to children
                field.typeInfo = objectNode.typeInfo;
                Visit(field);
            }

            SymbolTables.Pop();

            if (objectNode.typeInfo.templateId is not null)
            {
                if (!templateTypeChecker.Check(objectNode.typeInfo.templateId, objectNode))
                {
                    Errors.Add($"Object does not match template {objectNode.typeInfo.templateId}");
                }
            }

            if (objectNode.typeInfo.type != TypeEnum.Object && objectNode.typeInfo.type != TypeEnum.Any)
            {
                Errors.Add($"Type mismatch: Can not set value of type Object to value of type {objectNode.typeInfo.type}");
            }

            return objectNode;
        }
        public override AstNode VisitIdentifyer(IdentifyerNode node)
        {
            TypeInfo actualType = new TypeInfo(TypeEnum.Undefined);

            foreach (var scope in SymbolTables)
            {
                if (scope.ContainsKey(node.value))
                {
                    actualType = scope[node.value].typeInfo;
                    continue;
                }
            }

            if (actualType.type == TypeEnum.Undefined)
            {
                Errors.Add($"Variable {node.value} not declared");
                return base.VisitIdentifyer(node);
            }

            if (actualType.type == TypeEnum.Template)
            {
                return base.VisitIdentifyer(node);
            }

            if (!actualType.Equals(node.typeInfo))
            {
                Errors.Add($"Type mismatch: {actualType.type} != {node.typeInfo.type}");
                return base.VisitIdentifyer(node);
            }


            return node;
        }

        public override AstNode VisitExpression(ExpressionNode node)
        {
            // Pass type info to children
            AstNode child = node.children[0];
            child.typeInfo = node.typeInfo;

            // Visit the child to see if it maches the type
            Visit(child);

            // Set type info to the same as the child to propergate pontential errors up the tree
            node.typeInfo = child.typeInfo;

            return node;
        }

        public override AstNode VisitString(StringNode node)
        {
            CheckPrimitiveType(node, TypeEnum.String);
            return node;
        }

        public override AstNode VisitInt(IntNode node)
        {
            CheckPrimitiveType(node, TypeEnum.Int);
            return node;
        }

        public override AstNode VisitFloat(FloatNode node)
        {
            CheckPrimitiveType(node, TypeEnum.Float);
            return node;
        }

        public override AstNode VisitBool(BoolNode node)
        {
            CheckPrimitiveType(node, TypeEnum.Bool);
            return node;
        }

        public override AstNode VisitArray(ArrayNode node)
        {

            foreach (ExpressionNode expression in node.Elements)
            {
                // Set type info to the array type
                expression.typeInfo = node.typeInfo.arrayType;
                Visit(expression);
            }

            return node;
        }

        //addition
        public override AstNode VisitAddition(AdditionNode node)
        {
            AstNode left = node.Left;
            AstNode right = node.Right;
            left.typeInfo = node.typeInfo;
            right.typeInfo = node.typeInfo;

            Visit(left);
            Visit(right);

            if (left.typeInfo.type != right.typeInfo.type)
            {
                Errors.Add($"Type mismatch in addition: {left.typeInfo.type} != {right.typeInfo.type}");
                return base.VisitAddition(node);
            }

            if (left.typeInfo.type != TypeEnum.Int && left.typeInfo.type != TypeEnum.Float && left.typeInfo.type != TypeEnum.String)
            {
                Errors.Add($"Type {left.typeInfo.type} not supported in addition");
                return base.VisitAddition(node);
            }


            node.typeInfo = left.typeInfo;

            return node;
        }


        public override AstNode VisitTemplate(TemplateNode node)
        {
            if (TemplateTalbe.ContainsKey(node.Id.value))
            {
                Errors.Add($"Template {node.Id.value} already declared");
                return base.VisitTemplate(node);
            }

            Dictionary<string, AstNode> templateScope = new Dictionary<string, AstNode>();

            foreach (TemplateFieldNode field in node.Fields)
            {
                AstNode visitedField = Visit(field);
                if (templateScope.ContainsKey(field.Id.value))
                {
                    Errors.Add($"Field {field.Id.value} already declared in template {node.Id.value}");
                    return base.VisitTemplate(node);
                }

                templateScope.Add(field.Id.value, visitedField);
            }

            templateTypeChecker.AddTemplate(node.Id.value, node);

            node.typeInfo = new TypeInfo(TypeEnum.Template);
            CurrentScope.Add(node.Id.value, node);

            return base.VisitTemplate(node);
        }

        //templateField
        public override AstNode VisitTemplateField(TemplateFieldNode node)
        {
            node.typeInfo = new TypeInfo(TypeEnum.Unknown);
            AstNode type = node.Type;
            type.typeInfo = node.typeInfo;

            Visit(type);
            node.typeInfo = type.typeInfo;

            return node;
        }


        void CheckPrimitiveType(AstNode node, TypeEnum expectedType)
        {
            if (node.typeInfo.type == TypeEnum.Any)
            {
                node.typeInfo = new TypeInfo(expectedType);
                return;
            }

            if (node.typeInfo.type != expectedType)
            {
                Errors.Add($"Type mismatch: Can not set value of type {expectedType} to value of type {node.typeInfo.type}");
                node.typeInfo.type = TypeEnum.Error;
            }
        }

        TypeInfo calcArrayType(string rawArrayTypeString)
        {
            string arrayTypeString = rawArrayTypeString.Remove(rawArrayTypeString.Length - 2, 2);
            bool hasMoreDimensions = arrayTypeString.Contains("[]");
            bool hasSpecifiedType = arrayTypeString.Count() > 0;

            if (!hasSpecifiedType)
            {
                return new TypeInfo(TypeEnum.Any);
            }

            if (hasMoreDimensions)
            {
                return new TypeInfo(TypeEnum.Array, arrayType: calcArrayType(arrayTypeString));
            }

            switch (arrayTypeString)
            {
                case "int":
                    return new TypeInfo(TypeEnum.Int);
                case "float":
                    return new TypeInfo(TypeEnum.Float);
                case "string":
                    return new TypeInfo(TypeEnum.String);
                case "bool":
                    return new TypeInfo(TypeEnum.Bool);
                case "object":
                    return new TypeInfo(TypeEnum.Object);
                default:
                    return new TypeInfo(TypeEnum.Object, templateId: arrayTypeString);
            }
        }
    }
}