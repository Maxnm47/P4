using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.root;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public static class TemplateTypeChecker
    {
        public static bool Check(TemplateNode templateNode, ObjectNode objectNode, bool partial = false)
        {
            if (partial)
            {
                return CheckPartialMatch(templateNode, objectNode);
            }

            return CheckCompleteMatch(templateNode, objectNode);
        }

        private static bool CheckPartialMatch(TemplateNode templateNode, ObjectNode objectNode)
        {
            if (objectNode is null)
            {
                return false;
            }


            foreach (var field in objectNode.Fields)
            {
                if (!FieldInTemplate(templateNode.Fields, field))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckCompleteMatch(TemplateNode templateNode, ObjectNode objectNode)
        {
            if (!CheckPartialMatch(templateNode, objectNode))
            {
                return false;
            }

            foreach (var tField in templateNode.Fields)
            {
                if (!FieldInObject(objectNode.Fields, tField))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool FieldInTemplate(List<TemplateFieldNode> tFields, FieldNode fieldNode)
        {
            foreach (var tField in tFields)
            {
                if (tField.typeInfo.Equals(fieldNode.typeInfo))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool FieldInObject(List<FieldNode> fields, TemplateFieldNode tField)
        {
            foreach (var field in fields)
            {
                if (field.typeInfo.Equals(tField.typeInfo))
                {
                    return true;
                }
            }

            return false;
        }

    }
}