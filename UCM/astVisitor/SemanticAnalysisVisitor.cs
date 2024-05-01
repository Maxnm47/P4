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

            if (CurrentScope.ContainsKey(key))
            {
                Errors.Add($"Feild {key} already declared in scope");
                return base.VisitField(fieldNode);
            }

            TypeAnotationNode typeAnotation;
            if (fieldNode.Type is not null)
            {
                typeAnotation = Visit(fieldNode.Type) as TypeAnotationNode;
                fieldNode.Expr.typeInfo = typeAnotation.typeInfo;
            }
            else
            {
                typeAnotation = new TypeAnotationNode("unknown", TypeEnum.Undefined);
                typeAnotation.typeInfo = new TypeInfo(TypeEnum.Undefined);
                fieldNode.Expr.typeInfo = new TypeInfo(TypeEnum.Unknown);
            }

            fieldNode.Expr.typeInfo.fieldKey = key;
            ExpressionNode expr = Visit(fieldNode.Expr) as ExpressionNode;

            if (typeAnotation.typeInfo.type == TypeEnum.Undefined)
            {
                typeAnotation.typeInfo = expr.typeInfo;
            }

            expr.typeInfo.fieldKey = key;

            if (!expr!.typeInfo!.Equals(typeAnotation.typeInfo))
            {
                if (!(typeAnotation.typeInfo.arrayType != null
                && typeAnotation.typeInfo.arrayType.type == TypeEnum.Any
                && expr.typeInfo.type == TypeEnum.Array))
                {

                    if (expr.typeInfo.arrayType != null && typeAnotation.typeInfo.arrayType != null)
                    {
                        Errors.Add($"Type mismatch in field {key}: {typeAnotation.typeInfo.arrayType.type} array != {expr.typeInfo.arrayType.type} array");
                    }
                    else
                    {
                        Errors.Add($"Type mismatch in field {key}: {typeAnotation.typeInfo.type} != {expr.typeInfo.type}");
                    }
                }
            }

            if (typeAnotation.typeInfo.templateId != null)
            {
                fieldNode.typeInfo = typeAnotation.typeInfo;
                if (!templateTypeChecker.Check(typeAnotation.typeInfo.templateId, fieldNode.Expr.GetChild<ObjectNode>(0)))
                {
                    Errors.Add($"Template {typeAnotation.typeInfo.templateId} does not match field {key}");
                    return base.VisitField(fieldNode);
                }
            }


            fieldNode.typeInfo = expr.typeInfo;
            fieldNode.typeInfo.fieldKey = key;

            CurrentScope.Add(key, fieldNode);
            return fieldNode;
        }

        public override AstNode VisitTypeAnotation(TypeAnotationNode typeAnotationNode)
        {
            TypeInfo typeInfo = new TypeInfo(typeAnotationNode.type ?? TypeEnum.Unknown);

            if (typeInfo.type == TypeEnum.Object && typeAnotationNode.value != "object")
            {
                typeInfo.templateId = typeAnotationNode.value;
            }

            if (typeInfo.type == TypeEnum.Array)
            {
                typeInfo.arrayType = calcArrayType(typeAnotationNode.value);
            }



            typeAnotationNode.typeInfo = typeInfo;

            return typeAnotationNode;
        }

        public override AstNode VisitObject(ObjectNode objectNode)
        {
            Dictionary<string, AstNode> objectScope = new Dictionary<string, AstNode>();
            SymbolTables.Push(objectScope);

            foreach (FieldNode field in objectNode.Fields)
            {
                field.typeInfo = new TypeInfo(TypeEnum.Unknown); // Set to unknown to be updated later
                Visit(field);
            }

            SymbolTables.Pop();

            objectNode.typeInfo.type = TypeEnum.Object;



            return objectNode;
        }

        public override AstNode VisitExpression(ExpressionNode node)
        {
            AstNode child = node.children[0];
            child.typeInfo = node.typeInfo;
            child = Visit(child);

            node.children[0] = child;
            node.typeInfo = child.typeInfo;

            return node;
        }

        public override AstNode VisitString(StringNode node)
        {
            node.typeInfo = new TypeInfo(TypeEnum.String);
            return node;
        }

        public override AstNode VisitInt(IntNode node)
        {
            node.typeInfo = new TypeInfo(TypeEnum.Int);
            return node;
        }

        public override AstNode VisitFloat(FloatNode node)
        {
            node.typeInfo = new TypeInfo(TypeEnum.Float);
            return node;
        }

        public override AstNode VisitBool(BoolNode node)
        {
            node.typeInfo = new TypeInfo(TypeEnum.Bool);
            return node;
        }

        public override AstNode VisitArray(ArrayNode node)
        {
            TypeInfo arrayType = new TypeInfo(TypeEnum.Unknown);

            foreach (var child in node.children)
            {
                child.typeInfo = node.typeInfo.arrayType;
                AstNode visitedChild = Visit(child);
                if (arrayType.type == TypeEnum.Unknown)
                {
                    arrayType = visitedChild.typeInfo;
                }
                else if (!arrayType.Equals(visitedChild.typeInfo))
                {
                    arrayType.type = TypeEnum.Any;
                    continue;
                }


            }

            node.typeInfo = new TypeInfo(TypeEnum.Array, arrayType: arrayType);

            return node;
        }

        //addition
        public override AstNode VisitAddition(AdditionNode node)
        {
            AstNode left = Visit(node.Left);
            AstNode right = Visit(node.Right);


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

            return base.VisitTemplate(node);
        }

        //templateField
        public override AstNode VisitTemplateField(TemplateFieldNode node)
        {
            TypeAnotationNode type = Visit(node.Type) as TypeAnotationNode;


            node.typeInfo = type.typeInfo;
            type.typeInfo.fieldKey = node.Id.value;

            return node;
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