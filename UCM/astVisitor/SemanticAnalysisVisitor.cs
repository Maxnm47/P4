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

            // Get type info from type anotation if it exits else set type to any
            TypeInfo typeInfo = (fieldNode.Type is not null) ? (Visit(fieldNode.Type) as TypeAnotationNode).typeInfo : new TypeInfo(TypeEnum.Any);

            // Check if expression type matches the field type
            ExpressionNode expression = fieldNode.Expr;
            expression.typeInfo = typeInfo;
            Visit(expression);


            fieldNode.typeInfo = typeInfo.type == TypeEnum.Any ? expression.typeInfo : typeInfo;
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

            if (objectNode.typeInfo.templateId is not null)
            {
                if (!templateTypeChecker.Check(objectNode.typeInfo.templateId, objectNode))
                {
                    Errors.Add($"Object does not match template {objectNode.typeInfo.templateId}");
                }
            }


            return objectNode;
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