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

        public TypeInfo(TypeEnum type, List<TypeInfo> subFields)
        {
            this.type = type;
            this.fieldKey = null;
            this.templateId = null;
            this.subFields = subFields;
        }

        public TypeInfo(TypeEnum type, string fieldKey)
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

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TypeInfo other = (TypeInfo)obj;

            if (other.type != type)
            {
                return false;
            }

            if (other.fieldKey != fieldKey)
            {
                return false;
            }

            if (other.subFields == null && subFields == null)
            {
                return true;
            }
            else if (other.subFields == null)
            {
                return false;
            }

            for (int i = 0; i < subFields!.Count; i++)
            {
                if (!subFields[i].Equals(other.subFields![i]))
                {
                    return false;
                }
            }



            return true;
        }
    }
}