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
        public bool Check(string templateId, FieldNode field)
        {
            if (!templateTable.ContainsKey(templateId))
            {
                return false;
            }

            var templateNode = templateTable[templateId];
            bool isPartial = field.Hidden is not null;
            if (isPartial)
            {
                return CheckPartialMatch(templateNode, field);
            }
            else
            {
                return CheckCompleteMatch(templateNode, field);
            }
        }

        private bool CheckPartialMatch(TemplateNode template, FieldNode field)
        {
            foreach (var subField in field.Expr.GetChild<ObjectNode>(0).Fields)
            {
                if (!FieldInTemplate(template, subField))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCompleteMatch(TemplateNode template, FieldNode field)
        {
            if (!CheckPartialMatch(template, field))
            {
                return false;
            }

            List<FieldNode> fields = field.Expr.GetChild<ObjectNode>(0).Fields;

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
                    return Check(tField.typeInfo.templateId, fieldNode);
                }
            }

            return false;
        }
    }
}