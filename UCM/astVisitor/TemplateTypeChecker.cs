using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.root;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class TemplateTypeChecker
    {

        private Dictionary<string, TemplateNode> templateTable = new Dictionary<string, TemplateNode>();

        public void AddTemplate(string templateId, TemplateNode templateNode)
        {
            templateTable.Add(templateId, templateNode);
        }
        public bool Check(string templateId, ObjectNode objectNode, bool isPartial = false)
        {
            if (!templateTable.ContainsKey(templateId))
            {
                return false;
            }

            var templateNode = templateTable[templateId];

            if (isPartial)
            {
                return CheckPartialMatch(templateNode, objectNode);
            }
            else
            {
                return CheckCompleteMatch(templateNode, objectNode);
            }
        }

        private bool CheckPartialMatch(TemplateNode template, ObjectNode objectNode)
        {
            foreach (var subField in objectNode.Fields)
            {
                if (!FieldInTemplate(template, subField))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCompleteMatch(TemplateNode template, ObjectNode objectNode)
        {
            if (!CheckPartialMatch(template, objectNode))
            {
                return false;
            }

            List<FieldNode> fields = objectNode.Fields;

            if (fields.Count != template.Fields.Count)
            {
                return false;
            }

            return true;
        }

        private bool FieldInTemplate(TemplateNode template, FieldNode fieldNode)
        {
            foreach (var tField in template.Fields)
            {
                if (tField.typeInfo.Equals(fieldNode.typeInfo))
                {
                    return true;
                }

                if (tField.typeInfo.templateId != null)
                {
                    return Check(tField.typeInfo.templateId, fieldNode.Expr.GetChild<ObjectNode>(0));
                }
            }

            return false;
        }
    }
}