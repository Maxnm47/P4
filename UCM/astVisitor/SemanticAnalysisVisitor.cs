using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UCM.ast;
using UCM.ast.boolExpr;
using UCM.ast.complexValues;
using UCM.ast.loopConstruction;
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

        public override AstNode VisitRoot(RootNode rootNode)
        {
            foreach (AstNode node in rootNode.children)
            {
                Visit(node);
            }

            if (Errors.Count == 0)
            {
                return rootNode;
            }


            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string error in Errors)
            {
                Console.WriteLine(error);
            }

            Console.ResetColor();
            throw new Exception("Semantic analysis failed");
        }


        public override AstNode VisitField(FieldNode fieldNode)
        {
            bool hasDynamicKey = fieldNode.Key.Id is null;
            string key = hasDynamicKey ? Guid.NewGuid().ToString() : fieldNode.Key.Id.value;

            fieldNode.typeInfo ??= new TypeInfo(TypeEnum.Any);

            if (hasDynamicKey)
            {
                ExpressionNode keyExpression = fieldNode.Key.Expr;
                keyExpression.typeInfo = new TypeInfo(TypeEnum.String);
                Visit(keyExpression);

                if (keyExpression.typeInfo.type == TypeEnum.Error)
                {
                    Errors.Add("Dynamic keys must be of type string");
                    return fieldNode;
                }
            }


            if (fieldNode.typeInfo.templateId != null)
            {
                TypeInfo typeInfo = templateTypeChecker.GetFieldType(fieldNode.typeInfo.templateId, key);
                if (typeInfo == null)
                {
                    Errors.Add($"Field {key} is not declared in template {fieldNode.typeInfo.templateId}");
                    //return base.VisitField(fieldNode);
                }

                if (hasDynamicKey)
                {
                    Errors.Add("Dynamic keys can not be used in template typed objects");
                    return fieldNode;
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
            fieldNode.typeInfo.isHidden = fieldNode.Hidden is not null;
            ExpressionNode expression = fieldNode.Expr;
            expression.typeInfo = fieldNode.typeInfo;
            Visit(expression);



            CurrentScope.Add(key, fieldNode);
            return fieldNode;
        }




        public override AstNode VisitTypeAnotation(TypeAnotationNode typeAnotationNode)
        {
            TypeInfo exprectedType = typeAnotationNode.typeInfo;

            if (exprectedType.type == TypeEnum.Unknown || exprectedType.type == TypeEnum.Any)
            {
                exprectedType.type = typeAnotationNode.type ?? TypeEnum.Any;
                if (typeAnotationNode.type == TypeEnum.Object)
                {
                    exprectedType.templateId = typeAnotationNode.value.Equals("object") ? null : typeAnotationNode.value;
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
            List<FieldNode> fields = objectNode.Fields;

            if (objectNode.Id is not null)
            {
                ObjectNode adaptedObject = (FindSymbol(objectNode.Id.value) as FieldNode).Expr.GetChild<ObjectNode>(0);
                if (adaptedObject is null)
                {
                    Errors.Add($"Cannot adapt non declaed object {objectNode.Id.value}");
                    return base.VisitObject(objectNode);
                }

                foreach (FieldNode field in adaptedObject.Fields)
                {
                    if (!fields.Any(f => f.Key.Id.value == field.Key.Id.value))
                    {
                        fields.Add(field);
                    }
                }
            }


            SymbolTables.Push([]);

            foreach (FieldNode field in fields ?? [])
            {
                // Pass potential type info to children
                field.typeInfo = new TypeInfo(TypeEnum.Unknown);
                field.typeInfo.templateId = objectNode.typeInfo.templateId;
                Visit(field);
            }



            if (objectNode.Loops is not null && objectNode.typeInfo.templateId is not null)
            {
                Errors.Add("Template objects can not have loops");
                SymbolTables.Pop();
                return objectNode;
            }

            foreach (LoopConstructionNode loop in objectNode.Loops ?? [])
            {
                loop.typeInfo = new TypeInfo(TypeEnum.Field);
                loop.typeInfo.templateId = objectNode.typeInfo.templateId;
                Visit(loop);
            }

            SymbolTables.Pop();


            if (objectNode.typeInfo.templateId is not null)
            {
                if (!templateTypeChecker.Check(objectNode.typeInfo.templateId, fields, isPartial: objectNode.typeInfo.isHidden))
                {
                    Errors.Add($"Object does not match template {objectNode.typeInfo.templateId}");
                }
            }

            if (objectNode.typeInfo.type != TypeEnum.Object && objectNode.typeInfo.type != TypeEnum.Any)
            {
                Errors.Add($"Type mismatch: Can not set value of type Object to value of type {objectNode.typeInfo.type}");
            }

            objectNode.typeInfo.type = TypeEnum.Object;

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

        public override AstNode VisitAugmentedString(AugmentedStringNode node)
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
            if (node.typeInfo.type != TypeEnum.Array)
            {
                Errors.Add($"Type mismatch: Can not set value of type Array to value of type {node.typeInfo.type}");
                return node;
            }

            foreach (AstNode elemment in node.children)
            {
                // Set type info to the array type
                elemment.typeInfo = node.typeInfo.arrayType;
                Visit(elemment);
            }


            return node;
        }

        public override AstNode VisitObjectFieldAcess(ObjectFieldAcessNode objectAccessNode)
        {
            List<IdentifyerNode> identifiers = objectAccessNode.Id;

            AstNode currentNode = FindSymbol(identifiers[0].value);

            if (currentNode == null || !(currentNode is FieldNode fieldNode))
            {
                Errors.Add($"Object {identifiers[0].value} not declared");
                return objectAccessNode;
            }

            for (int i = 1; i < identifiers.Count; i++)
            {
                if (!(currentNode is FieldNode currentField) || !(currentField.Expr.GetChild<ObjectNode>(0) is ObjectNode currentObject))
                {
                    Errors.Add($"Identifier {identifiers[i - 1].value} does not refer to an object with fields");
                    return objectAccessNode;
                }

                bool fieldFound = false;
                foreach (var field in currentObject.Fields)
                {
                    if (field.Key.Id != null && field.Key.Id.value == identifiers[i].value)
                    {
                        currentNode = field;
                        fieldFound = true;
                        break;
                    }
                }

                if (!fieldFound)
                {
                    Errors.Add($"Field {identifiers[i].value} not found in object {identifiers[i - 1].value}");
                    return objectAccessNode;
                }
            }

            objectAccessNode.typeInfo = currentNode.typeInfo;
        
            return objectAccessNode;
        }

        public override AstNode VisitLoopConstruction(LoopConstructionNode loopConstructionNode)
        {
            LoopConstructContentNode evaluationContent = loopConstructionNode.EvaluationContent;
            List<FieldNode>? fields = evaluationContent.Fields;
            List<ExpressionNode>? expressions = evaluationContent.Expressions;

            ExpressionNode arrayExprssion = loopConstructionNode.Array;
            arrayExprssion.typeInfo = new TypeInfo(TypeEnum.Array, arrayType: new TypeInfo(TypeEnum.Unknown));

            SymbolTables.Push([]);

            IdentifyerNode entity = loopConstructionNode.Entity;
            TypeAnotationNode? entityType = loopConstructionNode.EntityType;

            if (entityType is not null)
            {
                entityType.typeInfo = new TypeInfo(TypeEnum.Unknown);
                Visit(entityType);
                entity.typeInfo = entityType.typeInfo;
                arrayExprssion.typeInfo.arrayType = entityType.typeInfo;
            }

            Visit(arrayExprssion);
            entity.typeInfo = arrayExprssion.typeInfo.arrayType;

            CurrentScope.Add(entity.value, entity);

            if (fields == null && expressions == null)
            {
                Errors.Add("Loop construct must have at least one field or expression");
                SymbolTables.Pop();
                return loopConstructionNode;
            }

            if (fields != null && expressions != null)
            {
                Errors.Add("Loop construct can not have both fields and expressions");
                SymbolTables.Pop();
                return loopConstructionNode;
            }

            if (fields != null && loopConstructionNode.typeInfo.type != TypeEnum.Field)
            {
                Errors.Add("Loop construct in array must have expressions not fields");
                SymbolTables.Pop();
                return loopConstructionNode;
            }

            if (expressions != null && loopConstructionNode.typeInfo.type == TypeEnum.Field)
            {
                Errors.Add("Loop construct in object must have fields not expressions");
                SymbolTables.Pop();
                return loopConstructionNode;
            }



            if (fields != null)
            {
                foreach (FieldNode field in fields)
                {
                    field.typeInfo = new TypeInfo(TypeEnum.Unknown);
                    field.typeInfo.templateId = loopConstructionNode.typeInfo.templateId;
                    Visit(field);
                    loopConstructionNode.typeInfo = field.typeInfo;
                }
            }


            if (expressions != null)
            {
                foreach (ExpressionNode expression in expressions)
                {
                    expression.typeInfo = loopConstructionNode.typeInfo;
                    Visit(expression);
                    loopConstructionNode.typeInfo = expression.typeInfo;
                }
            }


            SymbolTables.Pop();

            return loopConstructionNode;
        }

        public override AstNode VisitArrayAccess(ArrayAccessNode arrayAccessNode)
        {
            IdentifyerNode arrayName = arrayAccessNode.ArrayName;
            List<ExpressionNode> indexs = arrayAccessNode.Indexs;

            int dimentions = indexs.Count;

            foreach (ExpressionNode index in indexs)
            {
                index.typeInfo = new TypeInfo(TypeEnum.Int);
                Visit(index);

                if (index.typeInfo.type == TypeEnum.Error)
                {
                    Errors.Add($"Index must be of type int");
                }
            }


            FieldNode arrayField = FindSymbol(arrayName.value) as FieldNode;

            if (arrayField is null)
            {
                Errors.Add($"Array {arrayName.value} not declared");
                arrayAccessNode.typeInfo = new TypeInfo(TypeEnum.Error);
                return arrayAccessNode;
            }

            ArrayNode array = arrayField.Expr.GetChild<ArrayNode>(0);

            if (array.typeInfo.type != TypeEnum.Array)
            {
                Errors.Add($"Variable {arrayName.value} is not an array");
                arrayAccessNode.typeInfo = new TypeInfo(TypeEnum.Error);
                return arrayAccessNode;
            }

            TypeInfo arrayType = array.typeInfo.arrayType;

            for (int i = 0; i < dimentions - 1; i++)
            {
                if (arrayType.type != TypeEnum.Array)
                {
                    Errors.Add($"Variable {arrayName.value} is not an array of {dimentions} dimentions");
                    arrayAccessNode.typeInfo = new TypeInfo(TypeEnum.Error);
                    return arrayAccessNode;
                }
                arrayType = arrayType.arrayType;
            }

            if (arrayAccessNode.typeInfo.templateId != null && arrayType.templateId != arrayAccessNode.typeInfo.templateId)
            {
                Errors.Add($"Type mismatch: array access of type {arrayType.templateId ?? arrayType.type.ToString()} != {arrayAccessNode.typeInfo.templateId}");
                arrayAccessNode.typeInfo = new TypeInfo(TypeEnum.Error);
                return arrayAccessNode;
            }


            if (!arrayType.Equals(arrayAccessNode.typeInfo) &&
                arrayAccessNode.typeInfo.type != TypeEnum.Any &&
                arrayAccessNode.typeInfo.type != TypeEnum.Unknown)
            {
                Errors.Add($"Type mismatch: array access of type {arrayType.type} != {arrayAccessNode.typeInfo.type}");
                arrayAccessNode.typeInfo = new TypeInfo(TypeEnum.Error);
                return arrayAccessNode;
            }


            return arrayAccessNode;
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

        //subtraction
        public override AstNode VisitSubtraction(SubtractionNode node)
        {
            AstNode left = node.Left;
            AstNode right = node.Right;
            left.typeInfo = node.typeInfo;
            right.typeInfo = node.typeInfo;

            Visit(left);
            Visit(right);

            if (left.typeInfo.type != right.typeInfo.type)
            {
                Errors.Add($"Type mismatch in subtraction: {left.typeInfo.type} != {right.typeInfo.type}");
                return base.VisitSubtraction(node);
            }

            if (left.typeInfo.type != TypeEnum.Int && left.typeInfo.type != TypeEnum.Float)
            {
                Errors.Add($"Type {left.typeInfo.type} not supported in subtraction");
                return base.VisitSubtraction(node);
            }

            node.typeInfo = left.typeInfo;

            return node;
        }

        //multiplication
        public override AstNode VisitMultiplication(MultiplicationNode node)
        {
            AstNode left = node.Left;
            AstNode right = node.Right;
            left.typeInfo = node.typeInfo;
            right.typeInfo = node.typeInfo;

            Visit(left);
            Visit(right);

            if (left.typeInfo.type != right.typeInfo.type)
            {
                Errors.Add($"Type mismatch in multiplication: {left.typeInfo.type} != {right.typeInfo.type}");
                return base.VisitMultiplication(node);
            }

            if (left.typeInfo.type != TypeEnum.Int && left.typeInfo.type != TypeEnum.Float)
            {
                Errors.Add($"Type {left.typeInfo.type} not supported in multiplication");
                return base.VisitMultiplication(node);
            }

            node.typeInfo = left.typeInfo;

            return node;
        }

        //division
        public override AstNode VisitDivision(DivisionNode node)
        {
            AstNode left = node.Left;
            AstNode right = node.Right;
            left.typeInfo = node.typeInfo;
            right.typeInfo = node.typeInfo;

            Visit(left);
            Visit(right);

            if (left.typeInfo.type != right.typeInfo.type)
            {
                Errors.Add($"Type mismatch in division: {left.typeInfo.type} != {right.typeInfo.type}");
                return base.VisitDivision(node);
            }

            if (left.typeInfo.type != TypeEnum.Int && left.typeInfo.type != TypeEnum.Float)
            {
                Errors.Add($"Type {left.typeInfo.type} not supported in division");
                return base.VisitDivision(node);
            }

            node.typeInfo = left.typeInfo;

            return node;
        }

        // Modulo
        public override AstNode VisitModulo(ModuloNode node)
        {
            AstNode left = node.Left;
            AstNode right = node.Right;
            left.typeInfo = node.typeInfo;
            right.typeInfo = node.typeInfo;

            Visit(left);
            Visit(right);

            if (left.typeInfo.type != right.typeInfo.type)
            {
                Errors.Add($"Type mismatch in modulo: {left.typeInfo.type} != {right.typeInfo.type}");
                return base.VisitModulo(node);
            }

            if (left.typeInfo.type != TypeEnum.Int)
            {
                Errors.Add($"Type {left.typeInfo.type} not supported in modulo");
                return base.VisitModulo(node);
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


        public AstNode FindSymbol(string key)
        {
            foreach (var scope in SymbolTables)
            {
                if (scope.ContainsKey(key))
                {
                    return scope[key];
                }
            }

            return null;
        }

        void CheckPrimitiveType(AstNode node, TypeEnum expectedType)
        {
            if (node.typeInfo.type == TypeEnum.Any || node.typeInfo.type == TypeEnum.Unknown)
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