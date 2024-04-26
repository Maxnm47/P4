using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UCM.typechecker;

namespace UCM.astVisitor
{
    public class ObjectTable
    {
        public Dictionary<string, TypeInfo> objectTable { get; set; } = new Dictionary<string, TypeInfo>();

    }

    public class TypeInfo
    {
        public TypeEnum type;
        public string? fieldKey;
        public string? templateId;
        public bool isHidden = false;
        public List<TypeInfo>? subFields;


        public TypeInfo(TypeEnum type)
        {
            this.type = type;
            this.fieldKey = null;
            this.templateId = null;
            this.subFields = null;
        }

        public TypeInfo(TypeEnum type, string fieldKey = null, string templateId = null, List<TypeInfo> subFields = null, bool isHidden = false)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = templateId;
            this.subFields = subFields;
            this.isHidden = isHidden;
        }

        public TypeInfo(TypeEnum type, List<TypeInfo> subFields)
        {
            this.type = type;
            this.fieldKey = null;
            this.templateId = null;
            this.subFields = subFields;
        }

        public TypeInfo(TypeEnum type, string fieldKey = null)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = null;
            this.subFields = null;
        }

        public TypeInfo(TypeEnum type, string fieldKey, string templateId)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = templateId;
            this.subFields = null;
        }

        public TypeInfo(TypeEnum type, string fieldKey, string templateId, List<TypeInfo> subFields)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = templateId;
            this.subFields = subFields;
        }

        public TypeInfo(TypeEnum type, string fieldKey, List<TypeInfo> subFields)
        {
            this.type = type;
            this.fieldKey = fieldKey;
            this.templateId = null;
            this.subFields = subFields;
        }
    }
}