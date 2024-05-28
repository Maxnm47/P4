using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.ast;
using UCM.ast.root;
using UCM.typeEnum;

namespace UCM.astVisitor
{
    public class TemplateTypeChecker
    {


        private Dictionary<string, TemplateNode> templateTable = new Dictionary<string, TemplateNode>();
        public void AddTemplate(string templateId, TemplateNode templateNode)
        {
            templateTable.Add(templateId, templateNode);
        }

        public bool HasBeenDeclared(string templateId)
        {
            return templateTable.ContainsKey(templateId);
        }
        public bool Check(string templateId, List<FieldNode> fieldNodes, bool isPartial = false)
        {
            if (!templateTable.ContainsKey(templateId))
            {
                return false;
            }

            var templateNode = templateTable[templateId];

            if (isPartial)
            {
                return CheckPartialMatch(templateNode, fieldNodes);
            }
            else
            {
                return CheckCompleteMatch(templateNode, fieldNodes);
            }
        }

        private bool CheckPartialMatch(TemplateNode template, List<FieldNode> fieldNodes)
        {
            foreach (var subField in fieldNodes)
            {
                if (!FieldInTemplate(template.Id.value, subField))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCompleteMatch(TemplateNode template, List<FieldNode> fieldNodes)
        {
            if (!CheckPartialMatch(template, fieldNodes))
            {
                return false;
            }


            if (fieldNodes.Count != template.Fields.Count)
            {
                return false;
            }

            return true;
        }

        public bool FieldInTemplate(string templateName, FieldNode fieldNode)
        {
            if (!templateTable.ContainsKey(templateName))
            {
                return false;
            }

            TemplateNode template = templateTable[templateName];

            foreach (var tField in template.Fields)
            {
                if (tField.typeInfo.Equals(fieldNode.typeInfo) && tField.Id.value == fieldNode.Key.Id.value)
                {
                    if (tField.typeInfo.templateId != null)
                    {
                        return Check(tField.typeInfo.templateId, fieldNode.Expr.GetChild<ObjectNode>(0).Fields);
                    }
                    return true;
                }
            }

            return false;
        }

        public TypeInfo GetFieldType(string templateName, string fieldKey)
        {
            if (!templateTable.ContainsKey(templateName))
            {
                return null;
            }

            TemplateNode template = templateTable[templateName];

            foreach (var tField in template.Fields)
            {
                if (tField.Id.value == fieldKey)
                {
                    return tField.typeInfo;
                }
            }

            return null;
        }
    }
}